/// ---------------------------------------------
/// Ultimate Character Controller
/// Copyright (c) Opsive. All Rights Reserved.
/// https://www.opsive.com
/// ---------------------------------------------

namespace Opsive.UltimateCharacterController.AddOns.Climbing.Editor.Inspectors.Character.Abilities
{
	using Opsive.Shared.Editor.Inspectors;
	using Opsive.UltimateCharacterController.Editor.Inspectors.Character.Abilities;
	using Opsive.UltimateCharacterController.Editor.Utility;
	using UnityEditor;
	using UnityEditor.Animations;
	using UnityEngine;

	/// <summary>
	/// Draws a custom inspector for the ShortClimb Ability.
	/// </summary>
	[InspectorDrawer(typeof(Opsive.UltimateCharacterController.AddOns.Climbing.ShortClimb))]
	public class ShortClimbInspectorDrawer : DetectObjectAbilityBaseInspectorDrawer
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
			if (animatorController.layers.Length <= 12) {
				Debug.LogWarning("Warning: The animator controller does not contain the same number of layers as the demo animator. All of the animations cannot be added.");
				return;
			}

			var baseStateMachine1511798822 = animatorController.layers[12].stateMachine;

			// The state machine should start fresh.
			for (int i = 0; i < animatorController.layers.Length; ++i) {
				for (int j = 0; j < baseStateMachine1511798822.stateMachines.Length; ++j) {
					if (baseStateMachine1511798822.stateMachines[j].stateMachine.name == "Short Climb") {
						baseStateMachine1511798822.RemoveStateMachine(baseStateMachine1511798822.stateMachines[j].stateMachine);
						break;
					}
				}
			}

			// AnimationClip references.
			var shortClimbHighAnimationClip27500Path = AssetDatabase.GUIDToAssetPath("cbafffb180174b7458c03e78b0df003b"); 
			var shortClimbHighAnimationClip27500 = AnimatorBuilder.GetAnimationClip(shortClimbHighAnimationClip27500Path, "ShortClimbHigh");
			var shortClimbMediumAnimationClip27504Path = AssetDatabase.GUIDToAssetPath("a01e757ff5caca3499d3c62debb46065"); 
			var shortClimbMediumAnimationClip27504 = AnimatorBuilder.GetAnimationClip(shortClimbMediumAnimationClip27504Path, "ShortClimbMedium");
			var shortClimbLowAnimationClip27508Path = AssetDatabase.GUIDToAssetPath("9c684263e6e77bc49a3378644c1f57bf"); 
			var shortClimbLowAnimationClip27508 = AnimatorBuilder.GetAnimationClip(shortClimbLowAnimationClip27508Path, "ShortClimbLow");

			// State Machine.
			var shortClimbAnimatorStateMachine25610 = baseStateMachine1511798822.AddStateMachine("Short Climb", new Vector3(650f, 440f, 0f));

			// States.
			var shortClimbHighAnimatorState25990 = shortClimbAnimatorStateMachine25610.AddState("Short Climb High", new Vector3(380f, -50f, 0f));
			shortClimbHighAnimatorState25990.motion = shortClimbHighAnimationClip27500;
			shortClimbHighAnimatorState25990.cycleOffset = 0f;
			shortClimbHighAnimatorState25990.cycleOffsetParameterActive = false;
			shortClimbHighAnimatorState25990.iKOnFeet = false;
			shortClimbHighAnimatorState25990.mirror = false;
			shortClimbHighAnimatorState25990.mirrorParameterActive = false;
			shortClimbHighAnimatorState25990.speed = 1f;
			shortClimbHighAnimatorState25990.speedParameterActive = false;
			shortClimbHighAnimatorState25990.writeDefaultValues = true;

			var shortClimbMediumAnimatorState25992 = shortClimbAnimatorStateMachine25610.AddState("Short Climb Medium", new Vector3(380f, 10f, 0f));
			shortClimbMediumAnimatorState25992.motion = shortClimbMediumAnimationClip27504;
			shortClimbMediumAnimatorState25992.cycleOffset = 0f;
			shortClimbMediumAnimatorState25992.cycleOffsetParameterActive = false;
			shortClimbMediumAnimatorState25992.iKOnFeet = false;
			shortClimbMediumAnimatorState25992.mirror = false;
			shortClimbMediumAnimatorState25992.mirrorParameterActive = false;
			shortClimbMediumAnimatorState25992.speed = 1f;
			shortClimbMediumAnimatorState25992.speedParameterActive = false;
			shortClimbMediumAnimatorState25992.writeDefaultValues = true;

			var shortClimbLowAnimatorState25994 = shortClimbAnimatorStateMachine25610.AddState("Short Climb Low", new Vector3(380f, 70f, 0f));
			shortClimbLowAnimatorState25994.motion = shortClimbLowAnimationClip27508;
			shortClimbLowAnimatorState25994.cycleOffset = 0f;
			shortClimbLowAnimatorState25994.cycleOffsetParameterActive = false;
			shortClimbLowAnimatorState25994.iKOnFeet = false;
			shortClimbLowAnimatorState25994.mirror = false;
			shortClimbLowAnimatorState25994.mirrorParameterActive = false;
			shortClimbLowAnimatorState25994.speed = 1f;
			shortClimbLowAnimatorState25994.speedParameterActive = false;
			shortClimbLowAnimatorState25994.writeDefaultValues = true;

			// State Machine Defaults.
			shortClimbAnimatorStateMachine25610.anyStatePosition = new Vector3(50f, 20f, 0f);
			shortClimbAnimatorStateMachine25610.defaultState = shortClimbHighAnimatorState25990;
			shortClimbAnimatorStateMachine25610.entryPosition = new Vector3(50f, 120f, 0f);
			shortClimbAnimatorStateMachine25610.exitPosition = new Vector3(800f, 120f, 0f);
			shortClimbAnimatorStateMachine25610.parentStateMachinePosition = new Vector3(800f, 20f, 0f);

			// State Transitions.
			var animatorStateTransition27498 = shortClimbHighAnimatorState25990.AddExitTransition();
			animatorStateTransition27498.canTransitionToSelf = true;
			animatorStateTransition27498.duration = 0.15f;
			animatorStateTransition27498.exitTime = 0.8064516f;
			animatorStateTransition27498.hasExitTime = false;
			animatorStateTransition27498.hasFixedDuration = true;
			animatorStateTransition27498.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition27498.offset = 0f;
			animatorStateTransition27498.orderedInterruption = true;
			animatorStateTransition27498.isExit = true;
			animatorStateTransition27498.mute = false;
			animatorStateTransition27498.solo = false;
			animatorStateTransition27498.AddCondition(AnimatorConditionMode.NotEqual, 502f, "AbilityIndex");

			var animatorStateTransition27502 = shortClimbMediumAnimatorState25992.AddExitTransition();
			animatorStateTransition27502.canTransitionToSelf = true;
			animatorStateTransition27502.duration = 0.15f;
			animatorStateTransition27502.exitTime = 0.8064516f;
			animatorStateTransition27502.hasExitTime = false;
			animatorStateTransition27502.hasFixedDuration = true;
			animatorStateTransition27502.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition27502.offset = 0f;
			animatorStateTransition27502.orderedInterruption = true;
			animatorStateTransition27502.isExit = true;
			animatorStateTransition27502.mute = false;
			animatorStateTransition27502.solo = false;
			animatorStateTransition27502.AddCondition(AnimatorConditionMode.NotEqual, 502f, "AbilityIndex");

			var animatorStateTransition27506 = shortClimbLowAnimatorState25994.AddExitTransition();
			animatorStateTransition27506.canTransitionToSelf = true;
			animatorStateTransition27506.duration = 0.15f;
			animatorStateTransition27506.exitTime = 0.8064516f;
			animatorStateTransition27506.hasExitTime = false;
			animatorStateTransition27506.hasFixedDuration = true;
			animatorStateTransition27506.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition27506.offset = 0f;
			animatorStateTransition27506.orderedInterruption = true;
			animatorStateTransition27506.isExit = true;
			animatorStateTransition27506.mute = false;
			animatorStateTransition27506.solo = false;
			animatorStateTransition27506.AddCondition(AnimatorConditionMode.NotEqual, 502f, "AbilityIndex");


			// State Machine Transitions.
			var animatorStateTransition25818 = baseStateMachine1511798822.AddAnyStateTransition(shortClimbHighAnimatorState25990);
			animatorStateTransition25818.canTransitionToSelf = true;
			animatorStateTransition25818.duration = 0.15f;
			animatorStateTransition25818.exitTime = 0.75f;
			animatorStateTransition25818.hasExitTime = false;
			animatorStateTransition25818.hasFixedDuration = true;
			animatorStateTransition25818.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition25818.offset = 0f;
			animatorStateTransition25818.orderedInterruption = true;
			animatorStateTransition25818.isExit = false;
			animatorStateTransition25818.mute = false;
			animatorStateTransition25818.solo = false;
			animatorStateTransition25818.AddCondition(AnimatorConditionMode.If, 0f, "AbilityChange");
			animatorStateTransition25818.AddCondition(AnimatorConditionMode.Equals, 502f, "AbilityIndex");
			animatorStateTransition25818.AddCondition(AnimatorConditionMode.Greater, 1.4f, "AbilityFloatData");

			var animatorStateTransition25820 = baseStateMachine1511798822.AddAnyStateTransition(shortClimbMediumAnimatorState25992);
			animatorStateTransition25820.canTransitionToSelf = true;
			animatorStateTransition25820.duration = 0.15f;
			animatorStateTransition25820.exitTime = 0.75f;
			animatorStateTransition25820.hasExitTime = false;
			animatorStateTransition25820.hasFixedDuration = true;
			animatorStateTransition25820.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition25820.offset = 0f;
			animatorStateTransition25820.orderedInterruption = true;
			animatorStateTransition25820.isExit = false;
			animatorStateTransition25820.mute = false;
			animatorStateTransition25820.solo = false;
			animatorStateTransition25820.AddCondition(AnimatorConditionMode.If, 0f, "AbilityChange");
			animatorStateTransition25820.AddCondition(AnimatorConditionMode.Equals, 502f, "AbilityIndex");
			animatorStateTransition25820.AddCondition(AnimatorConditionMode.Greater, 0.9f, "AbilityFloatData");
			animatorStateTransition25820.AddCondition(AnimatorConditionMode.Less, 1.1f, "AbilityFloatData");

			var animatorStateTransition25822 = baseStateMachine1511798822.AddAnyStateTransition(shortClimbLowAnimatorState25994);
			animatorStateTransition25822.canTransitionToSelf = true;
			animatorStateTransition25822.duration = 0.15f;
			animatorStateTransition25822.exitTime = 0.75f;
			animatorStateTransition25822.hasExitTime = false;
			animatorStateTransition25822.hasFixedDuration = true;
			animatorStateTransition25822.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition25822.offset = 0f;
			animatorStateTransition25822.orderedInterruption = true;
			animatorStateTransition25822.isExit = false;
			animatorStateTransition25822.mute = false;
			animatorStateTransition25822.solo = false;
			animatorStateTransition25822.AddCondition(AnimatorConditionMode.If, 0f, "AbilityChange");
			animatorStateTransition25822.AddCondition(AnimatorConditionMode.Equals, 502f, "AbilityIndex");
			animatorStateTransition25822.AddCondition(AnimatorConditionMode.Less, 0.9f, "AbilityFloatData");
		}
	}
}
