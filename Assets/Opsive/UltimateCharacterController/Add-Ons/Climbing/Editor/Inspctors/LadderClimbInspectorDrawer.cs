/// ---------------------------------------------
/// Ultimate Character Controller
/// Copyright (c) Opsive. All Rights Reserved.
/// https://www.opsive.com
/// ---------------------------------------------

namespace Opsive.UltimateCharacterController.AddOns.Climbing.Editor.Inspectors.Character.Abilities
{
	using Opsive.Shared.Editor.Inspectors;
	using Opsive.UltimateCharacterController.Editor.Inspectors.Character.Abilities;
	using Opsive.UltimateCharacterController.Editor.Inspectors.Utility;
	using Opsive.UltimateCharacterController.Editor.Utility;
	using UnityEditor;
	using UnityEditor.Animations;
	using UnityEngine;

	/// <summary>
	/// Draws a custom inspector for the LadderClimb Ability.
	/// </summary>
	[InspectorDrawer(typeof(Opsive.UltimateCharacterController.AddOns.Climbing.LadderClimb))]
	public class LadderClimbInspectorDrawer : DetectObjectAbilityBaseInspectorDrawer
	{
		/// <summary>
		/// Draws the fields related to the inspector drawer.
		/// </summary>
		/// <param name="target">The object that is being drawn.</param>
		/// <param name="parent">The Unity Object that the object belongs to.</param>
		protected override void DrawInspectorDrawerFields(object target, Object parent)
		{
			base.DrawInspectorDrawerFields(target, parent);

			// Draw AllowMovements manually so it'll use the MaskField.
			var allowedMovements = (int)InspectorUtility.GetFieldValue<LadderClimb.AllowedMovement>(target, "m_AllowedMovements");
			var allowedMovementsString = System.Enum.GetNames(typeof(LadderClimb.AllowedMovement));
			var value = EditorGUILayout.MaskField(new GUIContent("Allowed Movements", InspectorUtility.GetFieldTooltip(target, "m_AllowedMovements")), allowedMovements, allowedMovementsString);
			if (value != allowedMovements) {
				InspectorUtility.SetFieldValue(target, "m_AllowedMovements", value);
			}
		}

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

			var baseStateMachine65573352 = animatorController.layers[12].stateMachine;

			// The state machine should start fresh.
			for (int i = 0; i < animatorController.layers.Length; ++i) {
				for (int j = 0; j < baseStateMachine65573352.stateMachines.Length; ++j) {
					if (baseStateMachine65573352.stateMachines[j].stateMachine.name == "Ladder Climb") {
						baseStateMachine65573352.RemoveStateMachine(baseStateMachine65573352.stateMachines[j].stateMachine);
						break;
					}
				}
			}

			// AnimationClip references.
			var climbLadderTopDismountRightAnimationClip28004Path = AssetDatabase.GUIDToAssetPath("8020ee5e313d0c54a96a32402cf7ae46"); 
			var climbLadderTopDismountRightAnimationClip28004 = AnimatorBuilder.GetAnimationClip(climbLadderTopDismountRightAnimationClip28004Path, "ClimbLadderTopDismountRight");
			var climbLadderBottomMountAnimationClip28010Path = AssetDatabase.GUIDToAssetPath("1ee2a6fa93329904f8841315613890a8"); 
			var climbLadderBottomMountAnimationClip28010 = AnimatorBuilder.GetAnimationClip(climbLadderBottomMountAnimationClip28010Path, "ClimbLadderBottomMount");
			var climbLadderBottomDismountRightAnimationClip28016Path = AssetDatabase.GUIDToAssetPath("eac22f07651e97c43acb1a41461da263"); 
			var climbLadderBottomDismountRightAnimationClip28016 = AnimatorBuilder.GetAnimationClip(climbLadderBottomDismountRightAnimationClip28016Path, "ClimbLadderBottomDismountRight");
			var climbLadderTopDismountLeftAnimationClip28020Path = AssetDatabase.GUIDToAssetPath("c178f786b45ce024581dba11faff2e93"); 
			var climbLadderTopDismountLeftAnimationClip28020 = AnimatorBuilder.GetAnimationClip(climbLadderTopDismountLeftAnimationClip28020Path, "ClimbLadderTopDismountLeft");
			var climbLadderTopMountAnimationClip28026Path = AssetDatabase.GUIDToAssetPath("8901ddb7fcee9e747b0d35d6e830b768"); 
			var climbLadderTopMountAnimationClip28026 = AnimatorBuilder.GetAnimationClip(climbLadderTopMountAnimationClip28026Path, "ClimbLadderTopMount");
			var climbLadderBottomDismountLeftAnimationClip28030Path = AssetDatabase.GUIDToAssetPath("25470ca977145354d91c2d4904bd434b"); 
			var climbLadderBottomDismountLeftAnimationClip28030 = AnimatorBuilder.GetAnimationClip(climbLadderBottomDismountLeftAnimationClip28030Path, "ClimbLadderBottomDismountLeft");
			var climbLadderLeftUpAnimationClip28050Path = AssetDatabase.GUIDToAssetPath("88298cd410899c945952b24872b24320"); 
			var climbLadderLeftUpAnimationClip28050 = AnimatorBuilder.GetAnimationClip(climbLadderLeftUpAnimationClip28050Path, "ClimbLadderLeftUp");
			var climbLadderRightUpAnimationClip28062Path = AssetDatabase.GUIDToAssetPath("88298cd410899c945952b24872b24320"); 
			var climbLadderRightUpAnimationClip28062 = AnimatorBuilder.GetAnimationClip(climbLadderRightUpAnimationClip28062Path, "ClimbLadderRightUp");
			var climbLadderLeftDownAnimationClip28074Path = AssetDatabase.GUIDToAssetPath("88298cd410899c945952b24872b24320"); 
			var climbLadderLeftDownAnimationClip28074 = AnimatorBuilder.GetAnimationClip(climbLadderLeftDownAnimationClip28074Path, "ClimbLadderLeftDown");
			var climbLadderRightDownAnimationClip28086Path = AssetDatabase.GUIDToAssetPath("88298cd410899c945952b24872b24320"); 
			var climbLadderRightDownAnimationClip28086 = AnimatorBuilder.GetAnimationClip(climbLadderRightDownAnimationClip28086Path, "ClimbLadderRightDown");
			var climbLadderIdleLeftAnimationClip28098Path = AssetDatabase.GUIDToAssetPath("35f6345e0926afc4494f8225ad65b06a"); 
			var climbLadderIdleLeftAnimationClip28098 = AnimatorBuilder.GetAnimationClip(climbLadderIdleLeftAnimationClip28098Path, "ClimbLadderIdleLeft");
			var climbLadderIdleRightAnimationClip28110Path = AssetDatabase.GUIDToAssetPath("35f6345e0926afc4494f8225ad65b06a"); 
			var climbLadderIdleRightAnimationClip28110 = AnimatorBuilder.GetAnimationClip(climbLadderIdleRightAnimationClip28110Path, "ClimbLadderIdleRight");
			var hangtoLadderClimbLeftAnimationClip28116Path = AssetDatabase.GUIDToAssetPath("8193daa5e5a44654285c8c3eddf1fed3"); 
			var hangtoLadderClimbLeftAnimationClip28116 = AnimatorBuilder.GetAnimationClip(hangtoLadderClimbLeftAnimationClip28116Path, "HangtoLadderClimbLeft");
			var hangtoLadderClimbRightAnimationClip28122Path = AssetDatabase.GUIDToAssetPath("8193daa5e5a44654285c8c3eddf1fed3"); 
			var hangtoLadderClimbRightAnimationClip28122 = AnimatorBuilder.GetAnimationClip(hangtoLadderClimbRightAnimationClip28122Path, "HangtoLadderClimbRight");

			// State Machine.
			var ladderClimbAnimatorStateMachine26216 = baseStateMachine65573352.AddStateMachine("Ladder Climb", new Vector3(650f, 380f, 0f));

			// States.
			var topDismountRightAnimatorState27988 = ladderClimbAnimatorStateMachine26216.AddState("Top Dismount Right", new Vector3(730f, -160f, 0f));
			topDismountRightAnimatorState27988.motion = climbLadderTopDismountRightAnimationClip28004;
			topDismountRightAnimatorState27988.cycleOffset = 0f;
			topDismountRightAnimatorState27988.cycleOffsetParameterActive = false;
			topDismountRightAnimatorState27988.iKOnFeet = false;
			topDismountRightAnimatorState27988.mirror = false;
			topDismountRightAnimatorState27988.mirrorParameterActive = false;
			topDismountRightAnimatorState27988.speed = 1f;
			topDismountRightAnimatorState27988.speedParameterActive = false;
			topDismountRightAnimatorState27988.writeDefaultValues = true;

			var bottomMountAnimatorState26598 = ladderClimbAnimatorStateMachine26216.AddState("Bottom Mount", new Vector3(390f, 220f, 0f));
			bottomMountAnimatorState26598.motion = climbLadderBottomMountAnimationClip28010;
			bottomMountAnimatorState26598.cycleOffset = 0f;
			bottomMountAnimatorState26598.cycleOffsetParameterActive = false;
			bottomMountAnimatorState26598.iKOnFeet = true;
			bottomMountAnimatorState26598.mirror = false;
			bottomMountAnimatorState26598.mirrorParameterActive = false;
			bottomMountAnimatorState26598.speed = 1f;
			bottomMountAnimatorState26598.speedParameterActive = false;
			bottomMountAnimatorState26598.writeDefaultValues = true;

			var bottomDismountRightAnimatorState27990 = ladderClimbAnimatorStateMachine26216.AddState("Bottom Dismount Right", new Vector3(730f, 280f, 0f));
			bottomDismountRightAnimatorState27990.motion = climbLadderBottomDismountRightAnimationClip28016;
			bottomDismountRightAnimatorState27990.cycleOffset = 0f;
			bottomDismountRightAnimatorState27990.cycleOffsetParameterActive = false;
			bottomDismountRightAnimatorState27990.iKOnFeet = true;
			bottomDismountRightAnimatorState27990.mirror = false;
			bottomDismountRightAnimatorState27990.mirrorParameterActive = false;
			bottomDismountRightAnimatorState27990.speed = 1f;
			bottomDismountRightAnimatorState27990.speedParameterActive = false;
			bottomDismountRightAnimatorState27990.writeDefaultValues = true;

			var topDismountLeftAnimatorState27992 = ladderClimbAnimatorStateMachine26216.AddState("Top Dismount Left", new Vector3(730f, -100f, 0f));
			topDismountLeftAnimatorState27992.motion = climbLadderTopDismountLeftAnimationClip28020;
			topDismountLeftAnimatorState27992.cycleOffset = 0f;
			topDismountLeftAnimatorState27992.cycleOffsetParameterActive = false;
			topDismountLeftAnimatorState27992.iKOnFeet = false;
			topDismountLeftAnimatorState27992.mirror = false;
			topDismountLeftAnimatorState27992.mirrorParameterActive = false;
			topDismountLeftAnimatorState27992.speed = 1f;
			topDismountLeftAnimatorState27992.speedParameterActive = false;
			topDismountLeftAnimatorState27992.writeDefaultValues = true;

			var topMountAnimatorState26596 = ladderClimbAnimatorStateMachine26216.AddState("Top Mount", new Vector3(390f, -90f, 0f));
			topMountAnimatorState26596.motion = climbLadderTopMountAnimationClip28026;
			topMountAnimatorState26596.cycleOffset = 0f;
			topMountAnimatorState26596.cycleOffsetParameterActive = false;
			topMountAnimatorState26596.iKOnFeet = true;
			topMountAnimatorState26596.mirror = false;
			topMountAnimatorState26596.mirrorParameterActive = false;
			topMountAnimatorState26596.speed = 1f;
			topMountAnimatorState26596.speedParameterActive = false;
			topMountAnimatorState26596.writeDefaultValues = true;

			var bottomDismountLeftAnimatorState27994 = ladderClimbAnimatorStateMachine26216.AddState("Bottom Dismount Left", new Vector3(730f, 210f, 0f));
			bottomDismountLeftAnimatorState27994.motion = climbLadderBottomDismountLeftAnimationClip28030;
			bottomDismountLeftAnimatorState27994.cycleOffset = 0f;
			bottomDismountLeftAnimatorState27994.cycleOffsetParameterActive = false;
			bottomDismountLeftAnimatorState27994.iKOnFeet = true;
			bottomDismountLeftAnimatorState27994.mirror = false;
			bottomDismountLeftAnimatorState27994.mirrorParameterActive = false;
			bottomDismountLeftAnimatorState27994.speed = 1f;
			bottomDismountLeftAnimatorState27994.speedParameterActive = false;
			bottomDismountLeftAnimatorState27994.writeDefaultValues = true;

			// State Machine.
			var climbAnimatorStateMachine27996 = ladderClimbAnimatorStateMachine26216.AddStateMachine("Climb", new Vector3(570f, 60f, 0f));

			// States.
			var climbLeftUpAnimatorState28032 = climbAnimatorStateMachine27996.AddState("Climb Left Up", new Vector3(290f, -180f, 0f));
			climbLeftUpAnimatorState28032.motion = climbLadderLeftUpAnimationClip28050;
			climbLeftUpAnimatorState28032.cycleOffset = 0f;
			climbLeftUpAnimatorState28032.cycleOffsetParameterActive = false;
			climbLeftUpAnimatorState28032.iKOnFeet = true;
			climbLeftUpAnimatorState28032.mirror = false;
			climbLeftUpAnimatorState28032.mirrorParameterActive = false;
			climbLeftUpAnimatorState28032.speed = 1f;
			climbLeftUpAnimatorState28032.speedParameterActive = false;
			climbLeftUpAnimatorState28032.writeDefaultValues = true;

			var climbRightUpAnimatorState28034 = climbAnimatorStateMachine27996.AddState("Climb Right Up", new Vector3(610f, -180f, 0f));
			climbRightUpAnimatorState28034.motion = climbLadderRightUpAnimationClip28062;
			climbRightUpAnimatorState28034.cycleOffset = 0f;
			climbRightUpAnimatorState28034.cycleOffsetParameterActive = false;
			climbRightUpAnimatorState28034.iKOnFeet = true;
			climbRightUpAnimatorState28034.mirror = false;
			climbRightUpAnimatorState28034.mirrorParameterActive = false;
			climbRightUpAnimatorState28034.speed = 1f;
			climbRightUpAnimatorState28034.speedParameterActive = false;
			climbRightUpAnimatorState28034.writeDefaultValues = true;

			var climbLeftDownAnimatorState28036 = climbAnimatorStateMachine27996.AddState("Climb Left Down", new Vector3(290f, 140f, 0f));
			climbLeftDownAnimatorState28036.motion = climbLadderLeftDownAnimationClip28074;
			climbLeftDownAnimatorState28036.cycleOffset = 0f;
			climbLeftDownAnimatorState28036.cycleOffsetParameterActive = false;
			climbLeftDownAnimatorState28036.iKOnFeet = true;
			climbLeftDownAnimatorState28036.mirror = false;
			climbLeftDownAnimatorState28036.mirrorParameterActive = false;
			climbLeftDownAnimatorState28036.speed = 1f;
			climbLeftDownAnimatorState28036.speedParameterActive = false;
			climbLeftDownAnimatorState28036.writeDefaultValues = true;

			var climbRightDownAnimatorState28038 = climbAnimatorStateMachine27996.AddState("Climb Right Down", new Vector3(610f, 140f, 0f));
			climbRightDownAnimatorState28038.motion = climbLadderRightDownAnimationClip28086;
			climbRightDownAnimatorState28038.cycleOffset = 0f;
			climbRightDownAnimatorState28038.cycleOffsetParameterActive = false;
			climbRightDownAnimatorState28038.iKOnFeet = true;
			climbRightDownAnimatorState28038.mirror = false;
			climbRightDownAnimatorState28038.mirrorParameterActive = false;
			climbRightDownAnimatorState28038.speed = 1f;
			climbRightDownAnimatorState28038.speedParameterActive = false;
			climbRightDownAnimatorState28038.writeDefaultValues = true;

			var climbLeftIdleAnimatorState28012 = climbAnimatorStateMachine27996.AddState("Climb Left Idle", new Vector3(310f, -20f, 0f));
			climbLeftIdleAnimatorState28012.motion = climbLadderIdleLeftAnimationClip28098;
			climbLeftIdleAnimatorState28012.cycleOffset = 0f;
			climbLeftIdleAnimatorState28012.cycleOffsetParameterActive = false;
			climbLeftIdleAnimatorState28012.iKOnFeet = true;
			climbLeftIdleAnimatorState28012.mirror = false;
			climbLeftIdleAnimatorState28012.mirrorParameterActive = false;
			climbLeftIdleAnimatorState28012.speed = 1f;
			climbLeftIdleAnimatorState28012.speedParameterActive = false;
			climbLeftIdleAnimatorState28012.writeDefaultValues = true;

			var climbRightIdleAnimatorState26600 = climbAnimatorStateMachine27996.AddState("Climb Right Idle", new Vector3(530f, -20f, 0f));
			climbRightIdleAnimatorState26600.motion = climbLadderIdleRightAnimationClip28110;
			climbRightIdleAnimatorState26600.cycleOffset = 0f;
			climbRightIdleAnimatorState26600.cycleOffsetParameterActive = false;
			climbRightIdleAnimatorState26600.iKOnFeet = true;
			climbRightIdleAnimatorState26600.mirror = false;
			climbRightIdleAnimatorState26600.mirrorParameterActive = false;
			climbRightIdleAnimatorState26600.speed = 1f;
			climbRightIdleAnimatorState26600.speedParameterActive = false;
			climbRightIdleAnimatorState26600.writeDefaultValues = true;

			// State Machine Defaults.
			climbAnimatorStateMachine27996.anyStatePosition = new Vector3(-80f, -80f, 0f);
			climbAnimatorStateMachine27996.defaultState = climbLeftUpAnimatorState28032;
			climbAnimatorStateMachine27996.entryPosition = new Vector3(-80f, -40f, 0f);
			climbAnimatorStateMachine27996.exitPosition = new Vector3(1080f, 20f, 0f);
			climbAnimatorStateMachine27996.parentStateMachinePosition = new Vector3(1060f, -50f, 0f);

			// State Machine.
			var hangtoLadderClimbAnimatorStateMachine27998 = ladderClimbAnimatorStateMachine26216.AddStateMachine("Hang to Ladder Climb", new Vector3(1014.525f, 318.5602f, 0f));

			// States.
			var hangtoLadderClimbLeftAnimatorState26630 = hangtoLadderClimbAnimatorStateMachine27998.AddState("Hang to Ladder Climb Left", new Vector3(410f, -10f, 0f));
			hangtoLadderClimbLeftAnimatorState26630.motion = hangtoLadderClimbLeftAnimationClip28116;
			hangtoLadderClimbLeftAnimatorState26630.cycleOffset = 0f;
			hangtoLadderClimbLeftAnimatorState26630.cycleOffsetParameterActive = false;
			hangtoLadderClimbLeftAnimatorState26630.iKOnFeet = false;
			hangtoLadderClimbLeftAnimatorState26630.mirror = false;
			hangtoLadderClimbLeftAnimatorState26630.mirrorParameterActive = false;
			hangtoLadderClimbLeftAnimatorState26630.speed = 1f;
			hangtoLadderClimbLeftAnimatorState26630.speedParameterActive = false;
			hangtoLadderClimbLeftAnimatorState26630.writeDefaultValues = true;

			var hangtoLadderClimbRightAnimatorState26632 = hangtoLadderClimbAnimatorStateMachine27998.AddState("Hang to Ladder Climb Right", new Vector3(410f, 60f, 0f));
			hangtoLadderClimbRightAnimatorState26632.motion = hangtoLadderClimbRightAnimationClip28122;
			hangtoLadderClimbRightAnimatorState26632.cycleOffset = 0f;
			hangtoLadderClimbRightAnimatorState26632.cycleOffsetParameterActive = false;
			hangtoLadderClimbRightAnimatorState26632.iKOnFeet = false;
			hangtoLadderClimbRightAnimatorState26632.mirror = false;
			hangtoLadderClimbRightAnimatorState26632.mirrorParameterActive = false;
			hangtoLadderClimbRightAnimatorState26632.speed = 1f;
			hangtoLadderClimbRightAnimatorState26632.speedParameterActive = false;
			hangtoLadderClimbRightAnimatorState26632.writeDefaultValues = true;

			// State Machine Defaults.
			hangtoLadderClimbAnimatorStateMachine27998.anyStatePosition = new Vector3(50f, 20f, 0f);
			hangtoLadderClimbAnimatorStateMachine27998.defaultState = hangtoLadderClimbLeftAnimatorState26630;
			hangtoLadderClimbAnimatorStateMachine27998.entryPosition = new Vector3(50f, 120f, 0f);
			hangtoLadderClimbAnimatorStateMachine27998.exitPosition = new Vector3(800f, 120f, 0f);
			hangtoLadderClimbAnimatorStateMachine27998.parentStateMachinePosition = new Vector3(800f, 20f, 0f);

			// State Machine Defaults.
			ladderClimbAnimatorStateMachine26216.anyStatePosition = new Vector3(50f, 20f, 0f);
			ladderClimbAnimatorStateMachine26216.defaultState = bottomMountAnimatorState26598;
			ladderClimbAnimatorStateMachine26216.entryPosition = new Vector3(50f, 120f, 0f);
			ladderClimbAnimatorStateMachine26216.exitPosition = new Vector3(1120f, 110f, 0f);
			ladderClimbAnimatorStateMachine26216.parentStateMachinePosition = new Vector3(1120f, 10f, 0f);

			// State Transitions.
			var animatorStateTransition28002 = topDismountRightAnimatorState27988.AddExitTransition();
			animatorStateTransition28002.canTransitionToSelf = true;
			animatorStateTransition28002.duration = 0.25f;
			animatorStateTransition28002.exitTime = 0.75f;
			animatorStateTransition28002.hasExitTime = false;
			animatorStateTransition28002.hasFixedDuration = true;
			animatorStateTransition28002.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition28002.offset = 0f;
			animatorStateTransition28002.orderedInterruption = true;
			animatorStateTransition28002.isExit = true;
			animatorStateTransition28002.mute = false;
			animatorStateTransition28002.solo = false;
			animatorStateTransition28002.AddCondition(AnimatorConditionMode.NotEqual, 501f, "AbilityIndex");

			var animatorStateTransition28006 = bottomMountAnimatorState26598.AddTransition(climbLeftIdleAnimatorState28012);
			animatorStateTransition28006.canTransitionToSelf = true;
			animatorStateTransition28006.duration = 0f;
			animatorStateTransition28006.exitTime = 1f;
			animatorStateTransition28006.hasExitTime = false;
			animatorStateTransition28006.hasFixedDuration = true;
			animatorStateTransition28006.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition28006.offset = 0f;
			animatorStateTransition28006.orderedInterruption = true;
			animatorStateTransition28006.isExit = false;
			animatorStateTransition28006.mute = false;
			animatorStateTransition28006.solo = false;
			animatorStateTransition28006.AddCondition(AnimatorConditionMode.Equals, 501f, "AbilityIndex");
			animatorStateTransition28006.AddCondition(AnimatorConditionMode.Equals, 3f, "AbilityIntData");

			var animatorStateTransition28008 = bottomMountAnimatorState26598.AddTransition(bottomDismountLeftAnimatorState27994);
			animatorStateTransition28008.canTransitionToSelf = true;
			animatorStateTransition28008.duration = 0f;
			animatorStateTransition28008.exitTime = 1.05f;
			animatorStateTransition28008.hasExitTime = true;
			animatorStateTransition28008.hasFixedDuration = true;
			animatorStateTransition28008.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition28008.offset = 0f;
			animatorStateTransition28008.orderedInterruption = true;
			animatorStateTransition28008.isExit = false;
			animatorStateTransition28008.mute = false;
			animatorStateTransition28008.solo = false;
			animatorStateTransition28008.AddCondition(AnimatorConditionMode.Equals, 501f, "AbilityIndex");
			animatorStateTransition28008.AddCondition(AnimatorConditionMode.Equals, 4f, "AbilityIntData");

			var animatorStateTransition8204 = bottomMountAnimatorState26598.AddExitTransition();
			animatorStateTransition8204.canTransitionToSelf = true;
			animatorStateTransition8204.duration = 0f;
			animatorStateTransition8204.exitTime = 1.05f;
			animatorStateTransition8204.hasExitTime = true;
			animatorStateTransition8204.hasFixedDuration = true;
			animatorStateTransition8204.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition8204.offset = 0f;
			animatorStateTransition8204.orderedInterruption = true;
			animatorStateTransition8204.isExit = true;
			animatorStateTransition8204.mute = false;
			animatorStateTransition8204.solo = false;
			animatorStateTransition8204.AddCondition(AnimatorConditionMode.NotEqual, 501f, "AbilityIndex");

			var animatorStateTransition28014 = bottomDismountRightAnimatorState27990.AddExitTransition();
			animatorStateTransition28014.canTransitionToSelf = true;
			animatorStateTransition28014.duration = 0.1f;
			animatorStateTransition28014.exitTime = 1.1f;
			animatorStateTransition28014.hasExitTime = false;
			animatorStateTransition28014.hasFixedDuration = true;
			animatorStateTransition28014.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition28014.offset = 0f;
			animatorStateTransition28014.orderedInterruption = true;
			animatorStateTransition28014.isExit = true;
			animatorStateTransition28014.mute = false;
			animatorStateTransition28014.solo = false;
			animatorStateTransition28014.AddCondition(AnimatorConditionMode.NotEqual, 501f, "AbilityIndex");

			var animatorStateTransition28018 = topDismountLeftAnimatorState27992.AddExitTransition();
			animatorStateTransition28018.canTransitionToSelf = true;
			animatorStateTransition28018.duration = 0.25f;
			animatorStateTransition28018.exitTime = 0.75f;
			animatorStateTransition28018.hasExitTime = false;
			animatorStateTransition28018.hasFixedDuration = true;
			animatorStateTransition28018.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition28018.offset = 0f;
			animatorStateTransition28018.orderedInterruption = true;
			animatorStateTransition28018.isExit = true;
			animatorStateTransition28018.mute = false;
			animatorStateTransition28018.solo = false;
			animatorStateTransition28018.AddCondition(AnimatorConditionMode.NotEqual, 501f, "AbilityIndex");

			var animatorStateTransition28022 = topMountAnimatorState26596.AddTransition(climbLeftIdleAnimatorState28012);
			animatorStateTransition28022.canTransitionToSelf = true;
			animatorStateTransition28022.duration = 0f;
			animatorStateTransition28022.exitTime = 1f;
			animatorStateTransition28022.hasExitTime = false;
			animatorStateTransition28022.hasFixedDuration = true;
			animatorStateTransition28022.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition28022.offset = 0f;
			animatorStateTransition28022.orderedInterruption = true;
			animatorStateTransition28022.isExit = false;
			animatorStateTransition28022.mute = false;
			animatorStateTransition28022.solo = false;
			animatorStateTransition28022.AddCondition(AnimatorConditionMode.Equals, 501f, "AbilityIndex");
			animatorStateTransition28022.AddCondition(AnimatorConditionMode.Equals, 3f, "AbilityIntData");

			var animatorStateTransition28024 = topMountAnimatorState26596.AddTransition(topDismountLeftAnimatorState27992);
			animatorStateTransition28024.canTransitionToSelf = true;
			animatorStateTransition28024.duration = 0f;
			animatorStateTransition28024.exitTime = 1.05f;
			animatorStateTransition28024.hasExitTime = true;
			animatorStateTransition28024.hasFixedDuration = true;
			animatorStateTransition28024.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition28024.offset = 0f;
			animatorStateTransition28024.orderedInterruption = true;
			animatorStateTransition28024.isExit = false;
			animatorStateTransition28024.mute = false;
			animatorStateTransition28024.solo = false;
			animatorStateTransition28024.AddCondition(AnimatorConditionMode.Equals, 501f, "AbilityIndex");
			animatorStateTransition28024.AddCondition(AnimatorConditionMode.Equals, 5f, "AbilityIntData");

			var animatorStateTransition8412 = topMountAnimatorState26596.AddExitTransition();
			animatorStateTransition8412.canTransitionToSelf = true;
			animatorStateTransition8412.duration = 0f;
			animatorStateTransition8412.exitTime = 1.05f;
			animatorStateTransition8412.hasExitTime = true;
			animatorStateTransition8412.hasFixedDuration = true;
			animatorStateTransition8412.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition8412.offset = 0f;
			animatorStateTransition8412.orderedInterruption = true;
			animatorStateTransition8412.isExit = true;
			animatorStateTransition8412.mute = false;
			animatorStateTransition8412.solo = false;
			animatorStateTransition8412.AddCondition(AnimatorConditionMode.NotEqual, 501f, "AbilityIndex");

			var animatorStateTransition28028 = bottomDismountLeftAnimatorState27994.AddExitTransition();
			animatorStateTransition28028.canTransitionToSelf = true;
			animatorStateTransition28028.duration = 0.1f;
			animatorStateTransition28028.exitTime = 1.1f;
			animatorStateTransition28028.hasExitTime = false;
			animatorStateTransition28028.hasFixedDuration = true;
			animatorStateTransition28028.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition28028.offset = 0f;
			animatorStateTransition28028.orderedInterruption = true;
			animatorStateTransition28028.isExit = true;
			animatorStateTransition28028.mute = false;
			animatorStateTransition28028.solo = false;
			animatorStateTransition28028.AddCondition(AnimatorConditionMode.NotEqual, 501f, "AbilityIndex");

			// StateMachine Transitions.
			var animatorTransition28000 = ladderClimbAnimatorStateMachine26216.AddStateMachineTransition(climbAnimatorStateMachine27996);
			animatorTransition28000.isExit = true;
			animatorTransition28000.mute = false;
			animatorTransition28000.solo = false;
			animatorTransition28000.AddCondition(AnimatorConditionMode.NotEqual, 501f, "AbilityIndex");

			// State Transitions.
			var animatorStateTransition28040 = climbLeftUpAnimatorState28032.AddTransition(climbLeftIdleAnimatorState28012);
			animatorStateTransition28040.canTransitionToSelf = true;
			animatorStateTransition28040.duration = 0f;
			animatorStateTransition28040.exitTime = 1.05f;
			animatorStateTransition28040.hasExitTime = true;
			animatorStateTransition28040.hasFixedDuration = true;
			animatorStateTransition28040.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition28040.offset = 0f;
			animatorStateTransition28040.orderedInterruption = true;
			animatorStateTransition28040.isExit = false;
			animatorStateTransition28040.mute = false;
			animatorStateTransition28040.solo = false;
			animatorStateTransition28040.AddCondition(AnimatorConditionMode.IfNot, 0f, "Moving");

			var animatorStateTransition28042 = climbLeftUpAnimatorState28032.AddTransition(topDismountLeftAnimatorState27992);
			animatorStateTransition28042.canTransitionToSelf = true;
			animatorStateTransition28042.duration = 0f;
			animatorStateTransition28042.exitTime = 1.05f;
			animatorStateTransition28042.hasExitTime = true;
			animatorStateTransition28042.hasFixedDuration = true;
			animatorStateTransition28042.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition28042.offset = 0f;
			animatorStateTransition28042.orderedInterruption = true;
			animatorStateTransition28042.isExit = false;
			animatorStateTransition28042.mute = false;
			animatorStateTransition28042.solo = false;
			animatorStateTransition28042.AddCondition(AnimatorConditionMode.Equals, 501f, "AbilityIndex");
			animatorStateTransition28042.AddCondition(AnimatorConditionMode.Equals, 5f, "AbilityIntData");

			var animatorStateTransition28044 = climbLeftUpAnimatorState28032.AddExitTransition();
			animatorStateTransition28044.canTransitionToSelf = true;
			animatorStateTransition28044.duration = 0.25f;
			animatorStateTransition28044.exitTime = 0.5000001f;
			animatorStateTransition28044.hasExitTime = false;
			animatorStateTransition28044.hasFixedDuration = true;
			animatorStateTransition28044.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition28044.offset = 0f;
			animatorStateTransition28044.orderedInterruption = true;
			animatorStateTransition28044.isExit = true;
			animatorStateTransition28044.mute = false;
			animatorStateTransition28044.solo = false;
			animatorStateTransition28044.AddCondition(AnimatorConditionMode.NotEqual, 501f, "AbilityIndex");

			var animatorStateTransition28046 = climbLeftUpAnimatorState28032.AddTransition(climbRightUpAnimatorState28034);
			animatorStateTransition28046.canTransitionToSelf = true;
			animatorStateTransition28046.duration = 0f;
			animatorStateTransition28046.exitTime = 1.05f;
			animatorStateTransition28046.hasExitTime = true;
			animatorStateTransition28046.hasFixedDuration = true;
			animatorStateTransition28046.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition28046.offset = 0f;
			animatorStateTransition28046.orderedInterruption = true;
			animatorStateTransition28046.isExit = false;
			animatorStateTransition28046.mute = false;
			animatorStateTransition28046.solo = false;
			animatorStateTransition28046.AddCondition(AnimatorConditionMode.Greater, 0.001f, "ForwardMovement");
			animatorStateTransition28046.AddCondition(AnimatorConditionMode.Equals, 3f, "AbilityIntData");

			var animatorStateTransition28048 = climbLeftUpAnimatorState28032.AddTransition(climbLeftDownAnimatorState28036);
			animatorStateTransition28048.canTransitionToSelf = true;
			animatorStateTransition28048.duration = 0f;
			animatorStateTransition28048.exitTime = 1.05f;
			animatorStateTransition28048.hasExitTime = true;
			animatorStateTransition28048.hasFixedDuration = true;
			animatorStateTransition28048.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition28048.offset = 0f;
			animatorStateTransition28048.orderedInterruption = true;
			animatorStateTransition28048.isExit = false;
			animatorStateTransition28048.mute = false;
			animatorStateTransition28048.solo = false;
			animatorStateTransition28048.AddCondition(AnimatorConditionMode.Less, -0.001f, "ForwardMovement");
			animatorStateTransition28048.AddCondition(AnimatorConditionMode.Equals, 3f, "AbilityIntData");

			var animatorStateTransition28052 = climbRightUpAnimatorState28034.AddTransition(climbRightIdleAnimatorState26600);
			animatorStateTransition28052.canTransitionToSelf = true;
			animatorStateTransition28052.duration = 0f;
			animatorStateTransition28052.exitTime = 1.05f;
			animatorStateTransition28052.hasExitTime = true;
			animatorStateTransition28052.hasFixedDuration = true;
			animatorStateTransition28052.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition28052.offset = 0f;
			animatorStateTransition28052.orderedInterruption = true;
			animatorStateTransition28052.isExit = false;
			animatorStateTransition28052.mute = false;
			animatorStateTransition28052.solo = false;
			animatorStateTransition28052.AddCondition(AnimatorConditionMode.IfNot, 0f, "Moving");

			var animatorStateTransition28054 = climbRightUpAnimatorState28034.AddTransition(topDismountRightAnimatorState27988);
			animatorStateTransition28054.canTransitionToSelf = true;
			animatorStateTransition28054.duration = 0f;
			animatorStateTransition28054.exitTime = 1.05f;
			animatorStateTransition28054.hasExitTime = true;
			animatorStateTransition28054.hasFixedDuration = true;
			animatorStateTransition28054.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition28054.offset = 0f;
			animatorStateTransition28054.orderedInterruption = true;
			animatorStateTransition28054.isExit = false;
			animatorStateTransition28054.mute = false;
			animatorStateTransition28054.solo = false;
			animatorStateTransition28054.AddCondition(AnimatorConditionMode.Equals, 501f, "AbilityIndex");
			animatorStateTransition28054.AddCondition(AnimatorConditionMode.Equals, 5f, "AbilityIntData");

			var animatorStateTransition28056 = climbRightUpAnimatorState28034.AddExitTransition();
			animatorStateTransition28056.canTransitionToSelf = true;
			animatorStateTransition28056.duration = 0.25f;
			animatorStateTransition28056.exitTime = 0.5f;
			animatorStateTransition28056.hasExitTime = false;
			animatorStateTransition28056.hasFixedDuration = true;
			animatorStateTransition28056.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition28056.offset = 0f;
			animatorStateTransition28056.orderedInterruption = true;
			animatorStateTransition28056.isExit = true;
			animatorStateTransition28056.mute = false;
			animatorStateTransition28056.solo = false;
			animatorStateTransition28056.AddCondition(AnimatorConditionMode.NotEqual, 501f, "AbilityIndex");

			var animatorStateTransition28058 = climbRightUpAnimatorState28034.AddTransition(climbLeftUpAnimatorState28032);
			animatorStateTransition28058.canTransitionToSelf = true;
			animatorStateTransition28058.duration = 0f;
			animatorStateTransition28058.exitTime = 1.05f;
			animatorStateTransition28058.hasExitTime = true;
			animatorStateTransition28058.hasFixedDuration = true;
			animatorStateTransition28058.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition28058.offset = 0f;
			animatorStateTransition28058.orderedInterruption = true;
			animatorStateTransition28058.isExit = false;
			animatorStateTransition28058.mute = false;
			animatorStateTransition28058.solo = false;
			animatorStateTransition28058.AddCondition(AnimatorConditionMode.Greater, 0.001f, "ForwardMovement");
			animatorStateTransition28058.AddCondition(AnimatorConditionMode.Equals, 3f, "AbilityIntData");

			var animatorStateTransition28060 = climbRightUpAnimatorState28034.AddTransition(climbRightDownAnimatorState28038);
			animatorStateTransition28060.canTransitionToSelf = true;
			animatorStateTransition28060.duration = 0f;
			animatorStateTransition28060.exitTime = 1.05f;
			animatorStateTransition28060.hasExitTime = true;
			animatorStateTransition28060.hasFixedDuration = true;
			animatorStateTransition28060.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition28060.offset = 0f;
			animatorStateTransition28060.orderedInterruption = true;
			animatorStateTransition28060.isExit = false;
			animatorStateTransition28060.mute = false;
			animatorStateTransition28060.solo = false;
			animatorStateTransition28060.AddCondition(AnimatorConditionMode.Less, -0.001f, "ForwardMovement");
			animatorStateTransition28060.AddCondition(AnimatorConditionMode.Equals, 3f, "AbilityIntData");

			var animatorStateTransition28064 = climbLeftDownAnimatorState28036.AddTransition(climbRightIdleAnimatorState26600);
			animatorStateTransition28064.canTransitionToSelf = true;
			animatorStateTransition28064.duration = 0f;
			animatorStateTransition28064.exitTime = 1.05f;
			animatorStateTransition28064.hasExitTime = true;
			animatorStateTransition28064.hasFixedDuration = true;
			animatorStateTransition28064.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition28064.offset = 0f;
			animatorStateTransition28064.orderedInterruption = true;
			animatorStateTransition28064.isExit = false;
			animatorStateTransition28064.mute = false;
			animatorStateTransition28064.solo = false;
			animatorStateTransition28064.AddCondition(AnimatorConditionMode.IfNot, 0f, "Moving");

			var animatorStateTransition28066 = climbLeftDownAnimatorState28036.AddTransition(bottomDismountLeftAnimatorState27994);
			animatorStateTransition28066.canTransitionToSelf = true;
			animatorStateTransition28066.duration = 0f;
			animatorStateTransition28066.exitTime = 1.05f;
			animatorStateTransition28066.hasExitTime = true;
			animatorStateTransition28066.hasFixedDuration = true;
			animatorStateTransition28066.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition28066.offset = 0f;
			animatorStateTransition28066.orderedInterruption = true;
			animatorStateTransition28066.isExit = false;
			animatorStateTransition28066.mute = false;
			animatorStateTransition28066.solo = false;
			animatorStateTransition28066.AddCondition(AnimatorConditionMode.Equals, 501f, "AbilityIndex");
			animatorStateTransition28066.AddCondition(AnimatorConditionMode.Equals, 4f, "AbilityIntData");

			var animatorStateTransition28068 = climbLeftDownAnimatorState28036.AddExitTransition();
			animatorStateTransition28068.canTransitionToSelf = true;
			animatorStateTransition28068.duration = 0.25f;
			animatorStateTransition28068.exitTime = 0.4000001f;
			animatorStateTransition28068.hasExitTime = false;
			animatorStateTransition28068.hasFixedDuration = true;
			animatorStateTransition28068.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition28068.offset = 0f;
			animatorStateTransition28068.orderedInterruption = true;
			animatorStateTransition28068.isExit = true;
			animatorStateTransition28068.mute = false;
			animatorStateTransition28068.solo = false;
			animatorStateTransition28068.AddCondition(AnimatorConditionMode.NotEqual, 501f, "AbilityIndex");

			var animatorStateTransition28070 = climbLeftDownAnimatorState28036.AddTransition(climbRightDownAnimatorState28038);
			animatorStateTransition28070.canTransitionToSelf = true;
			animatorStateTransition28070.duration = 0f;
			animatorStateTransition28070.exitTime = 1.05f;
			animatorStateTransition28070.hasExitTime = true;
			animatorStateTransition28070.hasFixedDuration = true;
			animatorStateTransition28070.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition28070.offset = 0f;
			animatorStateTransition28070.orderedInterruption = true;
			animatorStateTransition28070.isExit = false;
			animatorStateTransition28070.mute = false;
			animatorStateTransition28070.solo = false;
			animatorStateTransition28070.AddCondition(AnimatorConditionMode.Less, -0.001f, "ForwardMovement");
			animatorStateTransition28070.AddCondition(AnimatorConditionMode.Equals, 3f, "AbilityIntData");

			var animatorStateTransition28072 = climbLeftDownAnimatorState28036.AddTransition(climbLeftUpAnimatorState28032);
			animatorStateTransition28072.canTransitionToSelf = true;
			animatorStateTransition28072.duration = 0f;
			animatorStateTransition28072.exitTime = 1.05f;
			animatorStateTransition28072.hasExitTime = true;
			animatorStateTransition28072.hasFixedDuration = true;
			animatorStateTransition28072.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition28072.offset = 0f;
			animatorStateTransition28072.orderedInterruption = true;
			animatorStateTransition28072.isExit = false;
			animatorStateTransition28072.mute = false;
			animatorStateTransition28072.solo = false;
			animatorStateTransition28072.AddCondition(AnimatorConditionMode.Greater, 0.001f, "ForwardMovement");
			animatorStateTransition28072.AddCondition(AnimatorConditionMode.Equals, 3f, "AbilityIntData");

			var animatorStateTransition28076 = climbRightDownAnimatorState28038.AddTransition(climbLeftIdleAnimatorState28012);
			animatorStateTransition28076.canTransitionToSelf = true;
			animatorStateTransition28076.duration = 0f;
			animatorStateTransition28076.exitTime = 1.05f;
			animatorStateTransition28076.hasExitTime = true;
			animatorStateTransition28076.hasFixedDuration = true;
			animatorStateTransition28076.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition28076.offset = 0f;
			animatorStateTransition28076.orderedInterruption = true;
			animatorStateTransition28076.isExit = false;
			animatorStateTransition28076.mute = false;
			animatorStateTransition28076.solo = false;
			animatorStateTransition28076.AddCondition(AnimatorConditionMode.IfNot, 0f, "Moving");

			var animatorStateTransition28078 = climbRightDownAnimatorState28038.AddExitTransition();
			animatorStateTransition28078.canTransitionToSelf = true;
			animatorStateTransition28078.duration = 0.25f;
			animatorStateTransition28078.exitTime = 0.4000003f;
			animatorStateTransition28078.hasExitTime = false;
			animatorStateTransition28078.hasFixedDuration = true;
			animatorStateTransition28078.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition28078.offset = 0f;
			animatorStateTransition28078.orderedInterruption = true;
			animatorStateTransition28078.isExit = true;
			animatorStateTransition28078.mute = false;
			animatorStateTransition28078.solo = false;
			animatorStateTransition28078.AddCondition(AnimatorConditionMode.NotEqual, 501f, "AbilityIndex");

			var animatorStateTransition28080 = climbRightDownAnimatorState28038.AddTransition(bottomDismountRightAnimatorState27990);
			animatorStateTransition28080.canTransitionToSelf = true;
			animatorStateTransition28080.duration = 0f;
			animatorStateTransition28080.exitTime = 1.05f;
			animatorStateTransition28080.hasExitTime = true;
			animatorStateTransition28080.hasFixedDuration = true;
			animatorStateTransition28080.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition28080.offset = 0f;
			animatorStateTransition28080.orderedInterruption = true;
			animatorStateTransition28080.isExit = false;
			animatorStateTransition28080.mute = false;
			animatorStateTransition28080.solo = false;
			animatorStateTransition28080.AddCondition(AnimatorConditionMode.Equals, 501f, "AbilityIndex");
			animatorStateTransition28080.AddCondition(AnimatorConditionMode.Equals, 4f, "AbilityIntData");

			var animatorStateTransition28082 = climbRightDownAnimatorState28038.AddTransition(climbLeftDownAnimatorState28036);
			animatorStateTransition28082.canTransitionToSelf = true;
			animatorStateTransition28082.duration = 0f;
			animatorStateTransition28082.exitTime = 1.05f;
			animatorStateTransition28082.hasExitTime = true;
			animatorStateTransition28082.hasFixedDuration = true;
			animatorStateTransition28082.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition28082.offset = 0f;
			animatorStateTransition28082.orderedInterruption = true;
			animatorStateTransition28082.isExit = false;
			animatorStateTransition28082.mute = false;
			animatorStateTransition28082.solo = false;
			animatorStateTransition28082.AddCondition(AnimatorConditionMode.Less, -0.001f, "ForwardMovement");
			animatorStateTransition28082.AddCondition(AnimatorConditionMode.Equals, 3f, "AbilityIntData");

			var animatorStateTransition28084 = climbRightDownAnimatorState28038.AddTransition(climbRightUpAnimatorState28034);
			animatorStateTransition28084.canTransitionToSelf = true;
			animatorStateTransition28084.duration = 0f;
			animatorStateTransition28084.exitTime = 1.05f;
			animatorStateTransition28084.hasExitTime = true;
			animatorStateTransition28084.hasFixedDuration = true;
			animatorStateTransition28084.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition28084.offset = 0f;
			animatorStateTransition28084.orderedInterruption = true;
			animatorStateTransition28084.isExit = false;
			animatorStateTransition28084.mute = false;
			animatorStateTransition28084.solo = false;
			animatorStateTransition28084.AddCondition(AnimatorConditionMode.Greater, 0.001f, "ForwardMovement");
			animatorStateTransition28084.AddCondition(AnimatorConditionMode.Equals, 3f, "AbilityIntData");

			var animatorStateTransition28088 = climbLeftIdleAnimatorState28012.AddTransition(climbRightUpAnimatorState28034);
			animatorStateTransition28088.canTransitionToSelf = true;
			animatorStateTransition28088.duration = 0f;
			animatorStateTransition28088.exitTime = 0f;
			animatorStateTransition28088.hasExitTime = false;
			animatorStateTransition28088.hasFixedDuration = true;
			animatorStateTransition28088.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition28088.offset = 0f;
			animatorStateTransition28088.orderedInterruption = true;
			animatorStateTransition28088.isExit = false;
			animatorStateTransition28088.mute = false;
			animatorStateTransition28088.solo = false;
			animatorStateTransition28088.AddCondition(AnimatorConditionMode.Greater, 0.001f, "ForwardMovement");
			animatorStateTransition28088.AddCondition(AnimatorConditionMode.Equals, 3f, "AbilityIntData");

			var animatorStateTransition28090 = climbLeftIdleAnimatorState28012.AddTransition(climbLeftDownAnimatorState28036);
			animatorStateTransition28090.canTransitionToSelf = true;
			animatorStateTransition28090.duration = 0f;
			animatorStateTransition28090.exitTime = 1f;
			animatorStateTransition28090.hasExitTime = false;
			animatorStateTransition28090.hasFixedDuration = true;
			animatorStateTransition28090.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition28090.offset = 0f;
			animatorStateTransition28090.orderedInterruption = true;
			animatorStateTransition28090.isExit = false;
			animatorStateTransition28090.mute = false;
			animatorStateTransition28090.solo = false;
			animatorStateTransition28090.AddCondition(AnimatorConditionMode.Less, -0.001f, "ForwardMovement");
			animatorStateTransition28090.AddCondition(AnimatorConditionMode.Equals, 3f, "AbilityIntData");

			var animatorStateTransition28092 = climbLeftIdleAnimatorState28012.AddTransition(topDismountLeftAnimatorState27992);
			animatorStateTransition28092.canTransitionToSelf = true;
			animatorStateTransition28092.duration = 0.1f;
			animatorStateTransition28092.exitTime = 0f;
			animatorStateTransition28092.hasExitTime = false;
			animatorStateTransition28092.hasFixedDuration = true;
			animatorStateTransition28092.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition28092.offset = 0f;
			animatorStateTransition28092.orderedInterruption = true;
			animatorStateTransition28092.isExit = false;
			animatorStateTransition28092.mute = false;
			animatorStateTransition28092.solo = false;
			animatorStateTransition28092.AddCondition(AnimatorConditionMode.Equals, 501f, "AbilityIndex");
			animatorStateTransition28092.AddCondition(AnimatorConditionMode.Equals, 5f, "AbilityIntData");

			var animatorStateTransition28094 = climbLeftIdleAnimatorState28012.AddTransition(bottomDismountLeftAnimatorState27994);
			animatorStateTransition28094.canTransitionToSelf = true;
			animatorStateTransition28094.duration = 0f;
			animatorStateTransition28094.exitTime = 0f;
			animatorStateTransition28094.hasExitTime = false;
			animatorStateTransition28094.hasFixedDuration = true;
			animatorStateTransition28094.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition28094.offset = 0f;
			animatorStateTransition28094.orderedInterruption = true;
			animatorStateTransition28094.isExit = false;
			animatorStateTransition28094.mute = false;
			animatorStateTransition28094.solo = false;
			animatorStateTransition28094.AddCondition(AnimatorConditionMode.Equals, 501f, "AbilityIndex");
			animatorStateTransition28094.AddCondition(AnimatorConditionMode.Equals, 4f, "AbilityIntData");

			var animatorStateTransition28096 = climbLeftIdleAnimatorState28012.AddExitTransition();
			animatorStateTransition28096.canTransitionToSelf = true;
			animatorStateTransition28096.duration = 0.25f;
			animatorStateTransition28096.exitTime = 0f;
			animatorStateTransition28096.hasExitTime = false;
			animatorStateTransition28096.hasFixedDuration = true;
			animatorStateTransition28096.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition28096.offset = 0f;
			animatorStateTransition28096.orderedInterruption = true;
			animatorStateTransition28096.isExit = true;
			animatorStateTransition28096.mute = false;
			animatorStateTransition28096.solo = false;
			animatorStateTransition28096.AddCondition(AnimatorConditionMode.NotEqual, 501f, "AbilityIndex");

			var animatorStateTransition28100 = climbRightIdleAnimatorState26600.AddTransition(climbLeftUpAnimatorState28032);
			animatorStateTransition28100.canTransitionToSelf = true;
			animatorStateTransition28100.duration = 0f;
			animatorStateTransition28100.exitTime = 0f;
			animatorStateTransition28100.hasExitTime = false;
			animatorStateTransition28100.hasFixedDuration = true;
			animatorStateTransition28100.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition28100.offset = 0f;
			animatorStateTransition28100.orderedInterruption = true;
			animatorStateTransition28100.isExit = false;
			animatorStateTransition28100.mute = false;
			animatorStateTransition28100.solo = false;
			animatorStateTransition28100.AddCondition(AnimatorConditionMode.Greater, 0.001f, "ForwardMovement");
			animatorStateTransition28100.AddCondition(AnimatorConditionMode.Equals, 3f, "AbilityIntData");

			var animatorStateTransition28102 = climbRightIdleAnimatorState26600.AddTransition(climbRightDownAnimatorState28038);
			animatorStateTransition28102.canTransitionToSelf = true;
			animatorStateTransition28102.duration = 0f;
			animatorStateTransition28102.exitTime = 1f;
			animatorStateTransition28102.hasExitTime = false;
			animatorStateTransition28102.hasFixedDuration = true;
			animatorStateTransition28102.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition28102.offset = 0f;
			animatorStateTransition28102.orderedInterruption = true;
			animatorStateTransition28102.isExit = false;
			animatorStateTransition28102.mute = false;
			animatorStateTransition28102.solo = false;
			animatorStateTransition28102.AddCondition(AnimatorConditionMode.Less, -0.001f, "ForwardMovement");
			animatorStateTransition28102.AddCondition(AnimatorConditionMode.Equals, 3f, "AbilityIntData");

			var animatorStateTransition28104 = climbRightIdleAnimatorState26600.AddTransition(bottomDismountRightAnimatorState27990);
			animatorStateTransition28104.canTransitionToSelf = true;
			animatorStateTransition28104.duration = 0f;
			animatorStateTransition28104.exitTime = 0f;
			animatorStateTransition28104.hasExitTime = false;
			animatorStateTransition28104.hasFixedDuration = true;
			animatorStateTransition28104.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition28104.offset = 0f;
			animatorStateTransition28104.orderedInterruption = true;
			animatorStateTransition28104.isExit = false;
			animatorStateTransition28104.mute = false;
			animatorStateTransition28104.solo = false;
			animatorStateTransition28104.AddCondition(AnimatorConditionMode.Equals, 501f, "AbilityIndex");
			animatorStateTransition28104.AddCondition(AnimatorConditionMode.Equals, 4f, "AbilityIntData");

			var animatorStateTransition28106 = climbRightIdleAnimatorState26600.AddTransition(topDismountRightAnimatorState27988);
			animatorStateTransition28106.canTransitionToSelf = true;
			animatorStateTransition28106.duration = 0.1f;
			animatorStateTransition28106.exitTime = 0f;
			animatorStateTransition28106.hasExitTime = false;
			animatorStateTransition28106.hasFixedDuration = true;
			animatorStateTransition28106.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition28106.offset = 0f;
			animatorStateTransition28106.orderedInterruption = true;
			animatorStateTransition28106.isExit = false;
			animatorStateTransition28106.mute = false;
			animatorStateTransition28106.solo = false;
			animatorStateTransition28106.AddCondition(AnimatorConditionMode.Equals, 501f, "AbilityIndex");
			animatorStateTransition28106.AddCondition(AnimatorConditionMode.Equals, 5f, "AbilityIntData");

			var animatorStateTransition28108 = climbRightIdleAnimatorState26600.AddExitTransition();
			animatorStateTransition28108.canTransitionToSelf = true;
			animatorStateTransition28108.duration = 0.25f;
			animatorStateTransition28108.exitTime = 0f;
			animatorStateTransition28108.hasExitTime = false;
			animatorStateTransition28108.hasFixedDuration = true;
			animatorStateTransition28108.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition28108.offset = 0f;
			animatorStateTransition28108.orderedInterruption = true;
			animatorStateTransition28108.isExit = true;
			animatorStateTransition28108.mute = false;
			animatorStateTransition28108.solo = false;
			animatorStateTransition28108.AddCondition(AnimatorConditionMode.NotEqual, 501f, "AbilityIndex");

			// State Transitions.
			var animatorStateTransition28112 = hangtoLadderClimbLeftAnimatorState26630.AddExitTransition();
			animatorStateTransition28112.canTransitionToSelf = true;
			animatorStateTransition28112.duration = 0.05f;
			animatorStateTransition28112.exitTime = 1f;
			animatorStateTransition28112.hasExitTime = true;
			animatorStateTransition28112.hasFixedDuration = true;
			animatorStateTransition28112.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition28112.offset = 0f;
			animatorStateTransition28112.orderedInterruption = true;
			animatorStateTransition28112.isExit = true;
			animatorStateTransition28112.mute = false;
			animatorStateTransition28112.solo = false;
			animatorStateTransition28112.AddCondition(AnimatorConditionMode.NotEqual, 501f, "AbilityIndex");

			var animatorStateTransition28114 = hangtoLadderClimbLeftAnimatorState26630.AddTransition(climbLeftIdleAnimatorState28012);
			animatorStateTransition28114.canTransitionToSelf = true;
			animatorStateTransition28114.duration = 0.05f;
			animatorStateTransition28114.exitTime = 1f;
			animatorStateTransition28114.hasExitTime = true;
			animatorStateTransition28114.hasFixedDuration = true;
			animatorStateTransition28114.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition28114.offset = 0f;
			animatorStateTransition28114.orderedInterruption = true;
			animatorStateTransition28114.isExit = false;
			animatorStateTransition28114.mute = false;
			animatorStateTransition28114.solo = false;
			animatorStateTransition28114.AddCondition(AnimatorConditionMode.Equals, 501f, "AbilityIndex");

			var animatorStateTransition28118 = hangtoLadderClimbRightAnimatorState26632.AddExitTransition();
			animatorStateTransition28118.canTransitionToSelf = true;
			animatorStateTransition28118.duration = 0.05f;
			animatorStateTransition28118.exitTime = 1f;
			animatorStateTransition28118.hasExitTime = true;
			animatorStateTransition28118.hasFixedDuration = true;
			animatorStateTransition28118.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition28118.offset = 0f;
			animatorStateTransition28118.orderedInterruption = true;
			animatorStateTransition28118.isExit = true;
			animatorStateTransition28118.mute = false;
			animatorStateTransition28118.solo = false;
			animatorStateTransition28118.AddCondition(AnimatorConditionMode.NotEqual, 501f, "AbilityIndex");

			var animatorStateTransition28120 = hangtoLadderClimbRightAnimatorState26632.AddTransition(climbLeftIdleAnimatorState28012);
			animatorStateTransition28120.canTransitionToSelf = true;
			animatorStateTransition28120.duration = 0.05f;
			animatorStateTransition28120.exitTime = 1f;
			animatorStateTransition28120.hasExitTime = true;
			animatorStateTransition28120.hasFixedDuration = true;
			animatorStateTransition28120.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition28120.offset = 0f;
			animatorStateTransition28120.orderedInterruption = true;
			animatorStateTransition28120.isExit = false;
			animatorStateTransition28120.mute = false;
			animatorStateTransition28120.solo = false;
			animatorStateTransition28120.AddCondition(AnimatorConditionMode.Equals, 501f, "AbilityIndex");


			// State Machine Transitions.
			var animatorStateTransition26420 = baseStateMachine65573352.AddAnyStateTransition(topMountAnimatorState26596);
			animatorStateTransition26420.canTransitionToSelf = true;
			animatorStateTransition26420.duration = 0f;
			animatorStateTransition26420.exitTime = 0.75f;
			animatorStateTransition26420.hasExitTime = false;
			animatorStateTransition26420.hasFixedDuration = true;
			animatorStateTransition26420.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition26420.offset = 0f;
			animatorStateTransition26420.orderedInterruption = true;
			animatorStateTransition26420.isExit = false;
			animatorStateTransition26420.mute = false;
			animatorStateTransition26420.solo = false;
			animatorStateTransition26420.AddCondition(AnimatorConditionMode.If, 0f, "AbilityChange");
			animatorStateTransition26420.AddCondition(AnimatorConditionMode.Equals, 501f, "AbilityIndex");
			animatorStateTransition26420.AddCondition(AnimatorConditionMode.Equals, 1f, "AbilityIntData");

			var animatorStateTransition26422 = baseStateMachine65573352.AddAnyStateTransition(bottomMountAnimatorState26598);
			animatorStateTransition26422.canTransitionToSelf = false;
			animatorStateTransition26422.duration = 0f;
			animatorStateTransition26422.exitTime = 0.75f;
			animatorStateTransition26422.hasExitTime = false;
			animatorStateTransition26422.hasFixedDuration = true;
			animatorStateTransition26422.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition26422.offset = 0f;
			animatorStateTransition26422.orderedInterruption = true;
			animatorStateTransition26422.isExit = false;
			animatorStateTransition26422.mute = false;
			animatorStateTransition26422.solo = false;
			animatorStateTransition26422.AddCondition(AnimatorConditionMode.If, 0f, "AbilityChange");
			animatorStateTransition26422.AddCondition(AnimatorConditionMode.Equals, 501f, "AbilityIndex");
			animatorStateTransition26422.AddCondition(AnimatorConditionMode.Equals, 0f, "AbilityIntData");

			var animatorStateTransition26424 = baseStateMachine65573352.AddAnyStateTransition(climbRightIdleAnimatorState26600);
			animatorStateTransition26424.canTransitionToSelf = true;
			animatorStateTransition26424.duration = 0f;
			animatorStateTransition26424.exitTime = 0.75f;
			animatorStateTransition26424.hasExitTime = false;
			animatorStateTransition26424.hasFixedDuration = true;
			animatorStateTransition26424.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition26424.offset = 0f;
			animatorStateTransition26424.orderedInterruption = true;
			animatorStateTransition26424.isExit = false;
			animatorStateTransition26424.mute = false;
			animatorStateTransition26424.solo = false;
			animatorStateTransition26424.AddCondition(AnimatorConditionMode.If, 0f, "AbilityChange");
			animatorStateTransition26424.AddCondition(AnimatorConditionMode.Equals, 501f, "AbilityIndex");
			animatorStateTransition26424.AddCondition(AnimatorConditionMode.Equals, 2f, "AbilityIntData");

			var animatorStateTransition26454 = baseStateMachine65573352.AddAnyStateTransition(hangtoLadderClimbLeftAnimatorState26630);
			animatorStateTransition26454.canTransitionToSelf = false;
			animatorStateTransition26454.duration = 0.05f;
			animatorStateTransition26454.exitTime = 0.75f;
			animatorStateTransition26454.hasExitTime = false;
			animatorStateTransition26454.hasFixedDuration = true;
			animatorStateTransition26454.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition26454.offset = 0f;
			animatorStateTransition26454.orderedInterruption = true;
			animatorStateTransition26454.isExit = false;
			animatorStateTransition26454.mute = false;
			animatorStateTransition26454.solo = false;
			animatorStateTransition26454.AddCondition(AnimatorConditionMode.If, 0f, "AbilityChange");
			animatorStateTransition26454.AddCondition(AnimatorConditionMode.Equals, 501f, "AbilityIndex");
			animatorStateTransition26454.AddCondition(AnimatorConditionMode.Equals, 6f, "AbilityIntData");
			animatorStateTransition26454.AddCondition(AnimatorConditionMode.Less, 0f, "HorizontalMovement");

			var animatorStateTransition26456 = baseStateMachine65573352.AddAnyStateTransition(hangtoLadderClimbRightAnimatorState26632);
			animatorStateTransition26456.canTransitionToSelf = false;
			animatorStateTransition26456.duration = 0.05f;
			animatorStateTransition26456.exitTime = 0.75f;
			animatorStateTransition26456.hasExitTime = false;
			animatorStateTransition26456.hasFixedDuration = true;
			animatorStateTransition26456.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition26456.offset = 0f;
			animatorStateTransition26456.orderedInterruption = true;
			animatorStateTransition26456.isExit = false;
			animatorStateTransition26456.mute = false;
			animatorStateTransition26456.solo = false;
			animatorStateTransition26456.AddCondition(AnimatorConditionMode.If, 0f, "AbilityChange");
			animatorStateTransition26456.AddCondition(AnimatorConditionMode.Equals, 501f, "AbilityIndex");
			animatorStateTransition26456.AddCondition(AnimatorConditionMode.Equals, 6f, "AbilityIntData");
			animatorStateTransition26456.AddCondition(AnimatorConditionMode.Greater, 0f, "HorizontalMovement");
		}
	}
}
