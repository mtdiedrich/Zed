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
	/// Draws a custom inspector for the Drown Ability.
	/// </summary>
	[InspectorDrawer(typeof(Opsive.UltimateCharacterController.AddOns.Swimming.Drown))]
	public class DrownInspectorDrawer : AbilityInspectorDrawer
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

			var baseStateMachine1660401108 = animatorController.layers[0].stateMachine;

			// The state machine should start fresh.
			for (int i = 0; i < animatorController.layers.Length; ++i) {
				for (int j = 0; j < baseStateMachine1660401108.stateMachines.Length; ++j) {
					if (baseStateMachine1660401108.stateMachines[j].stateMachine.name == "Drown") {
						baseStateMachine1660401108.RemoveStateMachine(baseStateMachine1660401108.stateMachines[j].stateMachine);
						break;
					}
				}
			}

			// AnimationClip references.
			var drowningAnimationClip64538Path = AssetDatabase.GUIDToAssetPath("6e27b67dcdb0ced43a37b38895376787"); 
			var drowningAnimationClip64538 = AnimatorBuilder.GetAnimationClip(drowningAnimationClip64538Path, "Drowning");

			// State Machine.
			var drownAnimatorStateMachine76052 = baseStateMachine1660401108.AddStateMachine("Drown", new Vector3(624f, 156f, 0f));

			// States.
			var drownAnimatorState76882 = drownAnimatorStateMachine76052.AddState("Drown", new Vector3(413.599f, 57.65604f, 0f));
			drownAnimatorState76882.motion = drowningAnimationClip64538;
			drownAnimatorState76882.cycleOffset = 0f;
			drownAnimatorState76882.cycleOffsetParameterActive = false;
			drownAnimatorState76882.iKOnFeet = false;
			drownAnimatorState76882.mirror = false;
			drownAnimatorState76882.mirrorParameterActive = false;
			drownAnimatorState76882.speed = 1f;
			drownAnimatorState76882.speedParameterActive = false;
			drownAnimatorState76882.writeDefaultValues = true;

			// State Machine Defaults.
			drownAnimatorStateMachine76052.anyStatePosition = new Vector3(50f, 20f, 0f);
			drownAnimatorStateMachine76052.defaultState = drownAnimatorState76882;
			drownAnimatorStateMachine76052.entryPosition = new Vector3(50f, 120f, 0f);
			drownAnimatorStateMachine76052.exitPosition = new Vector3(800f, 120f, 0f);
			drownAnimatorStateMachine76052.parentStateMachinePosition = new Vector3(800f, 20f, 0f);

			// State Transitions.
			var animatorStateTransition78182 = drownAnimatorState76882.AddExitTransition();
			animatorStateTransition78182.canTransitionToSelf = true;
			animatorStateTransition78182.duration = 0.25f;
			animatorStateTransition78182.exitTime = 0.75f;
			animatorStateTransition78182.hasExitTime = false;
			animatorStateTransition78182.hasFixedDuration = true;
			animatorStateTransition78182.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78182.offset = 0f;
			animatorStateTransition78182.orderedInterruption = true;
			animatorStateTransition78182.isExit = true;
			animatorStateTransition78182.mute = false;
			animatorStateTransition78182.solo = false;
			animatorStateTransition78182.AddCondition(AnimatorConditionMode.NotEqual, 304f, "AbilityIndex");


			// State Machine Transitions.
			var animatorStateTransition76592 = baseStateMachine1660401108.AddAnyStateTransition(drownAnimatorState76882);
			animatorStateTransition76592.canTransitionToSelf = true;
			animatorStateTransition76592.duration = 0.25f;
			animatorStateTransition76592.exitTime = 0.75f;
			animatorStateTransition76592.hasExitTime = false;
			animatorStateTransition76592.hasFixedDuration = true;
			animatorStateTransition76592.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition76592.offset = 0f;
			animatorStateTransition76592.orderedInterruption = true;
			animatorStateTransition76592.isExit = false;
			animatorStateTransition76592.mute = false;
			animatorStateTransition76592.solo = false;
			animatorStateTransition76592.AddCondition(AnimatorConditionMode.If, 0f, "AbilityChange");
			animatorStateTransition76592.AddCondition(AnimatorConditionMode.Equals, 304f, "AbilityIndex");
		}
	}
}
