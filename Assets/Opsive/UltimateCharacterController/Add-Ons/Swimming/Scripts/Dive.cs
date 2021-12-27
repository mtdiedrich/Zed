﻿/// ---------------------------------------------
/// Ultimate Character Controller
/// Copyright (c) Opsive. All Rights Reserved.
/// https://www.opsive.com
/// ---------------------------------------------

namespace Opsive.UltimateCharacterController.AddOns.Swimming
{
    using Opsive.Shared.Events;
    using Opsive.UltimateCharacterController.Character.Abilities;
    using Opsive.UltimateCharacterController.Game;
    using Opsive.UltimateCharacterController.Utility;
    using UnityEngine;

    /// <summary>
    /// The Dive ability will allow the character to dive head first from an elevated area.
    /// </summary>
    [DefaultAbilityIndex(302)]
    [DefaultStartType(AbilityStartType.ButtonDown)]
    [DefaultAllowPositionalInput(false)]
    [DefaultAllowRotationalInput(false)]
    [DefaultInputName("Action")]
    [DefaultUseRootMotionPosition(AbilityBoolOverride.True)]
    [DefaultUseLookDirection(false)]
    [DefaultEquippedSlots(0)]
    [DefaultReequipSlots(false)]
    [Shared.Utility.Group("Swimming Pack")]
    public class Dive : DetectGroundAbilityBase
    {
        [Tooltip("The minimum distance from the dive platform to the water for the dive to be considered a high dive.")]
        [SerializeField] protected float m_MinHighDiveHeight = 5f;
        [Tooltip("The amount of force to apply when the dive ability starts.")]
        [SerializeField] protected Vector3 m_DiveForce = new Vector3(0, 0.0f, 0.35f);
        [Tooltip("The number of frames that the Start Force is applied in.")]
        [SerializeField] protected int m_Frames = 40;
        [Tooltip("The distance at which the character should play an animation which prepares the character for entering the water.")]
        [SerializeField] protected float m_WillEnterWaterDistance = 4;
        [Tooltip("Effect that should play when the character enters the water.")]
        [SerializeField] protected WaterEffectVelocity m_EntranceSplash;
        [Tooltip("The percentage that the gravity force is retained each frame after the character enters the water.")]
        [Range(0, 1)] [SerializeField] protected float m_RetainedGravityAmount = 0.9f;

        public float MinHighDiveHeight { get { return m_MinHighDiveHeight; } set { m_MinHighDiveHeight = value; } }
        public Vector3 DiveForce { get { return m_DiveForce; } set { m_DiveForce = value; } }
        public int Frames { get { return m_Frames; } set { m_Frames = value; } }
        public float WillEnterWaterDistance { get { return m_WillEnterWaterDistance; } set { m_WillEnterWaterDistance = value; } }
        public float RetainedGravityAmount { get { return m_RetainedGravityAmount; } set { m_RetainedGravityAmount = value; } }

        /// <summary>
        /// Specifies the type of dive to perform.
        /// </summary>
        private enum DiveStates { 
            Shallow,    // The character is diving from a shallow distance. 
            High,       // The character is diving from a high distance.
            EnterWater  // The character will enter the water shortly.
        };

        private DiveStates m_DiveState;
        private bool m_EnteredTrigger;
        private RaycastHit m_RaycastHit;
        private bool m_StartUseGravity;

        public override int AbilityIntData { get { return (int)m_DiveState; } }

        /// <summary>
        /// Initialize the default values.
        /// </summary>
        public override void Awake()
        {
            base.Awake();

            if (m_EntranceSplash != null) {
                m_EntranceSplash.Initialize(m_CharacterLocomotion);
            }

            EventHandler.RegisterEvent(m_GameObject, "OnAnimatorDiveAddForce", OnAddDiveForce);
            EventHandler.RegisterEvent(m_GameObject, "OnAnimatorDiveComplete", OnDiveComplete);
        }

        /// <summary>
        /// Can the ability be started?
        /// </summary>
        /// <returns>True if the ability can be started.</returns>
        public override bool CanStartAbility()
        {
            // The character has to be on the ground.
            if (!m_CharacterLocomotion.Grounded) {
                return false;
            }

            // An attribute may prevent the ability from starting.
            if (!base.CanStartAbility()) {
                return false;
            }

            return true;
        }

        /// <summary>
        /// The ability has started.
        /// </summary>
        protected override void AbilityStarted()
        {
            base.AbilityStarted();

            // Detect if the character should perform a shallow or high dive. Use the edge of the ground collider to determine the height of the water.
            var maxColliderBounds = m_GroundTransform.InverseTransformPoint(m_GroundCollider.bounds.max);
            maxColliderBounds.x = 0;
            maxColliderBounds.z += 0.1f;
            maxColliderBounds = m_GroundTransform.TransformPoint(maxColliderBounds);
            m_EnteredTrigger = false;
            m_StartUseGravity = m_CharacterLocomotion.UseGravity;

            RaycastHit hit;
            if (Physics.Raycast(maxColliderBounds, -m_GroundTransform.up, out hit, m_MinHighDiveHeight, 1 << LayerManager.Water, QueryTriggerInteraction.Collide)) {
                m_DiveState = DiveStates.Shallow;
            } else {
                m_DiveState = DiveStates.High;
            }
        }

        /// <summary>
        /// Called when another ability is attempting to start and the current ability is active.
        /// Returns true or false depending on if the new ability should be blocked from starting.
        /// </summary>
        /// <param name="startingAbility">The ability that is starting.</param>
        /// <returns>True if the ability should be blocked.</returns>
        public override bool ShouldBlockAbilityStart(Ability startingAbility)
        {
            return startingAbility is HeightChange;
        }

        /// <summary>
        /// Called when the current ability is attempting to start and another ability is active.
        /// Returns true or false depending on if the active ability should be stopped.
        /// </summary>
        /// <param name="activeAbility">The ability that is currently active.</param>
        /// <returns>True if the ability should be stopped.</returns>
        public override bool ShouldStopActiveAbility(Ability activeAbility)
        {
            return activeAbility is HeightChange;
        }

        /// <summary>
        /// Adds a force to the character.
        /// </summary>
        private void OnAddDiveForce()
        {
            AddRelativeForce(m_DiveForce, m_Frames, false, true);
        }

        /// <summary>
        /// Updates the ability.
        /// </summary>
        public override void Update()
        {
            // Do not call the base method to prevent an attribute from stopping the dive.
        }

        /// <summary>
        /// Update the ability's Animator parameters. Called before the rotation and position values are applied.
        /// </summary>
        public override void UpdateAnimator()
        {
            // The character should prepare for entry when they get close to the water.
            if (m_DiveState != DiveStates.EnterWater && Physics.Raycast(m_Transform.position, -m_CharacterLocomotion.Up, m_WillEnterWaterDistance, 1 << LayerManager.Water, QueryTriggerInteraction.Collide)) {
                m_DiveState = DiveStates.EnterWater;
                SetAbilityIntDataParameter((int)m_DiveState);
            }
            SetAbilityFloatDataParameter(m_CharacterLocomotion.LocalLocomotionVelocity.y);
        }

        /// <summary>
        /// Update the controller's rotation values.
        /// </summary>
        public override void UpdateRotation()
        {
            if (!m_CharacterLocomotion.Grounded) {
                return;
            }

            // The character should orient towards the direction of the diving platform.
            var angle = Vector3.SignedAngle(m_Transform.forward, m_GroundTransform.forward, m_CharacterLocomotion.Up);
            if (Mathf.Abs(angle) > 90) {
                angle = 180 + angle;
            }
            angle = Mathf.Lerp(0, MathUtility.ClampInnerAngle(angle), m_CharacterLocomotion.MotorRotationSpeed * Time.deltaTime);
            var deltaRotation = m_CharacterLocomotion.DeltaRotation;
            deltaRotation.y = angle;
            m_CharacterLocomotion.DeltaRotation = deltaRotation;
        }

        /// <summary>
        /// Update the controller's position values.
        /// </summary>
        public override void UpdatePosition()
        {
            if (!m_EnteredTrigger) {
                return;
            }

            // Reduce the gravity when the character enters the water. This is a similar idea to the buoyancy force within the Swim ability.
            m_CharacterLocomotion.GravityAmount *= m_RetainedGravityAmount;
        }

        /// <summary>
        /// The character has entered a trigger.
        /// </summary>
        /// <param name="other">The trigger collider that the character entered.</param>
        public override void OnTriggerEnter(Collider other)
        {
            if (!IsActive || other.gameObject.layer != LayerManager.Water) {
                return;
            }

            m_EnteredTrigger = true;
            if (m_EntranceSplash != null && Mathf.Abs(m_CharacterLocomotion.LocalLocomotionVelocity.y) > m_EntranceSplash.MinVelocity) {
                m_EntranceSplash.Play(other.ClosestPointOnBounds(m_Transform.position) - m_CharacterLocomotion.Up * m_CharacterLocomotion.SkinWidth);
            }
            m_CharacterLocomotion.UseGravity = false;
        }

        /// <summary>
        /// The dive has completed. Stop the ability.
        /// </summary>
        private void OnDiveComplete()
        {
            StopAbility();
        }

        /// <summary>
        /// The ability has stopped running.
        /// </summary>
        /// <param name="force">Was the ability force stopped?</param>
        protected override void AbilityStopped(bool force)
        {
            base.AbilityStopped(force);

            m_CharacterLocomotion.UseGravity = m_StartUseGravity;
        }

        /// <summary>
        /// The character has been destroyed.
        /// </summary>
        public override void OnDestroy()
        {
            base.OnDestroy();

            EventHandler.UnregisterEvent(m_GameObject, "OnAnimatorDiveAddForce", OnAddDiveForce);
            EventHandler.UnregisterEvent(m_GameObject, "OnAnimatorDiveComplete", OnDiveComplete);
        }
    }
}