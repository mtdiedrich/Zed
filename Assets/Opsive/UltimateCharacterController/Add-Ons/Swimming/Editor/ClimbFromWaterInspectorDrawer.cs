/// ---------------------------------------------
/// Ultimate Character Controller
/// Copyright (c) Opsive. All Rights Reserved.
/// https://www.opsive.com
/// ---------------------------------------------

namespace Opsive.UltimateCharacterController.Editor.Inspectors.Character.Abilities
{
    using Opsive.Shared.Editor.Inspectors;
	using Opsive.UltimateCharacterController.Editor.Utility;
	using UnityEditor;
	using UnityEditor.Animations;
	using UnityEngine;

	/// <summary>
	/// Draws a custom inspector for the ClimbFromWater Ability.
	/// </summary>
	[InspectorDrawer(typeof(Opsive.UltimateCharacterController.AddOns.Swimming.ClimbFromWater))]
	public class ClimbFromWaterInspectorDrawer : DetectObjectAbilityBaseInspectorDrawer
	{
		// ------------------------------------------- Start Generated Code -------------------------------------------
		// ------- Do NOT make any changes below. Changes will be removed when the animator is generated again. -------
		// ------------------------------------------------------------------------------------------------------------

		/// <summary>
		/// Returns true if the ability can build to the animator.
		/// </summary>
		public override bool CanBuildAnimator { get { return true; } }

		/// <summary>
		/// An editor only method which can add the abilities states/transitions to the animator.
		/// </summary>
		/// <param name="animatorController">The Animator Controller to add the states to.</param>
		/// <param name="firstPersonAnimatorController">The first person Animator Controller to add the states to.</param>
		public override void BuildAnimator(AnimatorController animatorController, AnimatorController firstPersonAnimatorController)
		{
			if (animatorController.layers.Length <= 0) {
				Debug.LogWarning("Warning: The animator controller does not contain the same number of layers as the demo animator. All of the animations cannot be added.");
				return;
			}

			var baseStateMachine1804056018 = animatorController.layers[0].stateMachine;

			// The state machine should start fresh.
			for (int i = 0; i < animatorController.layers.Length; ++i) {
				for (int j = 0; j < baseStateMachine1804056018.stateMachines.Length; ++j) {
					if (baseStateMachine1804056018.stateMachines[j].stateMachine.name == "Climb From Water") {
						baseStateMachine1804056018.RemoveStateMachine(baseStateMachine1804056018.stateMachines[j].stateMachine);
						break;
					}
				}
			}

			// AnimationClip references.
			var swimClimbFromWaterMovingAnimationClip64530Path = AssetDatabase.GUIDToAssetPath("0a3989f9b05f2eb4e97f108cb17cf1c1"); 
			var swimClimbFromWaterMovingAnimationClip64530 = AnimatorBuilder.GetAnimationClip(swimClimbFromWaterMovingAnimationClip64530Path, "SwimClimbFromWaterMoving");
			var swimClimbFromWaterIdleAnimationClip64528Path = AssetDatabase.GUIDToAssetPath("0a3989f9b05f2eb4e97f108cb17cf1c1"); 
			var swimClimbFromWaterIdleAnimationClip64528 = AnimatorBuilder.GetAnimationClip(swimClimbFromWaterIdleAnimationClip64528Path, "SwimClimbFromWaterIdle");

			// State Machine.
			var climbFromWaterAnimatorStateMachine76050 = baseStateMachine1804056018.AddStateMachine("Climb From Water", new Vector3(624f, 12f, 0f));

			// States.
			var climbFromWaterMovingAnimatorState76886 = climbFromWaterAnimatorStateMachine76050.AddState("Climb From Water Moving", new Vector3(384f, 72f, 0f));
			climbFromWaterMovingAnimatorState76886.motion = swimClimbFromWaterMovingAnimationClip64530;
			climbFromWaterMovingAnimatorState76886.cycleOffset = 0f;
			climbFromWaterMovingAnimatorState76886.cycleOffsetParameterActive = false;
			climbFromWaterMovingAnimatorState76886.iKOnFeet = true;
			climbFromWaterMovingAnimatorState76886.mirror = false;
			climbFromWaterMovingAnimatorState76886.mirrorParameterActive = false;
			climbFromWaterMovingAnimatorState76886.speed = 2f;
			climbFromWaterMovingAnimatorState76886.speedParameterActive = false;
			climbFromWaterMovingAnimatorState76886.writeDefaultValues = true;

			var climbFromWaterIdleAnimatorState76888 = climbFromWaterAnimatorStateMachine76050.AddState("Climb From Water Idle", new Vector3(384f, 12f, 0f));
			climbFromWaterIdleAnimatorState76888.motion = swimClimbFromWaterIdleAnimationClip64528;
			climbFromWaterIdleAnimatorState76888.cycleOffset = 0f;
			climbFromWaterIdleAnimatorState76888.cycleOffsetParameterActive = false;
			climbFromWaterIdleAnimatorState76888.iKOnFeet = true;
			climbFromWaterIdleAnimatorState76888.mirror = false;
			climbFromWaterIdleAnimatorState76888.mirrorParameterActive = false;
			climbFromWaterIdleAnimatorState76888.speed = 2f;
			climbFromWaterIdleAnimatorState76888.speedParameterActive = false;
			climbFromWaterIdleAnimatorState76888.writeDefaultValues = true;

			// State Machine Defaults.
			climbFromWaterAnimatorStateMachine76050.anyStatePosition = new Vector3(-96f, 36f, 0f);
			climbFromWaterAnimatorStateMachine76050.defaultState = climbFromWaterMovingAnimatorState76886;
			climbFromWaterAnimatorStateMachine76050.entryPosition = new Vector3(-96f, -36f, 0f);
			climbFromWaterAnimatorStateMachine76050.exitPosition = new Vector3(876f, 36f, 0f);
			climbFromWaterAnimatorStateMachine76050.parentStateMachinePosition = new Vector3(864f, -60f, 0f);

			// State Transitions.
			var animatorStateTransition78178 = climbFromWaterMovingAnimatorState76886.AddExitTransition();
			animatorStateTransition78178.canTransitionToSelf = true;
			animatorStateTransition78178.duration = 0.25f;
			animatorStateTransition78178.exitTime = 0.9f;
			animatorStateTransition78178.hasExitTime = false;
			animatorStateTransition78178.hasFixedDuration = true;
			animatorStateTransition78178.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78178.offset = 0f;
			animatorStateTransition78178.orderedInterruption = true;
			animatorStateTransition78178.isExit = true;
			animatorStateTransition78178.mute = false;
			animatorStateTransition78178.solo = false;
			animatorStateTransition78178.AddCondition(AnimatorConditionMode.NotEqual, 303f, "AbilityIndex");

			var animatorStateTransition78180 = climbFromWaterIdleAnimatorState76888.AddExitTransition();
			animatorStateTransition78180.canTransitionToSelf = true;
			animatorStateTransition78180.duration = 0.25f;
			animatorStateTransition78180.exitTime = 0.9f;
			animatorStateTransition78180.hasExitTime = false;
			animatorStateTransition78180.hasFixedDuration = true;
			animatorStateTransition78180.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78180.offset = 0f;
			animatorStateTransition78180.orderedInterruption = true;
			animatorStateTransition78180.isExit = true;
			animatorStateTransition78180.mute = false;
			animatorStateTransition78180.solo = false;
			animatorStateTransition78180.AddCondition(AnimatorConditionMode.NotEqual, 303f, "AbilityIndex");


			// State Machine Transitions.
			var animatorStateTransition76596 = baseStateMachine1804056018.AddAnyStateTransition(climbFromWaterMovingAnimatorState76886);
			animatorStateTransition76596.canTransitionToSelf = false;
			animatorStateTransition76596.duration = 0.05f;
			animatorStateTransition76596.exitTime = 0.75f;
			animatorStateTransition76596.hasExitTime = false;
			animatorStateTransition76596.hasFixedDuration = true;
			animatorStateTransition76596.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition76596.offset = 0f;
			animatorStateTransition76596.orderedInterruption = true;
			animatorStateTransition76596.isExit = false;
			animatorStateTransition76596.mute = false;
			animatorStateTransition76596.solo = false;
			animatorStateTransition76596.AddCondition(AnimatorConditionMode.If, 0f, "AbilityChange");
			animatorStateTransition76596.AddCondition(AnimatorConditionMode.Equals, 303f, "AbilityIndex");
			animatorStateTransition76596.AddCondition(AnimatorConditionMode.Equals, 1f, "AbilityIntData");

			var animatorStateTransition76598 = baseStateMachine1804056018.AddAnyStateTransition(climbFromWaterIdleAnimatorState76888);
			animatorStateTransition76598.canTransitionToSelf = false;
			animatorStateTransition76598.duration = 0.05f;
			animatorStateTransition76598.exitTime = 0.75f;
			animatorStateTransition76598.hasExitTime = false;
			animatorStateTransition76598.hasFixedDuration = true;
			animatorStateTransition76598.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition76598.offset = 0f;
			animatorStateTransition76598.orderedInterruption = true;
			animatorStateTransition76598.isExit = false;
			animatorStateTransition76598.mute = false;
			animatorStateTransition76598.solo = false;
			animatorStateTransition76598.AddCondition(AnimatorConditionMode.If, 0f, "AbilityChange");
			animatorStateTransition76598.AddCondition(AnimatorConditionMode.Equals, 303f, "AbilityIndex");
			animatorStateTransition76598.AddCondition(AnimatorConditionMode.Equals, 0f, "AbilityIntData");
		}
	}
}
