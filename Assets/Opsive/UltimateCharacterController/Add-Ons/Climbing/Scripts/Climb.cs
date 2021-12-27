/// ---------------------------------------------
/// Ultimate Character Controller
/// Copyright (c) Opsive. All Rights Reserved.
/// https://www.opsive.com
/// ---------------------------------------------

namespace Opsive.UltimateCharacterController.AddOns.Climbing
{
    using Opsive.Shared.Events;
    using Opsive.UltimateCharacterController.Character.Abilities;
    using UnityEngine;

    /// <summary>
    /// Abstract base class for all climbing abilities from the Climbing Pack.
    /// </summary>
    public abstract class Climb : DetectObjectAbilityBase
    {
        /// <summary>
        /// The ability has started.
        /// </summary>
        protected override void AbilityStarted()
        {
            base.AbilityStarted();

            m_CharacterLocomotion.GravityAmount = 0;
            // Force independent look so the movement type won't try to rotate the character.
            EventHandler.ExecuteEvent(m_GameObject, "OnCharacterForceIndependentLook", true);
        }

        /// <summary>
        /// Called when another ability is attempting to start and the current ability is active.
        /// Returns true or false depending on if the new ability should be blocked from starting.
        /// </summary>
        /// <param name="startingAbility">The ability that is starting.</param>
        /// <returns>True if the ability should be blocked.</returns>
        public override bool ShouldBlockAbilityStart(Ability startingAbility)
        {
            return startingAbility is Fall;
        }

        /// <summary>
        /// Called when the current ability is attempting to start and another ability is active.
        /// Returns true or false depending on if the active ability should be stopped.
        /// </summary>
        /// <param name="activeAbility">The ability that is currently active.</param>
        /// <returns>True if the ability should be stopped.</returns>
        public override bool ShouldStopActiveAbility(Ability activeAbility)
        {
            return activeAbility is Fall;
        }

        /// <summary>
        /// Returns true if the camera can zoom.
        /// </summary>
        /// <returns>True if the camera can zoom.</returns>
        public override bool CanCameraZoom()
        {
            return false;
        }

        /// <summary>
        /// The ability has stopped running.
        /// </summary>
        /// <param name="force">Was the ability force stopped?</param>
        protected override void AbilityStopped(bool force)
        {
            base.AbilityStopped(force);

            m_CharacterLocomotion.AbilityMotor = Vector3.zero;
            EventHandler.ExecuteEvent(m_GameObject, "OnCharacterForceIndependentLook", false);
        }
    }
}