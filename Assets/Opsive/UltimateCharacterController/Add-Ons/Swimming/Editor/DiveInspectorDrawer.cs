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
	/// Draws a custom inspector for the Dive Ability.
	/// </summary>
	[InspectorDrawer(typeof(Opsive.UltimateCharacterController.AddOns.Swimming.Dive))]
	public class DiveInspectorDrawer : AbilityInspectorDrawer
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

			var baseStateMachine1732752848 = animatorController.layers[0].stateMachine;

			// The state machine should start fresh.
			for (int i = 0; i < animatorController.layers.Length; ++i) {
				for (int j = 0; j < baseStateMachine1732752848.stateMachines.Length; ++j) {
					if (baseStateMachine1732752848.stateMachines[j].stateMachine.name == "Dive") {
						baseStateMachine1732752848.RemoveStateMachine(baseStateMachine1732752848.stateMachines[j].stateMachine);
						break;
					}
				}
			}

			// AnimationClip references.
			var shallowDiveStartAnimationClip64564Path = AssetDatabase.GUIDToAssetPath("a4bd809109678b74d89a0d193252fdb5"); 
			var shallowDiveStartAnimationClip64564 = AnimatorBuilder.GetAnimationClip(shallowDiveStartAnimationClip64564Path, "ShallowDiveStart");
			var shallowDiveEnterWaterAnimationClip64560Path = AssetDatabase.GUIDToAssetPath("a4bd809109678b74d89a0d193252fdb5"); 
			var shallowDiveEnterWaterAnimationClip64560 = AnimatorBuilder.GetAnimationClip(shallowDiveEnterWaterAnimationClip64560Path, "ShallowDiveEnterWater");
			var shallowDiveEndAnimationClip64558Path = AssetDatabase.GUIDToAssetPath("a4bd809109678b74d89a0d193252fdb5"); 
			var shallowDiveEndAnimationClip64558 = AnimatorBuilder.GetAnimationClip(shallowDiveEndAnimationClip64558Path, "ShallowDiveEnd");
			var shallowDiveFallAnimationClip64562Path = AssetDatabase.GUIDToAssetPath("a4bd809109678b74d89a0d193252fdb5"); 
			var shallowDiveFallAnimationClip64562 = AnimatorBuilder.GetAnimationClip(shallowDiveFallAnimationClip64562Path, "ShallowDiveFall");
			var highDiveEndAnimationClip64546Path = AssetDatabase.GUIDToAssetPath("5203dd6ff2f0f4742a81f21778d48d5e"); 
			var highDiveEndAnimationClip64546 = AnimatorBuilder.GetAnimationClip(highDiveEndAnimationClip64546Path, "HighDiveEnd");
			var highDiveEnterWaterAnimationClip64548Path = AssetDatabase.GUIDToAssetPath("5203dd6ff2f0f4742a81f21778d48d5e"); 
			var highDiveEnterWaterAnimationClip64548 = AnimatorBuilder.GetAnimationClip(highDiveEnterWaterAnimationClip64548Path, "HighDiveEnterWater");
			var highDiveStartAnimationClip64552Path = AssetDatabase.GUIDToAssetPath("5203dd6ff2f0f4742a81f21778d48d5e"); 
			var highDiveStartAnimationClip64552 = AnimatorBuilder.GetAnimationClip(highDiveStartAnimationClip64552Path, "HighDiveStart");
			var highDiveFallAnimationClip64550Path = AssetDatabase.GUIDToAssetPath("5203dd6ff2f0f4742a81f21778d48d5e"); 
			var highDiveFallAnimationClip64550 = AnimatorBuilder.GetAnimationClip(highDiveFallAnimationClip64550Path, "HighDiveFall");

			// State Machine.
			var diveAnimatorStateMachine76048 = baseStateMachine1732752848.AddStateMachine("Dive", new Vector3(624f, 60f, 0f));

			// State Machine.
			var shallowDiveAnimatorStateMachine78142 = diveAnimatorStateMachine76048.AddStateMachine("Shallow Dive", new Vector3(384f, 0f, 0f));

			// States.
			var diveStartAnimatorState76876 = shallowDiveAnimatorStateMachine78142.AddState("Dive Start", new Vector3(504f, -168f, 0f));
			diveStartAnimatorState76876.motion = shallowDiveStartAnimationClip64564;
			diveStartAnimatorState76876.cycleOffset = 0f;
			diveStartAnimatorState76876.cycleOffsetParameterActive = false;
			diveStartAnimatorState76876.iKOnFeet = false;
			diveStartAnimatorState76876.mirror = false;
			diveStartAnimatorState76876.mirrorParameterActive = false;
			diveStartAnimatorState76876.speed = 3f;
			diveStartAnimatorState76876.speedParameterActive = false;
			diveStartAnimatorState76876.writeDefaultValues = true;

			var enterWaterAnimatorState78146 = shallowDiveAnimatorStateMachine78142.AddState("Enter Water", new Vector3(504f, 36f, 0f));
			enterWaterAnimatorState78146.motion = shallowDiveEnterWaterAnimationClip64560;
			enterWaterAnimatorState78146.cycleOffset = 0f;
			enterWaterAnimatorState78146.cycleOffsetParameterActive = false;
			enterWaterAnimatorState78146.iKOnFeet = false;
			enterWaterAnimatorState78146.mirror = false;
			enterWaterAnimatorState78146.mirrorParameterActive = false;
			enterWaterAnimatorState78146.speed = 1f;
			enterWaterAnimatorState78146.speedParameterActive = false;
			enterWaterAnimatorState78146.writeDefaultValues = true;

			var endAnimatorState78148 = shallowDiveAnimatorStateMachine78142.AddState("End", new Vector3(852f, 36f, 0f));
			endAnimatorState78148.motion = shallowDiveEndAnimationClip64558;
			endAnimatorState78148.cycleOffset = 0f;
			endAnimatorState78148.cycleOffsetParameterActive = false;
			endAnimatorState78148.iKOnFeet = false;
			endAnimatorState78148.mirror = false;
			endAnimatorState78148.mirrorParameterActive = false;
			endAnimatorState78148.speed = 0.5f;
			endAnimatorState78148.speedParameterActive = false;
			endAnimatorState78148.writeDefaultValues = true;

			var diveFallAnimatorState78150 = shallowDiveAnimatorStateMachine78142.AddState("Dive Fall", new Vector3(744f, -72f, 0f));
			diveFallAnimatorState78150.motion = shallowDiveFallAnimationClip64562;
			diveFallAnimatorState78150.cycleOffset = 0f;
			diveFallAnimatorState78150.cycleOffsetParameterActive = false;
			diveFallAnimatorState78150.iKOnFeet = false;
			diveFallAnimatorState78150.mirror = false;
			diveFallAnimatorState78150.mirrorParameterActive = false;
			diveFallAnimatorState78150.speed = 1f;
			diveFallAnimatorState78150.speedParameterActive = false;
			diveFallAnimatorState78150.writeDefaultValues = true;

			// State Machine Defaults.
			shallowDiveAnimatorStateMachine78142.anyStatePosition = new Vector3(36f, 48f, 0f);
			shallowDiveAnimatorStateMachine78142.defaultState = diveStartAnimatorState76876;
			shallowDiveAnimatorStateMachine78142.entryPosition = new Vector3(48f, -48f, 0f);
			shallowDiveAnimatorStateMachine78142.exitPosition = new Vector3(1116f, 48f, 0f);
			shallowDiveAnimatorStateMachine78142.parentStateMachinePosition = new Vector3(1104f, -48f, 0f);

			// State Machine.
			var highDiveAnimatorStateMachine78144 = diveAnimatorStateMachine76048.AddStateMachine("High Dive", new Vector3(384f, 72f, 0f));

			// States.
			var endAnimatorState78162 = highDiveAnimatorStateMachine78144.AddState("End", new Vector3(564f, 204f, 0f));
			endAnimatorState78162.motion = highDiveEndAnimationClip64546;
			endAnimatorState78162.cycleOffset = 0f;
			endAnimatorState78162.cycleOffsetParameterActive = false;
			endAnimatorState78162.iKOnFeet = false;
			endAnimatorState78162.mirror = false;
			endAnimatorState78162.mirrorParameterActive = false;
			endAnimatorState78162.speed = 0.5f;
			endAnimatorState78162.speedParameterActive = false;
			endAnimatorState78162.writeDefaultValues = true;

			var enterWaterAnimatorState78164 = highDiveAnimatorStateMachine78144.AddState("Enter Water", new Vector3(264f, 204f, 0f));
			enterWaterAnimatorState78164.motion = highDiveEnterWaterAnimationClip64548;
			enterWaterAnimatorState78164.cycleOffset = 0f;
			enterWaterAnimatorState78164.cycleOffsetParameterActive = false;
			enterWaterAnimatorState78164.iKOnFeet = false;
			enterWaterAnimatorState78164.mirror = false;
			enterWaterAnimatorState78164.mirrorParameterActive = false;
			enterWaterAnimatorState78164.speed = 1f;
			enterWaterAnimatorState78164.speedParameterActive = false;
			enterWaterAnimatorState78164.writeDefaultValues = true;

			var diveStartAnimatorState76878 = highDiveAnimatorStateMachine78144.AddState("Dive Start", new Vector3(264f, 0f, 0f));
			diveStartAnimatorState76878.motion = highDiveStartAnimationClip64552;
			diveStartAnimatorState76878.cycleOffset = 0f;
			diveStartAnimatorState76878.cycleOffsetParameterActive = false;
			diveStartAnimatorState76878.iKOnFeet = false;
			diveStartAnimatorState76878.mirror = false;
			diveStartAnimatorState76878.mirrorParameterActive = false;
			diveStartAnimatorState76878.speed = 3f;
			diveStartAnimatorState76878.speedParameterActive = false;
			diveStartAnimatorState76878.writeDefaultValues = true;

			var diveFallAnimatorState78166 = highDiveAnimatorStateMachine78144.AddState("Dive Fall", new Vector3(384f, 96f, 0f));
			diveFallAnimatorState78166.motion = highDiveFallAnimationClip64550;
			diveFallAnimatorState78166.cycleOffset = 0f;
			diveFallAnimatorState78166.cycleOffsetParameterActive = false;
			diveFallAnimatorState78166.iKOnFeet = false;
			diveFallAnimatorState78166.mirror = false;
			diveFallAnimatorState78166.mirrorParameterActive = false;
			diveFallAnimatorState78166.speed = 1f;
			diveFallAnimatorState78166.speedParameterActive = false;
			diveFallAnimatorState78166.writeDefaultValues = true;

			// State Machine Defaults.
			highDiveAnimatorStateMachine78144.anyStatePosition = new Vector3(36f, 168f, 0f);
			highDiveAnimatorStateMachine78144.defaultState = diveStartAnimatorState76878;
			highDiveAnimatorStateMachine78144.entryPosition = new Vector3(36f, 84f, 0f);
			highDiveAnimatorStateMachine78144.exitPosition = new Vector3(888f, 168f, 0f);
			highDiveAnimatorStateMachine78144.parentStateMachinePosition = new Vector3(864f, 108f, 0f);

			// State Machine Defaults.
			diveAnimatorStateMachine76048.anyStatePosition = new Vector3(50f, 20f, 0f);
			diveAnimatorStateMachine76048.defaultState = diveStartAnimatorState76876;
			diveAnimatorStateMachine76048.entryPosition = new Vector3(50f, 120f, 0f);
			diveAnimatorStateMachine76048.exitPosition = new Vector3(800f, 120f, 0f);
			diveAnimatorStateMachine76048.parentStateMachinePosition = new Vector3(800f, 20f, 0f);

			// State Transitions.
			var animatorStateTransition78152 = diveStartAnimatorState76876.AddTransition(enterWaterAnimatorState78146);
			animatorStateTransition78152.canTransitionToSelf = true;
			animatorStateTransition78152.duration = 0.25f;
			animatorStateTransition78152.exitTime = 0.8f;
			animatorStateTransition78152.hasExitTime = true;
			animatorStateTransition78152.hasFixedDuration = true;
			animatorStateTransition78152.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78152.offset = 0f;
			animatorStateTransition78152.orderedInterruption = true;
			animatorStateTransition78152.isExit = false;
			animatorStateTransition78152.mute = false;
			animatorStateTransition78152.solo = false;
			animatorStateTransition78152.AddCondition(AnimatorConditionMode.Equals, 2f, "AbilityIntData");

			var animatorStateTransition78154 = diveStartAnimatorState76876.AddTransition(diveFallAnimatorState78150);
			animatorStateTransition78154.canTransitionToSelf = true;
			animatorStateTransition78154.duration = 0.25f;
			animatorStateTransition78154.exitTime = 0.8f;
			animatorStateTransition78154.hasExitTime = true;
			animatorStateTransition78154.hasFixedDuration = true;
			animatorStateTransition78154.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78154.offset = 0f;
			animatorStateTransition78154.orderedInterruption = true;
			animatorStateTransition78154.isExit = false;
			animatorStateTransition78154.mute = false;
			animatorStateTransition78154.solo = false;
			animatorStateTransition78154.AddCondition(AnimatorConditionMode.NotEqual, 2f, "AbilityIntData");

			var animatorStateTransition78156 = enterWaterAnimatorState78146.AddTransition(endAnimatorState78148);
			animatorStateTransition78156.canTransitionToSelf = true;
			animatorStateTransition78156.duration = 0.05f;
			animatorStateTransition78156.exitTime = 0.9f;
			animatorStateTransition78156.hasExitTime = true;
			animatorStateTransition78156.hasFixedDuration = true;
			animatorStateTransition78156.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78156.offset = 0f;
			animatorStateTransition78156.orderedInterruption = true;
			animatorStateTransition78156.isExit = false;
			animatorStateTransition78156.mute = false;
			animatorStateTransition78156.solo = false;

			var animatorStateTransition78158 = endAnimatorState78148.AddExitTransition();
			animatorStateTransition78158.canTransitionToSelf = true;
			animatorStateTransition78158.duration = 0.15f;
			animatorStateTransition78158.exitTime = 0.8f;
			animatorStateTransition78158.hasExitTime = true;
			animatorStateTransition78158.hasFixedDuration = true;
			animatorStateTransition78158.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78158.offset = 0f;
			animatorStateTransition78158.orderedInterruption = true;
			animatorStateTransition78158.isExit = true;
			animatorStateTransition78158.mute = false;
			animatorStateTransition78158.solo = false;
			animatorStateTransition78158.AddCondition(AnimatorConditionMode.NotEqual, 302f, "AbilityIndex");

			var animatorStateTransition78160 = diveFallAnimatorState78150.AddTransition(enterWaterAnimatorState78146);
			animatorStateTransition78160.canTransitionToSelf = true;
			animatorStateTransition78160.duration = 0.015f;
			animatorStateTransition78160.exitTime = 0.4000001f;
			animatorStateTransition78160.hasExitTime = false;
			animatorStateTransition78160.hasFixedDuration = true;
			animatorStateTransition78160.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78160.offset = 0f;
			animatorStateTransition78160.orderedInterruption = true;
			animatorStateTransition78160.isExit = false;
			animatorStateTransition78160.mute = false;
			animatorStateTransition78160.solo = false;
			animatorStateTransition78160.AddCondition(AnimatorConditionMode.Equals, 2f, "AbilityIntData");

			// State Transitions.
			var animatorStateTransition78168 = endAnimatorState78162.AddExitTransition();
			animatorStateTransition78168.canTransitionToSelf = true;
			animatorStateTransition78168.duration = 0.15f;
			animatorStateTransition78168.exitTime = 0.8f;
			animatorStateTransition78168.hasExitTime = false;
			animatorStateTransition78168.hasFixedDuration = true;
			animatorStateTransition78168.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78168.offset = 0f;
			animatorStateTransition78168.orderedInterruption = true;
			animatorStateTransition78168.isExit = true;
			animatorStateTransition78168.mute = false;
			animatorStateTransition78168.solo = false;
			animatorStateTransition78168.AddCondition(AnimatorConditionMode.NotEqual, 302f, "AbilityIndex");

			var animatorStateTransition78170 = enterWaterAnimatorState78164.AddTransition(endAnimatorState78162);
			animatorStateTransition78170.canTransitionToSelf = true;
			animatorStateTransition78170.duration = 0.05f;
			animatorStateTransition78170.exitTime = 0.9f;
			animatorStateTransition78170.hasExitTime = true;
			animatorStateTransition78170.hasFixedDuration = true;
			animatorStateTransition78170.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78170.offset = 0f;
			animatorStateTransition78170.orderedInterruption = true;
			animatorStateTransition78170.isExit = false;
			animatorStateTransition78170.mute = false;
			animatorStateTransition78170.solo = false;

			var animatorStateTransition78172 = diveStartAnimatorState76878.AddTransition(enterWaterAnimatorState78164);
			animatorStateTransition78172.canTransitionToSelf = true;
			animatorStateTransition78172.duration = 0.25f;
			animatorStateTransition78172.exitTime = 0.8f;
			animatorStateTransition78172.hasExitTime = true;
			animatorStateTransition78172.hasFixedDuration = true;
			animatorStateTransition78172.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78172.offset = 0f;
			animatorStateTransition78172.orderedInterruption = true;
			animatorStateTransition78172.isExit = false;
			animatorStateTransition78172.mute = false;
			animatorStateTransition78172.solo = false;
			animatorStateTransition78172.AddCondition(AnimatorConditionMode.Equals, 2f, "AbilityIntData");

			var animatorStateTransition78174 = diveStartAnimatorState76878.AddTransition(diveFallAnimatorState78166);
			animatorStateTransition78174.canTransitionToSelf = true;
			animatorStateTransition78174.duration = 0.5f;
			animatorStateTransition78174.exitTime = 0.8f;
			animatorStateTransition78174.hasExitTime = true;
			animatorStateTransition78174.hasFixedDuration = true;
			animatorStateTransition78174.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78174.offset = 0f;
			animatorStateTransition78174.orderedInterruption = true;
			animatorStateTransition78174.isExit = false;
			animatorStateTransition78174.mute = false;
			animatorStateTransition78174.solo = false;
			animatorStateTransition78174.AddCondition(AnimatorConditionMode.NotEqual, 2f, "AbilityIntData");

			var animatorStateTransition78176 = diveFallAnimatorState78166.AddTransition(enterWaterAnimatorState78164);
			animatorStateTransition78176.canTransitionToSelf = true;
			animatorStateTransition78176.duration = 0.015f;
			animatorStateTransition78176.exitTime = 0.75f;
			animatorStateTransition78176.hasExitTime = false;
			animatorStateTransition78176.hasFixedDuration = true;
			animatorStateTransition78176.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78176.offset = 0f;
			animatorStateTransition78176.orderedInterruption = true;
			animatorStateTransition78176.isExit = false;
			animatorStateTransition78176.mute = false;
			animatorStateTransition78176.solo = false;
			animatorStateTransition78176.AddCondition(AnimatorConditionMode.Equals, 2f, "AbilityIntData");


			// State Machine Transitions.
			var animatorStateTransition76586 = baseStateMachine1732752848.AddAnyStateTransition(diveStartAnimatorState76876);
			animatorStateTransition76586.canTransitionToSelf = false;
			animatorStateTransition76586.duration = 0.15f;
			animatorStateTransition76586.exitTime = 0.75f;
			animatorStateTransition76586.hasExitTime = false;
			animatorStateTransition76586.hasFixedDuration = true;
			animatorStateTransition76586.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition76586.offset = 0f;
			animatorStateTransition76586.orderedInterruption = true;
			animatorStateTransition76586.isExit = false;
			animatorStateTransition76586.mute = false;
			animatorStateTransition76586.solo = false;
			animatorStateTransition76586.AddCondition(AnimatorConditionMode.If, 0f, "AbilityChange");
			animatorStateTransition76586.AddCondition(AnimatorConditionMode.Equals, 302f, "AbilityIndex");
			animatorStateTransition76586.AddCondition(AnimatorConditionMode.NotEqual, 1f, "AbilityIntData");
			animatorStateTransition76586.AddCondition(AnimatorConditionMode.IfNot, 0f, "Moving");

			var animatorStateTransition76588 = baseStateMachine1732752848.AddAnyStateTransition(diveStartAnimatorState76878);
			animatorStateTransition76588.canTransitionToSelf = false;
			animatorStateTransition76588.duration = 0.15f;
			animatorStateTransition76588.exitTime = 0.75f;
			animatorStateTransition76588.hasExitTime = false;
			animatorStateTransition76588.hasFixedDuration = true;
			animatorStateTransition76588.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition76588.offset = 0f;
			animatorStateTransition76588.orderedInterruption = true;
			animatorStateTransition76588.isExit = false;
			animatorStateTransition76588.mute = false;
			animatorStateTransition76588.solo = false;
			animatorStateTransition76588.AddCondition(AnimatorConditionMode.If, 0f, "AbilityChange");
			animatorStateTransition76588.AddCondition(AnimatorConditionMode.Equals, 302f, "AbilityIndex");
			animatorStateTransition76588.AddCondition(AnimatorConditionMode.Equals, 1f, "AbilityIntData");
			animatorStateTransition76588.AddCondition(AnimatorConditionMode.IfNot, 0f, "Moving");

			var animatorStateTransition76600 = baseStateMachine1732752848.AddAnyStateTransition(diveStartAnimatorState76878);
			animatorStateTransition76600.canTransitionToSelf = false;
			animatorStateTransition76600.duration = 0.1f;
			animatorStateTransition76600.exitTime = 0.75f;
			animatorStateTransition76600.hasExitTime = false;
			animatorStateTransition76600.hasFixedDuration = true;
			animatorStateTransition76600.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition76600.offset = 0.5f;
			animatorStateTransition76600.orderedInterruption = true;
			animatorStateTransition76600.isExit = false;
			animatorStateTransition76600.mute = false;
			animatorStateTransition76600.solo = false;
			animatorStateTransition76600.AddCondition(AnimatorConditionMode.If, 0f, "AbilityChange");
			animatorStateTransition76600.AddCondition(AnimatorConditionMode.Equals, 302f, "AbilityIndex");
			animatorStateTransition76600.AddCondition(AnimatorConditionMode.Equals, 1f, "AbilityIntData");
			animatorStateTransition76600.AddCondition(AnimatorConditionMode.If, 0f, "Moving");

			var animatorStateTransition76602 = baseStateMachine1732752848.AddAnyStateTransition(diveStartAnimatorState76876);
			animatorStateTransition76602.canTransitionToSelf = false;
			animatorStateTransition76602.duration = 0.15f;
			animatorStateTransition76602.exitTime = 0.75f;
			animatorStateTransition76602.hasExitTime = false;
			animatorStateTransition76602.hasFixedDuration = true;
			animatorStateTransition76602.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition76602.offset = 0.5f;
			animatorStateTransition76602.orderedInterruption = true;
			animatorStateTransition76602.isExit = false;
			animatorStateTransition76602.mute = false;
			animatorStateTransition76602.solo = false;
			animatorStateTransition76602.AddCondition(AnimatorConditionMode.If, 0f, "AbilityChange");
			animatorStateTransition76602.AddCondition(AnimatorConditionMode.Equals, 302f, "AbilityIndex");
			animatorStateTransition76602.AddCondition(AnimatorConditionMode.NotEqual, 1f, "AbilityIntData");
			animatorStateTransition76602.AddCondition(AnimatorConditionMode.If, 0f, "Moving");
		}
	}
}
