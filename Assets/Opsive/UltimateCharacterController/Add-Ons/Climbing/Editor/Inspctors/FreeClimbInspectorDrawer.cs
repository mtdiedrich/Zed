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
	/// Draws a custom inspector for the FreeClimb Ability.
	/// </summary>
	[InspectorDrawer(typeof(FreeClimb))]
	public class HangInspectorDrawer : DetectObjectAbilityBaseInspectorDrawer
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
			var allowedMovements = (int)InspectorUtility.GetFieldValue<FreeClimb.AllowedMovement>(target, "m_AllowedMovements");
            var allowedMovementsString = System.Enum.GetNames(typeof(FreeClimb.AllowedMovement));
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

			var baseStateMachine2110969806 = animatorController.layers[12].stateMachine;

			// The state machine should start fresh.
			for (int i = 0; i < animatorController.layers.Length; ++i) {
				for (int j = 0; j < baseStateMachine2110969806.stateMachines.Length; ++j) {
					if (baseStateMachine2110969806.stateMachines[j].stateMachine.name == "Free Climb") {
						baseStateMachine2110969806.RemoveStateMachine(baseStateMachine2110969806.stateMachines[j].stateMachine);
						break;
					}
				}
			}

			// AnimationClip references.
			var freeClimbBottomMountAnimationClip30568Path = AssetDatabase.GUIDToAssetPath("ad3e0898ef7b1c8468137c319e19b2c0"); 
			var freeClimbBottomMountAnimationClip30568 = AnimatorBuilder.GetAnimationClip(freeClimbBottomMountAnimationClip30568Path, "FreeClimbBottomMount");
			var freeClimbTopMountAnimationClip30572Path = AssetDatabase.GUIDToAssetPath("594f727febd17b043894b835045c039e"); 
			var freeClimbTopMountAnimationClip30572 = AnimatorBuilder.GetAnimationClip(freeClimbTopMountAnimationClip30572Path, "FreeClimbTopMount");
			var freeClimbLeftDiagonalUpAnimationClip30632Path = AssetDatabase.GUIDToAssetPath("204c49d338799a44b8762fca301508da"); 
			var freeClimbLeftDiagonalUpAnimationClip30632 = AnimatorBuilder.GetAnimationClip(freeClimbLeftDiagonalUpAnimationClip30632Path, "FreeClimbLeftDiagonalUp");
			var freeClimbRightDiagonalUpAnimationClip30634Path = AssetDatabase.GUIDToAssetPath("204c49d338799a44b8762fca301508da"); 
			var freeClimbRightDiagonalUpAnimationClip30634 = AnimatorBuilder.GetAnimationClip(freeClimbRightDiagonalUpAnimationClip30634Path, "FreeClimbRightDiagonalUp");
			var freeClimbUpAnimationClip30636Path = AssetDatabase.GUIDToAssetPath("ddeba2ae54198e040b5f752b0da3be7e"); 
			var freeClimbUpAnimationClip30636 = AnimatorBuilder.GetAnimationClip(freeClimbUpAnimationClip30636Path, "FreeClimbUp");
			var freeClimbDownAnimationClip30638Path = AssetDatabase.GUIDToAssetPath("ddeba2ae54198e040b5f752b0da3be7e"); 
			var freeClimbDownAnimationClip30638 = AnimatorBuilder.GetAnimationClip(freeClimbDownAnimationClip30638Path, "FreeClimbDown");
			var freeClimbLeftDiagonalDownAnimationClip30640Path = AssetDatabase.GUIDToAssetPath("204c49d338799a44b8762fca301508da"); 
			var freeClimbLeftDiagonalDownAnimationClip30640 = AnimatorBuilder.GetAnimationClip(freeClimbLeftDiagonalDownAnimationClip30640Path, "FreeClimbLeftDiagonalDown");
			var freeClimbRightDiagonalDownAnimationClip30642Path = AssetDatabase.GUIDToAssetPath("204c49d338799a44b8762fca301508da"); 
			var freeClimbRightDiagonalDownAnimationClip30642 = AnimatorBuilder.GetAnimationClip(freeClimbRightDiagonalDownAnimationClip30642Path, "FreeClimbRightDiagonalDown");
			var freeClimbLeftJumpAnimationClip30644Path = AssetDatabase.GUIDToAssetPath("513fbf4a8043fcf41b0b8a794c099c40"); 
			var freeClimbLeftJumpAnimationClip30644 = AnimatorBuilder.GetAnimationClip(freeClimbLeftJumpAnimationClip30644Path, "FreeClimbLeftJump");
			var freeClimbLeftAnimationClip30646Path = AssetDatabase.GUIDToAssetPath("513fbf4a8043fcf41b0b8a794c099c40"); 
			var freeClimbLeftAnimationClip30646 = AnimatorBuilder.GetAnimationClip(freeClimbLeftAnimationClip30646Path, "FreeClimbLeft");
			var freeClimbIdleAnimationClip30648Path = AssetDatabase.GUIDToAssetPath("64f8f5acd8a248049bab290095ab89cb"); 
			var freeClimbIdleAnimationClip30648 = AnimatorBuilder.GetAnimationClip(freeClimbIdleAnimationClip30648Path, "FreeClimbIdle");
			var freeClimbRightAnimationClip30650Path = AssetDatabase.GUIDToAssetPath("513fbf4a8043fcf41b0b8a794c099c40"); 
			var freeClimbRightAnimationClip30650 = AnimatorBuilder.GetAnimationClip(freeClimbRightAnimationClip30650Path, "FreeClimbRight");
			var freeClimbRightJumpAnimationClip30652Path = AssetDatabase.GUIDToAssetPath("513fbf4a8043fcf41b0b8a794c099c40"); 
			var freeClimbRightJumpAnimationClip30652 = AnimatorBuilder.GetAnimationClip(freeClimbRightJumpAnimationClip30652Path, "FreeClimbRightJump");
			var freeClimbBottomDismountAnimationClip30576Path = AssetDatabase.GUIDToAssetPath("48bf46b5af3fb8048b881434cf6bd2b4"); 
			var freeClimbBottomDismountAnimationClip30576 = AnimatorBuilder.GetAnimationClip(freeClimbBottomDismountAnimationClip30576Path, "FreeClimbBottomDismount");
			var freeClimbTopDismountAnimationClip30580Path = AssetDatabase.GUIDToAssetPath("c6ee3468f2225ea439bafc3bc61eabb5"); 
			var freeClimbTopDismountAnimationClip30580 = AnimatorBuilder.GetAnimationClip(freeClimbTopDismountAnimationClip30580Path, "FreeClimbTopDismount");
			var freeClimbInnerRightTurnAnimationClip30588Path = AssetDatabase.GUIDToAssetPath("513fbf4a8043fcf41b0b8a794c099c40"); 
			var freeClimbInnerRightTurnAnimationClip30588 = AnimatorBuilder.GetAnimationClip(freeClimbInnerRightTurnAnimationClip30588Path, "FreeClimbInnerRightTurn");
			var freeClimbOuterRightTurnAnimationClip30596Path = AssetDatabase.GUIDToAssetPath("513fbf4a8043fcf41b0b8a794c099c40"); 
			var freeClimbOuterRightTurnAnimationClip30596 = AnimatorBuilder.GetAnimationClip(freeClimbOuterRightTurnAnimationClip30596Path, "FreeClimbOuterRightTurn");
			var freeClimbOuterLeftTurnAnimationClip30604Path = AssetDatabase.GUIDToAssetPath("513fbf4a8043fcf41b0b8a794c099c40"); 
			var freeClimbOuterLeftTurnAnimationClip30604 = AnimatorBuilder.GetAnimationClip(freeClimbOuterLeftTurnAnimationClip30604Path, "FreeClimbOuterLeftTurn");
			var freeClimbInnerLeftTurnAnimationClip30612Path = AssetDatabase.GUIDToAssetPath("513fbf4a8043fcf41b0b8a794c099c40"); 
			var freeClimbInnerLeftTurnAnimationClip30612 = AnimatorBuilder.GetAnimationClip(freeClimbInnerLeftTurnAnimationClip30612Path, "FreeClimbInnerLeftTurn");
			var freeClimbLeftDiagonalJumpUpLeftAnimationClip30654Path = AssetDatabase.GUIDToAssetPath("204c49d338799a44b8762fca301508da"); 
			var freeClimbLeftDiagonalJumpUpLeftAnimationClip30654 = AnimatorBuilder.GetAnimationClip(freeClimbLeftDiagonalJumpUpLeftAnimationClip30654Path, "FreeClimbLeftDiagonalJumpUpLeft");
			var freeClimbJumpUpLeftAnimationClip30656Path = AssetDatabase.GUIDToAssetPath("ddeba2ae54198e040b5f752b0da3be7e"); 
			var freeClimbJumpUpLeftAnimationClip30656 = AnimatorBuilder.GetAnimationClip(freeClimbJumpUpLeftAnimationClip30656Path, "FreeClimbJumpUpLeft");
			var freeClimbRightDiagonalJumpUpLeftAnimationClip30658Path = AssetDatabase.GUIDToAssetPath("204c49d338799a44b8762fca301508da"); 
			var freeClimbRightDiagonalJumpUpLeftAnimationClip30658 = AnimatorBuilder.GetAnimationClip(freeClimbRightDiagonalJumpUpLeftAnimationClip30658Path, "FreeClimbRightDiagonalJumpUpLeft");
			var freeClimbLeftDiagonalJumpUpRightAnimationClip30660Path = AssetDatabase.GUIDToAssetPath("204c49d338799a44b8762fca301508da"); 
			var freeClimbLeftDiagonalJumpUpRightAnimationClip30660 = AnimatorBuilder.GetAnimationClip(freeClimbLeftDiagonalJumpUpRightAnimationClip30660Path, "FreeClimbLeftDiagonalJumpUpRight");
			var freeClimbJumpUpRightAnimationClip30662Path = AssetDatabase.GUIDToAssetPath("ddeba2ae54198e040b5f752b0da3be7e"); 
			var freeClimbJumpUpRightAnimationClip30662 = AnimatorBuilder.GetAnimationClip(freeClimbJumpUpRightAnimationClip30662Path, "FreeClimbJumpUpRight");
			var freeClimbRightDiagonalJumpUpRightAnimationClip30664Path = AssetDatabase.GUIDToAssetPath("204c49d338799a44b8762fca301508da"); 
			var freeClimbRightDiagonalJumpUpRightAnimationClip30664 = AnimatorBuilder.GetAnimationClip(freeClimbRightDiagonalJumpUpRightAnimationClip30664Path, "FreeClimbRightDiagonalJumpUpRight");
			var hangtoFreeClimbLeftAnimationClip30618Path = AssetDatabase.GUIDToAssetPath("f42dffbc7133a3c4fbf6085ebb7d7ad5"); 
			var hangtoFreeClimbLeftAnimationClip30618 = AnimatorBuilder.GetAnimationClip(hangtoFreeClimbLeftAnimationClip30618Path, "HangtoFreeClimbLeft");
			var hangtoFreeClimbRightAnimationClip30624Path = AssetDatabase.GUIDToAssetPath("f42dffbc7133a3c4fbf6085ebb7d7ad5"); 
			var hangtoFreeClimbRightAnimationClip30624 = AnimatorBuilder.GetAnimationClip(hangtoFreeClimbRightAnimationClip30624Path, "HangtoFreeClimbRight");
			var hangtoFreeClimbVerticalAnimationClip30630Path = AssetDatabase.GUIDToAssetPath("47cec5d05251a604694ab3c623eb83e0"); 
			var hangtoFreeClimbVerticalAnimationClip30630 = AnimatorBuilder.GetAnimationClip(hangtoFreeClimbVerticalAnimationClip30630Path, "HangtoFreeClimbVertical");

			// State Machine.
			var freeClimbAnimatorStateMachine24626 = baseStateMachine2110969806.AddStateMachine("Free Climb", new Vector3(650f, 500f, 0f));

			// States.
			var freeClimbBottomMountAnimatorState24680 = freeClimbAnimatorStateMachine24626.AddState("Free Climb Bottom Mount", new Vector3(-460f, -270f, 0f));
			freeClimbBottomMountAnimatorState24680.motion = freeClimbBottomMountAnimationClip30568;
			freeClimbBottomMountAnimatorState24680.cycleOffset = 0f;
			freeClimbBottomMountAnimatorState24680.cycleOffsetParameterActive = false;
			freeClimbBottomMountAnimatorState24680.iKOnFeet = false;
			freeClimbBottomMountAnimatorState24680.mirror = false;
			freeClimbBottomMountAnimatorState24680.mirrorParameterActive = false;
			freeClimbBottomMountAnimatorState24680.speed = 1f;
			freeClimbBottomMountAnimatorState24680.speedParameterActive = false;
			freeClimbBottomMountAnimatorState24680.writeDefaultValues = true;

			var freeClimbTopMountAnimatorState24682 = freeClimbAnimatorStateMachine24626.AddState("Free Climb Top Mount", new Vector3(-460f, -200f, 0f));
			freeClimbTopMountAnimatorState24682.motion = freeClimbTopMountAnimationClip30572;
			freeClimbTopMountAnimatorState24682.cycleOffset = 0f;
			freeClimbTopMountAnimatorState24682.cycleOffsetParameterActive = false;
			freeClimbTopMountAnimatorState24682.iKOnFeet = false;
			freeClimbTopMountAnimatorState24682.mirror = false;
			freeClimbTopMountAnimatorState24682.mirrorParameterActive = false;
			freeClimbTopMountAnimatorState24682.speed = 1f;
			freeClimbTopMountAnimatorState24682.speedParameterActive = false;
			freeClimbTopMountAnimatorState24682.writeDefaultValues = true;

			var freeClimbVerticalAnimatorState24638 = freeClimbAnimatorStateMachine24626.AddState("Free Climb Vertical", new Vector3(-90f, -120f, 0f));
			var freeClimbVerticalAnimatorState24638blendTreeBlendTree25642 = new BlendTree();
			AssetDatabase.AddObjectToAsset(freeClimbVerticalAnimatorState24638blendTreeBlendTree25642, animatorController);
			freeClimbVerticalAnimatorState24638blendTreeBlendTree25642.hideFlags = HideFlags.HideInHierarchy;
			freeClimbVerticalAnimatorState24638blendTreeBlendTree25642.blendParameter = "HorizontalMovement";
			freeClimbVerticalAnimatorState24638blendTreeBlendTree25642.blendParameterY = "ForwardMovement";
			freeClimbVerticalAnimatorState24638blendTreeBlendTree25642.blendType = BlendTreeType.FreeformCartesian2D;
			freeClimbVerticalAnimatorState24638blendTreeBlendTree25642.maxThreshold = 0.4340277f;
			freeClimbVerticalAnimatorState24638blendTreeBlendTree25642.minThreshold = 0f;
			freeClimbVerticalAnimatorState24638blendTreeBlendTree25642.name = "Blend Tree";
			freeClimbVerticalAnimatorState24638blendTreeBlendTree25642.useAutomaticThresholds = true;
			var freeClimbVerticalAnimatorState24638blendTreeBlendTree25642Child0 =  new ChildMotion();
			freeClimbVerticalAnimatorState24638blendTreeBlendTree25642Child0.motion = freeClimbLeftDiagonalUpAnimationClip30632;
			freeClimbVerticalAnimatorState24638blendTreeBlendTree25642Child0.cycleOffset = 0f;
			freeClimbVerticalAnimatorState24638blendTreeBlendTree25642Child0.directBlendParameter = "HorizontalMovement";
			freeClimbVerticalAnimatorState24638blendTreeBlendTree25642Child0.mirror = false;
			freeClimbVerticalAnimatorState24638blendTreeBlendTree25642Child0.position = new Vector2(-1f, 1f);
			freeClimbVerticalAnimatorState24638blendTreeBlendTree25642Child0.threshold = 0f;
			freeClimbVerticalAnimatorState24638blendTreeBlendTree25642Child0.timeScale = 1f;
			var freeClimbVerticalAnimatorState24638blendTreeBlendTree25642Child1 =  new ChildMotion();
			freeClimbVerticalAnimatorState24638blendTreeBlendTree25642Child1.motion = freeClimbRightDiagonalUpAnimationClip30634;
			freeClimbVerticalAnimatorState24638blendTreeBlendTree25642Child1.cycleOffset = 0f;
			freeClimbVerticalAnimatorState24638blendTreeBlendTree25642Child1.directBlendParameter = "HorizontalMovement";
			freeClimbVerticalAnimatorState24638blendTreeBlendTree25642Child1.mirror = false;
			freeClimbVerticalAnimatorState24638blendTreeBlendTree25642Child1.position = new Vector2(1f, 1f);
			freeClimbVerticalAnimatorState24638blendTreeBlendTree25642Child1.threshold = 0.08680554f;
			freeClimbVerticalAnimatorState24638blendTreeBlendTree25642Child1.timeScale = 1f;
			var freeClimbVerticalAnimatorState24638blendTreeBlendTree25642Child2 =  new ChildMotion();
			freeClimbVerticalAnimatorState24638blendTreeBlendTree25642Child2.motion = freeClimbUpAnimationClip30636;
			freeClimbVerticalAnimatorState24638blendTreeBlendTree25642Child2.cycleOffset = 0f;
			freeClimbVerticalAnimatorState24638blendTreeBlendTree25642Child2.directBlendParameter = "HorizontalMovement";
			freeClimbVerticalAnimatorState24638blendTreeBlendTree25642Child2.mirror = false;
			freeClimbVerticalAnimatorState24638blendTreeBlendTree25642Child2.position = new Vector2(0f, 1f);
			freeClimbVerticalAnimatorState24638blendTreeBlendTree25642Child2.threshold = 0.1736111f;
			freeClimbVerticalAnimatorState24638blendTreeBlendTree25642Child2.timeScale = 1f;
			var freeClimbVerticalAnimatorState24638blendTreeBlendTree25642Child3 =  new ChildMotion();
			freeClimbVerticalAnimatorState24638blendTreeBlendTree25642Child3.motion = freeClimbDownAnimationClip30638;
			freeClimbVerticalAnimatorState24638blendTreeBlendTree25642Child3.cycleOffset = 0f;
			freeClimbVerticalAnimatorState24638blendTreeBlendTree25642Child3.directBlendParameter = "HorizontalMovement";
			freeClimbVerticalAnimatorState24638blendTreeBlendTree25642Child3.mirror = false;
			freeClimbVerticalAnimatorState24638blendTreeBlendTree25642Child3.position = new Vector2(0f, -1f);
			freeClimbVerticalAnimatorState24638blendTreeBlendTree25642Child3.threshold = 0.2604166f;
			freeClimbVerticalAnimatorState24638blendTreeBlendTree25642Child3.timeScale = 1f;
			var freeClimbVerticalAnimatorState24638blendTreeBlendTree25642Child4 =  new ChildMotion();
			freeClimbVerticalAnimatorState24638blendTreeBlendTree25642Child4.motion = freeClimbLeftDiagonalDownAnimationClip30640;
			freeClimbVerticalAnimatorState24638blendTreeBlendTree25642Child4.cycleOffset = 0f;
			freeClimbVerticalAnimatorState24638blendTreeBlendTree25642Child4.directBlendParameter = "HorizontalMovement";
			freeClimbVerticalAnimatorState24638blendTreeBlendTree25642Child4.mirror = false;
			freeClimbVerticalAnimatorState24638blendTreeBlendTree25642Child4.position = new Vector2(-1f, -1f);
			freeClimbVerticalAnimatorState24638blendTreeBlendTree25642Child4.threshold = 0.3472222f;
			freeClimbVerticalAnimatorState24638blendTreeBlendTree25642Child4.timeScale = 1f;
			var freeClimbVerticalAnimatorState24638blendTreeBlendTree25642Child5 =  new ChildMotion();
			freeClimbVerticalAnimatorState24638blendTreeBlendTree25642Child5.motion = freeClimbRightDiagonalDownAnimationClip30642;
			freeClimbVerticalAnimatorState24638blendTreeBlendTree25642Child5.cycleOffset = 0f;
			freeClimbVerticalAnimatorState24638blendTreeBlendTree25642Child5.directBlendParameter = "HorizontalMovement";
			freeClimbVerticalAnimatorState24638blendTreeBlendTree25642Child5.mirror = false;
			freeClimbVerticalAnimatorState24638blendTreeBlendTree25642Child5.position = new Vector2(1f, -1f);
			freeClimbVerticalAnimatorState24638blendTreeBlendTree25642Child5.threshold = 0.4340277f;
			freeClimbVerticalAnimatorState24638blendTreeBlendTree25642Child5.timeScale = 1f;
			freeClimbVerticalAnimatorState24638blendTreeBlendTree25642.children = new ChildMotion[] {
				freeClimbVerticalAnimatorState24638blendTreeBlendTree25642Child0,
				freeClimbVerticalAnimatorState24638blendTreeBlendTree25642Child1,
				freeClimbVerticalAnimatorState24638blendTreeBlendTree25642Child2,
				freeClimbVerticalAnimatorState24638blendTreeBlendTree25642Child3,
				freeClimbVerticalAnimatorState24638blendTreeBlendTree25642Child4,
				freeClimbVerticalAnimatorState24638blendTreeBlendTree25642Child5
			};
			freeClimbVerticalAnimatorState24638.motion = freeClimbVerticalAnimatorState24638blendTreeBlendTree25642;
			freeClimbVerticalAnimatorState24638.cycleOffset = 0f;
			freeClimbVerticalAnimatorState24638.cycleOffsetParameterActive = false;
			freeClimbVerticalAnimatorState24638.iKOnFeet = false;
			freeClimbVerticalAnimatorState24638.mirror = false;
			freeClimbVerticalAnimatorState24638.mirrorParameterActive = false;
			freeClimbVerticalAnimatorState24638.speed = 1f;
			freeClimbVerticalAnimatorState24638.speedParameterActive = false;
			freeClimbVerticalAnimatorState24638.writeDefaultValues = true;

			var freeClimbIdleAnimatorState24642 = freeClimbAnimatorStateMachine24626.AddState("Free Climb Idle", new Vector3(-90f, -240f, 0f));
			var freeClimbIdleAnimatorState24642blendTreeBlendTree25606 = new BlendTree();
			AssetDatabase.AddObjectToAsset(freeClimbIdleAnimatorState24642blendTreeBlendTree25606, animatorController);
			freeClimbIdleAnimatorState24642blendTreeBlendTree25606.hideFlags = HideFlags.HideInHierarchy;
			freeClimbIdleAnimatorState24642blendTreeBlendTree25606.blendParameter = "HorizontalMovement";
			freeClimbIdleAnimatorState24642blendTreeBlendTree25606.blendParameterY = "HorizontalMovement";
			freeClimbIdleAnimatorState24642blendTreeBlendTree25606.blendType = BlendTreeType.Simple1D;
			freeClimbIdleAnimatorState24642blendTreeBlendTree25606.maxThreshold = 2f;
			freeClimbIdleAnimatorState24642blendTreeBlendTree25606.minThreshold = -2f;
			freeClimbIdleAnimatorState24642blendTreeBlendTree25606.name = "Blend Tree";
			freeClimbIdleAnimatorState24642blendTreeBlendTree25606.useAutomaticThresholds = false;
			var freeClimbIdleAnimatorState24642blendTreeBlendTree25606Child0 =  new ChildMotion();
			freeClimbIdleAnimatorState24642blendTreeBlendTree25606Child0.motion = freeClimbLeftJumpAnimationClip30644;
			freeClimbIdleAnimatorState24642blendTreeBlendTree25606Child0.cycleOffset = 0f;
			freeClimbIdleAnimatorState24642blendTreeBlendTree25606Child0.directBlendParameter = "HorizontalMovement";
			freeClimbIdleAnimatorState24642blendTreeBlendTree25606Child0.mirror = false;
			freeClimbIdleAnimatorState24642blendTreeBlendTree25606Child0.position = new Vector2(0f, 0f);
			freeClimbIdleAnimatorState24642blendTreeBlendTree25606Child0.threshold = -2f;
			freeClimbIdleAnimatorState24642blendTreeBlendTree25606Child0.timeScale = 1f;
			var freeClimbIdleAnimatorState24642blendTreeBlendTree25606Child1 =  new ChildMotion();
			freeClimbIdleAnimatorState24642blendTreeBlendTree25606Child1.motion = freeClimbLeftAnimationClip30646;
			freeClimbIdleAnimatorState24642blendTreeBlendTree25606Child1.cycleOffset = 0f;
			freeClimbIdleAnimatorState24642blendTreeBlendTree25606Child1.directBlendParameter = "HorizontalMovement";
			freeClimbIdleAnimatorState24642blendTreeBlendTree25606Child1.mirror = false;
			freeClimbIdleAnimatorState24642blendTreeBlendTree25606Child1.position = new Vector2(0f, 0f);
			freeClimbIdleAnimatorState24642blendTreeBlendTree25606Child1.threshold = -1f;
			freeClimbIdleAnimatorState24642blendTreeBlendTree25606Child1.timeScale = 1f;
			var freeClimbIdleAnimatorState24642blendTreeBlendTree25606Child2 =  new ChildMotion();
			freeClimbIdleAnimatorState24642blendTreeBlendTree25606Child2.motion = freeClimbIdleAnimationClip30648;
			freeClimbIdleAnimatorState24642blendTreeBlendTree25606Child2.cycleOffset = 0f;
			freeClimbIdleAnimatorState24642blendTreeBlendTree25606Child2.directBlendParameter = "HorizontalMovement";
			freeClimbIdleAnimatorState24642blendTreeBlendTree25606Child2.mirror = false;
			freeClimbIdleAnimatorState24642blendTreeBlendTree25606Child2.position = new Vector2(0f, 0f);
			freeClimbIdleAnimatorState24642blendTreeBlendTree25606Child2.threshold = 0f;
			freeClimbIdleAnimatorState24642blendTreeBlendTree25606Child2.timeScale = 1f;
			var freeClimbIdleAnimatorState24642blendTreeBlendTree25606Child3 =  new ChildMotion();
			freeClimbIdleAnimatorState24642blendTreeBlendTree25606Child3.motion = freeClimbRightAnimationClip30650;
			freeClimbIdleAnimatorState24642blendTreeBlendTree25606Child3.cycleOffset = 0f;
			freeClimbIdleAnimatorState24642blendTreeBlendTree25606Child3.directBlendParameter = "HorizontalMovement";
			freeClimbIdleAnimatorState24642blendTreeBlendTree25606Child3.mirror = false;
			freeClimbIdleAnimatorState24642blendTreeBlendTree25606Child3.position = new Vector2(0f, 0f);
			freeClimbIdleAnimatorState24642blendTreeBlendTree25606Child3.threshold = 1f;
			freeClimbIdleAnimatorState24642blendTreeBlendTree25606Child3.timeScale = 1f;
			var freeClimbIdleAnimatorState24642blendTreeBlendTree25606Child4 =  new ChildMotion();
			freeClimbIdleAnimatorState24642blendTreeBlendTree25606Child4.motion = freeClimbRightJumpAnimationClip30652;
			freeClimbIdleAnimatorState24642blendTreeBlendTree25606Child4.cycleOffset = 0f;
			freeClimbIdleAnimatorState24642blendTreeBlendTree25606Child4.directBlendParameter = "HorizontalMovement";
			freeClimbIdleAnimatorState24642blendTreeBlendTree25606Child4.mirror = false;
			freeClimbIdleAnimatorState24642blendTreeBlendTree25606Child4.position = new Vector2(0f, 0f);
			freeClimbIdleAnimatorState24642blendTreeBlendTree25606Child4.threshold = 2f;
			freeClimbIdleAnimatorState24642blendTreeBlendTree25606Child4.timeScale = 1f;
			freeClimbIdleAnimatorState24642blendTreeBlendTree25606.children = new ChildMotion[] {
				freeClimbIdleAnimatorState24642blendTreeBlendTree25606Child0,
				freeClimbIdleAnimatorState24642blendTreeBlendTree25606Child1,
				freeClimbIdleAnimatorState24642blendTreeBlendTree25606Child2,
				freeClimbIdleAnimatorState24642blendTreeBlendTree25606Child3,
				freeClimbIdleAnimatorState24642blendTreeBlendTree25606Child4
			};
			freeClimbIdleAnimatorState24642.motion = freeClimbIdleAnimatorState24642blendTreeBlendTree25606;
			freeClimbIdleAnimatorState24642.cycleOffset = 0f;
			freeClimbIdleAnimatorState24642.cycleOffsetParameterActive = false;
			freeClimbIdleAnimatorState24642.iKOnFeet = false;
			freeClimbIdleAnimatorState24642.mirror = false;
			freeClimbIdleAnimatorState24642.mirrorParameterActive = false;
			freeClimbIdleAnimatorState24642.speed = 1f;
			freeClimbIdleAnimatorState24642.speedParameterActive = false;
			freeClimbIdleAnimatorState24642.writeDefaultValues = true;

			var freeClimbBottomDismountAnimatorState24684 = freeClimbAnimatorStateMachine24626.AddState("Free Climb Bottom Dismount", new Vector3(270f, -220f, 0f));
			freeClimbBottomDismountAnimatorState24684.motion = freeClimbBottomDismountAnimationClip30576;
			freeClimbBottomDismountAnimatorState24684.cycleOffset = 0f;
			freeClimbBottomDismountAnimatorState24684.cycleOffsetParameterActive = false;
			freeClimbBottomDismountAnimatorState24684.iKOnFeet = false;
			freeClimbBottomDismountAnimatorState24684.mirror = false;
			freeClimbBottomDismountAnimatorState24684.mirrorParameterActive = false;
			freeClimbBottomDismountAnimatorState24684.speed = 1f;
			freeClimbBottomDismountAnimatorState24684.speedParameterActive = false;
			freeClimbBottomDismountAnimatorState24684.writeDefaultValues = true;

			var freeClimbTopDismountAnimatorState24686 = freeClimbAnimatorStateMachine24626.AddState("Free Climb Top Dismount", new Vector3(270f, -170f, 0f));
			freeClimbTopDismountAnimatorState24686.motion = freeClimbTopDismountAnimationClip30580;
			freeClimbTopDismountAnimatorState24686.cycleOffset = 0f;
			freeClimbTopDismountAnimatorState24686.cycleOffsetParameterActive = false;
			freeClimbTopDismountAnimatorState24686.iKOnFeet = false;
			freeClimbTopDismountAnimatorState24686.mirror = false;
			freeClimbTopDismountAnimatorState24686.mirrorParameterActive = false;
			freeClimbTopDismountAnimatorState24686.speed = 1f;
			freeClimbTopDismountAnimatorState24686.speedParameterActive = false;
			freeClimbTopDismountAnimatorState24686.writeDefaultValues = true;

			var innerRightTurnAnimatorState24688 = freeClimbAnimatorStateMachine24626.AddState("Inner Right Turn", new Vector3(-250f, -450f, 0f));
			innerRightTurnAnimatorState24688.motion = freeClimbInnerRightTurnAnimationClip30588;
			innerRightTurnAnimatorState24688.cycleOffset = 0f;
			innerRightTurnAnimatorState24688.cycleOffsetParameterActive = false;
			innerRightTurnAnimatorState24688.iKOnFeet = false;
			innerRightTurnAnimatorState24688.mirror = false;
			innerRightTurnAnimatorState24688.mirrorParameterActive = false;
			innerRightTurnAnimatorState24688.speed = 1f;
			innerRightTurnAnimatorState24688.speedParameterActive = false;
			innerRightTurnAnimatorState24688.writeDefaultValues = true;

			var outerRightTurnAnimatorState24690 = freeClimbAnimatorStateMachine24626.AddState("Outer Right Turn", new Vector3(20f, -450f, 0f));
			outerRightTurnAnimatorState24690.motion = freeClimbOuterRightTurnAnimationClip30596;
			outerRightTurnAnimatorState24690.cycleOffset = 0f;
			outerRightTurnAnimatorState24690.cycleOffsetParameterActive = false;
			outerRightTurnAnimatorState24690.iKOnFeet = true;
			outerRightTurnAnimatorState24690.mirror = false;
			outerRightTurnAnimatorState24690.mirrorParameterActive = false;
			outerRightTurnAnimatorState24690.speed = 1f;
			outerRightTurnAnimatorState24690.speedParameterActive = false;
			outerRightTurnAnimatorState24690.writeDefaultValues = true;

			var outerLeftTurnAnimatorState24692 = freeClimbAnimatorStateMachine24626.AddState("Outer Left Turn", new Vector3(20f, -510f, 0f));
			outerLeftTurnAnimatorState24692.motion = freeClimbOuterLeftTurnAnimationClip30604;
			outerLeftTurnAnimatorState24692.cycleOffset = 0f;
			outerLeftTurnAnimatorState24692.cycleOffsetParameterActive = false;
			outerLeftTurnAnimatorState24692.iKOnFeet = false;
			outerLeftTurnAnimatorState24692.mirror = false;
			outerLeftTurnAnimatorState24692.mirrorParameterActive = false;
			outerLeftTurnAnimatorState24692.speed = 1f;
			outerLeftTurnAnimatorState24692.speedParameterActive = false;
			outerLeftTurnAnimatorState24692.writeDefaultValues = true;

			var innerLeftTurnAnimatorState24694 = freeClimbAnimatorStateMachine24626.AddState("Inner Left Turn", new Vector3(-250f, -510f, 0f));
			innerLeftTurnAnimatorState24694.motion = freeClimbInnerLeftTurnAnimationClip30612;
			innerLeftTurnAnimatorState24694.cycleOffset = 0f;
			innerLeftTurnAnimatorState24694.cycleOffsetParameterActive = false;
			innerLeftTurnAnimatorState24694.iKOnFeet = false;
			innerLeftTurnAnimatorState24694.mirror = false;
			innerLeftTurnAnimatorState24694.mirrorParameterActive = false;
			innerLeftTurnAnimatorState24694.speed = 1f;
			innerLeftTurnAnimatorState24694.speedParameterActive = false;
			innerLeftTurnAnimatorState24694.writeDefaultValues = true;

			var freeClimbJumpLeftAnimatorState24636 = freeClimbAnimatorStateMachine24626.AddState("Free Climb Jump Left", new Vector3(-210f, 0f, 0f));
			var freeClimbJumpLeftAnimatorState24636blendTreeBlendTree24698 = new BlendTree();
			AssetDatabase.AddObjectToAsset(freeClimbJumpLeftAnimatorState24636blendTreeBlendTree24698, animatorController);
			freeClimbJumpLeftAnimatorState24636blendTreeBlendTree24698.hideFlags = HideFlags.HideInHierarchy;
			freeClimbJumpLeftAnimatorState24636blendTreeBlendTree24698.blendParameter = "HorizontalMovement";
			freeClimbJumpLeftAnimatorState24636blendTreeBlendTree24698.blendParameterY = "HorizontalMovement";
			freeClimbJumpLeftAnimatorState24636blendTreeBlendTree24698.blendType = BlendTreeType.Simple1D;
			freeClimbJumpLeftAnimatorState24636blendTreeBlendTree24698.maxThreshold = 1f;
			freeClimbJumpLeftAnimatorState24636blendTreeBlendTree24698.minThreshold = -1f;
			freeClimbJumpLeftAnimatorState24636blendTreeBlendTree24698.name = "Blend Tree";
			freeClimbJumpLeftAnimatorState24636blendTreeBlendTree24698.useAutomaticThresholds = false;
			var freeClimbJumpLeftAnimatorState24636blendTreeBlendTree24698Child0 =  new ChildMotion();
			freeClimbJumpLeftAnimatorState24636blendTreeBlendTree24698Child0.motion = freeClimbLeftDiagonalJumpUpLeftAnimationClip30654;
			freeClimbJumpLeftAnimatorState24636blendTreeBlendTree24698Child0.cycleOffset = 0f;
			freeClimbJumpLeftAnimatorState24636blendTreeBlendTree24698Child0.directBlendParameter = "HorizontalMovement";
			freeClimbJumpLeftAnimatorState24636blendTreeBlendTree24698Child0.mirror = false;
			freeClimbJumpLeftAnimatorState24636blendTreeBlendTree24698Child0.position = new Vector2(0f, 0f);
			freeClimbJumpLeftAnimatorState24636blendTreeBlendTree24698Child0.threshold = -1f;
			freeClimbJumpLeftAnimatorState24636blendTreeBlendTree24698Child0.timeScale = 1f;
			var freeClimbJumpLeftAnimatorState24636blendTreeBlendTree24698Child1 =  new ChildMotion();
			freeClimbJumpLeftAnimatorState24636blendTreeBlendTree24698Child1.motion = freeClimbJumpUpLeftAnimationClip30656;
			freeClimbJumpLeftAnimatorState24636blendTreeBlendTree24698Child1.cycleOffset = 0f;
			freeClimbJumpLeftAnimatorState24636blendTreeBlendTree24698Child1.directBlendParameter = "HorizontalMovement";
			freeClimbJumpLeftAnimatorState24636blendTreeBlendTree24698Child1.mirror = false;
			freeClimbJumpLeftAnimatorState24636blendTreeBlendTree24698Child1.position = new Vector2(0f, 0f);
			freeClimbJumpLeftAnimatorState24636blendTreeBlendTree24698Child1.threshold = 0f;
			freeClimbJumpLeftAnimatorState24636blendTreeBlendTree24698Child1.timeScale = 1f;
			var freeClimbJumpLeftAnimatorState24636blendTreeBlendTree24698Child2 =  new ChildMotion();
			freeClimbJumpLeftAnimatorState24636blendTreeBlendTree24698Child2.motion = freeClimbRightDiagonalJumpUpLeftAnimationClip30658;
			freeClimbJumpLeftAnimatorState24636blendTreeBlendTree24698Child2.cycleOffset = 0f;
			freeClimbJumpLeftAnimatorState24636blendTreeBlendTree24698Child2.directBlendParameter = "HorizontalMovement";
			freeClimbJumpLeftAnimatorState24636blendTreeBlendTree24698Child2.mirror = false;
			freeClimbJumpLeftAnimatorState24636blendTreeBlendTree24698Child2.position = new Vector2(0f, 0f);
			freeClimbJumpLeftAnimatorState24636blendTreeBlendTree24698Child2.threshold = 1f;
			freeClimbJumpLeftAnimatorState24636blendTreeBlendTree24698Child2.timeScale = 1f;
			freeClimbJumpLeftAnimatorState24636blendTreeBlendTree24698.children = new ChildMotion[] {
				freeClimbJumpLeftAnimatorState24636blendTreeBlendTree24698Child0,
				freeClimbJumpLeftAnimatorState24636blendTreeBlendTree24698Child1,
				freeClimbJumpLeftAnimatorState24636blendTreeBlendTree24698Child2
			};
			freeClimbJumpLeftAnimatorState24636.motion = freeClimbJumpLeftAnimatorState24636blendTreeBlendTree24698;
			freeClimbJumpLeftAnimatorState24636.cycleOffset = 0f;
			freeClimbJumpLeftAnimatorState24636.cycleOffsetParameterActive = false;
			freeClimbJumpLeftAnimatorState24636.iKOnFeet = false;
			freeClimbJumpLeftAnimatorState24636.mirror = false;
			freeClimbJumpLeftAnimatorState24636.mirrorParameterActive = false;
			freeClimbJumpLeftAnimatorState24636.speed = 1f;
			freeClimbJumpLeftAnimatorState24636.speedParameterActive = false;
			freeClimbJumpLeftAnimatorState24636.writeDefaultValues = true;

			var freeClimbJumpRightAnimatorState24640 = freeClimbAnimatorStateMachine24626.AddState("Free Climb Jump Right", new Vector3(30f, 0f, 0f));
			var freeClimbJumpRightAnimatorState24640blendTreeBlendTree25610 = new BlendTree();
			AssetDatabase.AddObjectToAsset(freeClimbJumpRightAnimatorState24640blendTreeBlendTree25610, animatorController);
			freeClimbJumpRightAnimatorState24640blendTreeBlendTree25610.hideFlags = HideFlags.HideInHierarchy;
			freeClimbJumpRightAnimatorState24640blendTreeBlendTree25610.blendParameter = "HorizontalMovement";
			freeClimbJumpRightAnimatorState24640blendTreeBlendTree25610.blendParameterY = "HorizontalMovement";
			freeClimbJumpRightAnimatorState24640blendTreeBlendTree25610.blendType = BlendTreeType.Simple1D;
			freeClimbJumpRightAnimatorState24640blendTreeBlendTree25610.maxThreshold = 1f;
			freeClimbJumpRightAnimatorState24640blendTreeBlendTree25610.minThreshold = -1f;
			freeClimbJumpRightAnimatorState24640blendTreeBlendTree25610.name = "Blend Tree";
			freeClimbJumpRightAnimatorState24640blendTreeBlendTree25610.useAutomaticThresholds = false;
			var freeClimbJumpRightAnimatorState24640blendTreeBlendTree25610Child0 =  new ChildMotion();
			freeClimbJumpRightAnimatorState24640blendTreeBlendTree25610Child0.motion = freeClimbLeftDiagonalJumpUpRightAnimationClip30660;
			freeClimbJumpRightAnimatorState24640blendTreeBlendTree25610Child0.cycleOffset = 0f;
			freeClimbJumpRightAnimatorState24640blendTreeBlendTree25610Child0.directBlendParameter = "HorizontalMovement";
			freeClimbJumpRightAnimatorState24640blendTreeBlendTree25610Child0.mirror = false;
			freeClimbJumpRightAnimatorState24640blendTreeBlendTree25610Child0.position = new Vector2(0f, 0f);
			freeClimbJumpRightAnimatorState24640blendTreeBlendTree25610Child0.threshold = -1f;
			freeClimbJumpRightAnimatorState24640blendTreeBlendTree25610Child0.timeScale = 1f;
			var freeClimbJumpRightAnimatorState24640blendTreeBlendTree25610Child1 =  new ChildMotion();
			freeClimbJumpRightAnimatorState24640blendTreeBlendTree25610Child1.motion = freeClimbJumpUpRightAnimationClip30662;
			freeClimbJumpRightAnimatorState24640blendTreeBlendTree25610Child1.cycleOffset = 0f;
			freeClimbJumpRightAnimatorState24640blendTreeBlendTree25610Child1.directBlendParameter = "HorizontalMovement";
			freeClimbJumpRightAnimatorState24640blendTreeBlendTree25610Child1.mirror = false;
			freeClimbJumpRightAnimatorState24640blendTreeBlendTree25610Child1.position = new Vector2(0f, 0f);
			freeClimbJumpRightAnimatorState24640blendTreeBlendTree25610Child1.threshold = 0f;
			freeClimbJumpRightAnimatorState24640blendTreeBlendTree25610Child1.timeScale = 1f;
			var freeClimbJumpRightAnimatorState24640blendTreeBlendTree25610Child2 =  new ChildMotion();
			freeClimbJumpRightAnimatorState24640blendTreeBlendTree25610Child2.motion = freeClimbRightDiagonalJumpUpRightAnimationClip30664;
			freeClimbJumpRightAnimatorState24640blendTreeBlendTree25610Child2.cycleOffset = 0f;
			freeClimbJumpRightAnimatorState24640blendTreeBlendTree25610Child2.directBlendParameter = "HorizontalMovement";
			freeClimbJumpRightAnimatorState24640blendTreeBlendTree25610Child2.mirror = false;
			freeClimbJumpRightAnimatorState24640blendTreeBlendTree25610Child2.position = new Vector2(0f, 0f);
			freeClimbJumpRightAnimatorState24640blendTreeBlendTree25610Child2.threshold = 1f;
			freeClimbJumpRightAnimatorState24640blendTreeBlendTree25610Child2.timeScale = 1f;
			freeClimbJumpRightAnimatorState24640blendTreeBlendTree25610.children = new ChildMotion[] {
				freeClimbJumpRightAnimatorState24640blendTreeBlendTree25610Child0,
				freeClimbJumpRightAnimatorState24640blendTreeBlendTree25610Child1,
				freeClimbJumpRightAnimatorState24640blendTreeBlendTree25610Child2
			};
			freeClimbJumpRightAnimatorState24640.motion = freeClimbJumpRightAnimatorState24640blendTreeBlendTree25610;
			freeClimbJumpRightAnimatorState24640.cycleOffset = 0f;
			freeClimbJumpRightAnimatorState24640.cycleOffsetParameterActive = false;
			freeClimbJumpRightAnimatorState24640.iKOnFeet = false;
			freeClimbJumpRightAnimatorState24640.mirror = false;
			freeClimbJumpRightAnimatorState24640.mirrorParameterActive = false;
			freeClimbJumpRightAnimatorState24640.speed = 1f;
			freeClimbJumpRightAnimatorState24640.speedParameterActive = false;
			freeClimbJumpRightAnimatorState24640.writeDefaultValues = true;

			// State Machine.
			var hangtoFreeClimbAnimatorStateMachine24634 = freeClimbAnimatorStateMachine24626.AddStateMachine("Hang to Free Climb", new Vector3(300f, -10f, 0f));

			// States.
			var hangtoFreeClimbLeftAnimatorState25612 = hangtoFreeClimbAnimatorStateMachine24634.AddState("Hang to Free Climb Left", new Vector3(390f, -20f, 0f));
			hangtoFreeClimbLeftAnimatorState25612.motion = hangtoFreeClimbLeftAnimationClip30618;
			hangtoFreeClimbLeftAnimatorState25612.cycleOffset = 0f;
			hangtoFreeClimbLeftAnimatorState25612.cycleOffsetParameterActive = false;
			hangtoFreeClimbLeftAnimatorState25612.iKOnFeet = false;
			hangtoFreeClimbLeftAnimatorState25612.mirror = false;
			hangtoFreeClimbLeftAnimatorState25612.mirrorParameterActive = false;
			hangtoFreeClimbLeftAnimatorState25612.speed = 1.5f;
			hangtoFreeClimbLeftAnimatorState25612.speedParameterActive = false;
			hangtoFreeClimbLeftAnimatorState25612.writeDefaultValues = true;

			var hangtoFreeClimbRightAnimatorState25614 = hangtoFreeClimbAnimatorStateMachine24634.AddState("Hang to Free Climb Right", new Vector3(390f, 50f, 0f));
			hangtoFreeClimbRightAnimatorState25614.motion = hangtoFreeClimbRightAnimationClip30624;
			hangtoFreeClimbRightAnimatorState25614.cycleOffset = 0f;
			hangtoFreeClimbRightAnimatorState25614.cycleOffsetParameterActive = false;
			hangtoFreeClimbRightAnimatorState25614.iKOnFeet = false;
			hangtoFreeClimbRightAnimatorState25614.mirror = false;
			hangtoFreeClimbRightAnimatorState25614.mirrorParameterActive = false;
			hangtoFreeClimbRightAnimatorState25614.speed = 1.5f;
			hangtoFreeClimbRightAnimatorState25614.speedParameterActive = false;
			hangtoFreeClimbRightAnimatorState25614.writeDefaultValues = true;

			var hangtoFreeClimbVerticalAnimatorState25616 = hangtoFreeClimbAnimatorStateMachine24634.AddState("Hang to Free Climb Vertical", new Vector3(390f, 120f, 0f));
			hangtoFreeClimbVerticalAnimatorState25616.motion = hangtoFreeClimbVerticalAnimationClip30630;
			hangtoFreeClimbVerticalAnimatorState25616.cycleOffset = 0f;
			hangtoFreeClimbVerticalAnimatorState25616.cycleOffsetParameterActive = false;
			hangtoFreeClimbVerticalAnimatorState25616.iKOnFeet = false;
			hangtoFreeClimbVerticalAnimatorState25616.mirror = false;
			hangtoFreeClimbVerticalAnimatorState25616.mirrorParameterActive = false;
			hangtoFreeClimbVerticalAnimatorState25616.speed = 1f;
			hangtoFreeClimbVerticalAnimatorState25616.speedParameterActive = false;
			hangtoFreeClimbVerticalAnimatorState25616.writeDefaultValues = true;

			// State Machine Defaults.
			hangtoFreeClimbAnimatorStateMachine24634.anyStatePosition = new Vector3(50f, 20f, 0f);
			hangtoFreeClimbAnimatorStateMachine24634.defaultState = hangtoFreeClimbLeftAnimatorState25612;
			hangtoFreeClimbAnimatorStateMachine24634.entryPosition = new Vector3(50f, -20f, 0f);
			hangtoFreeClimbAnimatorStateMachine24634.exitPosition = new Vector3(800f, 120f, 0f);
			hangtoFreeClimbAnimatorStateMachine24634.parentStateMachinePosition = new Vector3(800f, 20f, 0f);

			// State Machine Defaults.
			freeClimbAnimatorStateMachine24626.anyStatePosition = new Vector3(-740f, -220f, 0f);
			freeClimbAnimatorStateMachine24626.defaultState = freeClimbBottomMountAnimatorState24680;
			freeClimbAnimatorStateMachine24626.entryPosition = new Vector3(-740f, -280f, 0f);
			freeClimbAnimatorStateMachine24626.exitPosition = new Vector3(610f, -180f, 0f);
			freeClimbAnimatorStateMachine24626.parentStateMachinePosition = new Vector3(580f, -280f, 0f);

			// State Transitions.
			var animatorStateTransition30566 = freeClimbBottomMountAnimatorState24680.AddTransition(freeClimbIdleAnimatorState24642);
			animatorStateTransition30566.canTransitionToSelf = true;
			animatorStateTransition30566.duration = 0.15f;
			animatorStateTransition30566.exitTime = 1f;
			animatorStateTransition30566.hasExitTime = false;
			animatorStateTransition30566.hasFixedDuration = true;
			animatorStateTransition30566.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition30566.offset = 0f;
			animatorStateTransition30566.orderedInterruption = true;
			animatorStateTransition30566.isExit = false;
			animatorStateTransition30566.mute = false;
			animatorStateTransition30566.solo = false;
			animatorStateTransition30566.AddCondition(AnimatorConditionMode.Equals, 503f, "AbilityIndex");
			animatorStateTransition30566.AddCondition(AnimatorConditionMode.Equals, 2f, "AbilityIntData");

			var animatorStateTransition36674 = freeClimbBottomMountAnimatorState24680.AddTransition(freeClimbBottomDismountAnimatorState24684);
			animatorStateTransition36674.canTransitionToSelf = true;
			animatorStateTransition36674.duration = 0f;
			animatorStateTransition36674.exitTime = 1.05f;
			animatorStateTransition36674.hasExitTime = true;
			animatorStateTransition36674.hasFixedDuration = true;
			animatorStateTransition36674.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition36674.offset = 0f;
			animatorStateTransition36674.orderedInterruption = true;
			animatorStateTransition36674.isExit = false;
			animatorStateTransition36674.mute = false;
			animatorStateTransition36674.solo = false;
			animatorStateTransition36674.AddCondition(AnimatorConditionMode.Equals, 503f, "AbilityIndex");
			animatorStateTransition36674.AddCondition(AnimatorConditionMode.Equals, 5f, "AbilityIntData");

			var animatorStateTransition30570 = freeClimbTopMountAnimatorState24682.AddTransition(freeClimbIdleAnimatorState24642);
			animatorStateTransition30570.canTransitionToSelf = true;
			animatorStateTransition30570.duration = 0.15f;
			animatorStateTransition30570.exitTime = 1f;
			animatorStateTransition30570.hasExitTime = false;
			animatorStateTransition30570.hasFixedDuration = true;
			animatorStateTransition30570.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition30570.offset = 0f;
			animatorStateTransition30570.orderedInterruption = true;
			animatorStateTransition30570.isExit = false;
			animatorStateTransition30570.mute = false;
			animatorStateTransition30570.solo = false;
			animatorStateTransition30570.AddCondition(AnimatorConditionMode.Equals, 503f, "AbilityIndex");
			animatorStateTransition30570.AddCondition(AnimatorConditionMode.Equals, 2f, "AbilityIntData");

			var animatorStateTransition47138 = freeClimbTopMountAnimatorState24682.AddTransition(freeClimbTopDismountAnimatorState24686);
			animatorStateTransition47138.canTransitionToSelf = true;
			animatorStateTransition47138.duration = 0f;
			animatorStateTransition47138.exitTime = 1.05f;
			animatorStateTransition47138.hasExitTime = true;
			animatorStateTransition47138.hasFixedDuration = true;
			animatorStateTransition47138.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition47138.offset = 0f;
			animatorStateTransition47138.orderedInterruption = true;
			animatorStateTransition47138.isExit = false;
			animatorStateTransition47138.mute = false;
			animatorStateTransition47138.solo = false;
			animatorStateTransition47138.AddCondition(AnimatorConditionMode.Equals, 503f, "AbilityIndex");
			animatorStateTransition47138.AddCondition(AnimatorConditionMode.Equals, 6f, "AbilityIntData");

			var animatorStateTransition25618 = freeClimbVerticalAnimatorState24638.AddTransition(freeClimbIdleAnimatorState24642);
			animatorStateTransition25618.canTransitionToSelf = true;
			animatorStateTransition25618.duration = 0.1f;
			animatorStateTransition25618.exitTime = 0.35f;
			animatorStateTransition25618.hasExitTime = false;
			animatorStateTransition25618.hasFixedDuration = true;
			animatorStateTransition25618.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition25618.offset = 0f;
			animatorStateTransition25618.orderedInterruption = true;
			animatorStateTransition25618.isExit = false;
			animatorStateTransition25618.mute = false;
			animatorStateTransition25618.solo = false;
			animatorStateTransition25618.AddCondition(AnimatorConditionMode.Equals, 503f, "AbilityIndex");
			animatorStateTransition25618.AddCondition(AnimatorConditionMode.Equals, 2f, "AbilityIntData");
			animatorStateTransition25618.AddCondition(AnimatorConditionMode.Greater, -0.1f, "HorizontalMovement");
			animatorStateTransition25618.AddCondition(AnimatorConditionMode.Less, 0.1f, "HorizontalMovement");
			animatorStateTransition25618.AddCondition(AnimatorConditionMode.Greater, -0.1f, "ForwardMovement");
			animatorStateTransition25618.AddCondition(AnimatorConditionMode.Less, 0.1f, "ForwardMovement");

			var animatorStateTransition25620 = freeClimbVerticalAnimatorState24638.AddTransition(freeClimbIdleAnimatorState24642);
			animatorStateTransition25620.canTransitionToSelf = true;
			animatorStateTransition25620.duration = 0.05f;
			animatorStateTransition25620.exitTime = 0.7f;
			animatorStateTransition25620.hasExitTime = false;
			animatorStateTransition25620.hasFixedDuration = true;
			animatorStateTransition25620.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition25620.offset = 0f;
			animatorStateTransition25620.orderedInterruption = true;
			animatorStateTransition25620.isExit = false;
			animatorStateTransition25620.mute = false;
			animatorStateTransition25620.solo = false;
			animatorStateTransition25620.AddCondition(AnimatorConditionMode.Equals, 503f, "AbilityIndex");
			animatorStateTransition25620.AddCondition(AnimatorConditionMode.Equals, 2f, "AbilityIntData");
			animatorStateTransition25620.AddCondition(AnimatorConditionMode.Less, -0.1f, "HorizontalMovement");
			animatorStateTransition25620.AddCondition(AnimatorConditionMode.Greater, -0.1f, "ForwardMovement");
			animatorStateTransition25620.AddCondition(AnimatorConditionMode.Less, 0.1f, "ForwardMovement");

			var animatorStateTransition25622 = freeClimbVerticalAnimatorState24638.AddTransition(freeClimbIdleAnimatorState24642);
			animatorStateTransition25622.canTransitionToSelf = true;
			animatorStateTransition25622.duration = 0.05f;
			animatorStateTransition25622.exitTime = 0.7f;
			animatorStateTransition25622.hasExitTime = false;
			animatorStateTransition25622.hasFixedDuration = true;
			animatorStateTransition25622.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition25622.offset = 0f;
			animatorStateTransition25622.orderedInterruption = true;
			animatorStateTransition25622.isExit = false;
			animatorStateTransition25622.mute = false;
			animatorStateTransition25622.solo = false;
			animatorStateTransition25622.AddCondition(AnimatorConditionMode.Equals, 503f, "AbilityIndex");
			animatorStateTransition25622.AddCondition(AnimatorConditionMode.Equals, 2f, "AbilityIntData");
			animatorStateTransition25622.AddCondition(AnimatorConditionMode.Greater, 0.1f, "HorizontalMovement");
			animatorStateTransition25622.AddCondition(AnimatorConditionMode.Greater, -0.1f, "ForwardMovement");
			animatorStateTransition25622.AddCondition(AnimatorConditionMode.Less, 0.1f, "ForwardMovement");

			var animatorStateTransition25624 = freeClimbVerticalAnimatorState24638.AddTransition(freeClimbBottomDismountAnimatorState24684);
			animatorStateTransition25624.canTransitionToSelf = true;
			animatorStateTransition25624.duration = 0.05f;
			animatorStateTransition25624.exitTime = 0.7f;
			animatorStateTransition25624.hasExitTime = false;
			animatorStateTransition25624.hasFixedDuration = true;
			animatorStateTransition25624.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition25624.offset = 0f;
			animatorStateTransition25624.orderedInterruption = true;
			animatorStateTransition25624.isExit = false;
			animatorStateTransition25624.mute = false;
			animatorStateTransition25624.solo = false;
			animatorStateTransition25624.AddCondition(AnimatorConditionMode.Equals, 503f, "AbilityIndex");
			animatorStateTransition25624.AddCondition(AnimatorConditionMode.Equals, 5f, "AbilityIntData");

			var animatorStateTransition25626 = freeClimbVerticalAnimatorState24638.AddTransition(freeClimbTopDismountAnimatorState24686);
			animatorStateTransition25626.canTransitionToSelf = true;
			animatorStateTransition25626.duration = 0.05f;
			animatorStateTransition25626.exitTime = 0.7f;
			animatorStateTransition25626.hasExitTime = false;
			animatorStateTransition25626.hasFixedDuration = true;
			animatorStateTransition25626.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition25626.offset = 0f;
			animatorStateTransition25626.orderedInterruption = true;
			animatorStateTransition25626.isExit = false;
			animatorStateTransition25626.mute = false;
			animatorStateTransition25626.solo = false;
			animatorStateTransition25626.AddCondition(AnimatorConditionMode.Equals, 503f, "AbilityIndex");
			animatorStateTransition25626.AddCondition(AnimatorConditionMode.Equals, 6f, "AbilityIntData");

			var animatorStateTransition25628 = freeClimbVerticalAnimatorState24638.AddTransition(freeClimbJumpLeftAnimatorState24636);
			animatorStateTransition25628.canTransitionToSelf = true;
			animatorStateTransition25628.duration = 0f;
			animatorStateTransition25628.exitTime = 1f;
			animatorStateTransition25628.hasExitTime = false;
			animatorStateTransition25628.hasFixedDuration = true;
			animatorStateTransition25628.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition25628.offset = 0f;
			animatorStateTransition25628.orderedInterruption = true;
			animatorStateTransition25628.isExit = false;
			animatorStateTransition25628.mute = false;
			animatorStateTransition25628.solo = false;
			animatorStateTransition25628.AddCondition(AnimatorConditionMode.Equals, 503f, "AbilityIndex");
			animatorStateTransition25628.AddCondition(AnimatorConditionMode.Equals, 2f, "AbilityIntData");
			animatorStateTransition25628.AddCondition(AnimatorConditionMode.Greater, 0f, "ForwardMovement");
			animatorStateTransition25628.AddCondition(AnimatorConditionMode.Greater, 1.5f, "Speed");
			animatorStateTransition25628.AddCondition(AnimatorConditionMode.Greater, 0.5f, "LegIndex");

			var animatorStateTransition25630 = freeClimbVerticalAnimatorState24638.AddTransition(innerLeftTurnAnimatorState24694);
			animatorStateTransition25630.canTransitionToSelf = true;
			animatorStateTransition25630.duration = 0.1f;
			animatorStateTransition25630.exitTime = 0.7f;
			animatorStateTransition25630.hasExitTime = false;
			animatorStateTransition25630.hasFixedDuration = true;
			animatorStateTransition25630.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition25630.offset = 0f;
			animatorStateTransition25630.orderedInterruption = true;
			animatorStateTransition25630.isExit = false;
			animatorStateTransition25630.mute = false;
			animatorStateTransition25630.solo = false;
			animatorStateTransition25630.AddCondition(AnimatorConditionMode.Equals, 503f, "AbilityIndex");
			animatorStateTransition25630.AddCondition(AnimatorConditionMode.Equals, 3f, "AbilityIntData");
			animatorStateTransition25630.AddCondition(AnimatorConditionMode.Less, 0f, "HorizontalMovement");

			var animatorStateTransition25632 = freeClimbVerticalAnimatorState24638.AddTransition(innerRightTurnAnimatorState24688);
			animatorStateTransition25632.canTransitionToSelf = true;
			animatorStateTransition25632.duration = 0.1f;
			animatorStateTransition25632.exitTime = 0.7f;
			animatorStateTransition25632.hasExitTime = false;
			animatorStateTransition25632.hasFixedDuration = true;
			animatorStateTransition25632.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition25632.offset = 0f;
			animatorStateTransition25632.orderedInterruption = true;
			animatorStateTransition25632.isExit = false;
			animatorStateTransition25632.mute = false;
			animatorStateTransition25632.solo = false;
			animatorStateTransition25632.AddCondition(AnimatorConditionMode.Equals, 503f, "AbilityIndex");
			animatorStateTransition25632.AddCondition(AnimatorConditionMode.Equals, 3f, "AbilityIntData");
			animatorStateTransition25632.AddCondition(AnimatorConditionMode.Greater, 0f, "HorizontalMovement");

			var animatorStateTransition25634 = freeClimbVerticalAnimatorState24638.AddTransition(outerRightTurnAnimatorState24690);
			animatorStateTransition25634.canTransitionToSelf = true;
			animatorStateTransition25634.duration = 0.1f;
			animatorStateTransition25634.exitTime = 0.7f;
			animatorStateTransition25634.hasExitTime = false;
			animatorStateTransition25634.hasFixedDuration = true;
			animatorStateTransition25634.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition25634.offset = 0f;
			animatorStateTransition25634.orderedInterruption = true;
			animatorStateTransition25634.isExit = false;
			animatorStateTransition25634.mute = false;
			animatorStateTransition25634.solo = false;
			animatorStateTransition25634.AddCondition(AnimatorConditionMode.Equals, 503f, "AbilityIndex");
			animatorStateTransition25634.AddCondition(AnimatorConditionMode.Equals, 4f, "AbilityIntData");
			animatorStateTransition25634.AddCondition(AnimatorConditionMode.Greater, 0f, "HorizontalMovement");

			var animatorStateTransition25636 = freeClimbVerticalAnimatorState24638.AddTransition(outerLeftTurnAnimatorState24692);
			animatorStateTransition25636.canTransitionToSelf = true;
			animatorStateTransition25636.duration = 0.1f;
			animatorStateTransition25636.exitTime = 0.7f;
			animatorStateTransition25636.hasExitTime = false;
			animatorStateTransition25636.hasFixedDuration = true;
			animatorStateTransition25636.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition25636.offset = 0f;
			animatorStateTransition25636.orderedInterruption = true;
			animatorStateTransition25636.isExit = false;
			animatorStateTransition25636.mute = false;
			animatorStateTransition25636.solo = false;
			animatorStateTransition25636.AddCondition(AnimatorConditionMode.Equals, 503f, "AbilityIndex");
			animatorStateTransition25636.AddCondition(AnimatorConditionMode.Equals, 4f, "AbilityIntData");
			animatorStateTransition25636.AddCondition(AnimatorConditionMode.Less, 0f, "HorizontalMovement");

			var animatorStateTransition25638 = freeClimbVerticalAnimatorState24638.AddExitTransition();
			animatorStateTransition25638.canTransitionToSelf = true;
			animatorStateTransition25638.duration = 0.1f;
			animatorStateTransition25638.exitTime = 0.7f;
			animatorStateTransition25638.hasExitTime = false;
			animatorStateTransition25638.hasFixedDuration = true;
			animatorStateTransition25638.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition25638.offset = 0f;
			animatorStateTransition25638.orderedInterruption = true;
			animatorStateTransition25638.isExit = true;
			animatorStateTransition25638.mute = false;
			animatorStateTransition25638.solo = false;
			animatorStateTransition25638.AddCondition(AnimatorConditionMode.NotEqual, 503f, "AbilityIndex");

			var animatorStateTransition25640 = freeClimbVerticalAnimatorState24638.AddTransition(freeClimbJumpRightAnimatorState24640);
			animatorStateTransition25640.canTransitionToSelf = true;
			animatorStateTransition25640.duration = 0f;
			animatorStateTransition25640.exitTime = 0.608578f;
			animatorStateTransition25640.hasExitTime = false;
			animatorStateTransition25640.hasFixedDuration = true;
			animatorStateTransition25640.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition25640.offset = 0f;
			animatorStateTransition25640.orderedInterruption = true;
			animatorStateTransition25640.isExit = false;
			animatorStateTransition25640.mute = false;
			animatorStateTransition25640.solo = false;
			animatorStateTransition25640.AddCondition(AnimatorConditionMode.Equals, 503f, "AbilityIndex");
			animatorStateTransition25640.AddCondition(AnimatorConditionMode.Equals, 2f, "AbilityIntData");
			animatorStateTransition25640.AddCondition(AnimatorConditionMode.Greater, 0f, "ForwardMovement");
			animatorStateTransition25640.AddCondition(AnimatorConditionMode.Greater, 1.5f, "Speed");
			animatorStateTransition25640.AddCondition(AnimatorConditionMode.Less, 0.5f, "LegIndex");

			var animatorStateTransition25588 = freeClimbIdleAnimatorState24642.AddTransition(freeClimbVerticalAnimatorState24638);
			animatorStateTransition25588.canTransitionToSelf = true;
			animatorStateTransition25588.duration = 0.1f;
			animatorStateTransition25588.exitTime = 0.775f;
			animatorStateTransition25588.hasExitTime = false;
			animatorStateTransition25588.hasFixedDuration = true;
			animatorStateTransition25588.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition25588.offset = 0f;
			animatorStateTransition25588.orderedInterruption = true;
			animatorStateTransition25588.isExit = false;
			animatorStateTransition25588.mute = false;
			animatorStateTransition25588.solo = false;
			animatorStateTransition25588.AddCondition(AnimatorConditionMode.Equals, 503f, "AbilityIndex");
			animatorStateTransition25588.AddCondition(AnimatorConditionMode.Equals, 2f, "AbilityIntData");
			animatorStateTransition25588.AddCondition(AnimatorConditionMode.Less, -0.1f, "ForwardMovement");

			var animatorStateTransition25590 = freeClimbIdleAnimatorState24642.AddTransition(freeClimbVerticalAnimatorState24638);
			animatorStateTransition25590.canTransitionToSelf = true;
			animatorStateTransition25590.duration = 0.1f;
			animatorStateTransition25590.exitTime = 0.775f;
			animatorStateTransition25590.hasExitTime = false;
			animatorStateTransition25590.hasFixedDuration = true;
			animatorStateTransition25590.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition25590.offset = 0f;
			animatorStateTransition25590.orderedInterruption = true;
			animatorStateTransition25590.isExit = false;
			animatorStateTransition25590.mute = false;
			animatorStateTransition25590.solo = false;
			animatorStateTransition25590.AddCondition(AnimatorConditionMode.Equals, 503f, "AbilityIndex");
			animatorStateTransition25590.AddCondition(AnimatorConditionMode.Equals, 2f, "AbilityIntData");
			animatorStateTransition25590.AddCondition(AnimatorConditionMode.Greater, 0.1f, "ForwardMovement");

			var animatorStateTransition25592 = freeClimbIdleAnimatorState24642.AddTransition(freeClimbBottomDismountAnimatorState24684);
			animatorStateTransition25592.canTransitionToSelf = true;
			animatorStateTransition25592.duration = 0.05f;
			animatorStateTransition25592.exitTime = 0.82f;
			animatorStateTransition25592.hasExitTime = false;
			animatorStateTransition25592.hasFixedDuration = true;
			animatorStateTransition25592.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition25592.offset = 0f;
			animatorStateTransition25592.orderedInterruption = true;
			animatorStateTransition25592.isExit = false;
			animatorStateTransition25592.mute = false;
			animatorStateTransition25592.solo = false;
			animatorStateTransition25592.AddCondition(AnimatorConditionMode.Equals, 503f, "AbilityIndex");
			animatorStateTransition25592.AddCondition(AnimatorConditionMode.Equals, 5f, "AbilityIntData");

			var animatorStateTransition25594 = freeClimbIdleAnimatorState24642.AddTransition(freeClimbTopDismountAnimatorState24686);
			animatorStateTransition25594.canTransitionToSelf = true;
			animatorStateTransition25594.duration = 0.15f;
			animatorStateTransition25594.exitTime = 0.82f;
			animatorStateTransition25594.hasExitTime = false;
			animatorStateTransition25594.hasFixedDuration = true;
			animatorStateTransition25594.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition25594.offset = 0f;
			animatorStateTransition25594.orderedInterruption = true;
			animatorStateTransition25594.isExit = false;
			animatorStateTransition25594.mute = false;
			animatorStateTransition25594.solo = false;
			animatorStateTransition25594.AddCondition(AnimatorConditionMode.Equals, 503f, "AbilityIndex");
			animatorStateTransition25594.AddCondition(AnimatorConditionMode.Equals, 6f, "AbilityIntData");

			var animatorStateTransition25596 = freeClimbIdleAnimatorState24642.AddTransition(innerRightTurnAnimatorState24688);
			animatorStateTransition25596.canTransitionToSelf = true;
			animatorStateTransition25596.duration = 0.05f;
			animatorStateTransition25596.exitTime = 0.82f;
			animatorStateTransition25596.hasExitTime = false;
			animatorStateTransition25596.hasFixedDuration = true;
			animatorStateTransition25596.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition25596.offset = 0f;
			animatorStateTransition25596.orderedInterruption = true;
			animatorStateTransition25596.isExit = false;
			animatorStateTransition25596.mute = false;
			animatorStateTransition25596.solo = false;
			animatorStateTransition25596.AddCondition(AnimatorConditionMode.Equals, 503f, "AbilityIndex");
			animatorStateTransition25596.AddCondition(AnimatorConditionMode.Equals, 3f, "AbilityIntData");
			animatorStateTransition25596.AddCondition(AnimatorConditionMode.Greater, 0f, "HorizontalMovement");

			var animatorStateTransition25598 = freeClimbIdleAnimatorState24642.AddTransition(outerRightTurnAnimatorState24690);
			animatorStateTransition25598.canTransitionToSelf = true;
			animatorStateTransition25598.duration = 0.05f;
			animatorStateTransition25598.exitTime = 0.82f;
			animatorStateTransition25598.hasExitTime = false;
			animatorStateTransition25598.hasFixedDuration = true;
			animatorStateTransition25598.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition25598.offset = 0f;
			animatorStateTransition25598.orderedInterruption = true;
			animatorStateTransition25598.isExit = false;
			animatorStateTransition25598.mute = false;
			animatorStateTransition25598.solo = false;
			animatorStateTransition25598.AddCondition(AnimatorConditionMode.Equals, 503f, "AbilityIndex");
			animatorStateTransition25598.AddCondition(AnimatorConditionMode.Equals, 4f, "AbilityIntData");
			animatorStateTransition25598.AddCondition(AnimatorConditionMode.Greater, 0f, "HorizontalMovement");

			var animatorStateTransition25600 = freeClimbIdleAnimatorState24642.AddTransition(innerLeftTurnAnimatorState24694);
			animatorStateTransition25600.canTransitionToSelf = true;
			animatorStateTransition25600.duration = 0.05f;
			animatorStateTransition25600.exitTime = 0.82f;
			animatorStateTransition25600.hasExitTime = false;
			animatorStateTransition25600.hasFixedDuration = true;
			animatorStateTransition25600.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition25600.offset = 0f;
			animatorStateTransition25600.orderedInterruption = true;
			animatorStateTransition25600.isExit = false;
			animatorStateTransition25600.mute = false;
			animatorStateTransition25600.solo = false;
			animatorStateTransition25600.AddCondition(AnimatorConditionMode.Equals, 503f, "AbilityIndex");
			animatorStateTransition25600.AddCondition(AnimatorConditionMode.Equals, 3f, "AbilityIntData");
			animatorStateTransition25600.AddCondition(AnimatorConditionMode.Less, 0f, "HorizontalMovement");

			var animatorStateTransition25602 = freeClimbIdleAnimatorState24642.AddTransition(outerLeftTurnAnimatorState24692);
			animatorStateTransition25602.canTransitionToSelf = true;
			animatorStateTransition25602.duration = 0.05f;
			animatorStateTransition25602.exitTime = 0.82f;
			animatorStateTransition25602.hasExitTime = false;
			animatorStateTransition25602.hasFixedDuration = true;
			animatorStateTransition25602.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition25602.offset = 0f;
			animatorStateTransition25602.orderedInterruption = true;
			animatorStateTransition25602.isExit = false;
			animatorStateTransition25602.mute = false;
			animatorStateTransition25602.solo = false;
			animatorStateTransition25602.AddCondition(AnimatorConditionMode.Equals, 503f, "AbilityIndex");
			animatorStateTransition25602.AddCondition(AnimatorConditionMode.Equals, 4f, "AbilityIntData");
			animatorStateTransition25602.AddCondition(AnimatorConditionMode.Less, 0f, "HorizontalMovement");

			var animatorStateTransition25604 = freeClimbIdleAnimatorState24642.AddExitTransition();
			animatorStateTransition25604.canTransitionToSelf = true;
			animatorStateTransition25604.duration = 0.1f;
			animatorStateTransition25604.exitTime = 0.82f;
			animatorStateTransition25604.hasExitTime = false;
			animatorStateTransition25604.hasFixedDuration = true;
			animatorStateTransition25604.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition25604.offset = 0f;
			animatorStateTransition25604.orderedInterruption = true;
			animatorStateTransition25604.isExit = true;
			animatorStateTransition25604.mute = false;
			animatorStateTransition25604.solo = false;
			animatorStateTransition25604.AddCondition(AnimatorConditionMode.NotEqual, 503f, "AbilityIndex");

			var animatorStateTransition30574 = freeClimbBottomDismountAnimatorState24684.AddExitTransition();
			animatorStateTransition30574.canTransitionToSelf = true;
			animatorStateTransition30574.duration = 0f;
			animatorStateTransition30574.exitTime = 1f;
			animatorStateTransition30574.hasExitTime = true;
			animatorStateTransition30574.hasFixedDuration = true;
			animatorStateTransition30574.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition30574.offset = 0f;
			animatorStateTransition30574.orderedInterruption = true;
			animatorStateTransition30574.isExit = true;
			animatorStateTransition30574.mute = false;
			animatorStateTransition30574.solo = false;

			var animatorStateTransition30578 = freeClimbTopDismountAnimatorState24686.AddExitTransition();
			animatorStateTransition30578.canTransitionToSelf = true;
			animatorStateTransition30578.duration = 0f;
			animatorStateTransition30578.exitTime = 1f;
			animatorStateTransition30578.hasExitTime = true;
			animatorStateTransition30578.hasFixedDuration = true;
			animatorStateTransition30578.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition30578.offset = 0f;
			animatorStateTransition30578.orderedInterruption = true;
			animatorStateTransition30578.isExit = true;
			animatorStateTransition30578.mute = false;
			animatorStateTransition30578.solo = false;

			var animatorStateTransition30582 = innerRightTurnAnimatorState24688.AddTransition(freeClimbIdleAnimatorState24642);
			animatorStateTransition30582.canTransitionToSelf = true;
			animatorStateTransition30582.duration = 0.05f;
			animatorStateTransition30582.exitTime = 1f;
			animatorStateTransition30582.hasExitTime = false;
			animatorStateTransition30582.hasFixedDuration = true;
			animatorStateTransition30582.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition30582.offset = 0f;
			animatorStateTransition30582.orderedInterruption = true;
			animatorStateTransition30582.isExit = false;
			animatorStateTransition30582.mute = false;
			animatorStateTransition30582.solo = false;
			animatorStateTransition30582.AddCondition(AnimatorConditionMode.Equals, 503f, "AbilityIndex");
			animatorStateTransition30582.AddCondition(AnimatorConditionMode.Equals, 2f, "AbilityIntData");

			var animatorStateTransition30584 = innerRightTurnAnimatorState24688.AddTransition(innerLeftTurnAnimatorState24694);
			animatorStateTransition30584.canTransitionToSelf = true;
			animatorStateTransition30584.duration = 0.05f;
			animatorStateTransition30584.exitTime = 1f;
			animatorStateTransition30584.hasExitTime = true;
			animatorStateTransition30584.hasFixedDuration = true;
			animatorStateTransition30584.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition30584.offset = 0f;
			animatorStateTransition30584.orderedInterruption = true;
			animatorStateTransition30584.isExit = false;
			animatorStateTransition30584.mute = false;
			animatorStateTransition30584.solo = false;
			animatorStateTransition30584.AddCondition(AnimatorConditionMode.Equals, 503f, "AbilityIndex");
			animatorStateTransition30584.AddCondition(AnimatorConditionMode.Equals, 3f, "AbilityIntData");
			animatorStateTransition30584.AddCondition(AnimatorConditionMode.Less, 0f, "HorizontalMovement");

			var animatorStateTransition30586 = innerRightTurnAnimatorState24688.AddExitTransition();
			animatorStateTransition30586.canTransitionToSelf = true;
			animatorStateTransition30586.duration = 0.05f;
			animatorStateTransition30586.exitTime = 0.7f;
			animatorStateTransition30586.hasExitTime = false;
			animatorStateTransition30586.hasFixedDuration = true;
			animatorStateTransition30586.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition30586.offset = 0f;
			animatorStateTransition30586.orderedInterruption = true;
			animatorStateTransition30586.isExit = true;
			animatorStateTransition30586.mute = false;
			animatorStateTransition30586.solo = false;
			animatorStateTransition30586.AddCondition(AnimatorConditionMode.NotEqual, 503f, "AbilityIndex");

			var animatorStateTransition30590 = outerRightTurnAnimatorState24690.AddTransition(freeClimbIdleAnimatorState24642);
			animatorStateTransition30590.canTransitionToSelf = true;
			animatorStateTransition30590.duration = 0.15f;
			animatorStateTransition30590.exitTime = 1f;
			animatorStateTransition30590.hasExitTime = false;
			animatorStateTransition30590.hasFixedDuration = true;
			animatorStateTransition30590.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition30590.offset = 0f;
			animatorStateTransition30590.orderedInterruption = true;
			animatorStateTransition30590.isExit = false;
			animatorStateTransition30590.mute = false;
			animatorStateTransition30590.solo = false;
			animatorStateTransition30590.AddCondition(AnimatorConditionMode.Equals, 503f, "AbilityIndex");
			animatorStateTransition30590.AddCondition(AnimatorConditionMode.Equals, 2f, "AbilityIntData");

			var animatorStateTransition30592 = outerRightTurnAnimatorState24690.AddTransition(outerLeftTurnAnimatorState24692);
			animatorStateTransition30592.canTransitionToSelf = true;
			animatorStateTransition30592.duration = 0.05f;
			animatorStateTransition30592.exitTime = 1f;
			animatorStateTransition30592.hasExitTime = true;
			animatorStateTransition30592.hasFixedDuration = true;
			animatorStateTransition30592.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition30592.offset = 0f;
			animatorStateTransition30592.orderedInterruption = true;
			animatorStateTransition30592.isExit = false;
			animatorStateTransition30592.mute = false;
			animatorStateTransition30592.solo = false;
			animatorStateTransition30592.AddCondition(AnimatorConditionMode.Equals, 503f, "AbilityIndex");
			animatorStateTransition30592.AddCondition(AnimatorConditionMode.Equals, 4f, "AbilityIntData");
			animatorStateTransition30592.AddCondition(AnimatorConditionMode.Less, 0f, "HorizontalMovement");

			var animatorStateTransition30594 = outerRightTurnAnimatorState24690.AddExitTransition();
			animatorStateTransition30594.canTransitionToSelf = true;
			animatorStateTransition30594.duration = 0.05f;
			animatorStateTransition30594.exitTime = 0.7f;
			animatorStateTransition30594.hasExitTime = false;
			animatorStateTransition30594.hasFixedDuration = true;
			animatorStateTransition30594.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition30594.offset = 0f;
			animatorStateTransition30594.orderedInterruption = true;
			animatorStateTransition30594.isExit = true;
			animatorStateTransition30594.mute = false;
			animatorStateTransition30594.solo = false;
			animatorStateTransition30594.AddCondition(AnimatorConditionMode.NotEqual, 503f, "AbilityIndex");

			var animatorStateTransition30598 = outerLeftTurnAnimatorState24692.AddTransition(freeClimbIdleAnimatorState24642);
			animatorStateTransition30598.canTransitionToSelf = true;
			animatorStateTransition30598.duration = 0.15f;
			animatorStateTransition30598.exitTime = 1f;
			animatorStateTransition30598.hasExitTime = false;
			animatorStateTransition30598.hasFixedDuration = true;
			animatorStateTransition30598.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition30598.offset = 0f;
			animatorStateTransition30598.orderedInterruption = true;
			animatorStateTransition30598.isExit = false;
			animatorStateTransition30598.mute = false;
			animatorStateTransition30598.solo = false;
			animatorStateTransition30598.AddCondition(AnimatorConditionMode.Equals, 503f, "AbilityIndex");
			animatorStateTransition30598.AddCondition(AnimatorConditionMode.Equals, 2f, "AbilityIntData");

			var animatorStateTransition30600 = outerLeftTurnAnimatorState24692.AddTransition(outerRightTurnAnimatorState24690);
			animatorStateTransition30600.canTransitionToSelf = true;
			animatorStateTransition30600.duration = 0.05f;
			animatorStateTransition30600.exitTime = 1f;
			animatorStateTransition30600.hasExitTime = true;
			animatorStateTransition30600.hasFixedDuration = true;
			animatorStateTransition30600.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition30600.offset = 0f;
			animatorStateTransition30600.orderedInterruption = true;
			animatorStateTransition30600.isExit = false;
			animatorStateTransition30600.mute = false;
			animatorStateTransition30600.solo = false;
			animatorStateTransition30600.AddCondition(AnimatorConditionMode.Equals, 503f, "AbilityIndex");
			animatorStateTransition30600.AddCondition(AnimatorConditionMode.Equals, 4f, "AbilityIntData");
			animatorStateTransition30600.AddCondition(AnimatorConditionMode.Greater, 0f, "HorizontalMovement");

			var animatorStateTransition30602 = outerLeftTurnAnimatorState24692.AddExitTransition();
			animatorStateTransition30602.canTransitionToSelf = true;
			animatorStateTransition30602.duration = 0.05f;
			animatorStateTransition30602.exitTime = 0.7f;
			animatorStateTransition30602.hasExitTime = false;
			animatorStateTransition30602.hasFixedDuration = true;
			animatorStateTransition30602.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition30602.offset = 0f;
			animatorStateTransition30602.orderedInterruption = true;
			animatorStateTransition30602.isExit = true;
			animatorStateTransition30602.mute = false;
			animatorStateTransition30602.solo = false;
			animatorStateTransition30602.AddCondition(AnimatorConditionMode.NotEqual, 503f, "AbilityIndex");

			var animatorStateTransition30606 = innerLeftTurnAnimatorState24694.AddTransition(freeClimbIdleAnimatorState24642);
			animatorStateTransition30606.canTransitionToSelf = true;
			animatorStateTransition30606.duration = 0.05f;
			animatorStateTransition30606.exitTime = 1f;
			animatorStateTransition30606.hasExitTime = false;
			animatorStateTransition30606.hasFixedDuration = true;
			animatorStateTransition30606.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition30606.offset = 0f;
			animatorStateTransition30606.orderedInterruption = true;
			animatorStateTransition30606.isExit = false;
			animatorStateTransition30606.mute = false;
			animatorStateTransition30606.solo = false;
			animatorStateTransition30606.AddCondition(AnimatorConditionMode.Equals, 503f, "AbilityIndex");
			animatorStateTransition30606.AddCondition(AnimatorConditionMode.Equals, 2f, "AbilityIntData");

			var animatorStateTransition30608 = innerLeftTurnAnimatorState24694.AddTransition(innerRightTurnAnimatorState24688);
			animatorStateTransition30608.canTransitionToSelf = true;
			animatorStateTransition30608.duration = 0.05f;
			animatorStateTransition30608.exitTime = 1f;
			animatorStateTransition30608.hasExitTime = true;
			animatorStateTransition30608.hasFixedDuration = true;
			animatorStateTransition30608.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition30608.offset = 0f;
			animatorStateTransition30608.orderedInterruption = true;
			animatorStateTransition30608.isExit = false;
			animatorStateTransition30608.mute = false;
			animatorStateTransition30608.solo = false;
			animatorStateTransition30608.AddCondition(AnimatorConditionMode.Equals, 503f, "AbilityIndex");
			animatorStateTransition30608.AddCondition(AnimatorConditionMode.Equals, 3f, "AbilityIntData");
			animatorStateTransition30608.AddCondition(AnimatorConditionMode.Greater, 0f, "HorizontalMovement");

			var animatorStateTransition30610 = innerLeftTurnAnimatorState24694.AddExitTransition();
			animatorStateTransition30610.canTransitionToSelf = true;
			animatorStateTransition30610.duration = 0.05f;
			animatorStateTransition30610.exitTime = 0.7f;
			animatorStateTransition30610.hasExitTime = false;
			animatorStateTransition30610.hasFixedDuration = true;
			animatorStateTransition30610.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition30610.offset = 0f;
			animatorStateTransition30610.orderedInterruption = true;
			animatorStateTransition30610.isExit = true;
			animatorStateTransition30610.mute = false;
			animatorStateTransition30610.solo = false;
			animatorStateTransition30610.AddCondition(AnimatorConditionMode.NotEqual, 503f, "AbilityIndex");

			var animatorStateTransition24696 = freeClimbJumpLeftAnimatorState24636.AddTransition(freeClimbVerticalAnimatorState24638);
			animatorStateTransition24696.canTransitionToSelf = true;
			animatorStateTransition24696.duration = 0.05f;
			animatorStateTransition24696.exitTime = 1f;
			animatorStateTransition24696.hasExitTime = true;
			animatorStateTransition24696.hasFixedDuration = true;
			animatorStateTransition24696.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition24696.offset = 0.5f;
			animatorStateTransition24696.orderedInterruption = true;
			animatorStateTransition24696.isExit = false;
			animatorStateTransition24696.mute = false;
			animatorStateTransition24696.solo = false;

			var animatorStateTransition25608 = freeClimbJumpRightAnimatorState24640.AddTransition(freeClimbVerticalAnimatorState24638);
			animatorStateTransition25608.canTransitionToSelf = true;
			animatorStateTransition25608.duration = 0.05f;
			animatorStateTransition25608.exitTime = 1f;
			animatorStateTransition25608.hasExitTime = true;
			animatorStateTransition25608.hasFixedDuration = true;
			animatorStateTransition25608.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition25608.offset = 0f;
			animatorStateTransition25608.orderedInterruption = true;
			animatorStateTransition25608.isExit = false;
			animatorStateTransition25608.mute = false;
			animatorStateTransition25608.solo = false;

			// State Transitions.
			var animatorStateTransition30614 = hangtoFreeClimbLeftAnimatorState25612.AddExitTransition();
			animatorStateTransition30614.canTransitionToSelf = true;
			animatorStateTransition30614.duration = 0.05f;
			animatorStateTransition30614.exitTime = 1f;
			animatorStateTransition30614.hasExitTime = false;
			animatorStateTransition30614.hasFixedDuration = true;
			animatorStateTransition30614.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition30614.offset = 0f;
			animatorStateTransition30614.orderedInterruption = true;
			animatorStateTransition30614.isExit = true;
			animatorStateTransition30614.mute = false;
			animatorStateTransition30614.solo = false;
			animatorStateTransition30614.AddCondition(AnimatorConditionMode.NotEqual, 503f, "AbilityIndex");

			var animatorStateTransition30616 = hangtoFreeClimbLeftAnimatorState25612.AddTransition(freeClimbIdleAnimatorState24642);
			animatorStateTransition30616.canTransitionToSelf = true;
			animatorStateTransition30616.duration = 0.05f;
			animatorStateTransition30616.exitTime = 1f;
			animatorStateTransition30616.hasExitTime = true;
			animatorStateTransition30616.hasFixedDuration = true;
			animatorStateTransition30616.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition30616.offset = 0f;
			animatorStateTransition30616.orderedInterruption = true;
			animatorStateTransition30616.isExit = false;
			animatorStateTransition30616.mute = false;
			animatorStateTransition30616.solo = false;
			animatorStateTransition30616.AddCondition(AnimatorConditionMode.Equals, 503f, "AbilityIndex");

			var animatorStateTransition30620 = hangtoFreeClimbRightAnimatorState25614.AddExitTransition();
			animatorStateTransition30620.canTransitionToSelf = true;
			animatorStateTransition30620.duration = 0.05f;
			animatorStateTransition30620.exitTime = 1f;
			animatorStateTransition30620.hasExitTime = false;
			animatorStateTransition30620.hasFixedDuration = true;
			animatorStateTransition30620.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition30620.offset = 0f;
			animatorStateTransition30620.orderedInterruption = true;
			animatorStateTransition30620.isExit = true;
			animatorStateTransition30620.mute = false;
			animatorStateTransition30620.solo = false;
			animatorStateTransition30620.AddCondition(AnimatorConditionMode.NotEqual, 503f, "AbilityIndex");

			var animatorStateTransition30622 = hangtoFreeClimbRightAnimatorState25614.AddTransition(freeClimbIdleAnimatorState24642);
			animatorStateTransition30622.canTransitionToSelf = true;
			animatorStateTransition30622.duration = 0.05f;
			animatorStateTransition30622.exitTime = 1f;
			animatorStateTransition30622.hasExitTime = true;
			animatorStateTransition30622.hasFixedDuration = true;
			animatorStateTransition30622.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition30622.offset = 0f;
			animatorStateTransition30622.orderedInterruption = true;
			animatorStateTransition30622.isExit = false;
			animatorStateTransition30622.mute = false;
			animatorStateTransition30622.solo = false;
			animatorStateTransition30622.AddCondition(AnimatorConditionMode.Equals, 503f, "AbilityIndex");

			var animatorStateTransition30626 = hangtoFreeClimbVerticalAnimatorState25616.AddTransition(freeClimbIdleAnimatorState24642);
			animatorStateTransition30626.canTransitionToSelf = true;
			animatorStateTransition30626.duration = 0.05f;
			animatorStateTransition30626.exitTime = 1f;
			animatorStateTransition30626.hasExitTime = true;
			animatorStateTransition30626.hasFixedDuration = true;
			animatorStateTransition30626.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition30626.offset = 0f;
			animatorStateTransition30626.orderedInterruption = true;
			animatorStateTransition30626.isExit = false;
			animatorStateTransition30626.mute = false;
			animatorStateTransition30626.solo = false;
			animatorStateTransition30626.AddCondition(AnimatorConditionMode.Equals, 503f, "AbilityIndex");

			var animatorStateTransition30628 = hangtoFreeClimbVerticalAnimatorState25616.AddExitTransition();
			animatorStateTransition30628.canTransitionToSelf = true;
			animatorStateTransition30628.duration = 0.05f;
			animatorStateTransition30628.exitTime = 1f;
			animatorStateTransition30628.hasExitTime = false;
			animatorStateTransition30628.hasFixedDuration = true;
			animatorStateTransition30628.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition30628.offset = 0f;
			animatorStateTransition30628.orderedInterruption = true;
			animatorStateTransition30628.isExit = true;
			animatorStateTransition30628.mute = false;
			animatorStateTransition30628.solo = false;
			animatorStateTransition30628.AddCondition(AnimatorConditionMode.NotEqual, 503f, "AbilityIndex");


			// State Machine Transitions.
			var animatorStateTransition24954 = baseStateMachine2110969806.AddAnyStateTransition(freeClimbBottomMountAnimatorState24680);
			animatorStateTransition24954.canTransitionToSelf = true;
			animatorStateTransition24954.duration = 0.15f;
			animatorStateTransition24954.exitTime = 0.75f;
			animatorStateTransition24954.hasExitTime = false;
			animatorStateTransition24954.hasFixedDuration = true;
			animatorStateTransition24954.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition24954.offset = 0f;
			animatorStateTransition24954.orderedInterruption = true;
			animatorStateTransition24954.isExit = false;
			animatorStateTransition24954.mute = false;
			animatorStateTransition24954.solo = false;
			animatorStateTransition24954.AddCondition(AnimatorConditionMode.If, 0f, "AbilityChange");
			animatorStateTransition24954.AddCondition(AnimatorConditionMode.Equals, 503f, "AbilityIndex");
			animatorStateTransition24954.AddCondition(AnimatorConditionMode.Equals, 0f, "AbilityIntData");

			var animatorStateTransition24956 = baseStateMachine2110969806.AddAnyStateTransition(freeClimbTopMountAnimatorState24682);
			animatorStateTransition24956.canTransitionToSelf = true;
			animatorStateTransition24956.duration = 0.15f;
			animatorStateTransition24956.exitTime = 0.75f;
			animatorStateTransition24956.hasExitTime = false;
			animatorStateTransition24956.hasFixedDuration = true;
			animatorStateTransition24956.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition24956.offset = 0f;
			animatorStateTransition24956.orderedInterruption = true;
			animatorStateTransition24956.isExit = false;
			animatorStateTransition24956.mute = false;
			animatorStateTransition24956.solo = false;
			animatorStateTransition24956.AddCondition(AnimatorConditionMode.If, 0f, "AbilityChange");
			animatorStateTransition24956.AddCondition(AnimatorConditionMode.Equals, 503f, "AbilityIndex");
			animatorStateTransition24956.AddCondition(AnimatorConditionMode.Equals, 1f, "AbilityIntData");

			var animatorStateTransition24958 = baseStateMachine2110969806.AddAnyStateTransition(freeClimbIdleAnimatorState24642);
			animatorStateTransition24958.canTransitionToSelf = true;
			animatorStateTransition24958.duration = 0.15f;
			animatorStateTransition24958.exitTime = 0.75f;
			animatorStateTransition24958.hasExitTime = false;
			animatorStateTransition24958.hasFixedDuration = true;
			animatorStateTransition24958.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition24958.offset = 0f;
			animatorStateTransition24958.orderedInterruption = true;
			animatorStateTransition24958.isExit = false;
			animatorStateTransition24958.mute = false;
			animatorStateTransition24958.solo = false;
			animatorStateTransition24958.AddCondition(AnimatorConditionMode.If, 0f, "AbilityChange");
			animatorStateTransition24958.AddCondition(AnimatorConditionMode.Equals, 503f, "AbilityIndex");
			animatorStateTransition24958.AddCondition(AnimatorConditionMode.Equals, 2f, "AbilityIntData");

			var animatorStateTransition24972 = baseStateMachine2110969806.AddAnyStateTransition(hangtoFreeClimbLeftAnimatorState25612);
			animatorStateTransition24972.canTransitionToSelf = false;
			animatorStateTransition24972.duration = 0.05f;
			animatorStateTransition24972.exitTime = 0.75f;
			animatorStateTransition24972.hasExitTime = false;
			animatorStateTransition24972.hasFixedDuration = true;
			animatorStateTransition24972.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition24972.offset = 0f;
			animatorStateTransition24972.orderedInterruption = true;
			animatorStateTransition24972.isExit = false;
			animatorStateTransition24972.mute = false;
			animatorStateTransition24972.solo = false;
			animatorStateTransition24972.AddCondition(AnimatorConditionMode.If, 0f, "AbilityChange");
			animatorStateTransition24972.AddCondition(AnimatorConditionMode.Equals, 503f, "AbilityIndex");
			animatorStateTransition24972.AddCondition(AnimatorConditionMode.Equals, 7f, "AbilityIntData");
			animatorStateTransition24972.AddCondition(AnimatorConditionMode.Less, 0f, "HorizontalMovement");

			var animatorStateTransition24974 = baseStateMachine2110969806.AddAnyStateTransition(hangtoFreeClimbRightAnimatorState25614);
			animatorStateTransition24974.canTransitionToSelf = false;
			animatorStateTransition24974.duration = 0.05f;
			animatorStateTransition24974.exitTime = 0.75f;
			animatorStateTransition24974.hasExitTime = false;
			animatorStateTransition24974.hasFixedDuration = true;
			animatorStateTransition24974.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition24974.offset = 0f;
			animatorStateTransition24974.orderedInterruption = true;
			animatorStateTransition24974.isExit = false;
			animatorStateTransition24974.mute = false;
			animatorStateTransition24974.solo = false;
			animatorStateTransition24974.AddCondition(AnimatorConditionMode.If, 0f, "AbilityChange");
			animatorStateTransition24974.AddCondition(AnimatorConditionMode.Equals, 503f, "AbilityIndex");
			animatorStateTransition24974.AddCondition(AnimatorConditionMode.Equals, 7f, "AbilityIntData");
			animatorStateTransition24974.AddCondition(AnimatorConditionMode.Greater, 0f, "HorizontalMovement");

			var animatorStateTransition24980 = baseStateMachine2110969806.AddAnyStateTransition(hangtoFreeClimbVerticalAnimatorState25616);
			animatorStateTransition24980.canTransitionToSelf = false;
			animatorStateTransition24980.duration = 0.05f;
			animatorStateTransition24980.exitTime = 0.75f;
			animatorStateTransition24980.hasExitTime = false;
			animatorStateTransition24980.hasFixedDuration = true;
			animatorStateTransition24980.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition24980.offset = 0f;
			animatorStateTransition24980.orderedInterruption = true;
			animatorStateTransition24980.isExit = false;
			animatorStateTransition24980.mute = false;
			animatorStateTransition24980.solo = false;
			animatorStateTransition24980.AddCondition(AnimatorConditionMode.If, 0f, "AbilityChange");
			animatorStateTransition24980.AddCondition(AnimatorConditionMode.Equals, 503f, "AbilityIndex");
			animatorStateTransition24980.AddCondition(AnimatorConditionMode.Equals, 8f, "AbilityIntData");
		}
	}
}
