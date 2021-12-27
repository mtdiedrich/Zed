/// ---------------------------------------------
/// Ultimate Character Controller
/// Copyright (c) Opsive. All Rights Reserved.
/// https://www.opsive.com
/// ---------------------------------------------

namespace Opsive.UltimateCharacterController.Editor.Inspectors.Character.Abilities
{
	using Opsive.Shared.Editor.Inspectors;
	using Opsive.UltimateCharacterController.AddOns.Swimming;
	using Opsive.UltimateCharacterController.Editor.Inspectors.Utility;
	using Opsive.UltimateCharacterController.Editor.Utility;
	using Opsive.UltimateCharacterController.Traits;
	using UnityEditor;
	using UnityEditor.Animations;
	using UnityEngine;

	/// <summary>
	/// Draws a custom inspector for the Swim Ability.
	/// </summary>
	[InspectorDrawer(typeof(Swim))]
	public class SwimInspectorDrawer : DetectObjectAbilityBaseInspectorDrawer
    {
        /// <summary>
        /// Draws the fields related to the inspector drawer.
        /// </summary>
        /// <param name="target">The object that is being drawn.</param>
        /// <param name="parent">The Unity Object that the object belongs to.</param>
        protected override void DrawInspectorDrawerFields(object target, Object parent)
        {
            base.DrawInspectorDrawerFields(target, parent);

            InspectorUtility.DrawAttributeModifier((parent as Component).GetComponent<AttributeManager>(), (target as Swim).BreathModifier, "Breath Attribute");
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
			if (animatorController.layers.Length <= 0) {
				Debug.LogWarning("Warning: The animator controller does not contain the same number of layers as the demo animator. All of the animations cannot be added.");
				return;
			}

			var baseStateMachine1709684174 = animatorController.layers[0].stateMachine;

			// The state machine should start fresh.
			for (int i = 0; i < animatorController.layers.Length; ++i) {
				for (int j = 0; j < baseStateMachine1709684174.stateMachines.Length; ++j) {
					if (baseStateMachine1709684174.stateMachines[j].stateMachine.name == "Swim") {
						baseStateMachine1709684174.RemoveStateMachine(baseStateMachine1709684174.stateMachines[j].stateMachine);
						break;
					}
				}
			}

			// AnimationClip references.
			var fallInWaterAnimationClip65032Path = AssetDatabase.GUIDToAssetPath("5417f5795beed3748a4a339e448541f9"); 
			var fallInWaterAnimationClip65032 = AnimatorBuilder.GetAnimationClip(fallInWaterAnimationClip65032Path, "FallInWater");
			var surfaceSwimIdleAnimationClip65074Path = AssetDatabase.GUIDToAssetPath("49a950985203bcd47b45a342dd66617e"); 
			var surfaceSwimIdleAnimationClip65074 = AnimatorBuilder.GetAnimationClip(surfaceSwimIdleAnimationClip65074Path, "SurfaceSwimIdle");
			var surfacePowerSwimBwdAnimationClip65038Path = AssetDatabase.GUIDToAssetPath("656232ee21ea0ff41abf60f04e64858c"); 
			var surfacePowerSwimBwdAnimationClip65038 = AnimatorBuilder.GetAnimationClip(surfacePowerSwimBwdAnimationClip65038Path, "SurfacePowerSwimBwd");
			var surfaceSwimBwdAnimationClip65056Path = AssetDatabase.GUIDToAssetPath("1c6fd722260a32f49b477f2ec339ab20"); 
			var surfaceSwimBwdAnimationClip65056 = AnimatorBuilder.GetAnimationClip(surfaceSwimBwdAnimationClip65056Path, "SurfaceSwimBwd");
			var surfacePowerSwimStrafeAnimationClip65050Path = AssetDatabase.GUIDToAssetPath("bb557eb0c7ebd964b9909d247bf877d3"); 
			var surfacePowerSwimStrafeAnimationClip65050 = AnimatorBuilder.GetAnimationClip(surfacePowerSwimStrafeAnimationClip65050Path, "SurfacePowerSwimStrafe");
			var surfaceSwimStrafeAnimationClip65080Path = AssetDatabase.GUIDToAssetPath("8469ba753dfb3ce4fabe0bab48e638d0"); 
			var surfaceSwimStrafeAnimationClip65080 = AnimatorBuilder.GetAnimationClip(surfaceSwimStrafeAnimationClip65080Path, "SurfaceSwimStrafe");
			var surfaceSwimFwdAnimationClip65062Path = AssetDatabase.GUIDToAssetPath("34888dbddbf44204cb7ce3d920c28fc6"); 
			var surfaceSwimFwdAnimationClip65062 = AnimatorBuilder.GetAnimationClip(surfaceSwimFwdAnimationClip65062Path, "SurfaceSwimFwd");
			var surfacePowerSwimFwdAnimationClip65044Path = AssetDatabase.GUIDToAssetPath("60ee98433976c904fa0f81f9698a3f57"); 
			var surfacePowerSwimFwdAnimationClip65044 = AnimatorBuilder.GetAnimationClip(surfacePowerSwimFwdAnimationClip65044Path, "SurfacePowerSwimFwd");
			var underwaterSwimBwdAnimationClip65172Path = AssetDatabase.GUIDToAssetPath("18ed38574f4ad754c911778975d2963b"); 
			var underwaterSwimBwdAnimationClip65172 = AnimatorBuilder.GetAnimationClip(underwaterSwimBwdAnimationClip65172Path, "UnderwaterSwimBwd");
			var underwaterKickStrafeAnimationClip65124Path = AssetDatabase.GUIDToAssetPath("44eb2f91ce4dd134ca5df47dad8e2128"); 
			var underwaterKickStrafeAnimationClip65124 = AnimatorBuilder.GetAnimationClip(underwaterKickStrafeAnimationClip65124Path, "UnderwaterKickStrafe");
			var underwaterStrokeStrafeAnimationClip65160Path = AssetDatabase.GUIDToAssetPath("1b3960f74d07e0342b8a63b4bb757ca4"); 
			var underwaterStrokeStrafeAnimationClip65160 = AnimatorBuilder.GetAnimationClip(underwaterStrokeStrafeAnimationClip65160Path, "UnderwaterStrokeStrafe");
			var underwaterIdleUpAnimationClip65190Path = AssetDatabase.GUIDToAssetPath("04bb0ea0103e9534d99025bd9c28c33e"); 
			var underwaterIdleUpAnimationClip65190 = AnimatorBuilder.GetAnimationClip(underwaterIdleUpAnimationClip65190Path, "UnderwaterIdleUp");
			var underwaterIdleFwdAnimationClip65184Path = AssetDatabase.GUIDToAssetPath("99c8c8d422f251a48b0dcdae23379ed3"); 
			var underwaterIdleFwdAnimationClip65184 = AnimatorBuilder.GetAnimationClip(underwaterIdleFwdAnimationClip65184Path, "UnderwaterIdleFwd");
			var underwaterIdleDownAnimationClip65178Path = AssetDatabase.GUIDToAssetPath("a55727babd23dbf4c8e77812456885df"); 
			var underwaterIdleDownAnimationClip65178 = AnimatorBuilder.GetAnimationClip(underwaterIdleDownAnimationClip65178Path, "UnderwaterIdleDown");
			var underwaterStrokeUpAnimationClip65166Path = AssetDatabase.GUIDToAssetPath("d8bd72cf843e70642bf0ea85025013ba"); 
			var underwaterStrokeUpAnimationClip65166 = AnimatorBuilder.GetAnimationClip(underwaterStrokeUpAnimationClip65166Path, "UnderwaterStrokeUp");
			var underwaterStrokeFwdAnimationClip65154Path = AssetDatabase.GUIDToAssetPath("eaa27658d6a72d14ca7f62229295b62d"); 
			var underwaterStrokeFwdAnimationClip65154 = AnimatorBuilder.GetAnimationClip(underwaterStrokeFwdAnimationClip65154Path, "UnderwaterStrokeFwd");
			var underwaterStrokeDownAnimationClip65148Path = AssetDatabase.GUIDToAssetPath("52fcf2bd8220b464d8498e0642c27250"); 
			var underwaterStrokeDownAnimationClip65148 = AnimatorBuilder.GetAnimationClip(underwaterStrokeDownAnimationClip65148Path, "UnderwaterStrokeDown");
			var underwaterKickUpAnimationClip65136Path = AssetDatabase.GUIDToAssetPath("426dee5db36de4944860bae40dc080a5"); 
			var underwaterKickUpAnimationClip65136 = AnimatorBuilder.GetAnimationClip(underwaterKickUpAnimationClip65136Path, "UnderwaterKickUp");
			var underwaterKickFwdAnimationClip65112Path = AssetDatabase.GUIDToAssetPath("274cdf2dc4e78834c813439bb16217ee"); 
			var underwaterKickFwdAnimationClip65112 = AnimatorBuilder.GetAnimationClip(underwaterKickFwdAnimationClip65112Path, "UnderwaterKickFwd");
			var underwaterKickDownAnimationClip65100Path = AssetDatabase.GUIDToAssetPath("0c15d136a6ed78940adfecd9eb19afb4"); 
			var underwaterKickDownAnimationClip65100 = AnimatorBuilder.GetAnimationClip(underwaterKickDownAnimationClip65100Path, "UnderwaterKickDown");
			var diveFromSurfaceAnimationClip65026Path = AssetDatabase.GUIDToAssetPath("c49a2659f0fec5d4898d185c3fc51a99"); 
			var diveFromSurfaceAnimationClip65026 = AnimatorBuilder.GetAnimationClip(diveFromSurfaceAnimationClip65026Path, "DiveFromSurface");
			var swimExitWaterAnimationClip65092Path = AssetDatabase.GUIDToAssetPath("4805feacf83e71f4d85fb6721373364b"); 
			var swimExitWaterAnimationClip65092 = AnimatorBuilder.GetAnimationClip(swimExitWaterAnimationClip65092Path, "SwimExitWater");
			var surfaceSwimToIdleAnimationClip65086Path = AssetDatabase.GUIDToAssetPath("59e074ba83e4ebf49bb6bbafee759137"); 
			var surfaceSwimToIdleAnimationClip65086 = AnimatorBuilder.GetAnimationClip(surfaceSwimToIdleAnimationClip65086Path, "SurfaceSwimToIdle");
			var underwaterKickStrafeItemAnimationClip65130Path = AssetDatabase.GUIDToAssetPath("5f368fc40f45b2345804854b74fd0cd4"); 
			var underwaterKickStrafeItemAnimationClip65130 = AnimatorBuilder.GetAnimationClip(underwaterKickStrafeItemAnimationClip65130Path, "UnderwaterKickStrafeItem");
			var underwaterKickUpItemAnimationClip65142Path = AssetDatabase.GUIDToAssetPath("69e64cc4f5df8f84c9582fbd387e3e2e"); 
			var underwaterKickUpItemAnimationClip65142 = AnimatorBuilder.GetAnimationClip(underwaterKickUpItemAnimationClip65142Path, "UnderwaterKickUpItem");
			var underwaterKickFwdItemAnimationClip65118Path = AssetDatabase.GUIDToAssetPath("a71cf04290562e84ebdca18bbd6e5a48"); 
			var underwaterKickFwdItemAnimationClip65118 = AnimatorBuilder.GetAnimationClip(underwaterKickFwdItemAnimationClip65118Path, "UnderwaterKickFwdItem");
			var underwaterKickDownItemAnimationClip65106Path = AssetDatabase.GUIDToAssetPath("57055f367494de04b89898a2d6ab299f"); 
			var underwaterKickDownItemAnimationClip65106 = AnimatorBuilder.GetAnimationClip(underwaterKickDownItemAnimationClip65106Path, "UnderwaterKickDownItem");
			var surfaceSwimFwdItemAnimationClip65068Path = AssetDatabase.GUIDToAssetPath("ae8a2c1cd552082458a39cdd3e9eaf31"); 
			var surfaceSwimFwdItemAnimationClip65068 = AnimatorBuilder.GetAnimationClip(surfaceSwimFwdItemAnimationClip65068Path, "SurfaceSwimFwdItem");

			// State Machine.
			var swimAnimatorStateMachine76046 = baseStateMachine1709684174.AddStateMachine("Swim", new Vector3(624f, 108f, 0f));

			// States.
			var fallInWaterAnimatorState76870 = swimAnimatorStateMachine76046.AddState("Fall In Water", new Vector3(144f, 48f, 0f));
			fallInWaterAnimatorState76870.motion = fallInWaterAnimationClip65032;
			fallInWaterAnimatorState76870.cycleOffset = 0f;
			fallInWaterAnimatorState76870.cycleOffsetParameterActive = false;
			fallInWaterAnimatorState76870.iKOnFeet = false;
			fallInWaterAnimatorState76870.mirror = false;
			fallInWaterAnimatorState76870.mirrorParameterActive = false;
			fallInWaterAnimatorState76870.speed = 1.5f;
			fallInWaterAnimatorState76870.speedParameterActive = false;
			fallInWaterAnimatorState76870.writeDefaultValues = true;

			var surfaceIdleAnimatorState76872 = swimAnimatorStateMachine76046.AddState("Surface Idle", new Vector3(384f, -336f, 0f));
			surfaceIdleAnimatorState76872.motion = surfaceSwimIdleAnimationClip65074;
			surfaceIdleAnimatorState76872.cycleOffset = 0f;
			surfaceIdleAnimatorState76872.cycleOffsetParameterActive = false;
			surfaceIdleAnimatorState76872.iKOnFeet = false;
			surfaceIdleAnimatorState76872.mirror = false;
			surfaceIdleAnimatorState76872.mirrorParameterActive = false;
			surfaceIdleAnimatorState76872.speed = 1f;
			surfaceIdleAnimatorState76872.speedParameterActive = false;
			surfaceIdleAnimatorState76872.writeDefaultValues = true;

			var surfaceSwimAnimatorState76880 = swimAnimatorStateMachine76046.AddState("Surface Swim", new Vector3(264f, -204f, 0f));
			var surfaceSwimAnimatorState76880blendTreeBlendTree78078 = new BlendTree();
			AssetDatabase.AddObjectToAsset(surfaceSwimAnimatorState76880blendTreeBlendTree78078, animatorController);
			surfaceSwimAnimatorState76880blendTreeBlendTree78078.hideFlags = HideFlags.HideInHierarchy;
			surfaceSwimAnimatorState76880blendTreeBlendTree78078.blendParameter = "HorizontalMovement";
			surfaceSwimAnimatorState76880blendTreeBlendTree78078.blendParameterY = "ForwardMovement";
			surfaceSwimAnimatorState76880blendTreeBlendTree78078.blendType = BlendTreeType.FreeformCartesian2D;
			surfaceSwimAnimatorState76880blendTreeBlendTree78078.maxThreshold = 8f;
			surfaceSwimAnimatorState76880blendTreeBlendTree78078.minThreshold = 0f;
			surfaceSwimAnimatorState76880blendTreeBlendTree78078.name = "Blend Tree";
			surfaceSwimAnimatorState76880blendTreeBlendTree78078.useAutomaticThresholds = false;
			var surfaceSwimAnimatorState76880blendTreeBlendTree78078Child0 =  new ChildMotion();
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child0.motion = surfacePowerSwimBwdAnimationClip65038;
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child0.cycleOffset = 0f;
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child0.directBlendParameter = "HorizontalMovement";
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child0.mirror = false;
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child0.position = new Vector2(0f, -2f);
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child0.threshold = 0f;
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child0.timeScale = 1.25f;
			var surfaceSwimAnimatorState76880blendTreeBlendTree78078Child1 =  new ChildMotion();
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child1.motion = surfaceSwimBwdAnimationClip65056;
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child1.cycleOffset = 0f;
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child1.directBlendParameter = "HorizontalMovement";
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child1.mirror = false;
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child1.position = new Vector2(0f, -1f);
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child1.threshold = 1f;
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child1.timeScale = 1f;
			var surfaceSwimAnimatorState76880blendTreeBlendTree78078Child2 =  new ChildMotion();
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child2.motion = surfacePowerSwimStrafeAnimationClip65050;
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child2.cycleOffset = 0f;
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child2.directBlendParameter = "HorizontalMovement";
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child2.mirror = false;
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child2.position = new Vector2(-2f, 0f);
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child2.threshold = 2f;
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child2.timeScale = 1.25f;
			var surfaceSwimAnimatorState76880blendTreeBlendTree78078Child3 =  new ChildMotion();
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child3.motion = surfaceSwimStrafeAnimationClip65080;
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child3.cycleOffset = 0f;
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child3.directBlendParameter = "HorizontalMovement";
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child3.mirror = false;
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child3.position = new Vector2(-1f, 0f);
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child3.threshold = 3f;
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child3.timeScale = 1f;
			var surfaceSwimAnimatorState76880blendTreeBlendTree78078Child4 =  new ChildMotion();
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child4.motion = surfaceSwimIdleAnimationClip65074;
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child4.cycleOffset = 0f;
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child4.directBlendParameter = "HorizontalMovement";
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child4.mirror = false;
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child4.position = new Vector2(0f, 0f);
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child4.threshold = 4f;
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child4.timeScale = 1f;
			var surfaceSwimAnimatorState76880blendTreeBlendTree78078Child5 =  new ChildMotion();
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child5.motion = surfaceSwimStrafeAnimationClip65080;
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child5.cycleOffset = 0.5f;
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child5.directBlendParameter = "HorizontalMovement";
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child5.mirror = true;
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child5.position = new Vector2(1f, 0f);
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child5.threshold = 5f;
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child5.timeScale = 1f;
			var surfaceSwimAnimatorState76880blendTreeBlendTree78078Child6 =  new ChildMotion();
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child6.motion = surfacePowerSwimStrafeAnimationClip65050;
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child6.cycleOffset = 0.5f;
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child6.directBlendParameter = "HorizontalMovement";
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child6.mirror = true;
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child6.position = new Vector2(2f, 0f);
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child6.threshold = 6f;
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child6.timeScale = 1.25f;
			var surfaceSwimAnimatorState76880blendTreeBlendTree78078Child7 =  new ChildMotion();
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child7.motion = surfaceSwimFwdAnimationClip65062;
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child7.cycleOffset = 0f;
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child7.directBlendParameter = "HorizontalMovement";
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child7.mirror = false;
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child7.position = new Vector2(0f, 1f);
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child7.threshold = 7f;
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child7.timeScale = 1f;
			var surfaceSwimAnimatorState76880blendTreeBlendTree78078Child8 =  new ChildMotion();
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child8.motion = surfacePowerSwimFwdAnimationClip65044;
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child8.cycleOffset = 0f;
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child8.directBlendParameter = "HorizontalMovement";
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child8.mirror = false;
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child8.position = new Vector2(0f, 2f);
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child8.threshold = 8f;
			surfaceSwimAnimatorState76880blendTreeBlendTree78078Child8.timeScale = 1.25f;
			surfaceSwimAnimatorState76880blendTreeBlendTree78078.children = new ChildMotion[] {
				surfaceSwimAnimatorState76880blendTreeBlendTree78078Child0,
				surfaceSwimAnimatorState76880blendTreeBlendTree78078Child1,
				surfaceSwimAnimatorState76880blendTreeBlendTree78078Child2,
				surfaceSwimAnimatorState76880blendTreeBlendTree78078Child3,
				surfaceSwimAnimatorState76880blendTreeBlendTree78078Child4,
				surfaceSwimAnimatorState76880blendTreeBlendTree78078Child5,
				surfaceSwimAnimatorState76880blendTreeBlendTree78078Child6,
				surfaceSwimAnimatorState76880blendTreeBlendTree78078Child7,
				surfaceSwimAnimatorState76880blendTreeBlendTree78078Child8
			};
			surfaceSwimAnimatorState76880.motion = surfaceSwimAnimatorState76880blendTreeBlendTree78078;
			surfaceSwimAnimatorState76880.cycleOffset = 0f;
			surfaceSwimAnimatorState76880.cycleOffsetParameterActive = false;
			surfaceSwimAnimatorState76880.iKOnFeet = false;
			surfaceSwimAnimatorState76880.mirror = false;
			surfaceSwimAnimatorState76880.mirrorParameterActive = false;
			surfaceSwimAnimatorState76880.speed = 1f;
			surfaceSwimAnimatorState76880.speedParameterActive = false;
			surfaceSwimAnimatorState76880.writeDefaultValues = true;

			var underwaterSwimAnimatorState76874 = swimAnimatorStateMachine76046.AddState("Underwater Swim", new Vector3(264f, 276f, 0f));
			var underwaterSwimAnimatorState76874blendTreeBlendTree78094 = new BlendTree();
			AssetDatabase.AddObjectToAsset(underwaterSwimAnimatorState76874blendTreeBlendTree78094, animatorController);
			underwaterSwimAnimatorState76874blendTreeBlendTree78094.hideFlags = HideFlags.HideInHierarchy;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094.blendParameter = "HorizontalMovement";
			underwaterSwimAnimatorState76874blendTreeBlendTree78094.blendParameterY = "ForwardMovement";
			underwaterSwimAnimatorState76874blendTreeBlendTree78094.blendType = BlendTreeType.FreeformCartesian2D;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094.maxThreshold = 90f;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094.minThreshold = -90f;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094.name = "Blend Tree";
			underwaterSwimAnimatorState76874blendTreeBlendTree78094.useAutomaticThresholds = true;
			var underwaterSwimAnimatorState76874blendTreeBlendTree78094Child0 =  new ChildMotion();
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child0.motion = underwaterSwimBwdAnimationClip65172;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child0.cycleOffset = 0f;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child0.directBlendParameter = "HorizontalMovement";
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child0.mirror = false;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child0.position = new Vector2(0f, -2f);
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child0.threshold = -90f;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child0.timeScale = 1.5f;
			var underwaterSwimAnimatorState76874blendTreeBlendTree78094Child1 =  new ChildMotion();
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child1.motion = underwaterSwimBwdAnimationClip65172;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child1.cycleOffset = 0f;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child1.directBlendParameter = "HorizontalMovement";
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child1.mirror = false;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child1.position = new Vector2(0f, -1f);
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child1.threshold = -67.5f;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child1.timeScale = 1f;
			var underwaterSwimAnimatorState76874blendTreeBlendTree78094Child2 =  new ChildMotion();
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child2.motion = underwaterKickStrafeAnimationClip65124;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child2.cycleOffset = 0f;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child2.directBlendParameter = "HorizontalMovement";
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child2.mirror = false;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child2.position = new Vector2(-2f, 0f);
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child2.threshold = -45f;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child2.timeScale = 1.5f;
			var underwaterSwimAnimatorState76874blendTreeBlendTree78094Child3 =  new ChildMotion();
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child3.motion = underwaterStrokeStrafeAnimationClip65160;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child3.cycleOffset = 0f;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child3.directBlendParameter = "HorizontalMovement";
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child3.mirror = false;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child3.position = new Vector2(-1f, 0f);
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child3.threshold = -22.5f;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child3.timeScale = 1f;
			var underwaterSwimAnimatorState76874blendTreeBlendTree78094Child4 =  new ChildMotion();
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child4.motion = underwaterStrokeStrafeAnimationClip65160;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child4.cycleOffset = 0.5f;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child4.directBlendParameter = "HorizontalMovement";
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child4.mirror = true;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child4.position = new Vector2(1f, 0f);
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child4.threshold = 0f;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child4.timeScale = 1f;
			var underwaterSwimAnimatorState76874blendTreeBlendTree78094Child5 =  new ChildMotion();
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child5.motion = underwaterKickStrafeAnimationClip65124;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child5.cycleOffset = 0.5f;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child5.directBlendParameter = "HorizontalMovement";
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child5.mirror = true;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child5.position = new Vector2(2f, 0f);
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child5.threshold = 22.5f;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child5.timeScale = 1.5f;
			var underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78096 = new BlendTree();
			AssetDatabase.AddObjectToAsset(underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78096, animatorController);
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78096.hideFlags = HideFlags.HideInHierarchy;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78096.blendParameter = "AbilityFloatData";
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78096.blendParameterY = "Blend";
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78096.blendType = BlendTreeType.Simple1D;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78096.maxThreshold = 90f;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78096.minThreshold = -90f;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78096.name = "BlendTree";
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78096.useAutomaticThresholds = false;
			var underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78096Child0 =  new ChildMotion();
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78096Child0.motion = underwaterIdleUpAnimationClip65190;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78096Child0.cycleOffset = 0f;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78096Child0.directBlendParameter = "HorizontalMovement";
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78096Child0.mirror = false;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78096Child0.position = new Vector2(0f, 0f);
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78096Child0.threshold = -90f;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78096Child0.timeScale = 1f;
			var underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78096Child1 =  new ChildMotion();
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78096Child1.motion = underwaterIdleFwdAnimationClip65184;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78096Child1.cycleOffset = 0f;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78096Child1.directBlendParameter = "HorizontalMovement";
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78096Child1.mirror = false;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78096Child1.position = new Vector2(0f, 0f);
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78096Child1.threshold = 0f;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78096Child1.timeScale = 1f;
			var underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78096Child2 =  new ChildMotion();
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78096Child2.motion = underwaterIdleDownAnimationClip65178;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78096Child2.cycleOffset = 0f;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78096Child2.directBlendParameter = "HorizontalMovement";
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78096Child2.mirror = false;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78096Child2.position = new Vector2(0f, 0f);
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78096Child2.threshold = 90f;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78096Child2.timeScale = 1f;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78096.children = new ChildMotion[] {
				underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78096Child0,
				underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78096Child1,
				underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78096Child2
			};
			var underwaterSwimAnimatorState76874blendTreeBlendTree78094Child6 =  new ChildMotion();
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child6.motion = underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78096;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child6.cycleOffset = 0f;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child6.directBlendParameter = "HorizontalMovement";
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child6.mirror = false;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child6.position = new Vector2(0f, 0f);
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child6.threshold = 45f;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child6.timeScale = 1f;
			var underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78098 = new BlendTree();
			AssetDatabase.AddObjectToAsset(underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78098, animatorController);
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78098.hideFlags = HideFlags.HideInHierarchy;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78098.blendParameter = "AbilityFloatData";
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78098.blendParameterY = "Blend";
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78098.blendType = BlendTreeType.Simple1D;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78098.maxThreshold = 90f;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78098.minThreshold = -90f;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78098.name = "BlendTree";
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78098.useAutomaticThresholds = false;
			var underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78098Child0 =  new ChildMotion();
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78098Child0.motion = underwaterStrokeUpAnimationClip65166;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78098Child0.cycleOffset = 0f;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78098Child0.directBlendParameter = "HorizontalMovement";
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78098Child0.mirror = false;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78098Child0.position = new Vector2(0f, 0f);
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78098Child0.threshold = -90f;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78098Child0.timeScale = 1f;
			var underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78098Child1 =  new ChildMotion();
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78098Child1.motion = underwaterStrokeFwdAnimationClip65154;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78098Child1.cycleOffset = 0f;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78098Child1.directBlendParameter = "HorizontalMovement";
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78098Child1.mirror = false;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78098Child1.position = new Vector2(0f, 0f);
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78098Child1.threshold = 0f;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78098Child1.timeScale = 1f;
			var underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78098Child2 =  new ChildMotion();
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78098Child2.motion = underwaterStrokeDownAnimationClip65148;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78098Child2.cycleOffset = 0f;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78098Child2.directBlendParameter = "HorizontalMovement";
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78098Child2.mirror = false;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78098Child2.position = new Vector2(0f, 0f);
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78098Child2.threshold = 90f;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78098Child2.timeScale = 1f;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78098.children = new ChildMotion[] {
				underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78098Child0,
				underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78098Child1,
				underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78098Child2
			};
			var underwaterSwimAnimatorState76874blendTreeBlendTree78094Child7 =  new ChildMotion();
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child7.motion = underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78098;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child7.cycleOffset = 0f;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child7.directBlendParameter = "HorizontalMovement";
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child7.mirror = false;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child7.position = new Vector2(0f, 1f);
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child7.threshold = 67.5f;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child7.timeScale = 1f;
			var underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78100 = new BlendTree();
			AssetDatabase.AddObjectToAsset(underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78100, animatorController);
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78100.hideFlags = HideFlags.HideInHierarchy;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78100.blendParameter = "AbilityFloatData";
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78100.blendParameterY = "Blend";
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78100.blendType = BlendTreeType.Simple1D;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78100.maxThreshold = 90f;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78100.minThreshold = -90f;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78100.name = "BlendTree";
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78100.useAutomaticThresholds = false;
			var underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78100Child0 =  new ChildMotion();
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78100Child0.motion = underwaterKickUpAnimationClip65136;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78100Child0.cycleOffset = 0f;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78100Child0.directBlendParameter = "HorizontalMovement";
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78100Child0.mirror = false;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78100Child0.position = new Vector2(0f, 0f);
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78100Child0.threshold = -90f;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78100Child0.timeScale = 1.5f;
			var underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78100Child1 =  new ChildMotion();
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78100Child1.motion = underwaterKickFwdAnimationClip65112;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78100Child1.cycleOffset = 0f;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78100Child1.directBlendParameter = "HorizontalMovement";
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78100Child1.mirror = false;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78100Child1.position = new Vector2(0f, 0f);
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78100Child1.threshold = 0f;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78100Child1.timeScale = 1.5f;
			var underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78100Child2 =  new ChildMotion();
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78100Child2.motion = underwaterKickDownAnimationClip65100;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78100Child2.cycleOffset = 0f;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78100Child2.directBlendParameter = "HorizontalMovement";
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78100Child2.mirror = false;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78100Child2.position = new Vector2(0f, 0f);
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78100Child2.threshold = 90f;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78100Child2.timeScale = 1.5f;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78100.children = new ChildMotion[] {
				underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78100Child0,
				underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78100Child1,
				underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78100Child2
			};
			var underwaterSwimAnimatorState76874blendTreeBlendTree78094Child8 =  new ChildMotion();
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child8.motion = underwaterSwimAnimatorState76874blendTreeBlendTree78094blendTreeBlendTree78100;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child8.cycleOffset = 0f;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child8.directBlendParameter = "HorizontalMovement";
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child8.mirror = false;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child8.position = new Vector2(0f, 2f);
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child8.threshold = 90f;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094Child8.timeScale = 1f;
			underwaterSwimAnimatorState76874blendTreeBlendTree78094.children = new ChildMotion[] {
				underwaterSwimAnimatorState76874blendTreeBlendTree78094Child0,
				underwaterSwimAnimatorState76874blendTreeBlendTree78094Child1,
				underwaterSwimAnimatorState76874blendTreeBlendTree78094Child2,
				underwaterSwimAnimatorState76874blendTreeBlendTree78094Child3,
				underwaterSwimAnimatorState76874blendTreeBlendTree78094Child4,
				underwaterSwimAnimatorState76874blendTreeBlendTree78094Child5,
				underwaterSwimAnimatorState76874blendTreeBlendTree78094Child6,
				underwaterSwimAnimatorState76874blendTreeBlendTree78094Child7,
				underwaterSwimAnimatorState76874blendTreeBlendTree78094Child8
			};
			underwaterSwimAnimatorState76874.motion = underwaterSwimAnimatorState76874blendTreeBlendTree78094;
			underwaterSwimAnimatorState76874.cycleOffset = 0f;
			underwaterSwimAnimatorState76874.cycleOffsetParameterActive = false;
			underwaterSwimAnimatorState76874.iKOnFeet = true;
			underwaterSwimAnimatorState76874.mirror = false;
			underwaterSwimAnimatorState76874.mirrorParameterActive = false;
			underwaterSwimAnimatorState76874.speed = 1f;
			underwaterSwimAnimatorState76874.speedParameterActive = false;
			underwaterSwimAnimatorState76874.writeDefaultValues = true;

			var diveFromSurfaceAnimatorState78032 = swimAnimatorStateMachine76046.AddState("Dive From Surface", new Vector3(432f, 48f, 0f));
			diveFromSurfaceAnimatorState78032.motion = diveFromSurfaceAnimationClip65026;
			diveFromSurfaceAnimatorState78032.cycleOffset = 0f;
			diveFromSurfaceAnimatorState78032.cycleOffsetParameterActive = false;
			diveFromSurfaceAnimatorState78032.iKOnFeet = false;
			diveFromSurfaceAnimatorState78032.mirror = false;
			diveFromSurfaceAnimatorState78032.mirrorParameterActive = false;
			diveFromSurfaceAnimatorState78032.speed = 1.5f;
			diveFromSurfaceAnimatorState78032.speedParameterActive = false;
			diveFromSurfaceAnimatorState78032.writeDefaultValues = true;

			var exitWaterMovingAnimatorState78034 = swimAnimatorStateMachine76046.AddState("Exit Water Moving", new Vector3(744f, 12f, 0f));
			exitWaterMovingAnimatorState78034.motion = swimExitWaterAnimationClip65092;
			exitWaterMovingAnimatorState78034.cycleOffset = 0f;
			exitWaterMovingAnimatorState78034.cycleOffsetParameterActive = false;
			exitWaterMovingAnimatorState78034.iKOnFeet = false;
			exitWaterMovingAnimatorState78034.mirror = false;
			exitWaterMovingAnimatorState78034.mirrorParameterActive = false;
			exitWaterMovingAnimatorState78034.speed = 1.5f;
			exitWaterMovingAnimatorState78034.speedParameterActive = false;
			exitWaterMovingAnimatorState78034.writeDefaultValues = true;

			var exitWaterIdleAnimatorState78036 = swimAnimatorStateMachine76046.AddState("Exit Water Idle", new Vector3(744f, -48f, 0f));
			exitWaterIdleAnimatorState78036.motion = surfaceSwimToIdleAnimationClip65086;
			exitWaterIdleAnimatorState78036.cycleOffset = 0f;
			exitWaterIdleAnimatorState78036.cycleOffsetParameterActive = false;
			exitWaterIdleAnimatorState78036.iKOnFeet = false;
			exitWaterIdleAnimatorState78036.mirror = false;
			exitWaterIdleAnimatorState78036.mirrorParameterActive = false;
			exitWaterIdleAnimatorState78036.speed = 1.5f;
			exitWaterIdleAnimatorState78036.speedParameterActive = false;
			exitWaterIdleAnimatorState78036.writeDefaultValues = true;

			var underwaterSwimItemAnimatorState76884 = swimAnimatorStateMachine76046.AddState("Underwater Swim Item", new Vector3(504f, 276f, 0f));
			var underwaterSwimItemAnimatorState76884blendTreeBlendTree78122 = new BlendTree();
			AssetDatabase.AddObjectToAsset(underwaterSwimItemAnimatorState76884blendTreeBlendTree78122, animatorController);
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122.hideFlags = HideFlags.HideInHierarchy;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122.blendParameter = "HorizontalMovement";
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122.blendParameterY = "ForwardMovement";
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122.blendType = BlendTreeType.FreeformCartesian2D;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122.maxThreshold = 360f;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122.minThreshold = -90f;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122.name = "Blend Tree";
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122.useAutomaticThresholds = false;
			var underwaterSwimItemAnimatorState76884blendTreeBlendTree78122Child0 =  new ChildMotion();
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122Child0.motion = underwaterSwimBwdAnimationClip65172;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122Child0.cycleOffset = 0f;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122Child0.directBlendParameter = "HorizontalMovement";
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122Child0.mirror = false;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122Child0.position = new Vector2(0f, -1f);
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122Child0.threshold = -90f;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122Child0.timeScale = 1.5f;
			var underwaterSwimItemAnimatorState76884blendTreeBlendTree78122Child1 =  new ChildMotion();
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122Child1.motion = underwaterKickStrafeItemAnimationClip65130;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122Child1.cycleOffset = 0f;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122Child1.directBlendParameter = "HorizontalMovement";
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122Child1.mirror = false;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122Child1.position = new Vector2(-1f, 0f);
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122Child1.threshold = 0f;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122Child1.timeScale = 1.5f;
			var underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78124 = new BlendTree();
			AssetDatabase.AddObjectToAsset(underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78124, animatorController);
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78124.hideFlags = HideFlags.HideInHierarchy;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78124.blendParameter = "AbilityFloatData";
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78124.blendParameterY = "Blend";
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78124.blendType = BlendTreeType.Simple1D;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78124.maxThreshold = 90f;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78124.minThreshold = -90f;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78124.name = "BlendTree";
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78124.useAutomaticThresholds = false;
			var underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78124Child0 =  new ChildMotion();
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78124Child0.motion = underwaterIdleUpAnimationClip65190;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78124Child0.cycleOffset = 0f;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78124Child0.directBlendParameter = "HorizontalMovement";
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78124Child0.mirror = false;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78124Child0.position = new Vector2(0f, 0f);
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78124Child0.threshold = -90f;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78124Child0.timeScale = 1f;
			var underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78124Child1 =  new ChildMotion();
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78124Child1.motion = underwaterIdleFwdAnimationClip65184;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78124Child1.cycleOffset = 0f;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78124Child1.directBlendParameter = "HorizontalMovement";
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78124Child1.mirror = false;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78124Child1.position = new Vector2(0f, 0f);
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78124Child1.threshold = 0f;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78124Child1.timeScale = 1f;
			var underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78124Child2 =  new ChildMotion();
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78124Child2.motion = underwaterIdleDownAnimationClip65178;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78124Child2.cycleOffset = 0f;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78124Child2.directBlendParameter = "HorizontalMovement";
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78124Child2.mirror = false;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78124Child2.position = new Vector2(0f, 0f);
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78124Child2.threshold = 90f;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78124Child2.timeScale = 1f;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78124.children = new ChildMotion[] {
				underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78124Child0,
				underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78124Child1,
				underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78124Child2
			};
			var underwaterSwimItemAnimatorState76884blendTreeBlendTree78122Child2 =  new ChildMotion();
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122Child2.motion = underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78124;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122Child2.cycleOffset = 0f;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122Child2.directBlendParameter = "HorizontalMovement";
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122Child2.mirror = false;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122Child2.position = new Vector2(0f, 0f);
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122Child2.threshold = 180f;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122Child2.timeScale = 1f;
			var underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78126 = new BlendTree();
			AssetDatabase.AddObjectToAsset(underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78126, animatorController);
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78126.hideFlags = HideFlags.HideInHierarchy;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78126.blendParameter = "AbilityFloatData";
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78126.blendParameterY = "Blend";
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78126.blendType = BlendTreeType.Simple1D;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78126.maxThreshold = 90f;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78126.minThreshold = -90f;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78126.name = "BlendTree";
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78126.useAutomaticThresholds = false;
			var underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78126Child0 =  new ChildMotion();
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78126Child0.motion = underwaterKickUpItemAnimationClip65142;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78126Child0.cycleOffset = 0f;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78126Child0.directBlendParameter = "HorizontalMovement";
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78126Child0.mirror = false;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78126Child0.position = new Vector2(0f, 0f);
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78126Child0.threshold = -90f;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78126Child0.timeScale = 1.5f;
			var underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78126Child1 =  new ChildMotion();
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78126Child1.motion = underwaterKickFwdItemAnimationClip65118;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78126Child1.cycleOffset = 0f;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78126Child1.directBlendParameter = "HorizontalMovement";
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78126Child1.mirror = false;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78126Child1.position = new Vector2(0f, 0f);
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78126Child1.threshold = 0f;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78126Child1.timeScale = 1.5f;
			var underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78126Child2 =  new ChildMotion();
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78126Child2.motion = underwaterKickDownItemAnimationClip65106;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78126Child2.cycleOffset = 0f;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78126Child2.directBlendParameter = "HorizontalMovement";
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78126Child2.mirror = false;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78126Child2.position = new Vector2(0f, 0f);
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78126Child2.threshold = 90f;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78126Child2.timeScale = 1.5f;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78126.children = new ChildMotion[] {
				underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78126Child0,
				underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78126Child1,
				underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78126Child2
			};
			var underwaterSwimItemAnimatorState76884blendTreeBlendTree78122Child3 =  new ChildMotion();
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122Child3.motion = underwaterSwimItemAnimatorState76884blendTreeBlendTree78122blendTreeBlendTree78126;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122Child3.cycleOffset = 0f;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122Child3.directBlendParameter = "HorizontalMovement";
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122Child3.mirror = false;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122Child3.position = new Vector2(0f, 1f);
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122Child3.threshold = 270f;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122Child3.timeScale = 1f;
			var underwaterSwimItemAnimatorState76884blendTreeBlendTree78122Child4 =  new ChildMotion();
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122Child4.motion = underwaterKickStrafeItemAnimationClip65130;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122Child4.cycleOffset = 0.5f;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122Child4.directBlendParameter = "HorizontalMovement";
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122Child4.mirror = true;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122Child4.position = new Vector2(1f, 0f);
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122Child4.threshold = 360f;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122Child4.timeScale = 1.5f;
			underwaterSwimItemAnimatorState76884blendTreeBlendTree78122.children = new ChildMotion[] {
				underwaterSwimItemAnimatorState76884blendTreeBlendTree78122Child0,
				underwaterSwimItemAnimatorState76884blendTreeBlendTree78122Child1,
				underwaterSwimItemAnimatorState76884blendTreeBlendTree78122Child2,
				underwaterSwimItemAnimatorState76884blendTreeBlendTree78122Child3,
				underwaterSwimItemAnimatorState76884blendTreeBlendTree78122Child4
			};
			underwaterSwimItemAnimatorState76884.motion = underwaterSwimItemAnimatorState76884blendTreeBlendTree78122;
			underwaterSwimItemAnimatorState76884.cycleOffset = 0f;
			underwaterSwimItemAnimatorState76884.cycleOffsetParameterActive = false;
			underwaterSwimItemAnimatorState76884.iKOnFeet = false;
			underwaterSwimItemAnimatorState76884.mirror = false;
			underwaterSwimItemAnimatorState76884.mirrorParameterActive = false;
			underwaterSwimItemAnimatorState76884.speed = 1f;
			underwaterSwimItemAnimatorState76884.speedParameterActive = false;
			underwaterSwimItemAnimatorState76884.writeDefaultValues = true;

			var surfaceSwimItemAnimatorState76890 = swimAnimatorStateMachine76046.AddState("Surface Swim Item", new Vector3(504f, -204f, 0f));
			var surfaceSwimItemAnimatorState76890blendTreeBlendTree78140 = new BlendTree();
			AssetDatabase.AddObjectToAsset(surfaceSwimItemAnimatorState76890blendTreeBlendTree78140, animatorController);
			surfaceSwimItemAnimatorState76890blendTreeBlendTree78140.hideFlags = HideFlags.HideInHierarchy;
			surfaceSwimItemAnimatorState76890blendTreeBlendTree78140.blendParameter = "HorizontalMovement";
			surfaceSwimItemAnimatorState76890blendTreeBlendTree78140.blendParameterY = "ForwardMovement";
			surfaceSwimItemAnimatorState76890blendTreeBlendTree78140.blendType = BlendTreeType.FreeformCartesian2D;
			surfaceSwimItemAnimatorState76890blendTreeBlendTree78140.maxThreshold = 7f;
			surfaceSwimItemAnimatorState76890blendTreeBlendTree78140.minThreshold = 1f;
			surfaceSwimItemAnimatorState76890blendTreeBlendTree78140.name = "Blend Tree";
			surfaceSwimItemAnimatorState76890blendTreeBlendTree78140.useAutomaticThresholds = false;
			var surfaceSwimItemAnimatorState76890blendTreeBlendTree78140Child0 =  new ChildMotion();
			surfaceSwimItemAnimatorState76890blendTreeBlendTree78140Child0.motion = surfaceSwimBwdAnimationClip65056;
			surfaceSwimItemAnimatorState76890blendTreeBlendTree78140Child0.cycleOffset = 0f;
			surfaceSwimItemAnimatorState76890blendTreeBlendTree78140Child0.directBlendParameter = "HorizontalMovement";
			surfaceSwimItemAnimatorState76890blendTreeBlendTree78140Child0.mirror = false;
			surfaceSwimItemAnimatorState76890blendTreeBlendTree78140Child0.position = new Vector2(0f, -1f);
			surfaceSwimItemAnimatorState76890blendTreeBlendTree78140Child0.threshold = 1f;
			surfaceSwimItemAnimatorState76890blendTreeBlendTree78140Child0.timeScale = 1f;
			var surfaceSwimItemAnimatorState76890blendTreeBlendTree78140Child1 =  new ChildMotion();
			surfaceSwimItemAnimatorState76890blendTreeBlendTree78140Child1.motion = surfaceSwimStrafeAnimationClip65080;
			surfaceSwimItemAnimatorState76890blendTreeBlendTree78140Child1.cycleOffset = 0f;
			surfaceSwimItemAnimatorState76890blendTreeBlendTree78140Child1.directBlendParameter = "HorizontalMovement";
			surfaceSwimItemAnimatorState76890blendTreeBlendTree78140Child1.mirror = false;
			surfaceSwimItemAnimatorState76890blendTreeBlendTree78140Child1.position = new Vector2(-1f, 0f);
			surfaceSwimItemAnimatorState76890blendTreeBlendTree78140Child1.threshold = 3f;
			surfaceSwimItemAnimatorState76890blendTreeBlendTree78140Child1.timeScale = 1f;
			var surfaceSwimItemAnimatorState76890blendTreeBlendTree78140Child2 =  new ChildMotion();
			surfaceSwimItemAnimatorState76890blendTreeBlendTree78140Child2.motion = surfaceSwimIdleAnimationClip65074;
			surfaceSwimItemAnimatorState76890blendTreeBlendTree78140Child2.cycleOffset = 0f;
			surfaceSwimItemAnimatorState76890blendTreeBlendTree78140Child2.directBlendParameter = "HorizontalMovement";
			surfaceSwimItemAnimatorState76890blendTreeBlendTree78140Child2.mirror = false;
			surfaceSwimItemAnimatorState76890blendTreeBlendTree78140Child2.position = new Vector2(0f, 0f);
			surfaceSwimItemAnimatorState76890blendTreeBlendTree78140Child2.threshold = 4f;
			surfaceSwimItemAnimatorState76890blendTreeBlendTree78140Child2.timeScale = 1f;
			var surfaceSwimItemAnimatorState76890blendTreeBlendTree78140Child3 =  new ChildMotion();
			surfaceSwimItemAnimatorState76890blendTreeBlendTree78140Child3.motion = surfaceSwimStrafeAnimationClip65080;
			surfaceSwimItemAnimatorState76890blendTreeBlendTree78140Child3.cycleOffset = 0.5f;
			surfaceSwimItemAnimatorState76890blendTreeBlendTree78140Child3.directBlendParameter = "HorizontalMovement";
			surfaceSwimItemAnimatorState76890blendTreeBlendTree78140Child3.mirror = true;
			surfaceSwimItemAnimatorState76890blendTreeBlendTree78140Child3.position = new Vector2(1f, 0f);
			surfaceSwimItemAnimatorState76890blendTreeBlendTree78140Child3.threshold = 5f;
			surfaceSwimItemAnimatorState76890blendTreeBlendTree78140Child3.timeScale = 1f;
			var surfaceSwimItemAnimatorState76890blendTreeBlendTree78140Child4 =  new ChildMotion();
			surfaceSwimItemAnimatorState76890blendTreeBlendTree78140Child4.motion = surfaceSwimFwdItemAnimationClip65068;
			surfaceSwimItemAnimatorState76890blendTreeBlendTree78140Child4.cycleOffset = 0f;
			surfaceSwimItemAnimatorState76890blendTreeBlendTree78140Child4.directBlendParameter = "HorizontalMovement";
			surfaceSwimItemAnimatorState76890blendTreeBlendTree78140Child4.mirror = false;
			surfaceSwimItemAnimatorState76890blendTreeBlendTree78140Child4.position = new Vector2(0f, 1f);
			surfaceSwimItemAnimatorState76890blendTreeBlendTree78140Child4.threshold = 7f;
			surfaceSwimItemAnimatorState76890blendTreeBlendTree78140Child4.timeScale = 1f;
			surfaceSwimItemAnimatorState76890blendTreeBlendTree78140.children = new ChildMotion[] {
				surfaceSwimItemAnimatorState76890blendTreeBlendTree78140Child0,
				surfaceSwimItemAnimatorState76890blendTreeBlendTree78140Child1,
				surfaceSwimItemAnimatorState76890blendTreeBlendTree78140Child2,
				surfaceSwimItemAnimatorState76890blendTreeBlendTree78140Child3,
				surfaceSwimItemAnimatorState76890blendTreeBlendTree78140Child4
			};
			surfaceSwimItemAnimatorState76890.motion = surfaceSwimItemAnimatorState76890blendTreeBlendTree78140;
			surfaceSwimItemAnimatorState76890.cycleOffset = 0f;
			surfaceSwimItemAnimatorState76890.cycleOffsetParameterActive = false;
			surfaceSwimItemAnimatorState76890.iKOnFeet = false;
			surfaceSwimItemAnimatorState76890.mirror = false;
			surfaceSwimItemAnimatorState76890.mirrorParameterActive = false;
			surfaceSwimItemAnimatorState76890.speed = 1f;
			surfaceSwimItemAnimatorState76890.speedParameterActive = false;
			surfaceSwimItemAnimatorState76890.writeDefaultValues = true;

			// State Machine Defaults.
			swimAnimatorStateMachine76046.anyStatePosition = new Vector3(-168f, 48f, 0f);
			swimAnimatorStateMachine76046.defaultState = surfaceIdleAnimatorState76872;
			swimAnimatorStateMachine76046.entryPosition = new Vector3(-204f, -36f, 0f);
			swimAnimatorStateMachine76046.exitPosition = new Vector3(1140f, 48f, 0f);
			swimAnimatorStateMachine76046.parentStateMachinePosition = new Vector3(1128f, -48f, 0f);

			// State Transitions.
			var animatorStateTransition78038 = fallInWaterAnimatorState76870.AddTransition(surfaceIdleAnimatorState76872);
			animatorStateTransition78038.canTransitionToSelf = true;
			animatorStateTransition78038.duration = 0.5f;
			animatorStateTransition78038.exitTime = 0.95f;
			animatorStateTransition78038.hasExitTime = true;
			animatorStateTransition78038.hasFixedDuration = true;
			animatorStateTransition78038.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78038.offset = 0f;
			animatorStateTransition78038.orderedInterruption = true;
			animatorStateTransition78038.isExit = false;
			animatorStateTransition78038.mute = false;
			animatorStateTransition78038.solo = false;
			animatorStateTransition78038.AddCondition(AnimatorConditionMode.Less, 0.1f, "ForwardMovement");
			animatorStateTransition78038.AddCondition(AnimatorConditionMode.Equals, 1f, "AbilityIntData");

			var animatorStateTransition78040 = fallInWaterAnimatorState76870.AddTransition(surfaceSwimAnimatorState76880);
			animatorStateTransition78040.canTransitionToSelf = true;
			animatorStateTransition78040.duration = 0.25f;
			animatorStateTransition78040.exitTime = 0.8f;
			animatorStateTransition78040.hasExitTime = false;
			animatorStateTransition78040.hasFixedDuration = true;
			animatorStateTransition78040.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78040.offset = 0f;
			animatorStateTransition78040.orderedInterruption = true;
			animatorStateTransition78040.isExit = false;
			animatorStateTransition78040.mute = false;
			animatorStateTransition78040.solo = false;
			animatorStateTransition78040.AddCondition(AnimatorConditionMode.Equals, 1f, "AbilityIntData");
			animatorStateTransition78040.AddCondition(AnimatorConditionMode.If, 0f, "Moving");
			animatorStateTransition78040.AddCondition(AnimatorConditionMode.Equals, 0f, "Slot0ItemID");

			var animatorStateTransition78042 = fallInWaterAnimatorState76870.AddExitTransition();
			animatorStateTransition78042.canTransitionToSelf = true;
			animatorStateTransition78042.duration = 0.25f;
			animatorStateTransition78042.exitTime = 0.8888889f;
			animatorStateTransition78042.hasExitTime = false;
			animatorStateTransition78042.hasFixedDuration = true;
			animatorStateTransition78042.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78042.offset = 0f;
			animatorStateTransition78042.orderedInterruption = true;
			animatorStateTransition78042.isExit = true;
			animatorStateTransition78042.mute = false;
			animatorStateTransition78042.solo = false;
			animatorStateTransition78042.AddCondition(AnimatorConditionMode.NotEqual, 301f, "AbilityIndex");

			var animatorStateTransition78044 = fallInWaterAnimatorState76870.AddTransition(underwaterSwimAnimatorState76874);
			animatorStateTransition78044.canTransitionToSelf = true;
			animatorStateTransition78044.duration = 0.5f;
			animatorStateTransition78044.exitTime = 0.9f;
			animatorStateTransition78044.hasExitTime = true;
			animatorStateTransition78044.hasFixedDuration = true;
			animatorStateTransition78044.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78044.offset = 0f;
			animatorStateTransition78044.orderedInterruption = true;
			animatorStateTransition78044.isExit = false;
			animatorStateTransition78044.mute = false;
			animatorStateTransition78044.solo = false;
			animatorStateTransition78044.AddCondition(AnimatorConditionMode.Equals, 2f, "AbilityIntData");
			animatorStateTransition78044.AddCondition(AnimatorConditionMode.Equals, 0f, "Slot0ItemID");
			animatorStateTransition78044.AddCondition(AnimatorConditionMode.IfNot, 0f, "Moving");

			var animatorStateTransition78046 = fallInWaterAnimatorState76870.AddTransition(underwaterSwimItemAnimatorState76884);
			animatorStateTransition78046.canTransitionToSelf = true;
			animatorStateTransition78046.duration = 0.25f;
			animatorStateTransition78046.exitTime = 0.8f;
			animatorStateTransition78046.hasExitTime = false;
			animatorStateTransition78046.hasFixedDuration = true;
			animatorStateTransition78046.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78046.offset = 0f;
			animatorStateTransition78046.orderedInterruption = true;
			animatorStateTransition78046.isExit = false;
			animatorStateTransition78046.mute = false;
			animatorStateTransition78046.solo = false;
			animatorStateTransition78046.AddCondition(AnimatorConditionMode.Equals, 2f, "AbilityIntData");
			animatorStateTransition78046.AddCondition(AnimatorConditionMode.Greater, 0f, "Slot0ItemID");
			animatorStateTransition78046.AddCondition(AnimatorConditionMode.If, 0f, "Moving");

			var animatorStateTransition78048 = fallInWaterAnimatorState76870.AddTransition(underwaterSwimAnimatorState76874);
			animatorStateTransition78048.canTransitionToSelf = true;
			animatorStateTransition78048.duration = 0.25f;
			animatorStateTransition78048.exitTime = 0.8888889f;
			animatorStateTransition78048.hasExitTime = false;
			animatorStateTransition78048.hasFixedDuration = true;
			animatorStateTransition78048.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78048.offset = 0f;
			animatorStateTransition78048.orderedInterruption = true;
			animatorStateTransition78048.isExit = false;
			animatorStateTransition78048.mute = false;
			animatorStateTransition78048.solo = false;
			animatorStateTransition78048.AddCondition(AnimatorConditionMode.Equals, 2f, "AbilityIntData");
			animatorStateTransition78048.AddCondition(AnimatorConditionMode.Equals, 0f, "Slot0ItemID");
			animatorStateTransition78048.AddCondition(AnimatorConditionMode.If, 0f, "Moving");

			var animatorStateTransition78050 = fallInWaterAnimatorState76870.AddTransition(underwaterSwimItemAnimatorState76884);
			animatorStateTransition78050.canTransitionToSelf = true;
			animatorStateTransition78050.duration = 0.5f;
			animatorStateTransition78050.exitTime = 0.9f;
			animatorStateTransition78050.hasExitTime = true;
			animatorStateTransition78050.hasFixedDuration = true;
			animatorStateTransition78050.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78050.offset = 0f;
			animatorStateTransition78050.orderedInterruption = true;
			animatorStateTransition78050.isExit = false;
			animatorStateTransition78050.mute = false;
			animatorStateTransition78050.solo = false;
			animatorStateTransition78050.AddCondition(AnimatorConditionMode.Equals, 2f, "AbilityIntData");
			animatorStateTransition78050.AddCondition(AnimatorConditionMode.Greater, 0f, "Slot0ItemID");
			animatorStateTransition78050.AddCondition(AnimatorConditionMode.IfNot, 0f, "Moving");

			var animatorStateTransition78052 = fallInWaterAnimatorState76870.AddTransition(surfaceSwimItemAnimatorState76890);
			animatorStateTransition78052.canTransitionToSelf = true;
			animatorStateTransition78052.duration = 0.25f;
			animatorStateTransition78052.exitTime = 0.8888889f;
			animatorStateTransition78052.hasExitTime = false;
			animatorStateTransition78052.hasFixedDuration = true;
			animatorStateTransition78052.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78052.offset = 0f;
			animatorStateTransition78052.orderedInterruption = true;
			animatorStateTransition78052.isExit = false;
			animatorStateTransition78052.mute = false;
			animatorStateTransition78052.solo = false;
			animatorStateTransition78052.AddCondition(AnimatorConditionMode.Equals, 1f, "AbilityIntData");
			animatorStateTransition78052.AddCondition(AnimatorConditionMode.If, 0f, "Moving");
			animatorStateTransition78052.AddCondition(AnimatorConditionMode.Greater, 0f, "Slot0ItemID");

			var animatorStateTransition78054 = surfaceIdleAnimatorState76872.AddTransition(surfaceSwimAnimatorState76880);
			animatorStateTransition78054.canTransitionToSelf = true;
			animatorStateTransition78054.duration = 0.4f;
			animatorStateTransition78054.exitTime = 0.75f;
			animatorStateTransition78054.hasExitTime = false;
			animatorStateTransition78054.hasFixedDuration = true;
			animatorStateTransition78054.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78054.offset = 0f;
			animatorStateTransition78054.orderedInterruption = true;
			animatorStateTransition78054.isExit = false;
			animatorStateTransition78054.mute = false;
			animatorStateTransition78054.solo = false;
			animatorStateTransition78054.AddCondition(AnimatorConditionMode.Equals, 1f, "AbilityIntData");
			animatorStateTransition78054.AddCondition(AnimatorConditionMode.If, 0f, "Moving");
			animatorStateTransition78054.AddCondition(AnimatorConditionMode.Equals, 0f, "Slot0ItemID");

			var animatorStateTransition78056 = surfaceIdleAnimatorState76872.AddTransition(diveFromSurfaceAnimatorState78032);
			animatorStateTransition78056.canTransitionToSelf = true;
			animatorStateTransition78056.duration = 0.25f;
			animatorStateTransition78056.exitTime = 0.75f;
			animatorStateTransition78056.hasExitTime = false;
			animatorStateTransition78056.hasFixedDuration = true;
			animatorStateTransition78056.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78056.offset = 0f;
			animatorStateTransition78056.orderedInterruption = true;
			animatorStateTransition78056.isExit = false;
			animatorStateTransition78056.mute = false;
			animatorStateTransition78056.solo = false;
			animatorStateTransition78056.AddCondition(AnimatorConditionMode.Equals, 2f, "AbilityIntData");

			var animatorStateTransition78058 = surfaceIdleAnimatorState76872.AddExitTransition();
			animatorStateTransition78058.canTransitionToSelf = true;
			animatorStateTransition78058.duration = 0.25f;
			animatorStateTransition78058.exitTime = 0.8f;
			animatorStateTransition78058.hasExitTime = false;
			animatorStateTransition78058.hasFixedDuration = true;
			animatorStateTransition78058.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78058.offset = 0f;
			animatorStateTransition78058.orderedInterruption = true;
			animatorStateTransition78058.isExit = true;
			animatorStateTransition78058.mute = false;
			animatorStateTransition78058.solo = false;
			animatorStateTransition78058.AddCondition(AnimatorConditionMode.NotEqual, 301f, "AbilityIndex");

			var animatorStateTransition78060 = surfaceIdleAnimatorState76872.AddTransition(exitWaterIdleAnimatorState78036);
			animatorStateTransition78060.canTransitionToSelf = true;
			animatorStateTransition78060.duration = 0.15f;
			animatorStateTransition78060.exitTime = 0f;
			animatorStateTransition78060.hasExitTime = false;
			animatorStateTransition78060.hasFixedDuration = true;
			animatorStateTransition78060.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78060.offset = 0f;
			animatorStateTransition78060.orderedInterruption = true;
			animatorStateTransition78060.isExit = false;
			animatorStateTransition78060.mute = false;
			animatorStateTransition78060.solo = false;
			animatorStateTransition78060.AddCondition(AnimatorConditionMode.Equals, 4f, "AbilityIntData");

			var animatorStateTransition78062 = surfaceIdleAnimatorState76872.AddTransition(exitWaterMovingAnimatorState78034);
			animatorStateTransition78062.canTransitionToSelf = true;
			animatorStateTransition78062.duration = 0.15f;
			animatorStateTransition78062.exitTime = 2.63155E-10f;
			animatorStateTransition78062.hasExitTime = false;
			animatorStateTransition78062.hasFixedDuration = true;
			animatorStateTransition78062.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78062.offset = 0f;
			animatorStateTransition78062.orderedInterruption = true;
			animatorStateTransition78062.isExit = false;
			animatorStateTransition78062.mute = false;
			animatorStateTransition78062.solo = false;
			animatorStateTransition78062.AddCondition(AnimatorConditionMode.Equals, 3f, "AbilityIntData");

			var animatorStateTransition78064 = surfaceIdleAnimatorState76872.AddTransition(surfaceSwimItemAnimatorState76890);
			animatorStateTransition78064.canTransitionToSelf = true;
			animatorStateTransition78064.duration = 0.4f;
			animatorStateTransition78064.exitTime = 0.8f;
			animatorStateTransition78064.hasExitTime = false;
			animatorStateTransition78064.hasFixedDuration = true;
			animatorStateTransition78064.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78064.offset = 0f;
			animatorStateTransition78064.orderedInterruption = true;
			animatorStateTransition78064.isExit = false;
			animatorStateTransition78064.mute = false;
			animatorStateTransition78064.solo = false;
			animatorStateTransition78064.AddCondition(AnimatorConditionMode.Equals, 1f, "AbilityIntData");
			animatorStateTransition78064.AddCondition(AnimatorConditionMode.If, 0f, "Moving");
			animatorStateTransition78064.AddCondition(AnimatorConditionMode.Greater, 0f, "Slot0ItemID");

			var animatorStateTransition78066 = surfaceSwimAnimatorState76880.AddTransition(exitWaterMovingAnimatorState78034);
			animatorStateTransition78066.canTransitionToSelf = true;
			animatorStateTransition78066.duration = 0.2259974f;
			animatorStateTransition78066.exitTime = 0.010637f;
			animatorStateTransition78066.hasExitTime = false;
			animatorStateTransition78066.hasFixedDuration = true;
			animatorStateTransition78066.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78066.offset = 0f;
			animatorStateTransition78066.orderedInterruption = true;
			animatorStateTransition78066.isExit = false;
			animatorStateTransition78066.mute = false;
			animatorStateTransition78066.solo = false;
			animatorStateTransition78066.AddCondition(AnimatorConditionMode.Equals, 3f, "AbilityIntData");

			var animatorStateTransition78068 = surfaceSwimAnimatorState76880.AddTransition(exitWaterIdleAnimatorState78036);
			animatorStateTransition78068.canTransitionToSelf = true;
			animatorStateTransition78068.duration = 0.15f;
			animatorStateTransition78068.exitTime = 0f;
			animatorStateTransition78068.hasExitTime = false;
			animatorStateTransition78068.hasFixedDuration = true;
			animatorStateTransition78068.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78068.offset = 0f;
			animatorStateTransition78068.orderedInterruption = true;
			animatorStateTransition78068.isExit = false;
			animatorStateTransition78068.mute = false;
			animatorStateTransition78068.solo = false;
			animatorStateTransition78068.AddCondition(AnimatorConditionMode.Equals, 4f, "AbilityIntData");

			var animatorStateTransition78070 = surfaceSwimAnimatorState76880.AddTransition(diveFromSurfaceAnimatorState78032);
			animatorStateTransition78070.canTransitionToSelf = true;
			animatorStateTransition78070.duration = 0.25f;
			animatorStateTransition78070.exitTime = 0.8f;
			animatorStateTransition78070.hasExitTime = false;
			animatorStateTransition78070.hasFixedDuration = true;
			animatorStateTransition78070.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78070.offset = 0f;
			animatorStateTransition78070.orderedInterruption = true;
			animatorStateTransition78070.isExit = false;
			animatorStateTransition78070.mute = false;
			animatorStateTransition78070.solo = false;
			animatorStateTransition78070.AddCondition(AnimatorConditionMode.Equals, 2f, "AbilityIntData");

			var animatorStateTransition78072 = surfaceSwimAnimatorState76880.AddTransition(surfaceIdleAnimatorState76872);
			animatorStateTransition78072.canTransitionToSelf = true;
			animatorStateTransition78072.duration = 0.4f;
			animatorStateTransition78072.exitTime = 0.8f;
			animatorStateTransition78072.hasExitTime = false;
			animatorStateTransition78072.hasFixedDuration = true;
			animatorStateTransition78072.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78072.offset = 0f;
			animatorStateTransition78072.orderedInterruption = true;
			animatorStateTransition78072.isExit = false;
			animatorStateTransition78072.mute = false;
			animatorStateTransition78072.solo = false;
			animatorStateTransition78072.AddCondition(AnimatorConditionMode.Equals, 1f, "AbilityIntData");
			animatorStateTransition78072.AddCondition(AnimatorConditionMode.IfNot, 0f, "Moving");

			var animatorStateTransition78074 = surfaceSwimAnimatorState76880.AddExitTransition();
			animatorStateTransition78074.canTransitionToSelf = true;
			animatorStateTransition78074.duration = 0.25f;
			animatorStateTransition78074.exitTime = 0.8f;
			animatorStateTransition78074.hasExitTime = false;
			animatorStateTransition78074.hasFixedDuration = true;
			animatorStateTransition78074.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78074.offset = 0f;
			animatorStateTransition78074.orderedInterruption = true;
			animatorStateTransition78074.isExit = true;
			animatorStateTransition78074.mute = false;
			animatorStateTransition78074.solo = false;
			animatorStateTransition78074.AddCondition(AnimatorConditionMode.NotEqual, 301f, "AbilityIndex");

			var animatorStateTransition78076 = surfaceSwimAnimatorState76880.AddTransition(surfaceSwimItemAnimatorState76890);
			animatorStateTransition78076.canTransitionToSelf = true;
			animatorStateTransition78076.duration = 0.15f;
			animatorStateTransition78076.exitTime = 0.8f;
			animatorStateTransition78076.hasExitTime = false;
			animatorStateTransition78076.hasFixedDuration = true;
			animatorStateTransition78076.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78076.offset = 0f;
			animatorStateTransition78076.orderedInterruption = true;
			animatorStateTransition78076.isExit = false;
			animatorStateTransition78076.mute = false;
			animatorStateTransition78076.solo = false;
			animatorStateTransition78076.AddCondition(AnimatorConditionMode.Equals, 1f, "AbilityIntData");
			animatorStateTransition78076.AddCondition(AnimatorConditionMode.Greater, 0f, "Slot0ItemID");

			var animatorStateTransition78080 = underwaterSwimAnimatorState76874.AddTransition(surfaceIdleAnimatorState76872);
			animatorStateTransition78080.canTransitionToSelf = true;
			animatorStateTransition78080.duration = 0.1f;
			animatorStateTransition78080.exitTime = 0.8f;
			animatorStateTransition78080.hasExitTime = false;
			animatorStateTransition78080.hasFixedDuration = true;
			animatorStateTransition78080.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78080.offset = 0f;
			animatorStateTransition78080.orderedInterruption = true;
			animatorStateTransition78080.isExit = false;
			animatorStateTransition78080.mute = false;
			animatorStateTransition78080.solo = false;
			animatorStateTransition78080.AddCondition(AnimatorConditionMode.Equals, 1f, "AbilityIntData");
			animatorStateTransition78080.AddCondition(AnimatorConditionMode.IfNot, 0f, "Moving");

			var animatorStateTransition78082 = underwaterSwimAnimatorState76874.AddExitTransition();
			animatorStateTransition78082.canTransitionToSelf = true;
			animatorStateTransition78082.duration = 0.25f;
			animatorStateTransition78082.exitTime = 0.8f;
			animatorStateTransition78082.hasExitTime = false;
			animatorStateTransition78082.hasFixedDuration = true;
			animatorStateTransition78082.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78082.offset = 0f;
			animatorStateTransition78082.orderedInterruption = true;
			animatorStateTransition78082.isExit = true;
			animatorStateTransition78082.mute = false;
			animatorStateTransition78082.solo = false;
			animatorStateTransition78082.AddCondition(AnimatorConditionMode.NotEqual, 301f, "AbilityIndex");

			var animatorStateTransition78084 = underwaterSwimAnimatorState76874.AddTransition(exitWaterMovingAnimatorState78034);
			animatorStateTransition78084.canTransitionToSelf = true;
			animatorStateTransition78084.duration = 0.2259974f;
			animatorStateTransition78084.exitTime = 0.01825405f;
			animatorStateTransition78084.hasExitTime = false;
			animatorStateTransition78084.hasFixedDuration = true;
			animatorStateTransition78084.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78084.offset = 0f;
			animatorStateTransition78084.orderedInterruption = true;
			animatorStateTransition78084.isExit = false;
			animatorStateTransition78084.mute = false;
			animatorStateTransition78084.solo = false;
			animatorStateTransition78084.AddCondition(AnimatorConditionMode.Equals, 3f, "AbilityIntData");

			var animatorStateTransition78086 = underwaterSwimAnimatorState76874.AddTransition(surfaceSwimAnimatorState76880);
			animatorStateTransition78086.canTransitionToSelf = true;
			animatorStateTransition78086.duration = 0.1f;
			animatorStateTransition78086.exitTime = 0.8285714f;
			animatorStateTransition78086.hasExitTime = false;
			animatorStateTransition78086.hasFixedDuration = true;
			animatorStateTransition78086.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78086.offset = 0f;
			animatorStateTransition78086.orderedInterruption = true;
			animatorStateTransition78086.isExit = false;
			animatorStateTransition78086.mute = false;
			animatorStateTransition78086.solo = false;
			animatorStateTransition78086.AddCondition(AnimatorConditionMode.Equals, 1f, "AbilityIntData");
			animatorStateTransition78086.AddCondition(AnimatorConditionMode.If, 0f, "Moving");
			animatorStateTransition78086.AddCondition(AnimatorConditionMode.Equals, 0f, "Slot0ItemID");

			var animatorStateTransition78088 = underwaterSwimAnimatorState76874.AddTransition(underwaterSwimItemAnimatorState76884);
			animatorStateTransition78088.canTransitionToSelf = true;
			animatorStateTransition78088.duration = 0.25f;
			animatorStateTransition78088.exitTime = 0.8285714f;
			animatorStateTransition78088.hasExitTime = false;
			animatorStateTransition78088.hasFixedDuration = true;
			animatorStateTransition78088.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78088.offset = 0f;
			animatorStateTransition78088.orderedInterruption = true;
			animatorStateTransition78088.isExit = false;
			animatorStateTransition78088.mute = false;
			animatorStateTransition78088.solo = false;
			animatorStateTransition78088.AddCondition(AnimatorConditionMode.Equals, 2f, "AbilityIntData");
			animatorStateTransition78088.AddCondition(AnimatorConditionMode.Greater, 0f, "Slot0ItemID");

			var animatorStateTransition78090 = underwaterSwimAnimatorState76874.AddTransition(exitWaterIdleAnimatorState78036);
			animatorStateTransition78090.canTransitionToSelf = true;
			animatorStateTransition78090.duration = 0.15f;
			animatorStateTransition78090.exitTime = 0.8285714f;
			animatorStateTransition78090.hasExitTime = false;
			animatorStateTransition78090.hasFixedDuration = true;
			animatorStateTransition78090.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78090.offset = 0f;
			animatorStateTransition78090.orderedInterruption = true;
			animatorStateTransition78090.isExit = false;
			animatorStateTransition78090.mute = false;
			animatorStateTransition78090.solo = false;
			animatorStateTransition78090.AddCondition(AnimatorConditionMode.Equals, 4f, "AbilityIntData");

			var animatorStateTransition78092 = underwaterSwimAnimatorState76874.AddTransition(surfaceSwimItemAnimatorState76890);
			animatorStateTransition78092.canTransitionToSelf = true;
			animatorStateTransition78092.duration = 0.1f;
			animatorStateTransition78092.exitTime = 0.8217822f;
			animatorStateTransition78092.hasExitTime = false;
			animatorStateTransition78092.hasFixedDuration = true;
			animatorStateTransition78092.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78092.offset = 0f;
			animatorStateTransition78092.orderedInterruption = true;
			animatorStateTransition78092.isExit = false;
			animatorStateTransition78092.mute = false;
			animatorStateTransition78092.solo = false;
			animatorStateTransition78092.AddCondition(AnimatorConditionMode.Equals, 1f, "AbilityIntData");
			animatorStateTransition78092.AddCondition(AnimatorConditionMode.If, 0f, "Moving");
			animatorStateTransition78092.AddCondition(AnimatorConditionMode.Greater, 0f, "Slot0ItemID");

			var animatorStateTransition78102 = diveFromSurfaceAnimatorState78032.AddTransition(underwaterSwimAnimatorState76874);
			animatorStateTransition78102.canTransitionToSelf = true;
			animatorStateTransition78102.duration = 0.25f;
			animatorStateTransition78102.exitTime = 0.88f;
			animatorStateTransition78102.hasExitTime = true;
			animatorStateTransition78102.hasFixedDuration = true;
			animatorStateTransition78102.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78102.offset = 0f;
			animatorStateTransition78102.orderedInterruption = true;
			animatorStateTransition78102.isExit = false;
			animatorStateTransition78102.mute = false;
			animatorStateTransition78102.solo = false;
			animatorStateTransition78102.AddCondition(AnimatorConditionMode.Equals, 0f, "Slot0ItemID");

			var animatorStateTransition78104 = diveFromSurfaceAnimatorState78032.AddTransition(underwaterSwimItemAnimatorState76884);
			animatorStateTransition78104.canTransitionToSelf = true;
			animatorStateTransition78104.duration = 0.25f;
			animatorStateTransition78104.exitTime = 0.88f;
			animatorStateTransition78104.hasExitTime = true;
			animatorStateTransition78104.hasFixedDuration = true;
			animatorStateTransition78104.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78104.offset = 0f;
			animatorStateTransition78104.orderedInterruption = true;
			animatorStateTransition78104.isExit = false;
			animatorStateTransition78104.mute = false;
			animatorStateTransition78104.solo = false;
			animatorStateTransition78104.AddCondition(AnimatorConditionMode.Greater, 0f, "Slot0ItemID");

			var animatorStateTransition78106 = exitWaterMovingAnimatorState78034.AddExitTransition();
			animatorStateTransition78106.canTransitionToSelf = true;
			animatorStateTransition78106.duration = 0.15f;
			animatorStateTransition78106.exitTime = 0.85f;
			animatorStateTransition78106.hasExitTime = true;
			animatorStateTransition78106.hasFixedDuration = true;
			animatorStateTransition78106.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78106.offset = 0f;
			animatorStateTransition78106.orderedInterruption = true;
			animatorStateTransition78106.isExit = true;
			animatorStateTransition78106.mute = false;
			animatorStateTransition78106.solo = false;
			animatorStateTransition78106.AddCondition(AnimatorConditionMode.NotEqual, 301f, "AbilityIndex");

			var animatorStateTransition78108 = exitWaterIdleAnimatorState78036.AddExitTransition();
			animatorStateTransition78108.canTransitionToSelf = true;
			animatorStateTransition78108.duration = 0.1f;
			animatorStateTransition78108.exitTime = 0.65f;
			animatorStateTransition78108.hasExitTime = false;
			animatorStateTransition78108.hasFixedDuration = true;
			animatorStateTransition78108.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78108.offset = 0f;
			animatorStateTransition78108.orderedInterruption = true;
			animatorStateTransition78108.isExit = true;
			animatorStateTransition78108.mute = false;
			animatorStateTransition78108.solo = false;
			animatorStateTransition78108.AddCondition(AnimatorConditionMode.NotEqual, 301f, "AbilityIndex");

			var animatorStateTransition78110 = underwaterSwimItemAnimatorState76884.AddExitTransition();
			animatorStateTransition78110.canTransitionToSelf = true;
			animatorStateTransition78110.duration = 0.25f;
			animatorStateTransition78110.exitTime = 0.8090909f;
			animatorStateTransition78110.hasExitTime = false;
			animatorStateTransition78110.hasFixedDuration = true;
			animatorStateTransition78110.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78110.offset = 0f;
			animatorStateTransition78110.orderedInterruption = true;
			animatorStateTransition78110.isExit = true;
			animatorStateTransition78110.mute = false;
			animatorStateTransition78110.solo = false;
			animatorStateTransition78110.AddCondition(AnimatorConditionMode.NotEqual, 301f, "AbilityIndex");

			var animatorStateTransition78112 = underwaterSwimItemAnimatorState76884.AddTransition(exitWaterMovingAnimatorState78034);
			animatorStateTransition78112.canTransitionToSelf = true;
			animatorStateTransition78112.duration = 0.2259974f;
			animatorStateTransition78112.exitTime = 0.8090909f;
			animatorStateTransition78112.hasExitTime = false;
			animatorStateTransition78112.hasFixedDuration = true;
			animatorStateTransition78112.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78112.offset = 0f;
			animatorStateTransition78112.orderedInterruption = true;
			animatorStateTransition78112.isExit = false;
			animatorStateTransition78112.mute = false;
			animatorStateTransition78112.solo = false;
			animatorStateTransition78112.AddCondition(AnimatorConditionMode.Equals, 3f, "AbilityIntData");

			var animatorStateTransition78114 = underwaterSwimItemAnimatorState76884.AddTransition(surfaceIdleAnimatorState76872);
			animatorStateTransition78114.canTransitionToSelf = true;
			animatorStateTransition78114.duration = 0.1f;
			animatorStateTransition78114.exitTime = 0.8090909f;
			animatorStateTransition78114.hasExitTime = false;
			animatorStateTransition78114.hasFixedDuration = true;
			animatorStateTransition78114.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78114.offset = 0f;
			animatorStateTransition78114.orderedInterruption = true;
			animatorStateTransition78114.isExit = false;
			animatorStateTransition78114.mute = false;
			animatorStateTransition78114.solo = false;
			animatorStateTransition78114.AddCondition(AnimatorConditionMode.Equals, 1f, "AbilityIntData");
			animatorStateTransition78114.AddCondition(AnimatorConditionMode.IfNot, 0f, "Moving");

			var animatorStateTransition78116 = underwaterSwimItemAnimatorState76884.AddTransition(surfaceSwimAnimatorState76880);
			animatorStateTransition78116.canTransitionToSelf = true;
			animatorStateTransition78116.duration = 0.1f;
			animatorStateTransition78116.exitTime = 0.8090909f;
			animatorStateTransition78116.hasExitTime = false;
			animatorStateTransition78116.hasFixedDuration = true;
			animatorStateTransition78116.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78116.offset = 0f;
			animatorStateTransition78116.orderedInterruption = true;
			animatorStateTransition78116.isExit = false;
			animatorStateTransition78116.mute = false;
			animatorStateTransition78116.solo = false;
			animatorStateTransition78116.AddCondition(AnimatorConditionMode.Equals, 1f, "AbilityIntData");
			animatorStateTransition78116.AddCondition(AnimatorConditionMode.If, 0f, "Moving");
			animatorStateTransition78116.AddCondition(AnimatorConditionMode.Equals, 0f, "Slot0ItemID");

			var animatorStateTransition78118 = underwaterSwimItemAnimatorState76884.AddTransition(underwaterSwimAnimatorState76874);
			animatorStateTransition78118.canTransitionToSelf = true;
			animatorStateTransition78118.duration = 0.25f;
			animatorStateTransition78118.exitTime = 0.8090909f;
			animatorStateTransition78118.hasExitTime = false;
			animatorStateTransition78118.hasFixedDuration = true;
			animatorStateTransition78118.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78118.offset = 0f;
			animatorStateTransition78118.orderedInterruption = true;
			animatorStateTransition78118.isExit = false;
			animatorStateTransition78118.mute = false;
			animatorStateTransition78118.solo = false;
			animatorStateTransition78118.AddCondition(AnimatorConditionMode.Equals, 2f, "AbilityIntData");
			animatorStateTransition78118.AddCondition(AnimatorConditionMode.Equals, 0f, "Slot0ItemID");

			var animatorStateTransition78120 = underwaterSwimItemAnimatorState76884.AddTransition(surfaceSwimItemAnimatorState76890);
			animatorStateTransition78120.canTransitionToSelf = true;
			animatorStateTransition78120.duration = 0.1f;
			animatorStateTransition78120.exitTime = 0.82f;
			animatorStateTransition78120.hasExitTime = false;
			animatorStateTransition78120.hasFixedDuration = true;
			animatorStateTransition78120.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78120.offset = 0f;
			animatorStateTransition78120.orderedInterruption = true;
			animatorStateTransition78120.isExit = false;
			animatorStateTransition78120.mute = false;
			animatorStateTransition78120.solo = false;
			animatorStateTransition78120.AddCondition(AnimatorConditionMode.Equals, 1f, "AbilityIntData");
			animatorStateTransition78120.AddCondition(AnimatorConditionMode.If, 0f, "Moving");
			animatorStateTransition78120.AddCondition(AnimatorConditionMode.Greater, 0f, "Slot0ItemID");

			var animatorStateTransition78128 = surfaceSwimItemAnimatorState76890.AddTransition(exitWaterMovingAnimatorState78034);
			animatorStateTransition78128.canTransitionToSelf = true;
			animatorStateTransition78128.duration = 0.2259974f;
			animatorStateTransition78128.exitTime = 0.8f;
			animatorStateTransition78128.hasExitTime = false;
			animatorStateTransition78128.hasFixedDuration = true;
			animatorStateTransition78128.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78128.offset = 0f;
			animatorStateTransition78128.orderedInterruption = true;
			animatorStateTransition78128.isExit = false;
			animatorStateTransition78128.mute = false;
			animatorStateTransition78128.solo = false;
			animatorStateTransition78128.AddCondition(AnimatorConditionMode.Equals, 3f, "AbilityIntData");

			var animatorStateTransition78130 = surfaceSwimItemAnimatorState76890.AddTransition(exitWaterIdleAnimatorState78036);
			animatorStateTransition78130.canTransitionToSelf = true;
			animatorStateTransition78130.duration = 0.15f;
			animatorStateTransition78130.exitTime = 0.8f;
			animatorStateTransition78130.hasExitTime = false;
			animatorStateTransition78130.hasFixedDuration = true;
			animatorStateTransition78130.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78130.offset = 0f;
			animatorStateTransition78130.orderedInterruption = true;
			animatorStateTransition78130.isExit = false;
			animatorStateTransition78130.mute = false;
			animatorStateTransition78130.solo = false;
			animatorStateTransition78130.AddCondition(AnimatorConditionMode.Equals, 4f, "AbilityIntData");

			var animatorStateTransition78132 = surfaceSwimItemAnimatorState76890.AddTransition(surfaceIdleAnimatorState76872);
			animatorStateTransition78132.canTransitionToSelf = true;
			animatorStateTransition78132.duration = 0.4f;
			animatorStateTransition78132.exitTime = 0.8f;
			animatorStateTransition78132.hasExitTime = false;
			animatorStateTransition78132.hasFixedDuration = true;
			animatorStateTransition78132.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78132.offset = 0f;
			animatorStateTransition78132.orderedInterruption = true;
			animatorStateTransition78132.isExit = false;
			animatorStateTransition78132.mute = false;
			animatorStateTransition78132.solo = false;
			animatorStateTransition78132.AddCondition(AnimatorConditionMode.Equals, 1f, "AbilityIntData");
			animatorStateTransition78132.AddCondition(AnimatorConditionMode.IfNot, 0f, "Moving");

			var animatorStateTransition78134 = surfaceSwimItemAnimatorState76890.AddTransition(diveFromSurfaceAnimatorState78032);
			animatorStateTransition78134.canTransitionToSelf = true;
			animatorStateTransition78134.duration = 0.25f;
			animatorStateTransition78134.exitTime = 0.8f;
			animatorStateTransition78134.hasExitTime = false;
			animatorStateTransition78134.hasFixedDuration = true;
			animatorStateTransition78134.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78134.offset = 0f;
			animatorStateTransition78134.orderedInterruption = true;
			animatorStateTransition78134.isExit = false;
			animatorStateTransition78134.mute = false;
			animatorStateTransition78134.solo = false;
			animatorStateTransition78134.AddCondition(AnimatorConditionMode.Equals, 2f, "AbilityIntData");

			var animatorStateTransition78136 = surfaceSwimItemAnimatorState76890.AddExitTransition();
			animatorStateTransition78136.canTransitionToSelf = true;
			animatorStateTransition78136.duration = 0.25f;
			animatorStateTransition78136.exitTime = 0.8f;
			animatorStateTransition78136.hasExitTime = false;
			animatorStateTransition78136.hasFixedDuration = true;
			animatorStateTransition78136.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78136.offset = 0f;
			animatorStateTransition78136.orderedInterruption = true;
			animatorStateTransition78136.isExit = true;
			animatorStateTransition78136.mute = false;
			animatorStateTransition78136.solo = false;
			animatorStateTransition78136.AddCondition(AnimatorConditionMode.NotEqual, 301f, "AbilityIndex");

			var animatorStateTransition78138 = surfaceSwimItemAnimatorState76890.AddTransition(surfaceSwimAnimatorState76880);
			animatorStateTransition78138.canTransitionToSelf = true;
			animatorStateTransition78138.duration = 0.15f;
			animatorStateTransition78138.exitTime = 0.8f;
			animatorStateTransition78138.hasExitTime = false;
			animatorStateTransition78138.hasFixedDuration = true;
			animatorStateTransition78138.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78138.offset = 0f;
			animatorStateTransition78138.orderedInterruption = true;
			animatorStateTransition78138.isExit = false;
			animatorStateTransition78138.mute = false;
			animatorStateTransition78138.solo = false;
			animatorStateTransition78138.AddCondition(AnimatorConditionMode.Equals, 1f, "AbilityIntData");
			animatorStateTransition78138.AddCondition(AnimatorConditionMode.Equals, 0f, "Slot0ItemID");


			// State Machine Transitions.
			var animatorStateTransition76580 = baseStateMachine1709684174.AddAnyStateTransition(fallInWaterAnimatorState76870);
			animatorStateTransition76580.canTransitionToSelf = false;
			animatorStateTransition76580.duration = 0.25f;
			animatorStateTransition76580.exitTime = 0.75f;
			animatorStateTransition76580.hasExitTime = false;
			animatorStateTransition76580.hasFixedDuration = true;
			animatorStateTransition76580.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition76580.offset = 0f;
			animatorStateTransition76580.orderedInterruption = true;
			animatorStateTransition76580.isExit = false;
			animatorStateTransition76580.mute = false;
			animatorStateTransition76580.solo = false;
			animatorStateTransition76580.AddCondition(AnimatorConditionMode.If, 0f, "AbilityChange");
			animatorStateTransition76580.AddCondition(AnimatorConditionMode.Equals, 301f, "AbilityIndex");
			animatorStateTransition76580.AddCondition(AnimatorConditionMode.Equals, 0f, "AbilityIntData");

			var animatorStateTransition76582 = baseStateMachine1709684174.AddAnyStateTransition(surfaceIdleAnimatorState76872);
			animatorStateTransition76582.canTransitionToSelf = false;
			animatorStateTransition76582.duration = 0.25f;
			animatorStateTransition76582.exitTime = 0.75f;
			animatorStateTransition76582.hasExitTime = false;
			animatorStateTransition76582.hasFixedDuration = true;
			animatorStateTransition76582.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition76582.offset = 0f;
			animatorStateTransition76582.orderedInterruption = true;
			animatorStateTransition76582.isExit = false;
			animatorStateTransition76582.mute = false;
			animatorStateTransition76582.solo = false;
			animatorStateTransition76582.AddCondition(AnimatorConditionMode.If, 0f, "AbilityChange");
			animatorStateTransition76582.AddCondition(AnimatorConditionMode.Equals, 301f, "AbilityIndex");
			animatorStateTransition76582.AddCondition(AnimatorConditionMode.Equals, 1f, "AbilityIntData");
			animatorStateTransition76582.AddCondition(AnimatorConditionMode.IfNot, 0f, "Moving");

			var animatorStateTransition76584 = baseStateMachine1709684174.AddAnyStateTransition(underwaterSwimAnimatorState76874);
			animatorStateTransition76584.canTransitionToSelf = false;
			animatorStateTransition76584.duration = 0.25f;
			animatorStateTransition76584.exitTime = 0.75f;
			animatorStateTransition76584.hasExitTime = false;
			animatorStateTransition76584.hasFixedDuration = true;
			animatorStateTransition76584.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition76584.offset = 0f;
			animatorStateTransition76584.orderedInterruption = true;
			animatorStateTransition76584.isExit = false;
			animatorStateTransition76584.mute = false;
			animatorStateTransition76584.solo = false;
			animatorStateTransition76584.AddCondition(AnimatorConditionMode.If, 0f, "AbilityChange");
			animatorStateTransition76584.AddCondition(AnimatorConditionMode.Equals, 301f, "AbilityIndex");
			animatorStateTransition76584.AddCondition(AnimatorConditionMode.Equals, 2f, "AbilityIntData");
			animatorStateTransition76584.AddCondition(AnimatorConditionMode.Equals, 0f, "Slot0ItemID");

			var animatorStateTransition76590 = baseStateMachine1709684174.AddAnyStateTransition(surfaceSwimAnimatorState76880);
			animatorStateTransition76590.canTransitionToSelf = false;
			animatorStateTransition76590.duration = 0.25f;
			animatorStateTransition76590.exitTime = 0.75f;
			animatorStateTransition76590.hasExitTime = false;
			animatorStateTransition76590.hasFixedDuration = true;
			animatorStateTransition76590.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition76590.offset = 0f;
			animatorStateTransition76590.orderedInterruption = true;
			animatorStateTransition76590.isExit = false;
			animatorStateTransition76590.mute = false;
			animatorStateTransition76590.solo = false;
			animatorStateTransition76590.AddCondition(AnimatorConditionMode.If, 0f, "AbilityChange");
			animatorStateTransition76590.AddCondition(AnimatorConditionMode.Equals, 301f, "AbilityIndex");
			animatorStateTransition76590.AddCondition(AnimatorConditionMode.Equals, 1f, "AbilityIntData");
			animatorStateTransition76590.AddCondition(AnimatorConditionMode.If, 0f, "Moving");
			animatorStateTransition76590.AddCondition(AnimatorConditionMode.Equals, 0f, "Slot0ItemID");

			var animatorStateTransition76594 = baseStateMachine1709684174.AddAnyStateTransition(underwaterSwimItemAnimatorState76884);
			animatorStateTransition76594.canTransitionToSelf = false;
			animatorStateTransition76594.duration = 0.25f;
			animatorStateTransition76594.exitTime = 0.75f;
			animatorStateTransition76594.hasExitTime = false;
			animatorStateTransition76594.hasFixedDuration = true;
			animatorStateTransition76594.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition76594.offset = 0f;
			animatorStateTransition76594.orderedInterruption = true;
			animatorStateTransition76594.isExit = false;
			animatorStateTransition76594.mute = false;
			animatorStateTransition76594.solo = false;
			animatorStateTransition76594.AddCondition(AnimatorConditionMode.If, 0f, "AbilityChange");
			animatorStateTransition76594.AddCondition(AnimatorConditionMode.Equals, 301f, "AbilityIndex");
			animatorStateTransition76594.AddCondition(AnimatorConditionMode.Equals, 2f, "AbilityIntData");
			animatorStateTransition76594.AddCondition(AnimatorConditionMode.Greater, 0f, "Slot0ItemID");

			var animatorStateTransition76604 = baseStateMachine1709684174.AddAnyStateTransition(surfaceSwimItemAnimatorState76890);
			animatorStateTransition76604.canTransitionToSelf = false;
			animatorStateTransition76604.duration = 0.25f;
			animatorStateTransition76604.exitTime = 0.75f;
			animatorStateTransition76604.hasExitTime = false;
			animatorStateTransition76604.hasFixedDuration = true;
			animatorStateTransition76604.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition76604.offset = 0f;
			animatorStateTransition76604.orderedInterruption = true;
			animatorStateTransition76604.isExit = false;
			animatorStateTransition76604.mute = false;
			animatorStateTransition76604.solo = false;
			animatorStateTransition76604.AddCondition(AnimatorConditionMode.If, 0f, "AbilityChange");
			animatorStateTransition76604.AddCondition(AnimatorConditionMode.Equals, 301f, "AbilityIndex");
			animatorStateTransition76604.AddCondition(AnimatorConditionMode.Equals, 1f, "AbilityIntData");
			animatorStateTransition76604.AddCondition(AnimatorConditionMode.If, 0f, "Moving");
			animatorStateTransition76604.AddCondition(AnimatorConditionMode.Greater, 0f, "Slot0ItemID");

			if (animatorController.layers.Length <= 3) {
				Debug.LogWarning("Warning: The animator controller does not contain the same number of layers as the demo animator. All of the animations cannot be added.");
				return;
			}

			var baseStateMachine1672981860 = animatorController.layers[3].stateMachine;

			// The state machine should start fresh.
			for (int i = 0; i < animatorController.layers.Length; ++i) {
				for (int j = 0; j < baseStateMachine1672981860.stateMachines.Length; ++j) {
					if (baseStateMachine1672981860.stateMachines[j].stateMachine.name == "Trident") {
						baseStateMachine1672981860.RemoveStateMachine(baseStateMachine1672981860.stateMachines[j].stateMachine);
						break;
					}
				}
			}

			// AnimationClip references.
			var tridentAimBwdAnimationClip64634Path = AssetDatabase.GUIDToAssetPath("b52b8b4fd9045e640aefcd13a1ae0170"); 
			var tridentAimBwdAnimationClip64634 = AnimatorBuilder.GetAnimationClip(tridentAimBwdAnimationClip64634Path, "TridentAimBwd");
			var tridentAimStrafeAnimationClip64646Path = AssetDatabase.GUIDToAssetPath("3b23654596ddfed499a0c096c21cde62"); 
			var tridentAimStrafeAnimationClip64646 = AnimatorBuilder.GetAnimationClip(tridentAimStrafeAnimationClip64646Path, "TridentAimStrafe");
			var tridentAimAnimationClip64628Path = AssetDatabase.GUIDToAssetPath("7459c2971979759458a27b9871d48f71"); 
			var tridentAimAnimationClip64628 = AnimatorBuilder.GetAnimationClip(tridentAimAnimationClip64628Path, "TridentAim");
			var tridentAimLandAnimationClip64640Path = AssetDatabase.GUIDToAssetPath("2ead76e2020b8f044a5a00dbf8bb2de1"); 
			var tridentAimLandAnimationClip64640 = AnimatorBuilder.GetAnimationClip(tridentAimLandAnimationClip64640Path, "TridentAimLand");

			// State Machine.
			var tridentAnimatorStateMachine78244 = baseStateMachine1672981860.AddStateMachine("Trident", new Vector3(624f, 204f, 0f));

			// States.
			var aimWaterAnimatorState78646 = tridentAnimatorStateMachine78244.AddState("Aim Water", new Vector3(384f, 60f, 0f));
			var aimWaterAnimatorState78646blendTreeBlendTree79060 = new BlendTree();
			AssetDatabase.AddObjectToAsset(aimWaterAnimatorState78646blendTreeBlendTree79060, animatorController);
			aimWaterAnimatorState78646blendTreeBlendTree79060.hideFlags = HideFlags.HideInHierarchy;
			aimWaterAnimatorState78646blendTreeBlendTree79060.blendParameter = "HorizontalMovement";
			aimWaterAnimatorState78646blendTreeBlendTree79060.blendParameterY = "ForwardMovement";
			aimWaterAnimatorState78646blendTreeBlendTree79060.blendType = BlendTreeType.FreeformCartesian2D;
			aimWaterAnimatorState78646blendTreeBlendTree79060.maxThreshold = 1f;
			aimWaterAnimatorState78646blendTreeBlendTree79060.minThreshold = 0f;
			aimWaterAnimatorState78646blendTreeBlendTree79060.name = "Blend Tree";
			aimWaterAnimatorState78646blendTreeBlendTree79060.useAutomaticThresholds = true;
			var aimWaterAnimatorState78646blendTreeBlendTree79060Child0 =  new ChildMotion();
			aimWaterAnimatorState78646blendTreeBlendTree79060Child0.motion = tridentAimBwdAnimationClip64634;
			aimWaterAnimatorState78646blendTreeBlendTree79060Child0.cycleOffset = 0f;
			aimWaterAnimatorState78646blendTreeBlendTree79060Child0.directBlendParameter = "HorizontalMovement";
			aimWaterAnimatorState78646blendTreeBlendTree79060Child0.mirror = false;
			aimWaterAnimatorState78646blendTreeBlendTree79060Child0.position = new Vector2(0f, -1f);
			aimWaterAnimatorState78646blendTreeBlendTree79060Child0.threshold = 0f;
			aimWaterAnimatorState78646blendTreeBlendTree79060Child0.timeScale = 1f;
			var aimWaterAnimatorState78646blendTreeBlendTree79060Child1 =  new ChildMotion();
			aimWaterAnimatorState78646blendTreeBlendTree79060Child1.motion = tridentAimStrafeAnimationClip64646;
			aimWaterAnimatorState78646blendTreeBlendTree79060Child1.cycleOffset = 0f;
			aimWaterAnimatorState78646blendTreeBlendTree79060Child1.directBlendParameter = "HorizontalMovement";
			aimWaterAnimatorState78646blendTreeBlendTree79060Child1.mirror = false;
			aimWaterAnimatorState78646blendTreeBlendTree79060Child1.position = new Vector2(-1f, 0f);
			aimWaterAnimatorState78646blendTreeBlendTree79060Child1.threshold = 0.25f;
			aimWaterAnimatorState78646blendTreeBlendTree79060Child1.timeScale = 1f;
			var aimWaterAnimatorState78646blendTreeBlendTree79060Child2 =  new ChildMotion();
			aimWaterAnimatorState78646blendTreeBlendTree79060Child2.motion = tridentAimAnimationClip64628;
			aimWaterAnimatorState78646blendTreeBlendTree79060Child2.cycleOffset = 0f;
			aimWaterAnimatorState78646blendTreeBlendTree79060Child2.directBlendParameter = "HorizontalMovement";
			aimWaterAnimatorState78646blendTreeBlendTree79060Child2.mirror = false;
			aimWaterAnimatorState78646blendTreeBlendTree79060Child2.position = new Vector2(0f, 0f);
			aimWaterAnimatorState78646blendTreeBlendTree79060Child2.threshold = 0.5f;
			aimWaterAnimatorState78646blendTreeBlendTree79060Child2.timeScale = 1f;
			var aimWaterAnimatorState78646blendTreeBlendTree79060Child3 =  new ChildMotion();
			aimWaterAnimatorState78646blendTreeBlendTree79060Child3.motion = tridentAimStrafeAnimationClip64646;
			aimWaterAnimatorState78646blendTreeBlendTree79060Child3.cycleOffset = 0f;
			aimWaterAnimatorState78646blendTreeBlendTree79060Child3.directBlendParameter = "HorizontalMovement";
			aimWaterAnimatorState78646blendTreeBlendTree79060Child3.mirror = false;
			aimWaterAnimatorState78646blendTreeBlendTree79060Child3.position = new Vector2(1f, 0f);
			aimWaterAnimatorState78646blendTreeBlendTree79060Child3.threshold = 0.75f;
			aimWaterAnimatorState78646blendTreeBlendTree79060Child3.timeScale = 1f;
			var aimWaterAnimatorState78646blendTreeBlendTree79060Child4 =  new ChildMotion();
			aimWaterAnimatorState78646blendTreeBlendTree79060Child4.motion = tridentAimAnimationClip64628;
			aimWaterAnimatorState78646blendTreeBlendTree79060Child4.cycleOffset = 0f;
			aimWaterAnimatorState78646blendTreeBlendTree79060Child4.directBlendParameter = "HorizontalMovement";
			aimWaterAnimatorState78646blendTreeBlendTree79060Child4.mirror = false;
			aimWaterAnimatorState78646blendTreeBlendTree79060Child4.position = new Vector2(0f, 1f);
			aimWaterAnimatorState78646blendTreeBlendTree79060Child4.threshold = 1f;
			aimWaterAnimatorState78646blendTreeBlendTree79060Child4.timeScale = 1f;
			aimWaterAnimatorState78646blendTreeBlendTree79060.children = new ChildMotion[] {
				aimWaterAnimatorState78646blendTreeBlendTree79060Child0,
				aimWaterAnimatorState78646blendTreeBlendTree79060Child1,
				aimWaterAnimatorState78646blendTreeBlendTree79060Child2,
				aimWaterAnimatorState78646blendTreeBlendTree79060Child3,
				aimWaterAnimatorState78646blendTreeBlendTree79060Child4
			};
			aimWaterAnimatorState78646.motion = aimWaterAnimatorState78646blendTreeBlendTree79060;
			aimWaterAnimatorState78646.cycleOffset = 0f;
			aimWaterAnimatorState78646.cycleOffsetParameterActive = false;
			aimWaterAnimatorState78646.iKOnFeet = false;
			aimWaterAnimatorState78646.mirror = false;
			aimWaterAnimatorState78646.mirrorParameterActive = false;
			aimWaterAnimatorState78646.speed = 1f;
			aimWaterAnimatorState78646.speedParameterActive = false;
			aimWaterAnimatorState78646.writeDefaultValues = true;

			var aimLandAnimatorState78678 = tridentAnimatorStateMachine78244.AddState("Aim Land", new Vector3(384f, 0f, 0f));
			aimLandAnimatorState78678.motion = tridentAimLandAnimationClip64640;
			aimLandAnimatorState78678.cycleOffset = 0f;
			aimLandAnimatorState78678.cycleOffsetParameterActive = false;
			aimLandAnimatorState78678.iKOnFeet = false;
			aimLandAnimatorState78678.mirror = false;
			aimLandAnimatorState78678.mirrorParameterActive = false;
			aimLandAnimatorState78678.speed = 1f;
			aimLandAnimatorState78678.speedParameterActive = false;
			aimLandAnimatorState78678.writeDefaultValues = true;

			// State Machine Defaults.
			tridentAnimatorStateMachine78244.anyStatePosition = new Vector3(50f, 20f, 0f);
			tridentAnimatorStateMachine78244.defaultState = aimWaterAnimatorState78646;
			tridentAnimatorStateMachine78244.entryPosition = new Vector3(50f, 120f, 0f);
			tridentAnimatorStateMachine78244.exitPosition = new Vector3(800f, 120f, 0f);
			tridentAnimatorStateMachine78244.parentStateMachinePosition = new Vector3(800f, 20f, 0f);

			if (animatorController.layers.Length <= 3) {
				Debug.LogWarning("Warning: The animator controller does not contain the same number of layers as the demo animator. All of the animations cannot be added.");
				return;
			}

			var baseStateMachine1742974310 = animatorController.layers[3].stateMachine;

			// The state machine should start fresh.
			for (int i = 0; i < animatorController.layers.Length; ++i) {
				for (int j = 0; j < baseStateMachine1742974310.stateMachines.Length; ++j) {
					if (baseStateMachine1742974310.stateMachines[j].stateMachine.name == "Underwater Gun") {
						baseStateMachine1742974310.RemoveStateMachine(baseStateMachine1742974310.stateMachines[j].stateMachine);
						break;
					}
				}
			}

			// AnimationClip references.
			var underwaterGunUnequipFromAimLandAnimationClip64994Path = AssetDatabase.GUIDToAssetPath("721f647ca7925b545ac8c7f61fc52e70"); 
			var underwaterGunUnequipFromAimLandAnimationClip64994 = AnimatorBuilder.GetAnimationClip(underwaterGunUnequipFromAimLandAnimationClip64994Path, "UnderwaterGunUnequipFromAimLand");
			var underwaterGunEquipFromAimLandAnimationClip64922Path = AssetDatabase.GUIDToAssetPath("ca1e4aa3f69753b49a943a147431fa92"); 
			var underwaterGunEquipFromAimLandAnimationClip64922 = AnimatorBuilder.GetAnimationClip(underwaterGunEquipFromAimLandAnimationClip64922Path, "UnderwaterGunEquipFromAimLand");
			var underwaterGunEquipFromIdleLandAnimationClip64940Path = AssetDatabase.GUIDToAssetPath("79dd6fe7e9b79e24f8e03530a53ffac6"); 
			var underwaterGunEquipFromIdleLandAnimationClip64940 = AnimatorBuilder.GetAnimationClip(underwaterGunEquipFromIdleLandAnimationClip64940Path, "UnderwaterGunEquipFromIdleLand");
			var underwaterGunDropLandAnimationClip64904Path = AssetDatabase.GUIDToAssetPath("10638b29e54942c4a85aed37b4ffb959"); 
			var underwaterGunDropLandAnimationClip64904 = AnimatorBuilder.GetAnimationClip(underwaterGunDropLandAnimationClip64904Path, "UnderwaterGunDropLand");
			var underwaterGunIdleLandAnimationClip64976Path = AssetDatabase.GUIDToAssetPath("d5ac8d1801a8b2b42bf9f42101d745a0"); 
			var underwaterGunIdleLandAnimationClip64976 = AnimatorBuilder.GetAnimationClip(underwaterGunIdleLandAnimationClip64976Path, "UnderwaterGunIdleLand");
			var underwaterGunAimLandAnimationClip64886Path = AssetDatabase.GUIDToAssetPath("61c2f2ac67418014bb259550547d31c7"); 
			var underwaterGunAimLandAnimationClip64886 = AnimatorBuilder.GetAnimationClip(underwaterGunAimLandAnimationClip64886Path, "UnderwaterGunAimLand");
			var underwaterGunFireLandAnimationClip64958Path = AssetDatabase.GUIDToAssetPath("2c4975bc16f2e2d488e6705318e32a92"); 
			var underwaterGunFireLandAnimationClip64958 = AnimatorBuilder.GetAnimationClip(underwaterGunFireLandAnimationClip64958Path, "UnderwaterGunFireLand");
			var underwaterGunFireStrafeAnimationClip64964Path = AssetDatabase.GUIDToAssetPath("9c1724098a8521747acf7a5b0e63cc67"); 
			var underwaterGunFireStrafeAnimationClip64964 = AnimatorBuilder.GetAnimationClip(underwaterGunFireStrafeAnimationClip64964Path, "UnderwaterGunFireStrafe");
			var underwaterGunFireAnimationClip64952Path = AssetDatabase.GUIDToAssetPath("18156ecfb59e8ae4595703fddc1939a4"); 
			var underwaterGunFireAnimationClip64952 = AnimatorBuilder.GetAnimationClip(underwaterGunFireAnimationClip64952Path, "UnderwaterGunFire");
			var underwaterGunAimStrafeAnimationClip64892Path = AssetDatabase.GUIDToAssetPath("e0859a37264257345b1b27f8f2adace1"); 
			var underwaterGunAimStrafeAnimationClip64892 = AnimatorBuilder.GetAnimationClip(underwaterGunAimStrafeAnimationClip64892Path, "UnderwaterGunAimStrafe");
			var underwaterGunAimAnimationClip64880Path = AssetDatabase.GUIDToAssetPath("ea90e76c69b5dac41b0f0dbee1c486fe"); 
			var underwaterGunAimAnimationClip64880 = AnimatorBuilder.GetAnimationClip(underwaterGunAimAnimationClip64880Path, "UnderwaterGunAim");
			var underwaterGunIdleStrafeAnimationClip64982Path = AssetDatabase.GUIDToAssetPath("1ce7681d2f2345b4e881131942d5eb7b"); 
			var underwaterGunIdleStrafeAnimationClip64982 = AnimatorBuilder.GetAnimationClip(underwaterGunIdleStrafeAnimationClip64982Path, "UnderwaterGunIdleStrafe");
			var underwaterGunIdleAnimationClip64970Path = AssetDatabase.GUIDToAssetPath("dd83fc596d1210143bc3b2b50c61124e"); 
			var underwaterGunIdleAnimationClip64970 = AnimatorBuilder.GetAnimationClip(underwaterGunIdleAnimationClip64970Path, "UnderwaterGunIdle");
			var underwaterGunDropStrafeAnimationClip64910Path = AssetDatabase.GUIDToAssetPath("a68a1714e46821741b53ae17a67efa4c"); 
			var underwaterGunDropStrafeAnimationClip64910 = AnimatorBuilder.GetAnimationClip(underwaterGunDropStrafeAnimationClip64910Path, "UnderwaterGunDropStrafe");
			var underwaterGunDropAnimationClip64898Path = AssetDatabase.GUIDToAssetPath("b4d39e80ba9664840abca8241b43665f"); 
			var underwaterGunDropAnimationClip64898 = AnimatorBuilder.GetAnimationClip(underwaterGunDropAnimationClip64898Path, "UnderwaterGunDrop");
			var underwaterGunEquipFromIdleStrafeAnimationClip64946Path = AssetDatabase.GUIDToAssetPath("567464df1b0be0c4682de5c69b509784"); 
			var underwaterGunEquipFromIdleStrafeAnimationClip64946 = AnimatorBuilder.GetAnimationClip(underwaterGunEquipFromIdleStrafeAnimationClip64946Path, "UnderwaterGunEquipFromIdleStrafe");
			var underwaterGunEquipFromIdleAnimationClip64934Path = AssetDatabase.GUIDToAssetPath("085123f580067e9408bb4644102a74fb"); 
			var underwaterGunEquipFromIdleAnimationClip64934 = AnimatorBuilder.GetAnimationClip(underwaterGunEquipFromIdleAnimationClip64934Path, "UnderwaterGunEquipFromIdle");
			var underwaterGunEquipFromAimStrafeAnimationClip64928Path = AssetDatabase.GUIDToAssetPath("5bb3fdd8073bd3145b5b2928c66c734f"); 
			var underwaterGunEquipFromAimStrafeAnimationClip64928 = AnimatorBuilder.GetAnimationClip(underwaterGunEquipFromAimStrafeAnimationClip64928Path, "UnderwaterGunEquipFromAimStrafe");
			var underwaterGunEquipFromAimAnimationClip64916Path = AssetDatabase.GUIDToAssetPath("afd46ae593ba8c04a82c28b5bdf0e36a"); 
			var underwaterGunEquipFromAimAnimationClip64916 = AnimatorBuilder.GetAnimationClip(underwaterGunEquipFromAimAnimationClip64916Path, "UnderwaterGunEquipFromAim");
			var underwaterGunUnequipFromAimStrafeAnimationClip65000Path = AssetDatabase.GUIDToAssetPath("75639ef9d4aa3b74c82c8ad6b9708bd3"); 
			var underwaterGunUnequipFromAimStrafeAnimationClip65000 = AnimatorBuilder.GetAnimationClip(underwaterGunUnequipFromAimStrafeAnimationClip65000Path, "UnderwaterGunUnequipFromAimStrafe");
			var underwaterGunUnequipFromAimAnimationClip64988Path = AssetDatabase.GUIDToAssetPath("c81201e8deaa85147bf8993a3fca205f"); 
			var underwaterGunUnequipFromAimAnimationClip64988 = AnimatorBuilder.GetAnimationClip(underwaterGunUnequipFromAimAnimationClip64988Path, "UnderwaterGunUnequipFromAim");
			var underwaterGunUnequipFromIdleLandAnimationClip65012Path = AssetDatabase.GUIDToAssetPath("7d0010c9ac2cd534dbda1b07ee98a9cd"); 
			var underwaterGunUnequipFromIdleLandAnimationClip65012 = AnimatorBuilder.GetAnimationClip(underwaterGunUnequipFromIdleLandAnimationClip65012Path, "UnderwaterGunUnequipFromIdleLand");
			var underwaterGunUnequipFromIdleStrafeAnimationClip65018Path = AssetDatabase.GUIDToAssetPath("ded0b711b659eca43a979b6fa2300874"); 
			var underwaterGunUnequipFromIdleStrafeAnimationClip65018 = AnimatorBuilder.GetAnimationClip(underwaterGunUnequipFromIdleStrafeAnimationClip65018Path, "UnderwaterGunUnequipFromIdleStrafe");
			var underwaterGunUnequipFromIdleAnimationClip65006Path = AssetDatabase.GUIDToAssetPath("ce536312b48abf34a8f6590cece82921"); 
			var underwaterGunUnequipFromIdleAnimationClip65006 = AnimatorBuilder.GetAnimationClip(underwaterGunUnequipFromIdleAnimationClip65006Path, "UnderwaterGunUnequipFromIdle");

			// State Machine.
			var underwaterGunAnimatorStateMachine78246 = baseStateMachine1742974310.AddStateMachine("Underwater Gun", new Vector3(384f, 348f, 0f));

			// States.
			var unequipFromIdleLandAnimatorState78648 = underwaterGunAnimatorStateMachine78246.AddState("Unequip From Idle Land", new Vector3(384f, -36f, 0f));
			unequipFromIdleLandAnimatorState78648.motion = underwaterGunUnequipFromAimLandAnimationClip64994;
			unequipFromIdleLandAnimatorState78648.cycleOffset = 0f;
			unequipFromIdleLandAnimatorState78648.cycleOffsetParameterActive = false;
			unequipFromIdleLandAnimatorState78648.iKOnFeet = false;
			unequipFromIdleLandAnimatorState78648.mirror = false;
			unequipFromIdleLandAnimatorState78648.mirrorParameterActive = false;
			unequipFromIdleLandAnimatorState78648.speed = 3f;
			unequipFromIdleLandAnimatorState78648.speedParameterActive = false;
			unequipFromIdleLandAnimatorState78648.writeDefaultValues = true;

			var unequipFromAimLandAnimatorState78650 = underwaterGunAnimatorStateMachine78246.AddState("Unequip From Aim Land", new Vector3(384f, -156f, 0f));
			unequipFromAimLandAnimatorState78650.motion = underwaterGunUnequipFromAimLandAnimationClip64994;
			unequipFromAimLandAnimatorState78650.cycleOffset = 0f;
			unequipFromAimLandAnimatorState78650.cycleOffsetParameterActive = false;
			unequipFromAimLandAnimatorState78650.iKOnFeet = false;
			unequipFromAimLandAnimatorState78650.mirror = false;
			unequipFromAimLandAnimatorState78650.mirrorParameterActive = false;
			unequipFromAimLandAnimatorState78650.speed = 3f;
			unequipFromAimLandAnimatorState78650.speedParameterActive = false;
			unequipFromAimLandAnimatorState78650.writeDefaultValues = true;

			var equipFromAimLandAnimatorState78652 = underwaterGunAnimatorStateMachine78246.AddState("Equip From Aim Land", new Vector3(384f, -216f, 0f));
			equipFromAimLandAnimatorState78652.motion = underwaterGunEquipFromAimLandAnimationClip64922;
			equipFromAimLandAnimatorState78652.cycleOffset = 0f;
			equipFromAimLandAnimatorState78652.cycleOffsetParameterActive = false;
			equipFromAimLandAnimatorState78652.iKOnFeet = false;
			equipFromAimLandAnimatorState78652.mirror = false;
			equipFromAimLandAnimatorState78652.mirrorParameterActive = false;
			equipFromAimLandAnimatorState78652.speed = 3f;
			equipFromAimLandAnimatorState78652.speedParameterActive = false;
			equipFromAimLandAnimatorState78652.writeDefaultValues = true;

			var equipFromIdleLandAnimatorState78654 = underwaterGunAnimatorStateMachine78246.AddState("Equip From Idle Land", new Vector3(384f, -96f, 0f));
			equipFromIdleLandAnimatorState78654.motion = underwaterGunEquipFromIdleLandAnimationClip64940;
			equipFromIdleLandAnimatorState78654.cycleOffset = 0f;
			equipFromIdleLandAnimatorState78654.cycleOffsetParameterActive = false;
			equipFromIdleLandAnimatorState78654.iKOnFeet = false;
			equipFromIdleLandAnimatorState78654.mirror = false;
			equipFromIdleLandAnimatorState78654.mirrorParameterActive = false;
			equipFromIdleLandAnimatorState78654.speed = 3f;
			equipFromIdleLandAnimatorState78654.speedParameterActive = false;
			equipFromIdleLandAnimatorState78654.writeDefaultValues = true;

			var dropLandAnimatorState78656 = underwaterGunAnimatorStateMachine78246.AddState("Drop Land", new Vector3(384f, 24f, 0f));
			dropLandAnimatorState78656.motion = underwaterGunDropLandAnimationClip64904;
			dropLandAnimatorState78656.cycleOffset = 0f;
			dropLandAnimatorState78656.cycleOffsetParameterActive = false;
			dropLandAnimatorState78656.iKOnFeet = false;
			dropLandAnimatorState78656.mirror = false;
			dropLandAnimatorState78656.mirrorParameterActive = false;
			dropLandAnimatorState78656.speed = 1f;
			dropLandAnimatorState78656.speedParameterActive = false;
			dropLandAnimatorState78656.writeDefaultValues = true;

			var idleLandAnimatorState78658 = underwaterGunAnimatorStateMachine78246.AddState("Idle Land", new Vector3(384f, -336f, 0f));
			idleLandAnimatorState78658.motion = underwaterGunIdleLandAnimationClip64976;
			idleLandAnimatorState78658.cycleOffset = 0f;
			idleLandAnimatorState78658.cycleOffsetParameterActive = false;
			idleLandAnimatorState78658.iKOnFeet = false;
			idleLandAnimatorState78658.mirror = false;
			idleLandAnimatorState78658.mirrorParameterActive = false;
			idleLandAnimatorState78658.speed = 1f;
			idleLandAnimatorState78658.speedParameterActive = false;
			idleLandAnimatorState78658.writeDefaultValues = true;

			var aimLandAnimatorState78660 = underwaterGunAnimatorStateMachine78246.AddState("Aim Land", new Vector3(384f, -276f, 0f));
			aimLandAnimatorState78660.motion = underwaterGunAimLandAnimationClip64886;
			aimLandAnimatorState78660.cycleOffset = 0f;
			aimLandAnimatorState78660.cycleOffsetParameterActive = false;
			aimLandAnimatorState78660.iKOnFeet = false;
			aimLandAnimatorState78660.mirror = false;
			aimLandAnimatorState78660.mirrorParameterActive = false;
			aimLandAnimatorState78660.speed = 1f;
			aimLandAnimatorState78660.speedParameterActive = false;
			aimLandAnimatorState78660.writeDefaultValues = true;

			var fireWaterAnimatorState78662 = underwaterGunAnimatorStateMachine78246.AddState("Fire Water", new Vector3(384f, 204f, 0f));
			var fireWaterAnimatorState78662blendTreeBlendTree79082 = new BlendTree();
			AssetDatabase.AddObjectToAsset(fireWaterAnimatorState78662blendTreeBlendTree79082, animatorController);
			fireWaterAnimatorState78662blendTreeBlendTree79082.hideFlags = HideFlags.HideInHierarchy;
			fireWaterAnimatorState78662blendTreeBlendTree79082.blendParameter = "HorizontalMovement";
			fireWaterAnimatorState78662blendTreeBlendTree79082.blendParameterY = "ForwardMovement";
			fireWaterAnimatorState78662blendTreeBlendTree79082.blendType = BlendTreeType.FreeformCartesian2D;
			fireWaterAnimatorState78662blendTreeBlendTree79082.maxThreshold = 1f;
			fireWaterAnimatorState78662blendTreeBlendTree79082.minThreshold = 0f;
			fireWaterAnimatorState78662blendTreeBlendTree79082.name = "Blend Tree";
			fireWaterAnimatorState78662blendTreeBlendTree79082.useAutomaticThresholds = true;
			var fireWaterAnimatorState78662blendTreeBlendTree79082Child0 =  new ChildMotion();
			fireWaterAnimatorState78662blendTreeBlendTree79082Child0.motion = underwaterGunFireLandAnimationClip64958;
			fireWaterAnimatorState78662blendTreeBlendTree79082Child0.cycleOffset = 0f;
			fireWaterAnimatorState78662blendTreeBlendTree79082Child0.directBlendParameter = "HorizontalMovement";
			fireWaterAnimatorState78662blendTreeBlendTree79082Child0.mirror = false;
			fireWaterAnimatorState78662blendTreeBlendTree79082Child0.position = new Vector2(0f, -1f);
			fireWaterAnimatorState78662blendTreeBlendTree79082Child0.threshold = 0f;
			fireWaterAnimatorState78662blendTreeBlendTree79082Child0.timeScale = 1f;
			var fireWaterAnimatorState78662blendTreeBlendTree79082Child1 =  new ChildMotion();
			fireWaterAnimatorState78662blendTreeBlendTree79082Child1.motion = underwaterGunFireStrafeAnimationClip64964;
			fireWaterAnimatorState78662blendTreeBlendTree79082Child1.cycleOffset = 0f;
			fireWaterAnimatorState78662blendTreeBlendTree79082Child1.directBlendParameter = "HorizontalMovement";
			fireWaterAnimatorState78662blendTreeBlendTree79082Child1.mirror = false;
			fireWaterAnimatorState78662blendTreeBlendTree79082Child1.position = new Vector2(-1f, 0f);
			fireWaterAnimatorState78662blendTreeBlendTree79082Child1.threshold = 0.25f;
			fireWaterAnimatorState78662blendTreeBlendTree79082Child1.timeScale = 1f;
			var fireWaterAnimatorState78662blendTreeBlendTree79082Child2 =  new ChildMotion();
			fireWaterAnimatorState78662blendTreeBlendTree79082Child2.motion = underwaterGunFireAnimationClip64952;
			fireWaterAnimatorState78662blendTreeBlendTree79082Child2.cycleOffset = 0f;
			fireWaterAnimatorState78662blendTreeBlendTree79082Child2.directBlendParameter = "HorizontalMovement";
			fireWaterAnimatorState78662blendTreeBlendTree79082Child2.mirror = false;
			fireWaterAnimatorState78662blendTreeBlendTree79082Child2.position = new Vector2(0f, 0f);
			fireWaterAnimatorState78662blendTreeBlendTree79082Child2.threshold = 0.5f;
			fireWaterAnimatorState78662blendTreeBlendTree79082Child2.timeScale = 1f;
			var fireWaterAnimatorState78662blendTreeBlendTree79082Child3 =  new ChildMotion();
			fireWaterAnimatorState78662blendTreeBlendTree79082Child3.motion = underwaterGunFireStrafeAnimationClip64964;
			fireWaterAnimatorState78662blendTreeBlendTree79082Child3.cycleOffset = 0.5f;
			fireWaterAnimatorState78662blendTreeBlendTree79082Child3.directBlendParameter = "HorizontalMovement";
			fireWaterAnimatorState78662blendTreeBlendTree79082Child3.mirror = true;
			fireWaterAnimatorState78662blendTreeBlendTree79082Child3.position = new Vector2(1f, 0f);
			fireWaterAnimatorState78662blendTreeBlendTree79082Child3.threshold = 0.75f;
			fireWaterAnimatorState78662blendTreeBlendTree79082Child3.timeScale = 1f;
			var fireWaterAnimatorState78662blendTreeBlendTree79082Child4 =  new ChildMotion();
			fireWaterAnimatorState78662blendTreeBlendTree79082Child4.motion = underwaterGunFireAnimationClip64952;
			fireWaterAnimatorState78662blendTreeBlendTree79082Child4.cycleOffset = 0f;
			fireWaterAnimatorState78662blendTreeBlendTree79082Child4.directBlendParameter = "HorizontalMovement";
			fireWaterAnimatorState78662blendTreeBlendTree79082Child4.mirror = false;
			fireWaterAnimatorState78662blendTreeBlendTree79082Child4.position = new Vector2(0f, 1f);
			fireWaterAnimatorState78662blendTreeBlendTree79082Child4.threshold = 1f;
			fireWaterAnimatorState78662blendTreeBlendTree79082Child4.timeScale = 1f;
			fireWaterAnimatorState78662blendTreeBlendTree79082.children = new ChildMotion[] {
				fireWaterAnimatorState78662blendTreeBlendTree79082Child0,
				fireWaterAnimatorState78662blendTreeBlendTree79082Child1,
				fireWaterAnimatorState78662blendTreeBlendTree79082Child2,
				fireWaterAnimatorState78662blendTreeBlendTree79082Child3,
				fireWaterAnimatorState78662blendTreeBlendTree79082Child4
			};
			fireWaterAnimatorState78662.motion = fireWaterAnimatorState78662blendTreeBlendTree79082;
			fireWaterAnimatorState78662.cycleOffset = 0f;
			fireWaterAnimatorState78662.cycleOffsetParameterActive = false;
			fireWaterAnimatorState78662.iKOnFeet = false;
			fireWaterAnimatorState78662.mirror = false;
			fireWaterAnimatorState78662.mirrorParameterActive = false;
			fireWaterAnimatorState78662.speed = 1.75f;
			fireWaterAnimatorState78662.speedParameterActive = false;
			fireWaterAnimatorState78662.writeDefaultValues = true;

			var aimWaterAnimatorState78664 = underwaterGunAnimatorStateMachine78246.AddState("Aim Water", new Vector3(384f, 144f, 0f));
			var aimWaterAnimatorState78664blendTreeBlendTree79086 = new BlendTree();
			AssetDatabase.AddObjectToAsset(aimWaterAnimatorState78664blendTreeBlendTree79086, animatorController);
			aimWaterAnimatorState78664blendTreeBlendTree79086.hideFlags = HideFlags.HideInHierarchy;
			aimWaterAnimatorState78664blendTreeBlendTree79086.blendParameter = "HorizontalMovement";
			aimWaterAnimatorState78664blendTreeBlendTree79086.blendParameterY = "ForwardMovement";
			aimWaterAnimatorState78664blendTreeBlendTree79086.blendType = BlendTreeType.FreeformCartesian2D;
			aimWaterAnimatorState78664blendTreeBlendTree79086.maxThreshold = 1f;
			aimWaterAnimatorState78664blendTreeBlendTree79086.minThreshold = 0f;
			aimWaterAnimatorState78664blendTreeBlendTree79086.name = "Blend Tree";
			aimWaterAnimatorState78664blendTreeBlendTree79086.useAutomaticThresholds = true;
			var aimWaterAnimatorState78664blendTreeBlendTree79086Child0 =  new ChildMotion();
			aimWaterAnimatorState78664blendTreeBlendTree79086Child0.motion = underwaterGunAimLandAnimationClip64886;
			aimWaterAnimatorState78664blendTreeBlendTree79086Child0.cycleOffset = 0f;
			aimWaterAnimatorState78664blendTreeBlendTree79086Child0.directBlendParameter = "HorizontalMovement";
			aimWaterAnimatorState78664blendTreeBlendTree79086Child0.mirror = false;
			aimWaterAnimatorState78664blendTreeBlendTree79086Child0.position = new Vector2(0f, -1f);
			aimWaterAnimatorState78664blendTreeBlendTree79086Child0.threshold = 0f;
			aimWaterAnimatorState78664blendTreeBlendTree79086Child0.timeScale = 1f;
			var aimWaterAnimatorState78664blendTreeBlendTree79086Child1 =  new ChildMotion();
			aimWaterAnimatorState78664blendTreeBlendTree79086Child1.motion = underwaterGunAimStrafeAnimationClip64892;
			aimWaterAnimatorState78664blendTreeBlendTree79086Child1.cycleOffset = 0f;
			aimWaterAnimatorState78664blendTreeBlendTree79086Child1.directBlendParameter = "HorizontalMovement";
			aimWaterAnimatorState78664blendTreeBlendTree79086Child1.mirror = false;
			aimWaterAnimatorState78664blendTreeBlendTree79086Child1.position = new Vector2(-1f, 0f);
			aimWaterAnimatorState78664blendTreeBlendTree79086Child1.threshold = 0.25f;
			aimWaterAnimatorState78664blendTreeBlendTree79086Child1.timeScale = 1f;
			var aimWaterAnimatorState78664blendTreeBlendTree79086Child2 =  new ChildMotion();
			aimWaterAnimatorState78664blendTreeBlendTree79086Child2.motion = underwaterGunAimAnimationClip64880;
			aimWaterAnimatorState78664blendTreeBlendTree79086Child2.cycleOffset = 0f;
			aimWaterAnimatorState78664blendTreeBlendTree79086Child2.directBlendParameter = "HorizontalMovement";
			aimWaterAnimatorState78664blendTreeBlendTree79086Child2.mirror = false;
			aimWaterAnimatorState78664blendTreeBlendTree79086Child2.position = new Vector2(0f, 0f);
			aimWaterAnimatorState78664blendTreeBlendTree79086Child2.threshold = 0.5f;
			aimWaterAnimatorState78664blendTreeBlendTree79086Child2.timeScale = 1f;
			var aimWaterAnimatorState78664blendTreeBlendTree79086Child3 =  new ChildMotion();
			aimWaterAnimatorState78664blendTreeBlendTree79086Child3.motion = underwaterGunAimStrafeAnimationClip64892;
			aimWaterAnimatorState78664blendTreeBlendTree79086Child3.cycleOffset = 0.5f;
			aimWaterAnimatorState78664blendTreeBlendTree79086Child3.directBlendParameter = "HorizontalMovement";
			aimWaterAnimatorState78664blendTreeBlendTree79086Child3.mirror = true;
			aimWaterAnimatorState78664blendTreeBlendTree79086Child3.position = new Vector2(1f, 0f);
			aimWaterAnimatorState78664blendTreeBlendTree79086Child3.threshold = 0.75f;
			aimWaterAnimatorState78664blendTreeBlendTree79086Child3.timeScale = 1f;
			var aimWaterAnimatorState78664blendTreeBlendTree79086Child4 =  new ChildMotion();
			aimWaterAnimatorState78664blendTreeBlendTree79086Child4.motion = underwaterGunAimAnimationClip64880;
			aimWaterAnimatorState78664blendTreeBlendTree79086Child4.cycleOffset = 0f;
			aimWaterAnimatorState78664blendTreeBlendTree79086Child4.directBlendParameter = "HorizontalMovement";
			aimWaterAnimatorState78664blendTreeBlendTree79086Child4.mirror = false;
			aimWaterAnimatorState78664blendTreeBlendTree79086Child4.position = new Vector2(0f, 1f);
			aimWaterAnimatorState78664blendTreeBlendTree79086Child4.threshold = 1f;
			aimWaterAnimatorState78664blendTreeBlendTree79086Child4.timeScale = 1f;
			aimWaterAnimatorState78664blendTreeBlendTree79086.children = new ChildMotion[] {
				aimWaterAnimatorState78664blendTreeBlendTree79086Child0,
				aimWaterAnimatorState78664blendTreeBlendTree79086Child1,
				aimWaterAnimatorState78664blendTreeBlendTree79086Child2,
				aimWaterAnimatorState78664blendTreeBlendTree79086Child3,
				aimWaterAnimatorState78664blendTreeBlendTree79086Child4
			};
			aimWaterAnimatorState78664.motion = aimWaterAnimatorState78664blendTreeBlendTree79086;
			aimWaterAnimatorState78664.cycleOffset = 0f;
			aimWaterAnimatorState78664.cycleOffsetParameterActive = false;
			aimWaterAnimatorState78664.iKOnFeet = false;
			aimWaterAnimatorState78664.mirror = false;
			aimWaterAnimatorState78664.mirrorParameterActive = false;
			aimWaterAnimatorState78664.speed = 1f;
			aimWaterAnimatorState78664.speedParameterActive = false;
			aimWaterAnimatorState78664.writeDefaultValues = true;

			var idleWaterAnimatorState78666 = underwaterGunAnimatorStateMachine78246.AddState("Idle Water", new Vector3(384f, 84f, 0f));
			var idleWaterAnimatorState78666blendTreeBlendTree79090 = new BlendTree();
			AssetDatabase.AddObjectToAsset(idleWaterAnimatorState78666blendTreeBlendTree79090, animatorController);
			idleWaterAnimatorState78666blendTreeBlendTree79090.hideFlags = HideFlags.HideInHierarchy;
			idleWaterAnimatorState78666blendTreeBlendTree79090.blendParameter = "HorizontalMovement";
			idleWaterAnimatorState78666blendTreeBlendTree79090.blendParameterY = "ForwardMovement";
			idleWaterAnimatorState78666blendTreeBlendTree79090.blendType = BlendTreeType.FreeformCartesian2D;
			idleWaterAnimatorState78666blendTreeBlendTree79090.maxThreshold = 1f;
			idleWaterAnimatorState78666blendTreeBlendTree79090.minThreshold = 0f;
			idleWaterAnimatorState78666blendTreeBlendTree79090.name = "Blend Tree";
			idleWaterAnimatorState78666blendTreeBlendTree79090.useAutomaticThresholds = true;
			var idleWaterAnimatorState78666blendTreeBlendTree79090Child0 =  new ChildMotion();
			idleWaterAnimatorState78666blendTreeBlendTree79090Child0.motion = underwaterGunIdleLandAnimationClip64976;
			idleWaterAnimatorState78666blendTreeBlendTree79090Child0.cycleOffset = 0f;
			idleWaterAnimatorState78666blendTreeBlendTree79090Child0.directBlendParameter = "HorizontalMovement";
			idleWaterAnimatorState78666blendTreeBlendTree79090Child0.mirror = false;
			idleWaterAnimatorState78666blendTreeBlendTree79090Child0.position = new Vector2(0f, -1f);
			idleWaterAnimatorState78666blendTreeBlendTree79090Child0.threshold = 0f;
			idleWaterAnimatorState78666blendTreeBlendTree79090Child0.timeScale = 1f;
			var idleWaterAnimatorState78666blendTreeBlendTree79090Child1 =  new ChildMotion();
			idleWaterAnimatorState78666blendTreeBlendTree79090Child1.motion = underwaterGunIdleStrafeAnimationClip64982;
			idleWaterAnimatorState78666blendTreeBlendTree79090Child1.cycleOffset = 0f;
			idleWaterAnimatorState78666blendTreeBlendTree79090Child1.directBlendParameter = "HorizontalMovement";
			idleWaterAnimatorState78666blendTreeBlendTree79090Child1.mirror = false;
			idleWaterAnimatorState78666blendTreeBlendTree79090Child1.position = new Vector2(-1f, 0f);
			idleWaterAnimatorState78666blendTreeBlendTree79090Child1.threshold = 0.25f;
			idleWaterAnimatorState78666blendTreeBlendTree79090Child1.timeScale = 1f;
			var idleWaterAnimatorState78666blendTreeBlendTree79090Child2 =  new ChildMotion();
			idleWaterAnimatorState78666blendTreeBlendTree79090Child2.motion = underwaterGunIdleAnimationClip64970;
			idleWaterAnimatorState78666blendTreeBlendTree79090Child2.cycleOffset = 0f;
			idleWaterAnimatorState78666blendTreeBlendTree79090Child2.directBlendParameter = "HorizontalMovement";
			idleWaterAnimatorState78666blendTreeBlendTree79090Child2.mirror = false;
			idleWaterAnimatorState78666blendTreeBlendTree79090Child2.position = new Vector2(0f, 0f);
			idleWaterAnimatorState78666blendTreeBlendTree79090Child2.threshold = 0.5f;
			idleWaterAnimatorState78666blendTreeBlendTree79090Child2.timeScale = 1f;
			var idleWaterAnimatorState78666blendTreeBlendTree79090Child3 =  new ChildMotion();
			idleWaterAnimatorState78666blendTreeBlendTree79090Child3.motion = underwaterGunIdleStrafeAnimationClip64982;
			idleWaterAnimatorState78666blendTreeBlendTree79090Child3.cycleOffset = 0f;
			idleWaterAnimatorState78666blendTreeBlendTree79090Child3.directBlendParameter = "HorizontalMovement";
			idleWaterAnimatorState78666blendTreeBlendTree79090Child3.mirror = false;
			idleWaterAnimatorState78666blendTreeBlendTree79090Child3.position = new Vector2(1f, 0f);
			idleWaterAnimatorState78666blendTreeBlendTree79090Child3.threshold = 0.75f;
			idleWaterAnimatorState78666blendTreeBlendTree79090Child3.timeScale = 1f;
			var idleWaterAnimatorState78666blendTreeBlendTree79090Child4 =  new ChildMotion();
			idleWaterAnimatorState78666blendTreeBlendTree79090Child4.motion = underwaterGunIdleAnimationClip64970;
			idleWaterAnimatorState78666blendTreeBlendTree79090Child4.cycleOffset = 0f;
			idleWaterAnimatorState78666blendTreeBlendTree79090Child4.directBlendParameter = "HorizontalMovement";
			idleWaterAnimatorState78666blendTreeBlendTree79090Child4.mirror = false;
			idleWaterAnimatorState78666blendTreeBlendTree79090Child4.position = new Vector2(0f, 1f);
			idleWaterAnimatorState78666blendTreeBlendTree79090Child4.threshold = 1f;
			idleWaterAnimatorState78666blendTreeBlendTree79090Child4.timeScale = 1f;
			idleWaterAnimatorState78666blendTreeBlendTree79090.children = new ChildMotion[] {
				idleWaterAnimatorState78666blendTreeBlendTree79090Child0,
				idleWaterAnimatorState78666blendTreeBlendTree79090Child1,
				idleWaterAnimatorState78666blendTreeBlendTree79090Child2,
				idleWaterAnimatorState78666blendTreeBlendTree79090Child3,
				idleWaterAnimatorState78666blendTreeBlendTree79090Child4
			};
			idleWaterAnimatorState78666.motion = idleWaterAnimatorState78666blendTreeBlendTree79090;
			idleWaterAnimatorState78666.cycleOffset = 0f;
			idleWaterAnimatorState78666.cycleOffsetParameterActive = false;
			idleWaterAnimatorState78666.iKOnFeet = false;
			idleWaterAnimatorState78666.mirror = false;
			idleWaterAnimatorState78666.mirrorParameterActive = false;
			idleWaterAnimatorState78666.speed = 1f;
			idleWaterAnimatorState78666.speedParameterActive = false;
			idleWaterAnimatorState78666.writeDefaultValues = true;

			var dropWaterAnimatorState78668 = underwaterGunAnimatorStateMachine78246.AddState("Drop Water", new Vector3(384f, 504f, 0f));
			var dropWaterAnimatorState78668blendTreeBlendTree79094 = new BlendTree();
			AssetDatabase.AddObjectToAsset(dropWaterAnimatorState78668blendTreeBlendTree79094, animatorController);
			dropWaterAnimatorState78668blendTreeBlendTree79094.hideFlags = HideFlags.HideInHierarchy;
			dropWaterAnimatorState78668blendTreeBlendTree79094.blendParameter = "HorizontalMovement";
			dropWaterAnimatorState78668blendTreeBlendTree79094.blendParameterY = "ForwardMovement";
			dropWaterAnimatorState78668blendTreeBlendTree79094.blendType = BlendTreeType.FreeformCartesian2D;
			dropWaterAnimatorState78668blendTreeBlendTree79094.maxThreshold = 1f;
			dropWaterAnimatorState78668blendTreeBlendTree79094.minThreshold = 0f;
			dropWaterAnimatorState78668blendTreeBlendTree79094.name = "Blend Tree";
			dropWaterAnimatorState78668blendTreeBlendTree79094.useAutomaticThresholds = true;
			var dropWaterAnimatorState78668blendTreeBlendTree79094Child0 =  new ChildMotion();
			dropWaterAnimatorState78668blendTreeBlendTree79094Child0.motion = underwaterGunDropLandAnimationClip64904;
			dropWaterAnimatorState78668blendTreeBlendTree79094Child0.cycleOffset = 0f;
			dropWaterAnimatorState78668blendTreeBlendTree79094Child0.directBlendParameter = "HorizontalMovement";
			dropWaterAnimatorState78668blendTreeBlendTree79094Child0.mirror = false;
			dropWaterAnimatorState78668blendTreeBlendTree79094Child0.position = new Vector2(0f, -1f);
			dropWaterAnimatorState78668blendTreeBlendTree79094Child0.threshold = 0f;
			dropWaterAnimatorState78668blendTreeBlendTree79094Child0.timeScale = 1f;
			var dropWaterAnimatorState78668blendTreeBlendTree79094Child1 =  new ChildMotion();
			dropWaterAnimatorState78668blendTreeBlendTree79094Child1.motion = underwaterGunDropStrafeAnimationClip64910;
			dropWaterAnimatorState78668blendTreeBlendTree79094Child1.cycleOffset = 0f;
			dropWaterAnimatorState78668blendTreeBlendTree79094Child1.directBlendParameter = "HorizontalMovement";
			dropWaterAnimatorState78668blendTreeBlendTree79094Child1.mirror = false;
			dropWaterAnimatorState78668blendTreeBlendTree79094Child1.position = new Vector2(-1f, 0f);
			dropWaterAnimatorState78668blendTreeBlendTree79094Child1.threshold = 0.25f;
			dropWaterAnimatorState78668blendTreeBlendTree79094Child1.timeScale = 1f;
			var dropWaterAnimatorState78668blendTreeBlendTree79094Child2 =  new ChildMotion();
			dropWaterAnimatorState78668blendTreeBlendTree79094Child2.motion = underwaterGunDropAnimationClip64898;
			dropWaterAnimatorState78668blendTreeBlendTree79094Child2.cycleOffset = 0f;
			dropWaterAnimatorState78668blendTreeBlendTree79094Child2.directBlendParameter = "HorizontalMovement";
			dropWaterAnimatorState78668blendTreeBlendTree79094Child2.mirror = false;
			dropWaterAnimatorState78668blendTreeBlendTree79094Child2.position = new Vector2(0f, 0f);
			dropWaterAnimatorState78668blendTreeBlendTree79094Child2.threshold = 0.5f;
			dropWaterAnimatorState78668blendTreeBlendTree79094Child2.timeScale = 1f;
			var dropWaterAnimatorState78668blendTreeBlendTree79094Child3 =  new ChildMotion();
			dropWaterAnimatorState78668blendTreeBlendTree79094Child3.motion = underwaterGunDropStrafeAnimationClip64910;
			dropWaterAnimatorState78668blendTreeBlendTree79094Child3.cycleOffset = 0f;
			dropWaterAnimatorState78668blendTreeBlendTree79094Child3.directBlendParameter = "HorizontalMovement";
			dropWaterAnimatorState78668blendTreeBlendTree79094Child3.mirror = false;
			dropWaterAnimatorState78668blendTreeBlendTree79094Child3.position = new Vector2(1f, 0f);
			dropWaterAnimatorState78668blendTreeBlendTree79094Child3.threshold = 0.75f;
			dropWaterAnimatorState78668blendTreeBlendTree79094Child3.timeScale = 1f;
			var dropWaterAnimatorState78668blendTreeBlendTree79094Child4 =  new ChildMotion();
			dropWaterAnimatorState78668blendTreeBlendTree79094Child4.motion = underwaterGunDropAnimationClip64898;
			dropWaterAnimatorState78668blendTreeBlendTree79094Child4.cycleOffset = 0f;
			dropWaterAnimatorState78668blendTreeBlendTree79094Child4.directBlendParameter = "HorizontalMovement";
			dropWaterAnimatorState78668blendTreeBlendTree79094Child4.mirror = false;
			dropWaterAnimatorState78668blendTreeBlendTree79094Child4.position = new Vector2(0f, 1f);
			dropWaterAnimatorState78668blendTreeBlendTree79094Child4.threshold = 1f;
			dropWaterAnimatorState78668blendTreeBlendTree79094Child4.timeScale = 1f;
			dropWaterAnimatorState78668blendTreeBlendTree79094.children = new ChildMotion[] {
				dropWaterAnimatorState78668blendTreeBlendTree79094Child0,
				dropWaterAnimatorState78668blendTreeBlendTree79094Child1,
				dropWaterAnimatorState78668blendTreeBlendTree79094Child2,
				dropWaterAnimatorState78668blendTreeBlendTree79094Child3,
				dropWaterAnimatorState78668blendTreeBlendTree79094Child4
			};
			dropWaterAnimatorState78668.motion = dropWaterAnimatorState78668blendTreeBlendTree79094;
			dropWaterAnimatorState78668.cycleOffset = 0f;
			dropWaterAnimatorState78668.cycleOffsetParameterActive = false;
			dropWaterAnimatorState78668.iKOnFeet = false;
			dropWaterAnimatorState78668.mirror = false;
			dropWaterAnimatorState78668.mirrorParameterActive = false;
			dropWaterAnimatorState78668.speed = 1f;
			dropWaterAnimatorState78668.speedParameterActive = false;
			dropWaterAnimatorState78668.writeDefaultValues = true;

			var equipFromIdleWaterAnimatorState78670 = underwaterGunAnimatorStateMachine78246.AddState("Equip From Idle Water", new Vector3(384f, 384f, 0f));
			var equipFromIdleWaterAnimatorState78670blendTreeBlendTree79098 = new BlendTree();
			AssetDatabase.AddObjectToAsset(equipFromIdleWaterAnimatorState78670blendTreeBlendTree79098, animatorController);
			equipFromIdleWaterAnimatorState78670blendTreeBlendTree79098.hideFlags = HideFlags.HideInHierarchy;
			equipFromIdleWaterAnimatorState78670blendTreeBlendTree79098.blendParameter = "HorizontalMovement";
			equipFromIdleWaterAnimatorState78670blendTreeBlendTree79098.blendParameterY = "ForwardMovement";
			equipFromIdleWaterAnimatorState78670blendTreeBlendTree79098.blendType = BlendTreeType.FreeformCartesian2D;
			equipFromIdleWaterAnimatorState78670blendTreeBlendTree79098.maxThreshold = 1f;
			equipFromIdleWaterAnimatorState78670blendTreeBlendTree79098.minThreshold = 0f;
			equipFromIdleWaterAnimatorState78670blendTreeBlendTree79098.name = "Blend Tree";
			equipFromIdleWaterAnimatorState78670blendTreeBlendTree79098.useAutomaticThresholds = true;
			var equipFromIdleWaterAnimatorState78670blendTreeBlendTree79098Child0 =  new ChildMotion();
			equipFromIdleWaterAnimatorState78670blendTreeBlendTree79098Child0.motion = underwaterGunEquipFromIdleLandAnimationClip64940;
			equipFromIdleWaterAnimatorState78670blendTreeBlendTree79098Child0.cycleOffset = 0f;
			equipFromIdleWaterAnimatorState78670blendTreeBlendTree79098Child0.directBlendParameter = "HorizontalMovement";
			equipFromIdleWaterAnimatorState78670blendTreeBlendTree79098Child0.mirror = false;
			equipFromIdleWaterAnimatorState78670blendTreeBlendTree79098Child0.position = new Vector2(0f, -1f);
			equipFromIdleWaterAnimatorState78670blendTreeBlendTree79098Child0.threshold = 0f;
			equipFromIdleWaterAnimatorState78670blendTreeBlendTree79098Child0.timeScale = 1f;
			var equipFromIdleWaterAnimatorState78670blendTreeBlendTree79098Child1 =  new ChildMotion();
			equipFromIdleWaterAnimatorState78670blendTreeBlendTree79098Child1.motion = underwaterGunEquipFromIdleStrafeAnimationClip64946;
			equipFromIdleWaterAnimatorState78670blendTreeBlendTree79098Child1.cycleOffset = 0f;
			equipFromIdleWaterAnimatorState78670blendTreeBlendTree79098Child1.directBlendParameter = "HorizontalMovement";
			equipFromIdleWaterAnimatorState78670blendTreeBlendTree79098Child1.mirror = false;
			equipFromIdleWaterAnimatorState78670blendTreeBlendTree79098Child1.position = new Vector2(-1f, 0f);
			equipFromIdleWaterAnimatorState78670blendTreeBlendTree79098Child1.threshold = 0.25f;
			equipFromIdleWaterAnimatorState78670blendTreeBlendTree79098Child1.timeScale = 1f;
			var equipFromIdleWaterAnimatorState78670blendTreeBlendTree79098Child2 =  new ChildMotion();
			equipFromIdleWaterAnimatorState78670blendTreeBlendTree79098Child2.motion = underwaterGunEquipFromIdleAnimationClip64934;
			equipFromIdleWaterAnimatorState78670blendTreeBlendTree79098Child2.cycleOffset = 0f;
			equipFromIdleWaterAnimatorState78670blendTreeBlendTree79098Child2.directBlendParameter = "HorizontalMovement";
			equipFromIdleWaterAnimatorState78670blendTreeBlendTree79098Child2.mirror = false;
			equipFromIdleWaterAnimatorState78670blendTreeBlendTree79098Child2.position = new Vector2(0f, 0f);
			equipFromIdleWaterAnimatorState78670blendTreeBlendTree79098Child2.threshold = 0.5f;
			equipFromIdleWaterAnimatorState78670blendTreeBlendTree79098Child2.timeScale = 1f;
			var equipFromIdleWaterAnimatorState78670blendTreeBlendTree79098Child3 =  new ChildMotion();
			equipFromIdleWaterAnimatorState78670blendTreeBlendTree79098Child3.motion = underwaterGunEquipFromIdleStrafeAnimationClip64946;
			equipFromIdleWaterAnimatorState78670blendTreeBlendTree79098Child3.cycleOffset = 0f;
			equipFromIdleWaterAnimatorState78670blendTreeBlendTree79098Child3.directBlendParameter = "HorizontalMovement";
			equipFromIdleWaterAnimatorState78670blendTreeBlendTree79098Child3.mirror = false;
			equipFromIdleWaterAnimatorState78670blendTreeBlendTree79098Child3.position = new Vector2(1f, 0f);
			equipFromIdleWaterAnimatorState78670blendTreeBlendTree79098Child3.threshold = 0.75f;
			equipFromIdleWaterAnimatorState78670blendTreeBlendTree79098Child3.timeScale = 1f;
			var equipFromIdleWaterAnimatorState78670blendTreeBlendTree79098Child4 =  new ChildMotion();
			equipFromIdleWaterAnimatorState78670blendTreeBlendTree79098Child4.motion = underwaterGunEquipFromIdleAnimationClip64934;
			equipFromIdleWaterAnimatorState78670blendTreeBlendTree79098Child4.cycleOffset = 0f;
			equipFromIdleWaterAnimatorState78670blendTreeBlendTree79098Child4.directBlendParameter = "HorizontalMovement";
			equipFromIdleWaterAnimatorState78670blendTreeBlendTree79098Child4.mirror = false;
			equipFromIdleWaterAnimatorState78670blendTreeBlendTree79098Child4.position = new Vector2(0f, 1f);
			equipFromIdleWaterAnimatorState78670blendTreeBlendTree79098Child4.threshold = 1f;
			equipFromIdleWaterAnimatorState78670blendTreeBlendTree79098Child4.timeScale = 1f;
			equipFromIdleWaterAnimatorState78670blendTreeBlendTree79098.children = new ChildMotion[] {
				equipFromIdleWaterAnimatorState78670blendTreeBlendTree79098Child0,
				equipFromIdleWaterAnimatorState78670blendTreeBlendTree79098Child1,
				equipFromIdleWaterAnimatorState78670blendTreeBlendTree79098Child2,
				equipFromIdleWaterAnimatorState78670blendTreeBlendTree79098Child3,
				equipFromIdleWaterAnimatorState78670blendTreeBlendTree79098Child4
			};
			equipFromIdleWaterAnimatorState78670.motion = equipFromIdleWaterAnimatorState78670blendTreeBlendTree79098;
			equipFromIdleWaterAnimatorState78670.cycleOffset = 0f;
			equipFromIdleWaterAnimatorState78670.cycleOffsetParameterActive = false;
			equipFromIdleWaterAnimatorState78670.iKOnFeet = false;
			equipFromIdleWaterAnimatorState78670.mirror = false;
			equipFromIdleWaterAnimatorState78670.mirrorParameterActive = false;
			equipFromIdleWaterAnimatorState78670.speed = 3f;
			equipFromIdleWaterAnimatorState78670.speedParameterActive = false;
			equipFromIdleWaterAnimatorState78670.writeDefaultValues = true;

			var equipFromAimWaterAnimatorState78672 = underwaterGunAnimatorStateMachine78246.AddState("Equip From Aim Water", new Vector3(384f, 264f, 0f));
			var equipFromAimWaterAnimatorState78672blendTreeBlendTree79102 = new BlendTree();
			AssetDatabase.AddObjectToAsset(equipFromAimWaterAnimatorState78672blendTreeBlendTree79102, animatorController);
			equipFromAimWaterAnimatorState78672blendTreeBlendTree79102.hideFlags = HideFlags.HideInHierarchy;
			equipFromAimWaterAnimatorState78672blendTreeBlendTree79102.blendParameter = "HorizontalMovement";
			equipFromAimWaterAnimatorState78672blendTreeBlendTree79102.blendParameterY = "ForwardMovement";
			equipFromAimWaterAnimatorState78672blendTreeBlendTree79102.blendType = BlendTreeType.FreeformCartesian2D;
			equipFromAimWaterAnimatorState78672blendTreeBlendTree79102.maxThreshold = 1.333333f;
			equipFromAimWaterAnimatorState78672blendTreeBlendTree79102.minThreshold = 0f;
			equipFromAimWaterAnimatorState78672blendTreeBlendTree79102.name = "Blend Tree";
			equipFromAimWaterAnimatorState78672blendTreeBlendTree79102.useAutomaticThresholds = false;
			var equipFromAimWaterAnimatorState78672blendTreeBlendTree79102Child0 =  new ChildMotion();
			equipFromAimWaterAnimatorState78672blendTreeBlendTree79102Child0.motion = underwaterGunEquipFromAimLandAnimationClip64922;
			equipFromAimWaterAnimatorState78672blendTreeBlendTree79102Child0.cycleOffset = 0f;
			equipFromAimWaterAnimatorState78672blendTreeBlendTree79102Child0.directBlendParameter = "HorizontalMovement";
			equipFromAimWaterAnimatorState78672blendTreeBlendTree79102Child0.mirror = false;
			equipFromAimWaterAnimatorState78672blendTreeBlendTree79102Child0.position = new Vector2(0f, -1f);
			equipFromAimWaterAnimatorState78672blendTreeBlendTree79102Child0.threshold = 0f;
			equipFromAimWaterAnimatorState78672blendTreeBlendTree79102Child0.timeScale = 1f;
			var equipFromAimWaterAnimatorState78672blendTreeBlendTree79102Child1 =  new ChildMotion();
			equipFromAimWaterAnimatorState78672blendTreeBlendTree79102Child1.motion = underwaterGunEquipFromAimStrafeAnimationClip64928;
			equipFromAimWaterAnimatorState78672blendTreeBlendTree79102Child1.cycleOffset = 0f;
			equipFromAimWaterAnimatorState78672blendTreeBlendTree79102Child1.directBlendParameter = "HorizontalMovement";
			equipFromAimWaterAnimatorState78672blendTreeBlendTree79102Child1.mirror = false;
			equipFromAimWaterAnimatorState78672blendTreeBlendTree79102Child1.position = new Vector2(-1f, 0f);
			equipFromAimWaterAnimatorState78672blendTreeBlendTree79102Child1.threshold = 0.3333333f;
			equipFromAimWaterAnimatorState78672blendTreeBlendTree79102Child1.timeScale = 1f;
			var equipFromAimWaterAnimatorState78672blendTreeBlendTree79102Child2 =  new ChildMotion();
			equipFromAimWaterAnimatorState78672blendTreeBlendTree79102Child2.motion = underwaterGunEquipFromAimAnimationClip64916;
			equipFromAimWaterAnimatorState78672blendTreeBlendTree79102Child2.cycleOffset = 0f;
			equipFromAimWaterAnimatorState78672blendTreeBlendTree79102Child2.directBlendParameter = "HorizontalMovement";
			equipFromAimWaterAnimatorState78672blendTreeBlendTree79102Child2.mirror = false;
			equipFromAimWaterAnimatorState78672blendTreeBlendTree79102Child2.position = new Vector2(0f, 0f);
			equipFromAimWaterAnimatorState78672blendTreeBlendTree79102Child2.threshold = 0.6666667f;
			equipFromAimWaterAnimatorState78672blendTreeBlendTree79102Child2.timeScale = 1f;
			var equipFromAimWaterAnimatorState78672blendTreeBlendTree79102Child3 =  new ChildMotion();
			equipFromAimWaterAnimatorState78672blendTreeBlendTree79102Child3.motion = underwaterGunEquipFromAimStrafeAnimationClip64928;
			equipFromAimWaterAnimatorState78672blendTreeBlendTree79102Child3.cycleOffset = 0.5f;
			equipFromAimWaterAnimatorState78672blendTreeBlendTree79102Child3.directBlendParameter = "HorizontalMovement";
			equipFromAimWaterAnimatorState78672blendTreeBlendTree79102Child3.mirror = true;
			equipFromAimWaterAnimatorState78672blendTreeBlendTree79102Child3.position = new Vector2(1f, 0f);
			equipFromAimWaterAnimatorState78672blendTreeBlendTree79102Child3.threshold = 1f;
			equipFromAimWaterAnimatorState78672blendTreeBlendTree79102Child3.timeScale = 1f;
			var equipFromAimWaterAnimatorState78672blendTreeBlendTree79102Child4 =  new ChildMotion();
			equipFromAimWaterAnimatorState78672blendTreeBlendTree79102Child4.motion = underwaterGunEquipFromAimAnimationClip64916;
			equipFromAimWaterAnimatorState78672blendTreeBlendTree79102Child4.cycleOffset = 0f;
			equipFromAimWaterAnimatorState78672blendTreeBlendTree79102Child4.directBlendParameter = "HorizontalMovement";
			equipFromAimWaterAnimatorState78672blendTreeBlendTree79102Child4.mirror = false;
			equipFromAimWaterAnimatorState78672blendTreeBlendTree79102Child4.position = new Vector2(0f, 1f);
			equipFromAimWaterAnimatorState78672blendTreeBlendTree79102Child4.threshold = 1.333333f;
			equipFromAimWaterAnimatorState78672blendTreeBlendTree79102Child4.timeScale = 1f;
			equipFromAimWaterAnimatorState78672blendTreeBlendTree79102.children = new ChildMotion[] {
				equipFromAimWaterAnimatorState78672blendTreeBlendTree79102Child0,
				equipFromAimWaterAnimatorState78672blendTreeBlendTree79102Child1,
				equipFromAimWaterAnimatorState78672blendTreeBlendTree79102Child2,
				equipFromAimWaterAnimatorState78672blendTreeBlendTree79102Child3,
				equipFromAimWaterAnimatorState78672blendTreeBlendTree79102Child4
			};
			equipFromAimWaterAnimatorState78672.motion = equipFromAimWaterAnimatorState78672blendTreeBlendTree79102;
			equipFromAimWaterAnimatorState78672.cycleOffset = 0f;
			equipFromAimWaterAnimatorState78672.cycleOffsetParameterActive = false;
			equipFromAimWaterAnimatorState78672.iKOnFeet = false;
			equipFromAimWaterAnimatorState78672.mirror = false;
			equipFromAimWaterAnimatorState78672.mirrorParameterActive = false;
			equipFromAimWaterAnimatorState78672.speed = 3f;
			equipFromAimWaterAnimatorState78672.speedParameterActive = false;
			equipFromAimWaterAnimatorState78672.writeDefaultValues = true;

			var unequipFromAimWaterAnimatorState78674 = underwaterGunAnimatorStateMachine78246.AddState("Unequip From Aim Water", new Vector3(384f, 324f, 0f));
			var unequipFromAimWaterAnimatorState78674blendTreeBlendTree79106 = new BlendTree();
			AssetDatabase.AddObjectToAsset(unequipFromAimWaterAnimatorState78674blendTreeBlendTree79106, animatorController);
			unequipFromAimWaterAnimatorState78674blendTreeBlendTree79106.hideFlags = HideFlags.HideInHierarchy;
			unequipFromAimWaterAnimatorState78674blendTreeBlendTree79106.blendParameter = "HorizontalMovement";
			unequipFromAimWaterAnimatorState78674blendTreeBlendTree79106.blendParameterY = "ForwardMovement";
			unequipFromAimWaterAnimatorState78674blendTreeBlendTree79106.blendType = BlendTreeType.FreeformCartesian2D;
			unequipFromAimWaterAnimatorState78674blendTreeBlendTree79106.maxThreshold = 1f;
			unequipFromAimWaterAnimatorState78674blendTreeBlendTree79106.minThreshold = 0f;
			unequipFromAimWaterAnimatorState78674blendTreeBlendTree79106.name = "Blend Tree";
			unequipFromAimWaterAnimatorState78674blendTreeBlendTree79106.useAutomaticThresholds = true;
			var unequipFromAimWaterAnimatorState78674blendTreeBlendTree79106Child0 =  new ChildMotion();
			unequipFromAimWaterAnimatorState78674blendTreeBlendTree79106Child0.motion = underwaterGunUnequipFromAimLandAnimationClip64994;
			unequipFromAimWaterAnimatorState78674blendTreeBlendTree79106Child0.cycleOffset = 0f;
			unequipFromAimWaterAnimatorState78674blendTreeBlendTree79106Child0.directBlendParameter = "HorizontalMovement";
			unequipFromAimWaterAnimatorState78674blendTreeBlendTree79106Child0.mirror = false;
			unequipFromAimWaterAnimatorState78674blendTreeBlendTree79106Child0.position = new Vector2(0f, -1f);
			unequipFromAimWaterAnimatorState78674blendTreeBlendTree79106Child0.threshold = 0f;
			unequipFromAimWaterAnimatorState78674blendTreeBlendTree79106Child0.timeScale = 1f;
			var unequipFromAimWaterAnimatorState78674blendTreeBlendTree79106Child1 =  new ChildMotion();
			unequipFromAimWaterAnimatorState78674blendTreeBlendTree79106Child1.motion = underwaterGunUnequipFromAimStrafeAnimationClip65000;
			unequipFromAimWaterAnimatorState78674blendTreeBlendTree79106Child1.cycleOffset = 0f;
			unequipFromAimWaterAnimatorState78674blendTreeBlendTree79106Child1.directBlendParameter = "HorizontalMovement";
			unequipFromAimWaterAnimatorState78674blendTreeBlendTree79106Child1.mirror = false;
			unequipFromAimWaterAnimatorState78674blendTreeBlendTree79106Child1.position = new Vector2(-1f, 0f);
			unequipFromAimWaterAnimatorState78674blendTreeBlendTree79106Child1.threshold = 0.25f;
			unequipFromAimWaterAnimatorState78674blendTreeBlendTree79106Child1.timeScale = 1f;
			var unequipFromAimWaterAnimatorState78674blendTreeBlendTree79106Child2 =  new ChildMotion();
			unequipFromAimWaterAnimatorState78674blendTreeBlendTree79106Child2.motion = underwaterGunUnequipFromAimAnimationClip64988;
			unequipFromAimWaterAnimatorState78674blendTreeBlendTree79106Child2.cycleOffset = 0f;
			unequipFromAimWaterAnimatorState78674blendTreeBlendTree79106Child2.directBlendParameter = "HorizontalMovement";
			unequipFromAimWaterAnimatorState78674blendTreeBlendTree79106Child2.mirror = false;
			unequipFromAimWaterAnimatorState78674blendTreeBlendTree79106Child2.position = new Vector2(0f, 0f);
			unequipFromAimWaterAnimatorState78674blendTreeBlendTree79106Child2.threshold = 0.5f;
			unequipFromAimWaterAnimatorState78674blendTreeBlendTree79106Child2.timeScale = 1f;
			var unequipFromAimWaterAnimatorState78674blendTreeBlendTree79106Child3 =  new ChildMotion();
			unequipFromAimWaterAnimatorState78674blendTreeBlendTree79106Child3.motion = underwaterGunUnequipFromAimStrafeAnimationClip65000;
			unequipFromAimWaterAnimatorState78674blendTreeBlendTree79106Child3.cycleOffset = 0f;
			unequipFromAimWaterAnimatorState78674blendTreeBlendTree79106Child3.directBlendParameter = "HorizontalMovement";
			unequipFromAimWaterAnimatorState78674blendTreeBlendTree79106Child3.mirror = false;
			unequipFromAimWaterAnimatorState78674blendTreeBlendTree79106Child3.position = new Vector2(1f, 0f);
			unequipFromAimWaterAnimatorState78674blendTreeBlendTree79106Child3.threshold = 0.75f;
			unequipFromAimWaterAnimatorState78674blendTreeBlendTree79106Child3.timeScale = 1f;
			var unequipFromAimWaterAnimatorState78674blendTreeBlendTree79106Child4 =  new ChildMotion();
			unequipFromAimWaterAnimatorState78674blendTreeBlendTree79106Child4.motion = underwaterGunUnequipFromAimAnimationClip64988;
			unequipFromAimWaterAnimatorState78674blendTreeBlendTree79106Child4.cycleOffset = 0f;
			unequipFromAimWaterAnimatorState78674blendTreeBlendTree79106Child4.directBlendParameter = "HorizontalMovement";
			unequipFromAimWaterAnimatorState78674blendTreeBlendTree79106Child4.mirror = false;
			unequipFromAimWaterAnimatorState78674blendTreeBlendTree79106Child4.position = new Vector2(0f, 1f);
			unequipFromAimWaterAnimatorState78674blendTreeBlendTree79106Child4.threshold = 1f;
			unequipFromAimWaterAnimatorState78674blendTreeBlendTree79106Child4.timeScale = 1f;
			unequipFromAimWaterAnimatorState78674blendTreeBlendTree79106.children = new ChildMotion[] {
				unequipFromAimWaterAnimatorState78674blendTreeBlendTree79106Child0,
				unequipFromAimWaterAnimatorState78674blendTreeBlendTree79106Child1,
				unequipFromAimWaterAnimatorState78674blendTreeBlendTree79106Child2,
				unequipFromAimWaterAnimatorState78674blendTreeBlendTree79106Child3,
				unequipFromAimWaterAnimatorState78674blendTreeBlendTree79106Child4
			};
			unequipFromAimWaterAnimatorState78674.motion = unequipFromAimWaterAnimatorState78674blendTreeBlendTree79106;
			unequipFromAimWaterAnimatorState78674.cycleOffset = 0f;
			unequipFromAimWaterAnimatorState78674.cycleOffsetParameterActive = false;
			unequipFromAimWaterAnimatorState78674.iKOnFeet = false;
			unequipFromAimWaterAnimatorState78674.mirror = false;
			unequipFromAimWaterAnimatorState78674.mirrorParameterActive = false;
			unequipFromAimWaterAnimatorState78674.speed = 3f;
			unequipFromAimWaterAnimatorState78674.speedParameterActive = false;
			unequipFromAimWaterAnimatorState78674.writeDefaultValues = true;

			var unequipFromIdleWaterAnimatorState78676 = underwaterGunAnimatorStateMachine78246.AddState("Unequip From Idle Water", new Vector3(384f, 444f, 0f));
			var unequipFromIdleWaterAnimatorState78676blendTreeBlendTree79110 = new BlendTree();
			AssetDatabase.AddObjectToAsset(unequipFromIdleWaterAnimatorState78676blendTreeBlendTree79110, animatorController);
			unequipFromIdleWaterAnimatorState78676blendTreeBlendTree79110.hideFlags = HideFlags.HideInHierarchy;
			unequipFromIdleWaterAnimatorState78676blendTreeBlendTree79110.blendParameter = "HorizontalMovement";
			unequipFromIdleWaterAnimatorState78676blendTreeBlendTree79110.blendParameterY = "ForwardMovement";
			unequipFromIdleWaterAnimatorState78676blendTreeBlendTree79110.blendType = BlendTreeType.FreeformCartesian2D;
			unequipFromIdleWaterAnimatorState78676blendTreeBlendTree79110.maxThreshold = 1f;
			unequipFromIdleWaterAnimatorState78676blendTreeBlendTree79110.minThreshold = 0f;
			unequipFromIdleWaterAnimatorState78676blendTreeBlendTree79110.name = "Blend Tree";
			unequipFromIdleWaterAnimatorState78676blendTreeBlendTree79110.useAutomaticThresholds = true;
			var unequipFromIdleWaterAnimatorState78676blendTreeBlendTree79110Child0 =  new ChildMotion();
			unequipFromIdleWaterAnimatorState78676blendTreeBlendTree79110Child0.motion = underwaterGunUnequipFromIdleLandAnimationClip65012;
			unequipFromIdleWaterAnimatorState78676blendTreeBlendTree79110Child0.cycleOffset = 0f;
			unequipFromIdleWaterAnimatorState78676blendTreeBlendTree79110Child0.directBlendParameter = "HorizontalMovement";
			unequipFromIdleWaterAnimatorState78676blendTreeBlendTree79110Child0.mirror = false;
			unequipFromIdleWaterAnimatorState78676blendTreeBlendTree79110Child0.position = new Vector2(0f, -1f);
			unequipFromIdleWaterAnimatorState78676blendTreeBlendTree79110Child0.threshold = 0f;
			unequipFromIdleWaterAnimatorState78676blendTreeBlendTree79110Child0.timeScale = 1f;
			var unequipFromIdleWaterAnimatorState78676blendTreeBlendTree79110Child1 =  new ChildMotion();
			unequipFromIdleWaterAnimatorState78676blendTreeBlendTree79110Child1.motion = underwaterGunUnequipFromIdleStrafeAnimationClip65018;
			unequipFromIdleWaterAnimatorState78676blendTreeBlendTree79110Child1.cycleOffset = 0f;
			unequipFromIdleWaterAnimatorState78676blendTreeBlendTree79110Child1.directBlendParameter = "HorizontalMovement";
			unequipFromIdleWaterAnimatorState78676blendTreeBlendTree79110Child1.mirror = false;
			unequipFromIdleWaterAnimatorState78676blendTreeBlendTree79110Child1.position = new Vector2(-1f, 0f);
			unequipFromIdleWaterAnimatorState78676blendTreeBlendTree79110Child1.threshold = 0.25f;
			unequipFromIdleWaterAnimatorState78676blendTreeBlendTree79110Child1.timeScale = 1f;
			var unequipFromIdleWaterAnimatorState78676blendTreeBlendTree79110Child2 =  new ChildMotion();
			unequipFromIdleWaterAnimatorState78676blendTreeBlendTree79110Child2.motion = underwaterGunUnequipFromIdleAnimationClip65006;
			unequipFromIdleWaterAnimatorState78676blendTreeBlendTree79110Child2.cycleOffset = 0f;
			unequipFromIdleWaterAnimatorState78676blendTreeBlendTree79110Child2.directBlendParameter = "HorizontalMovement";
			unequipFromIdleWaterAnimatorState78676blendTreeBlendTree79110Child2.mirror = false;
			unequipFromIdleWaterAnimatorState78676blendTreeBlendTree79110Child2.position = new Vector2(0f, 0f);
			unequipFromIdleWaterAnimatorState78676blendTreeBlendTree79110Child2.threshold = 0.5f;
			unequipFromIdleWaterAnimatorState78676blendTreeBlendTree79110Child2.timeScale = 1f;
			var unequipFromIdleWaterAnimatorState78676blendTreeBlendTree79110Child3 =  new ChildMotion();
			unequipFromIdleWaterAnimatorState78676blendTreeBlendTree79110Child3.motion = underwaterGunUnequipFromIdleStrafeAnimationClip65018;
			unequipFromIdleWaterAnimatorState78676blendTreeBlendTree79110Child3.cycleOffset = 0f;
			unequipFromIdleWaterAnimatorState78676blendTreeBlendTree79110Child3.directBlendParameter = "HorizontalMovement";
			unequipFromIdleWaterAnimatorState78676blendTreeBlendTree79110Child3.mirror = false;
			unequipFromIdleWaterAnimatorState78676blendTreeBlendTree79110Child3.position = new Vector2(1f, 0f);
			unequipFromIdleWaterAnimatorState78676blendTreeBlendTree79110Child3.threshold = 0.75f;
			unequipFromIdleWaterAnimatorState78676blendTreeBlendTree79110Child3.timeScale = 1f;
			var unequipFromIdleWaterAnimatorState78676blendTreeBlendTree79110Child4 =  new ChildMotion();
			unequipFromIdleWaterAnimatorState78676blendTreeBlendTree79110Child4.motion = underwaterGunUnequipFromIdleAnimationClip65006;
			unequipFromIdleWaterAnimatorState78676blendTreeBlendTree79110Child4.cycleOffset = 0f;
			unequipFromIdleWaterAnimatorState78676blendTreeBlendTree79110Child4.directBlendParameter = "HorizontalMovement";
			unequipFromIdleWaterAnimatorState78676blendTreeBlendTree79110Child4.mirror = false;
			unequipFromIdleWaterAnimatorState78676blendTreeBlendTree79110Child4.position = new Vector2(0f, 1f);
			unequipFromIdleWaterAnimatorState78676blendTreeBlendTree79110Child4.threshold = 1f;
			unequipFromIdleWaterAnimatorState78676blendTreeBlendTree79110Child4.timeScale = 1f;
			unequipFromIdleWaterAnimatorState78676blendTreeBlendTree79110.children = new ChildMotion[] {
				unequipFromIdleWaterAnimatorState78676blendTreeBlendTree79110Child0,
				unequipFromIdleWaterAnimatorState78676blendTreeBlendTree79110Child1,
				unequipFromIdleWaterAnimatorState78676blendTreeBlendTree79110Child2,
				unequipFromIdleWaterAnimatorState78676blendTreeBlendTree79110Child3,
				unequipFromIdleWaterAnimatorState78676blendTreeBlendTree79110Child4
			};
			unequipFromIdleWaterAnimatorState78676.motion = unequipFromIdleWaterAnimatorState78676blendTreeBlendTree79110;
			unequipFromIdleWaterAnimatorState78676.cycleOffset = 0f;
			unequipFromIdleWaterAnimatorState78676.cycleOffsetParameterActive = false;
			unequipFromIdleWaterAnimatorState78676.iKOnFeet = false;
			unequipFromIdleWaterAnimatorState78676.mirror = false;
			unequipFromIdleWaterAnimatorState78676.mirrorParameterActive = false;
			unequipFromIdleWaterAnimatorState78676.speed = 3f;
			unequipFromIdleWaterAnimatorState78676.speedParameterActive = false;
			unequipFromIdleWaterAnimatorState78676.writeDefaultValues = true;

			// State Machine Defaults.
			underwaterGunAnimatorStateMachine78246.anyStatePosition = new Vector3(50f, 20f, 0f);
			underwaterGunAnimatorStateMachine78246.defaultState = unequipFromIdleLandAnimatorState78648;
			underwaterGunAnimatorStateMachine78246.entryPosition = new Vector3(50f, 120f, 0f);
			underwaterGunAnimatorStateMachine78246.exitPosition = new Vector3(800f, 120f, 0f);
			underwaterGunAnimatorStateMachine78246.parentStateMachinePosition = new Vector3(800f, 20f, 0f);

			// State Transitions.
			var animatorStateTransition79056 = aimWaterAnimatorState78646.AddExitTransition();
			animatorStateTransition79056.canTransitionToSelf = true;
			animatorStateTransition79056.duration = 0.25f;
			animatorStateTransition79056.exitTime = 0f;
			animatorStateTransition79056.hasExitTime = false;
			animatorStateTransition79056.hasFixedDuration = true;
			animatorStateTransition79056.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition79056.offset = 0f;
			animatorStateTransition79056.orderedInterruption = true;
			animatorStateTransition79056.isExit = true;
			animatorStateTransition79056.mute = false;
			animatorStateTransition79056.solo = false;
			animatorStateTransition79056.AddCondition(AnimatorConditionMode.NotEqual, 26f, "Slot0ItemID");

			var animatorStateTransition79058 = aimWaterAnimatorState78646.AddExitTransition();
			animatorStateTransition79058.canTransitionToSelf = true;
			animatorStateTransition79058.duration = 0.25f;
			animatorStateTransition79058.exitTime = 0f;
			animatorStateTransition79058.hasExitTime = false;
			animatorStateTransition79058.hasFixedDuration = true;
			animatorStateTransition79058.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition79058.offset = 0f;
			animatorStateTransition79058.orderedInterruption = true;
			animatorStateTransition79058.isExit = true;
			animatorStateTransition79058.mute = false;
			animatorStateTransition79058.solo = false;
			animatorStateTransition79058.AddCondition(AnimatorConditionMode.IfNot, 0f, "Aiming");

			var animatorStateTransition79062 = aimLandAnimatorState78678.AddExitTransition();
			animatorStateTransition79062.canTransitionToSelf = true;
			animatorStateTransition79062.duration = 0.15f;
			animatorStateTransition79062.exitTime = 0f;
			animatorStateTransition79062.hasExitTime = false;
			animatorStateTransition79062.hasFixedDuration = true;
			animatorStateTransition79062.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition79062.offset = 0f;
			animatorStateTransition79062.orderedInterruption = true;
			animatorStateTransition79062.isExit = true;
			animatorStateTransition79062.mute = false;
			animatorStateTransition79062.solo = false;
			animatorStateTransition79062.AddCondition(AnimatorConditionMode.NotEqual, 26f, "Slot0ItemID");

			var animatorStateTransition79064 = aimLandAnimatorState78678.AddExitTransition();
			animatorStateTransition79064.canTransitionToSelf = true;
			animatorStateTransition79064.duration = 0.15f;
			animatorStateTransition79064.exitTime = 0f;
			animatorStateTransition79064.hasExitTime = false;
			animatorStateTransition79064.hasFixedDuration = true;
			animatorStateTransition79064.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition79064.offset = 0f;
			animatorStateTransition79064.orderedInterruption = true;
			animatorStateTransition79064.isExit = true;
			animatorStateTransition79064.mute = false;
			animatorStateTransition79064.solo = false;
			animatorStateTransition79064.AddCondition(AnimatorConditionMode.IfNot, 0f, "Aiming");


			// State Machine Transitions.
			var animatorStateTransition78426 = baseStateMachine1672981860.AddAnyStateTransition(aimWaterAnimatorState78646);
			animatorStateTransition78426.canTransitionToSelf = false;
			animatorStateTransition78426.duration = 0.25f;
			animatorStateTransition78426.exitTime = 0.75f;
			animatorStateTransition78426.hasExitTime = false;
			animatorStateTransition78426.hasFixedDuration = true;
			animatorStateTransition78426.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78426.offset = 0f;
			animatorStateTransition78426.orderedInterruption = true;
			animatorStateTransition78426.isExit = false;
			animatorStateTransition78426.mute = false;
			animatorStateTransition78426.solo = false;
			animatorStateTransition78426.AddCondition(AnimatorConditionMode.Equals, 26f, "Slot0ItemID");
			animatorStateTransition78426.AddCondition(AnimatorConditionMode.If, 0f, "Aiming");
			animatorStateTransition78426.AddCondition(AnimatorConditionMode.Equals, 301f, "AbilityIndex");
			animatorStateTransition78426.AddCondition(AnimatorConditionMode.NotEqual, 1f, "AbilityIntData");

			var animatorStateTransition78480 = baseStateMachine1672981860.AddAnyStateTransition(aimLandAnimatorState78678);
			animatorStateTransition78480.canTransitionToSelf = false;
			animatorStateTransition78480.duration = 0.1f;
			animatorStateTransition78480.exitTime = 0.75f;
			animatorStateTransition78480.hasExitTime = false;
			animatorStateTransition78480.hasFixedDuration = true;
			animatorStateTransition78480.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78480.offset = 0f;
			animatorStateTransition78480.orderedInterruption = true;
			animatorStateTransition78480.isExit = false;
			animatorStateTransition78480.mute = false;
			animatorStateTransition78480.solo = false;
			animatorStateTransition78480.AddCondition(AnimatorConditionMode.Equals, 26f, "Slot0ItemID");
			animatorStateTransition78480.AddCondition(AnimatorConditionMode.If, 0f, "Aiming");
			animatorStateTransition78480.AddCondition(AnimatorConditionMode.Equals, 301f, "AbilityIndex");
			animatorStateTransition78480.AddCondition(AnimatorConditionMode.Equals, 1f, "AbilityIntData");
			// State Transitions.
			var animatorStateTransition79066 = unequipFromIdleLandAnimatorState78648.AddExitTransition();
			animatorStateTransition79066.canTransitionToSelf = true;
			animatorStateTransition79066.duration = 0.2f;
			animatorStateTransition79066.exitTime = 0.75f;
			animatorStateTransition79066.hasExitTime = false;
			animatorStateTransition79066.hasFixedDuration = true;
			animatorStateTransition79066.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition79066.offset = 0f;
			animatorStateTransition79066.orderedInterruption = true;
			animatorStateTransition79066.isExit = true;
			animatorStateTransition79066.mute = false;
			animatorStateTransition79066.solo = false;
			animatorStateTransition79066.AddCondition(AnimatorConditionMode.NotEqual, 5f, "Slot0ItemStateIndex");

			var animatorStateTransition79068 = unequipFromAimLandAnimatorState78650.AddExitTransition();
			animatorStateTransition79068.canTransitionToSelf = true;
			animatorStateTransition79068.duration = 0.2f;
			animatorStateTransition79068.exitTime = 0.8846154f;
			animatorStateTransition79068.hasExitTime = false;
			animatorStateTransition79068.hasFixedDuration = true;
			animatorStateTransition79068.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition79068.offset = 0f;
			animatorStateTransition79068.orderedInterruption = true;
			animatorStateTransition79068.isExit = true;
			animatorStateTransition79068.mute = false;
			animatorStateTransition79068.solo = false;
			animatorStateTransition79068.AddCondition(AnimatorConditionMode.NotEqual, 5f, "Slot0ItemStateIndex");

			var animatorStateTransition79070 = equipFromAimLandAnimatorState78652.AddExitTransition();
			animatorStateTransition79070.canTransitionToSelf = true;
			animatorStateTransition79070.duration = 0.2f;
			animatorStateTransition79070.exitTime = 0.8846154f;
			animatorStateTransition79070.hasExitTime = false;
			animatorStateTransition79070.hasFixedDuration = true;
			animatorStateTransition79070.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition79070.offset = 0f;
			animatorStateTransition79070.orderedInterruption = true;
			animatorStateTransition79070.isExit = true;
			animatorStateTransition79070.mute = false;
			animatorStateTransition79070.solo = false;
			animatorStateTransition79070.AddCondition(AnimatorConditionMode.NotEqual, 4f, "Slot0ItemStateIndex");

			var animatorStateTransition79072 = equipFromIdleLandAnimatorState78654.AddExitTransition();
			animatorStateTransition79072.canTransitionToSelf = true;
			animatorStateTransition79072.duration = 0.2f;
			animatorStateTransition79072.exitTime = 0.75f;
			animatorStateTransition79072.hasExitTime = false;
			animatorStateTransition79072.hasFixedDuration = true;
			animatorStateTransition79072.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition79072.offset = 0f;
			animatorStateTransition79072.orderedInterruption = true;
			animatorStateTransition79072.isExit = true;
			animatorStateTransition79072.mute = false;
			animatorStateTransition79072.solo = false;
			animatorStateTransition79072.AddCondition(AnimatorConditionMode.NotEqual, 4f, "Slot0ItemStateIndex");

			var animatorStateTransition79074 = dropLandAnimatorState78656.AddExitTransition();
			animatorStateTransition79074.canTransitionToSelf = true;
			animatorStateTransition79074.duration = 0.1f;
			animatorStateTransition79074.exitTime = 0.9f;
			animatorStateTransition79074.hasExitTime = true;
			animatorStateTransition79074.hasFixedDuration = true;
			animatorStateTransition79074.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition79074.offset = 0f;
			animatorStateTransition79074.orderedInterruption = true;
			animatorStateTransition79074.isExit = true;
			animatorStateTransition79074.mute = false;
			animatorStateTransition79074.solo = false;

			var animatorStateTransition79076 = idleLandAnimatorState78658.AddExitTransition();
			animatorStateTransition79076.canTransitionToSelf = true;
			animatorStateTransition79076.duration = 0.15f;
			animatorStateTransition79076.exitTime = 0.75f;
			animatorStateTransition79076.hasExitTime = false;
			animatorStateTransition79076.hasFixedDuration = true;
			animatorStateTransition79076.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition79076.offset = 0f;
			animatorStateTransition79076.orderedInterruption = true;
			animatorStateTransition79076.isExit = true;
			animatorStateTransition79076.mute = false;
			animatorStateTransition79076.solo = false;
			animatorStateTransition79076.AddCondition(AnimatorConditionMode.NotEqual, 7f, "Slot0ItemID");

			var animatorStateTransition79078 = aimLandAnimatorState78660.AddExitTransition();
			animatorStateTransition79078.canTransitionToSelf = true;
			animatorStateTransition79078.duration = 0.15f;
			animatorStateTransition79078.exitTime = 0.75f;
			animatorStateTransition79078.hasExitTime = false;
			animatorStateTransition79078.hasFixedDuration = true;
			animatorStateTransition79078.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition79078.offset = 0f;
			animatorStateTransition79078.orderedInterruption = true;
			animatorStateTransition79078.isExit = true;
			animatorStateTransition79078.mute = false;
			animatorStateTransition79078.solo = false;
			animatorStateTransition79078.AddCondition(AnimatorConditionMode.NotEqual, 7f, "Slot0ItemID");

			var animatorStateTransition79080 = fireWaterAnimatorState78662.AddExitTransition();
			animatorStateTransition79080.canTransitionToSelf = true;
			animatorStateTransition79080.duration = 0.04f;
			animatorStateTransition79080.exitTime = 0f;
			animatorStateTransition79080.hasExitTime = false;
			animatorStateTransition79080.hasFixedDuration = true;
			animatorStateTransition79080.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition79080.offset = 0f;
			animatorStateTransition79080.orderedInterruption = false;
			animatorStateTransition79080.isExit = true;
			animatorStateTransition79080.mute = false;
			animatorStateTransition79080.solo = false;
			animatorStateTransition79080.AddCondition(AnimatorConditionMode.NotEqual, 2f, "Slot0ItemStateIndex");

			var animatorStateTransition79084 = aimWaterAnimatorState78664.AddExitTransition();
			animatorStateTransition79084.canTransitionToSelf = true;
			animatorStateTransition79084.duration = 0.15f;
			animatorStateTransition79084.exitTime = 0.75f;
			animatorStateTransition79084.hasExitTime = false;
			animatorStateTransition79084.hasFixedDuration = true;
			animatorStateTransition79084.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition79084.offset = 0f;
			animatorStateTransition79084.orderedInterruption = true;
			animatorStateTransition79084.isExit = true;
			animatorStateTransition79084.mute = false;
			animatorStateTransition79084.solo = false;
			animatorStateTransition79084.AddCondition(AnimatorConditionMode.NotEqual, 7f, "Slot0ItemID");

			var animatorStateTransition79088 = idleWaterAnimatorState78666.AddExitTransition();
			animatorStateTransition79088.canTransitionToSelf = true;
			animatorStateTransition79088.duration = 0.15f;
			animatorStateTransition79088.exitTime = 0.75f;
			animatorStateTransition79088.hasExitTime = false;
			animatorStateTransition79088.hasFixedDuration = true;
			animatorStateTransition79088.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition79088.offset = 0f;
			animatorStateTransition79088.orderedInterruption = true;
			animatorStateTransition79088.isExit = true;
			animatorStateTransition79088.mute = false;
			animatorStateTransition79088.solo = false;
			animatorStateTransition79088.AddCondition(AnimatorConditionMode.NotEqual, 7f, "Slot0ItemID");

			var animatorStateTransition79092 = dropWaterAnimatorState78668.AddExitTransition();
			animatorStateTransition79092.canTransitionToSelf = true;
			animatorStateTransition79092.duration = 0.1f;
			animatorStateTransition79092.exitTime = 0.9f;
			animatorStateTransition79092.hasExitTime = true;
			animatorStateTransition79092.hasFixedDuration = true;
			animatorStateTransition79092.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition79092.offset = 0f;
			animatorStateTransition79092.orderedInterruption = true;
			animatorStateTransition79092.isExit = true;
			animatorStateTransition79092.mute = false;
			animatorStateTransition79092.solo = false;

			var animatorStateTransition79096 = equipFromIdleWaterAnimatorState78670.AddExitTransition();
			animatorStateTransition79096.canTransitionToSelf = true;
			animatorStateTransition79096.duration = 0.2f;
			animatorStateTransition79096.exitTime = 0.75f;
			animatorStateTransition79096.hasExitTime = false;
			animatorStateTransition79096.hasFixedDuration = true;
			animatorStateTransition79096.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition79096.offset = 0f;
			animatorStateTransition79096.orderedInterruption = true;
			animatorStateTransition79096.isExit = true;
			animatorStateTransition79096.mute = false;
			animatorStateTransition79096.solo = false;
			animatorStateTransition79096.AddCondition(AnimatorConditionMode.NotEqual, 4f, "Slot0ItemStateIndex");

			var animatorStateTransition79100 = equipFromAimWaterAnimatorState78672.AddExitTransition();
			animatorStateTransition79100.canTransitionToSelf = true;
			animatorStateTransition79100.duration = 0.2f;
			animatorStateTransition79100.exitTime = 0.8846154f;
			animatorStateTransition79100.hasExitTime = false;
			animatorStateTransition79100.hasFixedDuration = true;
			animatorStateTransition79100.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition79100.offset = 0f;
			animatorStateTransition79100.orderedInterruption = true;
			animatorStateTransition79100.isExit = true;
			animatorStateTransition79100.mute = false;
			animatorStateTransition79100.solo = false;
			animatorStateTransition79100.AddCondition(AnimatorConditionMode.NotEqual, 4f, "Slot0ItemStateIndex");

			var animatorStateTransition79104 = unequipFromAimWaterAnimatorState78674.AddExitTransition();
			animatorStateTransition79104.canTransitionToSelf = true;
			animatorStateTransition79104.duration = 0.2f;
			animatorStateTransition79104.exitTime = 0.8846154f;
			animatorStateTransition79104.hasExitTime = false;
			animatorStateTransition79104.hasFixedDuration = true;
			animatorStateTransition79104.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition79104.offset = 0f;
			animatorStateTransition79104.orderedInterruption = true;
			animatorStateTransition79104.isExit = true;
			animatorStateTransition79104.mute = false;
			animatorStateTransition79104.solo = false;
			animatorStateTransition79104.AddCondition(AnimatorConditionMode.NotEqual, 5f, "Slot0ItemStateIndex");

			var animatorStateTransition79108 = unequipFromIdleWaterAnimatorState78676.AddExitTransition();
			animatorStateTransition79108.canTransitionToSelf = true;
			animatorStateTransition79108.duration = 0.2f;
			animatorStateTransition79108.exitTime = 0.75f;
			animatorStateTransition79108.hasExitTime = false;
			animatorStateTransition79108.hasFixedDuration = true;
			animatorStateTransition79108.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition79108.offset = 0f;
			animatorStateTransition79108.orderedInterruption = true;
			animatorStateTransition79108.isExit = true;
			animatorStateTransition79108.mute = false;
			animatorStateTransition79108.solo = false;
			animatorStateTransition79108.AddCondition(AnimatorConditionMode.NotEqual, 5f, "Slot0ItemStateIndex");


			// State Machine Transitions.
			var animatorStateTransition78444 = baseStateMachine1742974310.AddAnyStateTransition(fireWaterAnimatorState78662);
			animatorStateTransition78444.canTransitionToSelf = false;
			animatorStateTransition78444.duration = 0.04f;
			animatorStateTransition78444.exitTime = 0.75f;
			animatorStateTransition78444.hasExitTime = false;
			animatorStateTransition78444.hasFixedDuration = true;
			animatorStateTransition78444.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78444.offset = 0f;
			animatorStateTransition78444.orderedInterruption = true;
			animatorStateTransition78444.isExit = false;
			animatorStateTransition78444.mute = false;
			animatorStateTransition78444.solo = false;
			animatorStateTransition78444.AddCondition(AnimatorConditionMode.Equals, 7f, "Slot0ItemID");
			animatorStateTransition78444.AddCondition(AnimatorConditionMode.Equals, 2f, "Slot0ItemStateIndex");
			animatorStateTransition78444.AddCondition(AnimatorConditionMode.Equals, 2f, "Slot0ItemSubstateIndex");
			animatorStateTransition78444.AddCondition(AnimatorConditionMode.Equals, 301f, "AbilityIndex");
			animatorStateTransition78444.AddCondition(AnimatorConditionMode.NotEqual, 1f, "AbilityIntData");

			var animatorStateTransition78446 = baseStateMachine1742974310.AddAnyStateTransition(aimWaterAnimatorState78664);
			animatorStateTransition78446.canTransitionToSelf = false;
			animatorStateTransition78446.duration = 0.04f;
			animatorStateTransition78446.exitTime = 0.75f;
			animatorStateTransition78446.hasExitTime = false;
			animatorStateTransition78446.hasFixedDuration = true;
			animatorStateTransition78446.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78446.offset = 0f;
			animatorStateTransition78446.orderedInterruption = true;
			animatorStateTransition78446.isExit = false;
			animatorStateTransition78446.mute = false;
			animatorStateTransition78446.solo = false;
			animatorStateTransition78446.AddCondition(AnimatorConditionMode.Equals, 7f, "Slot0ItemID");
			animatorStateTransition78446.AddCondition(AnimatorConditionMode.Equals, 2f, "Slot0ItemStateIndex");
			animatorStateTransition78446.AddCondition(AnimatorConditionMode.NotEqual, 11f, "Slot0ItemSubstateIndex");
			animatorStateTransition78446.AddCondition(AnimatorConditionMode.NotEqual, 2f, "Slot0ItemSubstateIndex");
			animatorStateTransition78446.AddCondition(AnimatorConditionMode.Equals, 301f, "AbilityIndex");
			animatorStateTransition78446.AddCondition(AnimatorConditionMode.NotEqual, 1f, "AbilityIntData");

			var animatorStateTransition78448 = baseStateMachine1742974310.AddAnyStateTransition(aimWaterAnimatorState78664);
			animatorStateTransition78448.canTransitionToSelf = false;
			animatorStateTransition78448.duration = 0.08f;
			animatorStateTransition78448.exitTime = 0.75f;
			animatorStateTransition78448.hasExitTime = false;
			animatorStateTransition78448.hasFixedDuration = true;
			animatorStateTransition78448.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78448.offset = 0f;
			animatorStateTransition78448.orderedInterruption = true;
			animatorStateTransition78448.isExit = false;
			animatorStateTransition78448.mute = false;
			animatorStateTransition78448.solo = false;
			animatorStateTransition78448.AddCondition(AnimatorConditionMode.Equals, 7f, "Slot0ItemID");
			animatorStateTransition78448.AddCondition(AnimatorConditionMode.If, 0f, "Aiming");
			animatorStateTransition78448.AddCondition(AnimatorConditionMode.Less, 2f, "Slot0ItemStateIndex");
			animatorStateTransition78448.AddCondition(AnimatorConditionMode.Equals, 301f, "AbilityIndex");
			animatorStateTransition78448.AddCondition(AnimatorConditionMode.NotEqual, 1f, "AbilityIntData");

			var animatorStateTransition78450 = baseStateMachine1742974310.AddAnyStateTransition(idleWaterAnimatorState78666);
			animatorStateTransition78450.canTransitionToSelf = false;
			animatorStateTransition78450.duration = 0.1f;
			animatorStateTransition78450.exitTime = 0.75f;
			animatorStateTransition78450.hasExitTime = false;
			animatorStateTransition78450.hasFixedDuration = true;
			animatorStateTransition78450.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78450.offset = 0f;
			animatorStateTransition78450.orderedInterruption = true;
			animatorStateTransition78450.isExit = false;
			animatorStateTransition78450.mute = false;
			animatorStateTransition78450.solo = false;
			animatorStateTransition78450.AddCondition(AnimatorConditionMode.Equals, 7f, "Slot0ItemID");
			animatorStateTransition78450.AddCondition(AnimatorConditionMode.Less, 2f, "Slot0ItemStateIndex");
			animatorStateTransition78450.AddCondition(AnimatorConditionMode.IfNot, 0f, "Aiming");
			animatorStateTransition78450.AddCondition(AnimatorConditionMode.Equals, 301f, "AbilityIndex");
			animatorStateTransition78450.AddCondition(AnimatorConditionMode.NotEqual, 1f, "AbilityIntData");

			var animatorStateTransition78452 = baseStateMachine1742974310.AddAnyStateTransition(dropWaterAnimatorState78668);
			animatorStateTransition78452.canTransitionToSelf = false;
			animatorStateTransition78452.duration = 0.1f;
			animatorStateTransition78452.exitTime = 0.75f;
			animatorStateTransition78452.hasExitTime = false;
			animatorStateTransition78452.hasFixedDuration = true;
			animatorStateTransition78452.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78452.offset = 0f;
			animatorStateTransition78452.orderedInterruption = true;
			animatorStateTransition78452.isExit = false;
			animatorStateTransition78452.mute = false;
			animatorStateTransition78452.solo = false;
			animatorStateTransition78452.AddCondition(AnimatorConditionMode.If, 0f, "Slot0ItemStateIndexChange");
			animatorStateTransition78452.AddCondition(AnimatorConditionMode.Equals, 7f, "Slot0ItemID");
			animatorStateTransition78452.AddCondition(AnimatorConditionMode.Equals, 6f, "Slot0ItemStateIndex");
			animatorStateTransition78452.AddCondition(AnimatorConditionMode.Equals, 301f, "AbilityIndex");
			animatorStateTransition78452.AddCondition(AnimatorConditionMode.NotEqual, 1f, "AbilityIntData");

			var animatorStateTransition78454 = baseStateMachine1742974310.AddAnyStateTransition(equipFromIdleWaterAnimatorState78670);
			animatorStateTransition78454.canTransitionToSelf = false;
			animatorStateTransition78454.duration = 0.15f;
			animatorStateTransition78454.exitTime = 0.75f;
			animatorStateTransition78454.hasExitTime = false;
			animatorStateTransition78454.hasFixedDuration = true;
			animatorStateTransition78454.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78454.offset = 0f;
			animatorStateTransition78454.orderedInterruption = true;
			animatorStateTransition78454.isExit = false;
			animatorStateTransition78454.mute = false;
			animatorStateTransition78454.solo = false;
			animatorStateTransition78454.AddCondition(AnimatorConditionMode.If, 0f, "Slot0ItemStateIndexChange");
			animatorStateTransition78454.AddCondition(AnimatorConditionMode.Equals, 7f, "Slot0ItemID");
			animatorStateTransition78454.AddCondition(AnimatorConditionMode.Equals, 4f, "Slot0ItemStateIndex");
			animatorStateTransition78454.AddCondition(AnimatorConditionMode.IfNot, 0f, "Aiming");
			animatorStateTransition78454.AddCondition(AnimatorConditionMode.Equals, 301f, "AbilityIndex");
			animatorStateTransition78454.AddCondition(AnimatorConditionMode.NotEqual, 1f, "AbilityIntData");

			var animatorStateTransition78456 = baseStateMachine1742974310.AddAnyStateTransition(equipFromAimWaterAnimatorState78672);
			animatorStateTransition78456.canTransitionToSelf = false;
			animatorStateTransition78456.duration = 0.15f;
			animatorStateTransition78456.exitTime = 0.75f;
			animatorStateTransition78456.hasExitTime = false;
			animatorStateTransition78456.hasFixedDuration = true;
			animatorStateTransition78456.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78456.offset = 0f;
			animatorStateTransition78456.orderedInterruption = true;
			animatorStateTransition78456.isExit = false;
			animatorStateTransition78456.mute = false;
			animatorStateTransition78456.solo = false;
			animatorStateTransition78456.AddCondition(AnimatorConditionMode.If, 0f, "Slot0ItemStateIndexChange");
			animatorStateTransition78456.AddCondition(AnimatorConditionMode.Equals, 7f, "Slot0ItemID");
			animatorStateTransition78456.AddCondition(AnimatorConditionMode.Equals, 4f, "Slot0ItemStateIndex");
			animatorStateTransition78456.AddCondition(AnimatorConditionMode.If, 0f, "Aiming");
			animatorStateTransition78456.AddCondition(AnimatorConditionMode.Equals, 301f, "AbilityIndex");
			animatorStateTransition78456.AddCondition(AnimatorConditionMode.NotEqual, 1f, "AbilityIntData");

			var animatorStateTransition78458 = baseStateMachine1742974310.AddAnyStateTransition(unequipFromAimWaterAnimatorState78674);
			animatorStateTransition78458.canTransitionToSelf = false;
			animatorStateTransition78458.duration = 0.15f;
			animatorStateTransition78458.exitTime = 0.75f;
			animatorStateTransition78458.hasExitTime = false;
			animatorStateTransition78458.hasFixedDuration = true;
			animatorStateTransition78458.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78458.offset = 0f;
			animatorStateTransition78458.orderedInterruption = true;
			animatorStateTransition78458.isExit = false;
			animatorStateTransition78458.mute = false;
			animatorStateTransition78458.solo = false;
			animatorStateTransition78458.AddCondition(AnimatorConditionMode.If, 0f, "Slot0ItemStateIndexChange");
			animatorStateTransition78458.AddCondition(AnimatorConditionMode.Equals, 7f, "Slot0ItemID");
			animatorStateTransition78458.AddCondition(AnimatorConditionMode.Equals, 5f, "Slot0ItemStateIndex");
			animatorStateTransition78458.AddCondition(AnimatorConditionMode.If, 0f, "Aiming");
			animatorStateTransition78458.AddCondition(AnimatorConditionMode.Equals, 301f, "AbilityIndex");
			animatorStateTransition78458.AddCondition(AnimatorConditionMode.NotEqual, 1f, "AbilityIntData");

			var animatorStateTransition78460 = baseStateMachine1742974310.AddAnyStateTransition(unequipFromIdleWaterAnimatorState78676);
			animatorStateTransition78460.canTransitionToSelf = false;
			animatorStateTransition78460.duration = 0.15f;
			animatorStateTransition78460.exitTime = 0.75f;
			animatorStateTransition78460.hasExitTime = false;
			animatorStateTransition78460.hasFixedDuration = true;
			animatorStateTransition78460.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78460.offset = 0f;
			animatorStateTransition78460.orderedInterruption = true;
			animatorStateTransition78460.isExit = false;
			animatorStateTransition78460.mute = false;
			animatorStateTransition78460.solo = false;
			animatorStateTransition78460.AddCondition(AnimatorConditionMode.If, 0f, "Slot0ItemStateIndexChange");
			animatorStateTransition78460.AddCondition(AnimatorConditionMode.Equals, 7f, "Slot0ItemID");
			animatorStateTransition78460.AddCondition(AnimatorConditionMode.Equals, 5f, "Slot0ItemStateIndex");
			animatorStateTransition78460.AddCondition(AnimatorConditionMode.IfNot, 0f, "Aiming");
			animatorStateTransition78460.AddCondition(AnimatorConditionMode.Equals, 301f, "AbilityIndex");
			animatorStateTransition78460.AddCondition(AnimatorConditionMode.NotEqual, 1f, "AbilityIntData");

			var animatorStateTransition78464 = baseStateMachine1742974310.AddAnyStateTransition(idleLandAnimatorState78658);
			animatorStateTransition78464.canTransitionToSelf = false;
			animatorStateTransition78464.duration = 0.1f;
			animatorStateTransition78464.exitTime = 0.75f;
			animatorStateTransition78464.hasExitTime = false;
			animatorStateTransition78464.hasFixedDuration = true;
			animatorStateTransition78464.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78464.offset = 0f;
			animatorStateTransition78464.orderedInterruption = true;
			animatorStateTransition78464.isExit = false;
			animatorStateTransition78464.mute = false;
			animatorStateTransition78464.solo = false;
			animatorStateTransition78464.AddCondition(AnimatorConditionMode.Equals, 7f, "Slot0ItemID");
			animatorStateTransition78464.AddCondition(AnimatorConditionMode.Less, 2f, "Slot0ItemStateIndex");
			animatorStateTransition78464.AddCondition(AnimatorConditionMode.IfNot, 0f, "Aiming");
			animatorStateTransition78464.AddCondition(AnimatorConditionMode.Equals, 301f, "AbilityIndex");
			animatorStateTransition78464.AddCondition(AnimatorConditionMode.Equals, 1f, "AbilityIntData");

			var animatorStateTransition78466 = baseStateMachine1742974310.AddAnyStateTransition(aimLandAnimatorState78660);
			animatorStateTransition78466.canTransitionToSelf = false;
			animatorStateTransition78466.duration = 0.04f;
			animatorStateTransition78466.exitTime = 0.75f;
			animatorStateTransition78466.hasExitTime = false;
			animatorStateTransition78466.hasFixedDuration = true;
			animatorStateTransition78466.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78466.offset = 0f;
			animatorStateTransition78466.orderedInterruption = true;
			animatorStateTransition78466.isExit = false;
			animatorStateTransition78466.mute = false;
			animatorStateTransition78466.solo = false;
			animatorStateTransition78466.AddCondition(AnimatorConditionMode.Equals, 7f, "Slot0ItemID");
			animatorStateTransition78466.AddCondition(AnimatorConditionMode.Equals, 2f, "Slot0ItemStateIndex");
			animatorStateTransition78466.AddCondition(AnimatorConditionMode.NotEqual, 2f, "Slot0ItemSubstateIndex");
			animatorStateTransition78466.AddCondition(AnimatorConditionMode.NotEqual, 11f, "Slot0ItemSubstateIndex");
			animatorStateTransition78466.AddCondition(AnimatorConditionMode.Equals, 301f, "AbilityIndex");
			animatorStateTransition78466.AddCondition(AnimatorConditionMode.Equals, 1f, "AbilityIntData");

			var animatorStateTransition78468 = baseStateMachine1742974310.AddAnyStateTransition(equipFromAimLandAnimatorState78652);
			animatorStateTransition78468.canTransitionToSelf = false;
			animatorStateTransition78468.duration = 0.15f;
			animatorStateTransition78468.exitTime = 0.75f;
			animatorStateTransition78468.hasExitTime = false;
			animatorStateTransition78468.hasFixedDuration = true;
			animatorStateTransition78468.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78468.offset = 0f;
			animatorStateTransition78468.orderedInterruption = true;
			animatorStateTransition78468.isExit = false;
			animatorStateTransition78468.mute = false;
			animatorStateTransition78468.solo = false;
			animatorStateTransition78468.AddCondition(AnimatorConditionMode.If, 0f, "Slot0ItemStateIndexChange");
			animatorStateTransition78468.AddCondition(AnimatorConditionMode.Equals, 7f, "Slot0ItemID");
			animatorStateTransition78468.AddCondition(AnimatorConditionMode.Equals, 4f, "Slot0ItemStateIndex");
			animatorStateTransition78468.AddCondition(AnimatorConditionMode.If, 0f, "Aiming");
			animatorStateTransition78468.AddCondition(AnimatorConditionMode.Equals, 301f, "AbilityIndex");
			animatorStateTransition78468.AddCondition(AnimatorConditionMode.Equals, 1f, "AbilityIntData");

			var animatorStateTransition78470 = baseStateMachine1742974310.AddAnyStateTransition(unequipFromAimLandAnimatorState78650);
			animatorStateTransition78470.canTransitionToSelf = false;
			animatorStateTransition78470.duration = 0.15f;
			animatorStateTransition78470.exitTime = 0.75f;
			animatorStateTransition78470.hasExitTime = false;
			animatorStateTransition78470.hasFixedDuration = true;
			animatorStateTransition78470.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78470.offset = 0f;
			animatorStateTransition78470.orderedInterruption = true;
			animatorStateTransition78470.isExit = false;
			animatorStateTransition78470.mute = false;
			animatorStateTransition78470.solo = false;
			animatorStateTransition78470.AddCondition(AnimatorConditionMode.If, 0f, "Slot0ItemStateIndexChange");
			animatorStateTransition78470.AddCondition(AnimatorConditionMode.Equals, 7f, "Slot0ItemID");
			animatorStateTransition78470.AddCondition(AnimatorConditionMode.Equals, 5f, "Slot0ItemStateIndex");
			animatorStateTransition78470.AddCondition(AnimatorConditionMode.If, 0f, "Aiming");
			animatorStateTransition78470.AddCondition(AnimatorConditionMode.Equals, 301f, "AbilityIndex");
			animatorStateTransition78470.AddCondition(AnimatorConditionMode.Equals, 1f, "AbilityIntData");

			var animatorStateTransition78472 = baseStateMachine1742974310.AddAnyStateTransition(equipFromIdleLandAnimatorState78654);
			animatorStateTransition78472.canTransitionToSelf = false;
			animatorStateTransition78472.duration = 0.15f;
			animatorStateTransition78472.exitTime = 0.75f;
			animatorStateTransition78472.hasExitTime = false;
			animatorStateTransition78472.hasFixedDuration = true;
			animatorStateTransition78472.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78472.offset = 0f;
			animatorStateTransition78472.orderedInterruption = true;
			animatorStateTransition78472.isExit = false;
			animatorStateTransition78472.mute = false;
			animatorStateTransition78472.solo = false;
			animatorStateTransition78472.AddCondition(AnimatorConditionMode.If, 0f, "Slot0ItemStateIndexChange");
			animatorStateTransition78472.AddCondition(AnimatorConditionMode.Equals, 7f, "Slot0ItemID");
			animatorStateTransition78472.AddCondition(AnimatorConditionMode.Equals, 4f, "Slot0ItemStateIndex");
			animatorStateTransition78472.AddCondition(AnimatorConditionMode.IfNot, 0f, "Aiming");
			animatorStateTransition78472.AddCondition(AnimatorConditionMode.Equals, 301f, "AbilityIndex");
			animatorStateTransition78472.AddCondition(AnimatorConditionMode.Equals, 1f, "AbilityIntData");

			var animatorStateTransition78474 = baseStateMachine1742974310.AddAnyStateTransition(unequipFromIdleLandAnimatorState78648);
			animatorStateTransition78474.canTransitionToSelf = false;
			animatorStateTransition78474.duration = 0.15f;
			animatorStateTransition78474.exitTime = 0.75f;
			animatorStateTransition78474.hasExitTime = false;
			animatorStateTransition78474.hasFixedDuration = true;
			animatorStateTransition78474.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78474.offset = 0f;
			animatorStateTransition78474.orderedInterruption = true;
			animatorStateTransition78474.isExit = false;
			animatorStateTransition78474.mute = false;
			animatorStateTransition78474.solo = false;
			animatorStateTransition78474.AddCondition(AnimatorConditionMode.If, 0f, "Slot0ItemStateIndexChange");
			animatorStateTransition78474.AddCondition(AnimatorConditionMode.Equals, 7f, "Slot0ItemID");
			animatorStateTransition78474.AddCondition(AnimatorConditionMode.Equals, 5f, "Slot0ItemStateIndex");
			animatorStateTransition78474.AddCondition(AnimatorConditionMode.IfNot, 0f, "Aiming");
			animatorStateTransition78474.AddCondition(AnimatorConditionMode.Equals, 301f, "AbilityIndex");
			animatorStateTransition78474.AddCondition(AnimatorConditionMode.Equals, 1f, "AbilityIntData");

			var animatorStateTransition78476 = baseStateMachine1742974310.AddAnyStateTransition(dropLandAnimatorState78656);
			animatorStateTransition78476.canTransitionToSelf = false;
			animatorStateTransition78476.duration = 0.1f;
			animatorStateTransition78476.exitTime = 0.75f;
			animatorStateTransition78476.hasExitTime = false;
			animatorStateTransition78476.hasFixedDuration = true;
			animatorStateTransition78476.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78476.offset = 0f;
			animatorStateTransition78476.orderedInterruption = true;
			animatorStateTransition78476.isExit = false;
			animatorStateTransition78476.mute = false;
			animatorStateTransition78476.solo = false;
			animatorStateTransition78476.AddCondition(AnimatorConditionMode.If, 0f, "Slot0ItemStateIndexChange");
			animatorStateTransition78476.AddCondition(AnimatorConditionMode.Equals, 7f, "Slot0ItemID");
			animatorStateTransition78476.AddCondition(AnimatorConditionMode.Equals, 6f, "Slot0ItemStateIndex");
			animatorStateTransition78476.AddCondition(AnimatorConditionMode.Equals, 301f, "AbilityIndex");
			animatorStateTransition78476.AddCondition(AnimatorConditionMode.Equals, 1f, "AbilityIntData");

			var animatorStateTransition78478 = baseStateMachine1742974310.AddAnyStateTransition(aimLandAnimatorState78660);
			animatorStateTransition78478.canTransitionToSelf = false;
			animatorStateTransition78478.duration = 0.08f;
			animatorStateTransition78478.exitTime = 0.75f;
			animatorStateTransition78478.hasExitTime = false;
			animatorStateTransition78478.hasFixedDuration = true;
			animatorStateTransition78478.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition78478.offset = 0f;
			animatorStateTransition78478.orderedInterruption = true;
			animatorStateTransition78478.isExit = false;
			animatorStateTransition78478.mute = false;
			animatorStateTransition78478.solo = false;
			animatorStateTransition78478.AddCondition(AnimatorConditionMode.Equals, 7f, "Slot0ItemID");
			animatorStateTransition78478.AddCondition(AnimatorConditionMode.Less, 2f, "Slot0ItemStateIndex");
			animatorStateTransition78478.AddCondition(AnimatorConditionMode.If, 0f, "Aiming");
			animatorStateTransition78478.AddCondition(AnimatorConditionMode.Equals, 301f, "AbilityIndex");
			animatorStateTransition78478.AddCondition(AnimatorConditionMode.Equals, 1f, "AbilityIntData");


			if (animatorController.layers.Length <= 4) {
				Debug.LogWarning("Warning: The animator controller does not contain the same number of layers as the demo animator. All of the animations cannot be added.");
				return;
			}

			var baseStateMachine1668786664 = animatorController.layers[4].stateMachine;

			// The state machine should start fresh.
			for (int i = 0; i < animatorController.layers.Length; ++i) {
				for (int j = 0; j < baseStateMachine1668786664.stateMachines.Length; ++j) {
					if (baseStateMachine1668786664.stateMachines[j].stateMachine.name == "Trident") {
						baseStateMachine1668786664.RemoveStateMachine(baseStateMachine1668786664.stateMachines[j].stateMachine);
						break;
					}
				}
			}

			// AnimationClip references.
			var tridentAttackFromAimBwdAnimationClip64658Path = AssetDatabase.GUIDToAssetPath("8e1d50508cb45d847a6d1f3a2cd0329d"); 
			var tridentAttackFromAimBwdAnimationClip64658 = AnimatorBuilder.GetAnimationClip(tridentAttackFromAimBwdAnimationClip64658Path, "TridentAttackFromAimBwd");
			var tridentAttackFromAimStrafeAnimationClip64664Path = AssetDatabase.GUIDToAssetPath("eb98d063a1589c340970b18c17ce6eb6"); 
			var tridentAttackFromAimStrafeAnimationClip64664 = AnimatorBuilder.GetAnimationClip(tridentAttackFromAimStrafeAnimationClip64664Path, "TridentAttackFromAimStrafe");
			var tridentAttackFromAimAnimationClip64652Path = AssetDatabase.GUIDToAssetPath("a3dc8609e0cfedf4b9f68f0d6a46bfbe"); 
			var tridentAttackFromAimAnimationClip64652 = AnimatorBuilder.GetAnimationClip(tridentAttackFromAimAnimationClip64652Path, "TridentAttackFromAim");
			var tridentEquipFromIdleLandAnimationClip64730Path = AssetDatabase.GUIDToAssetPath("e9d28eea056551b46a22a0fed06f09e9"); 
			var tridentEquipFromIdleLandAnimationClip64730 = AnimatorBuilder.GetAnimationClip(tridentEquipFromIdleLandAnimationClip64730Path, "TridentEquipFromIdleLand");
			var tridentEquipFromIdleStrafeAnimationClip64736Path = AssetDatabase.GUIDToAssetPath("b77d965c9cc37b4439e3d09f139252b2"); 
			var tridentEquipFromIdleStrafeAnimationClip64736 = AnimatorBuilder.GetAnimationClip(tridentEquipFromIdleStrafeAnimationClip64736Path, "TridentEquipFromIdleStrafe");
			var tridentEquipFromIdleAnimationClip64724Path = AssetDatabase.GUIDToAssetPath("4f016170e4a6faa4daa47381af83fe28"); 
			var tridentEquipFromIdleAnimationClip64724 = AnimatorBuilder.GetAnimationClip(tridentEquipFromIdleAnimationClip64724Path, "TridentEquipFromIdle");
			var tridentUnequipFromIdleLandAnimationClip64784Path = AssetDatabase.GUIDToAssetPath("fc0d82d29e11a424599530e5f0bad0c7"); 
			var tridentUnequipFromIdleLandAnimationClip64784 = AnimatorBuilder.GetAnimationClip(tridentUnequipFromIdleLandAnimationClip64784Path, "TridentUnequipFromIdleLand");
			var tridentUnequipFromIdleStrafeAnimationClip64790Path = AssetDatabase.GUIDToAssetPath("cfc8ade4e0e71ae45829ee2140024302"); 
			var tridentUnequipFromIdleStrafeAnimationClip64790 = AnimatorBuilder.GetAnimationClip(tridentUnequipFromIdleStrafeAnimationClip64790Path, "TridentUnequipFromIdleStrafe");
			var tridentUnequipFromIdleAnimationClip64778Path = AssetDatabase.GUIDToAssetPath("3c2a7bf84a2d5114fb37c5a297a7b887"); 
			var tridentUnequipFromIdleAnimationClip64778 = AnimatorBuilder.GetAnimationClip(tridentUnequipFromIdleAnimationClip64778Path, "TridentUnequipFromIdle");
			var tridentDropLandAnimationClip64694Path = AssetDatabase.GUIDToAssetPath("959e65fca30dd644f9cae654ec81b8da"); 
			var tridentDropLandAnimationClip64694 = AnimatorBuilder.GetAnimationClip(tridentDropLandAnimationClip64694Path, "TridentDropLand");
			var tridentDropStrafeAnimationClip64700Path = AssetDatabase.GUIDToAssetPath("452c61bd405e6f449bb623ea43646c9b"); 
			var tridentDropStrafeAnimationClip64700 = AnimatorBuilder.GetAnimationClip(tridentDropStrafeAnimationClip64700Path, "TridentDropStrafe");
			var tridentDropAnimationClip64688Path = AssetDatabase.GUIDToAssetPath("c96b586da7c6f7a4591ed7da7b70de97"); 
			var tridentDropAnimationClip64688 = AnimatorBuilder.GetAnimationClip(tridentDropAnimationClip64688Path, "TridentDrop");
			var tridentAttackFromIdleBwdAnimationClip64676Path = AssetDatabase.GUIDToAssetPath("9a9972e171c764a4f9b610f74b77d2e5"); 
			var tridentAttackFromIdleBwdAnimationClip64676 = AnimatorBuilder.GetAnimationClip(tridentAttackFromIdleBwdAnimationClip64676Path, "TridentAttackFromIdleBwd");
			var tridentAttackFromIdleStrafeAnimationClip64682Path = AssetDatabase.GUIDToAssetPath("980924073cfd7e84d86ea042125f9d02"); 
			var tridentAttackFromIdleStrafeAnimationClip64682 = AnimatorBuilder.GetAnimationClip(tridentAttackFromIdleStrafeAnimationClip64682Path, "TridentAttackFromIdleStrafe");
			var tridentAttackFromIdleAnimationClip64670Path = AssetDatabase.GUIDToAssetPath("73689710cc9c0a543a885976d45739f2"); 
			var tridentAttackFromIdleAnimationClip64670 = AnimatorBuilder.GetAnimationClip(tridentAttackFromIdleAnimationClip64670Path, "TridentAttackFromIdle");
			var tridentEquipFromAimLandAnimationClip64712Path = AssetDatabase.GUIDToAssetPath("22eb24fca486bd54d9a4ac0fbd103b12"); 
			var tridentEquipFromAimLandAnimationClip64712 = AnimatorBuilder.GetAnimationClip(tridentEquipFromAimLandAnimationClip64712Path, "TridentEquipFromAimLand");
			var tridentEquipFromAimStrafeAnimationClip64718Path = AssetDatabase.GUIDToAssetPath("ebbc17eb546e5504dbe03a2044a1e81f"); 
			var tridentEquipFromAimStrafeAnimationClip64718 = AnimatorBuilder.GetAnimationClip(tridentEquipFromAimStrafeAnimationClip64718Path, "TridentEquipFromAimStrafe");
			var tridentEquipFromAimAnimationClip64706Path = AssetDatabase.GUIDToAssetPath("d9368f69e3256be42907b3357b79cc49"); 
			var tridentEquipFromAimAnimationClip64706 = AnimatorBuilder.GetAnimationClip(tridentEquipFromAimAnimationClip64706Path, "TridentEquipFromAim");
			var tridentUnequipFromAimLandAnimationClip64766Path = AssetDatabase.GUIDToAssetPath("c09b728f5db1996409aa4b944e46091f"); 
			var tridentUnequipFromAimLandAnimationClip64766 = AnimatorBuilder.GetAnimationClip(tridentUnequipFromAimLandAnimationClip64766Path, "TridentUnequipFromAimLand");
			var tridentUnequipFromAimStrafeAnimationClip64772Path = AssetDatabase.GUIDToAssetPath("09db21570b913e441925305c64671094"); 
			var tridentUnequipFromAimStrafeAnimationClip64772 = AnimatorBuilder.GetAnimationClip(tridentUnequipFromAimStrafeAnimationClip64772Path, "TridentUnequipFromAimStrafe");
			var tridentUnequipFromAimAnimationClip64760Path = AssetDatabase.GUIDToAssetPath("4c125ce7139dc9b4098e90e495807e34"); 
			var tridentUnequipFromAimAnimationClip64760 = AnimatorBuilder.GetAnimationClip(tridentUnequipFromAimAnimationClip64760Path, "TridentUnequipFromAim");

			// State Machine.
			var tridentAnimatorStateMachine79144 = baseStateMachine1668786664.AddStateMachine("Trident", new Vector3(624f, 252f, 0f));

			// States.
			var attackFromAimAnimatorState79734 = tridentAnimatorStateMachine79144.AddState("Attack From Aim", new Vector3(144f, -228f, 0f));
			var attackFromAimAnimatorState79734blendTreeBlendTree80554 = new BlendTree();
			AssetDatabase.AddObjectToAsset(attackFromAimAnimatorState79734blendTreeBlendTree80554, animatorController);
			attackFromAimAnimatorState79734blendTreeBlendTree80554.hideFlags = HideFlags.HideInHierarchy;
			attackFromAimAnimatorState79734blendTreeBlendTree80554.blendParameter = "HorizontalMovement";
			attackFromAimAnimatorState79734blendTreeBlendTree80554.blendParameterY = "ForwardMovement";
			attackFromAimAnimatorState79734blendTreeBlendTree80554.blendType = BlendTreeType.FreeformCartesian2D;
			attackFromAimAnimatorState79734blendTreeBlendTree80554.maxThreshold = 1f;
			attackFromAimAnimatorState79734blendTreeBlendTree80554.minThreshold = 0f;
			attackFromAimAnimatorState79734blendTreeBlendTree80554.name = "Blend Tree";
			attackFromAimAnimatorState79734blendTreeBlendTree80554.useAutomaticThresholds = true;
			var attackFromAimAnimatorState79734blendTreeBlendTree80554Child0 =  new ChildMotion();
			attackFromAimAnimatorState79734blendTreeBlendTree80554Child0.motion = tridentAttackFromAimBwdAnimationClip64658;
			attackFromAimAnimatorState79734blendTreeBlendTree80554Child0.cycleOffset = 0f;
			attackFromAimAnimatorState79734blendTreeBlendTree80554Child0.directBlendParameter = "HorizontalMovement";
			attackFromAimAnimatorState79734blendTreeBlendTree80554Child0.mirror = false;
			attackFromAimAnimatorState79734blendTreeBlendTree80554Child0.position = new Vector2(0f, -1f);
			attackFromAimAnimatorState79734blendTreeBlendTree80554Child0.threshold = 0f;
			attackFromAimAnimatorState79734blendTreeBlendTree80554Child0.timeScale = 1f;
			var attackFromAimAnimatorState79734blendTreeBlendTree80554Child1 =  new ChildMotion();
			attackFromAimAnimatorState79734blendTreeBlendTree80554Child1.motion = tridentAttackFromAimStrafeAnimationClip64664;
			attackFromAimAnimatorState79734blendTreeBlendTree80554Child1.cycleOffset = 0f;
			attackFromAimAnimatorState79734blendTreeBlendTree80554Child1.directBlendParameter = "HorizontalMovement";
			attackFromAimAnimatorState79734blendTreeBlendTree80554Child1.mirror = false;
			attackFromAimAnimatorState79734blendTreeBlendTree80554Child1.position = new Vector2(-1f, 0f);
			attackFromAimAnimatorState79734blendTreeBlendTree80554Child1.threshold = 0.25f;
			attackFromAimAnimatorState79734blendTreeBlendTree80554Child1.timeScale = 1f;
			var attackFromAimAnimatorState79734blendTreeBlendTree80554Child2 =  new ChildMotion();
			attackFromAimAnimatorState79734blendTreeBlendTree80554Child2.motion = tridentAttackFromAimAnimationClip64652;
			attackFromAimAnimatorState79734blendTreeBlendTree80554Child2.cycleOffset = 0f;
			attackFromAimAnimatorState79734blendTreeBlendTree80554Child2.directBlendParameter = "HorizontalMovement";
			attackFromAimAnimatorState79734blendTreeBlendTree80554Child2.mirror = false;
			attackFromAimAnimatorState79734blendTreeBlendTree80554Child2.position = new Vector2(0f, 0f);
			attackFromAimAnimatorState79734blendTreeBlendTree80554Child2.threshold = 0.5f;
			attackFromAimAnimatorState79734blendTreeBlendTree80554Child2.timeScale = 1f;
			var attackFromAimAnimatorState79734blendTreeBlendTree80554Child3 =  new ChildMotion();
			attackFromAimAnimatorState79734blendTreeBlendTree80554Child3.motion = tridentAttackFromAimStrafeAnimationClip64664;
			attackFromAimAnimatorState79734blendTreeBlendTree80554Child3.cycleOffset = 0f;
			attackFromAimAnimatorState79734blendTreeBlendTree80554Child3.directBlendParameter = "HorizontalMovement";
			attackFromAimAnimatorState79734blendTreeBlendTree80554Child3.mirror = false;
			attackFromAimAnimatorState79734blendTreeBlendTree80554Child3.position = new Vector2(1f, 0f);
			attackFromAimAnimatorState79734blendTreeBlendTree80554Child3.threshold = 0.75f;
			attackFromAimAnimatorState79734blendTreeBlendTree80554Child3.timeScale = 1f;
			var attackFromAimAnimatorState79734blendTreeBlendTree80554Child4 =  new ChildMotion();
			attackFromAimAnimatorState79734blendTreeBlendTree80554Child4.motion = tridentAttackFromAimAnimationClip64652;
			attackFromAimAnimatorState79734blendTreeBlendTree80554Child4.cycleOffset = 0f;
			attackFromAimAnimatorState79734blendTreeBlendTree80554Child4.directBlendParameter = "HorizontalMovement";
			attackFromAimAnimatorState79734blendTreeBlendTree80554Child4.mirror = false;
			attackFromAimAnimatorState79734blendTreeBlendTree80554Child4.position = new Vector2(0f, 1f);
			attackFromAimAnimatorState79734blendTreeBlendTree80554Child4.threshold = 1f;
			attackFromAimAnimatorState79734blendTreeBlendTree80554Child4.timeScale = 1f;
			attackFromAimAnimatorState79734blendTreeBlendTree80554.children = new ChildMotion[] {
				attackFromAimAnimatorState79734blendTreeBlendTree80554Child0,
				attackFromAimAnimatorState79734blendTreeBlendTree80554Child1,
				attackFromAimAnimatorState79734blendTreeBlendTree80554Child2,
				attackFromAimAnimatorState79734blendTreeBlendTree80554Child3,
				attackFromAimAnimatorState79734blendTreeBlendTree80554Child4
			};
			attackFromAimAnimatorState79734.motion = attackFromAimAnimatorState79734blendTreeBlendTree80554;
			attackFromAimAnimatorState79734.cycleOffset = 0f;
			attackFromAimAnimatorState79734.cycleOffsetParameterActive = false;
			attackFromAimAnimatorState79734.iKOnFeet = false;
			attackFromAimAnimatorState79734.mirror = false;
			attackFromAimAnimatorState79734.mirrorParameterActive = false;
			attackFromAimAnimatorState79734.speed = 3f;
			attackFromAimAnimatorState79734.speedParameterActive = false;
			attackFromAimAnimatorState79734.writeDefaultValues = true;

			var equipFromIdleWaterAnimatorState79740 = tridentAnimatorStateMachine79144.AddState("Equip From Idle Water", new Vector3(144f, 312f, 0f));
			var equipFromIdleWaterAnimatorState79740blendTreeBlendTree80558 = new BlendTree();
			AssetDatabase.AddObjectToAsset(equipFromIdleWaterAnimatorState79740blendTreeBlendTree80558, animatorController);
			equipFromIdleWaterAnimatorState79740blendTreeBlendTree80558.hideFlags = HideFlags.HideInHierarchy;
			equipFromIdleWaterAnimatorState79740blendTreeBlendTree80558.blendParameter = "HorizontalMovement";
			equipFromIdleWaterAnimatorState79740blendTreeBlendTree80558.blendParameterY = "ForwardMovement";
			equipFromIdleWaterAnimatorState79740blendTreeBlendTree80558.blendType = BlendTreeType.FreeformCartesian2D;
			equipFromIdleWaterAnimatorState79740blendTreeBlendTree80558.maxThreshold = 1f;
			equipFromIdleWaterAnimatorState79740blendTreeBlendTree80558.minThreshold = 0f;
			equipFromIdleWaterAnimatorState79740blendTreeBlendTree80558.name = "Blend Tree";
			equipFromIdleWaterAnimatorState79740blendTreeBlendTree80558.useAutomaticThresholds = true;
			var equipFromIdleWaterAnimatorState79740blendTreeBlendTree80558Child0 =  new ChildMotion();
			equipFromIdleWaterAnimatorState79740blendTreeBlendTree80558Child0.motion = tridentEquipFromIdleLandAnimationClip64730;
			equipFromIdleWaterAnimatorState79740blendTreeBlendTree80558Child0.cycleOffset = 0f;
			equipFromIdleWaterAnimatorState79740blendTreeBlendTree80558Child0.directBlendParameter = "HorizontalMovement";
			equipFromIdleWaterAnimatorState79740blendTreeBlendTree80558Child0.mirror = false;
			equipFromIdleWaterAnimatorState79740blendTreeBlendTree80558Child0.position = new Vector2(0f, -1f);
			equipFromIdleWaterAnimatorState79740blendTreeBlendTree80558Child0.threshold = 0f;
			equipFromIdleWaterAnimatorState79740blendTreeBlendTree80558Child0.timeScale = 1f;
			var equipFromIdleWaterAnimatorState79740blendTreeBlendTree80558Child1 =  new ChildMotion();
			equipFromIdleWaterAnimatorState79740blendTreeBlendTree80558Child1.motion = tridentEquipFromIdleStrafeAnimationClip64736;
			equipFromIdleWaterAnimatorState79740blendTreeBlendTree80558Child1.cycleOffset = 0f;
			equipFromIdleWaterAnimatorState79740blendTreeBlendTree80558Child1.directBlendParameter = "HorizontalMovement";
			equipFromIdleWaterAnimatorState79740blendTreeBlendTree80558Child1.mirror = false;
			equipFromIdleWaterAnimatorState79740blendTreeBlendTree80558Child1.position = new Vector2(-1f, 0f);
			equipFromIdleWaterAnimatorState79740blendTreeBlendTree80558Child1.threshold = 0.25f;
			equipFromIdleWaterAnimatorState79740blendTreeBlendTree80558Child1.timeScale = 1f;
			var equipFromIdleWaterAnimatorState79740blendTreeBlendTree80558Child2 =  new ChildMotion();
			equipFromIdleWaterAnimatorState79740blendTreeBlendTree80558Child2.motion = tridentEquipFromIdleAnimationClip64724;
			equipFromIdleWaterAnimatorState79740blendTreeBlendTree80558Child2.cycleOffset = 0f;
			equipFromIdleWaterAnimatorState79740blendTreeBlendTree80558Child2.directBlendParameter = "HorizontalMovement";
			equipFromIdleWaterAnimatorState79740blendTreeBlendTree80558Child2.mirror = false;
			equipFromIdleWaterAnimatorState79740blendTreeBlendTree80558Child2.position = new Vector2(0f, 0f);
			equipFromIdleWaterAnimatorState79740blendTreeBlendTree80558Child2.threshold = 0.5f;
			equipFromIdleWaterAnimatorState79740blendTreeBlendTree80558Child2.timeScale = 1f;
			var equipFromIdleWaterAnimatorState79740blendTreeBlendTree80558Child3 =  new ChildMotion();
			equipFromIdleWaterAnimatorState79740blendTreeBlendTree80558Child3.motion = tridentEquipFromIdleStrafeAnimationClip64736;
			equipFromIdleWaterAnimatorState79740blendTreeBlendTree80558Child3.cycleOffset = 0f;
			equipFromIdleWaterAnimatorState79740blendTreeBlendTree80558Child3.directBlendParameter = "HorizontalMovement";
			equipFromIdleWaterAnimatorState79740blendTreeBlendTree80558Child3.mirror = false;
			equipFromIdleWaterAnimatorState79740blendTreeBlendTree80558Child3.position = new Vector2(1f, 0f);
			equipFromIdleWaterAnimatorState79740blendTreeBlendTree80558Child3.threshold = 0.75f;
			equipFromIdleWaterAnimatorState79740blendTreeBlendTree80558Child3.timeScale = 1f;
			var equipFromIdleWaterAnimatorState79740blendTreeBlendTree80558Child4 =  new ChildMotion();
			equipFromIdleWaterAnimatorState79740blendTreeBlendTree80558Child4.motion = tridentEquipFromIdleAnimationClip64724;
			equipFromIdleWaterAnimatorState79740blendTreeBlendTree80558Child4.cycleOffset = 0f;
			equipFromIdleWaterAnimatorState79740blendTreeBlendTree80558Child4.directBlendParameter = "HorizontalMovement";
			equipFromIdleWaterAnimatorState79740blendTreeBlendTree80558Child4.mirror = false;
			equipFromIdleWaterAnimatorState79740blendTreeBlendTree80558Child4.position = new Vector2(0f, 1f);
			equipFromIdleWaterAnimatorState79740blendTreeBlendTree80558Child4.threshold = 1f;
			equipFromIdleWaterAnimatorState79740blendTreeBlendTree80558Child4.timeScale = 1f;
			equipFromIdleWaterAnimatorState79740blendTreeBlendTree80558.children = new ChildMotion[] {
				equipFromIdleWaterAnimatorState79740blendTreeBlendTree80558Child0,
				equipFromIdleWaterAnimatorState79740blendTreeBlendTree80558Child1,
				equipFromIdleWaterAnimatorState79740blendTreeBlendTree80558Child2,
				equipFromIdleWaterAnimatorState79740blendTreeBlendTree80558Child3,
				equipFromIdleWaterAnimatorState79740blendTreeBlendTree80558Child4
			};
			equipFromIdleWaterAnimatorState79740.motion = equipFromIdleWaterAnimatorState79740blendTreeBlendTree80558;
			equipFromIdleWaterAnimatorState79740.cycleOffset = 0f;
			equipFromIdleWaterAnimatorState79740.cycleOffsetParameterActive = false;
			equipFromIdleWaterAnimatorState79740.iKOnFeet = false;
			equipFromIdleWaterAnimatorState79740.mirror = false;
			equipFromIdleWaterAnimatorState79740.mirrorParameterActive = false;
			equipFromIdleWaterAnimatorState79740.speed = 2.75f;
			equipFromIdleWaterAnimatorState79740.speedParameterActive = false;
			equipFromIdleWaterAnimatorState79740.writeDefaultValues = true;

			var unequipFromIdleWaterAnimatorState79742 = tridentAnimatorStateMachine79144.AddState("Unequip From Idle Water", new Vector3(144f, 372f, 0f));
			var unequipFromIdleWaterAnimatorState79742blendTreeBlendTree80562 = new BlendTree();
			AssetDatabase.AddObjectToAsset(unequipFromIdleWaterAnimatorState79742blendTreeBlendTree80562, animatorController);
			unequipFromIdleWaterAnimatorState79742blendTreeBlendTree80562.hideFlags = HideFlags.HideInHierarchy;
			unequipFromIdleWaterAnimatorState79742blendTreeBlendTree80562.blendParameter = "HorizontalMovement";
			unequipFromIdleWaterAnimatorState79742blendTreeBlendTree80562.blendParameterY = "ForwardMovement";
			unequipFromIdleWaterAnimatorState79742blendTreeBlendTree80562.blendType = BlendTreeType.FreeformCartesian2D;
			unequipFromIdleWaterAnimatorState79742blendTreeBlendTree80562.maxThreshold = 1f;
			unequipFromIdleWaterAnimatorState79742blendTreeBlendTree80562.minThreshold = 0f;
			unequipFromIdleWaterAnimatorState79742blendTreeBlendTree80562.name = "Blend Tree";
			unequipFromIdleWaterAnimatorState79742blendTreeBlendTree80562.useAutomaticThresholds = true;
			var unequipFromIdleWaterAnimatorState79742blendTreeBlendTree80562Child0 =  new ChildMotion();
			unequipFromIdleWaterAnimatorState79742blendTreeBlendTree80562Child0.motion = tridentUnequipFromIdleLandAnimationClip64784;
			unequipFromIdleWaterAnimatorState79742blendTreeBlendTree80562Child0.cycleOffset = 0f;
			unequipFromIdleWaterAnimatorState79742blendTreeBlendTree80562Child0.directBlendParameter = "HorizontalMovement";
			unequipFromIdleWaterAnimatorState79742blendTreeBlendTree80562Child0.mirror = false;
			unequipFromIdleWaterAnimatorState79742blendTreeBlendTree80562Child0.position = new Vector2(0f, -1f);
			unequipFromIdleWaterAnimatorState79742blendTreeBlendTree80562Child0.threshold = 0f;
			unequipFromIdleWaterAnimatorState79742blendTreeBlendTree80562Child0.timeScale = 1f;
			var unequipFromIdleWaterAnimatorState79742blendTreeBlendTree80562Child1 =  new ChildMotion();
			unequipFromIdleWaterAnimatorState79742blendTreeBlendTree80562Child1.motion = tridentUnequipFromIdleStrafeAnimationClip64790;
			unequipFromIdleWaterAnimatorState79742blendTreeBlendTree80562Child1.cycleOffset = 0f;
			unequipFromIdleWaterAnimatorState79742blendTreeBlendTree80562Child1.directBlendParameter = "HorizontalMovement";
			unequipFromIdleWaterAnimatorState79742blendTreeBlendTree80562Child1.mirror = false;
			unequipFromIdleWaterAnimatorState79742blendTreeBlendTree80562Child1.position = new Vector2(-1f, 0f);
			unequipFromIdleWaterAnimatorState79742blendTreeBlendTree80562Child1.threshold = 0.25f;
			unequipFromIdleWaterAnimatorState79742blendTreeBlendTree80562Child1.timeScale = 1f;
			var unequipFromIdleWaterAnimatorState79742blendTreeBlendTree80562Child2 =  new ChildMotion();
			unequipFromIdleWaterAnimatorState79742blendTreeBlendTree80562Child2.motion = tridentUnequipFromIdleAnimationClip64778;
			unequipFromIdleWaterAnimatorState79742blendTreeBlendTree80562Child2.cycleOffset = 0f;
			unequipFromIdleWaterAnimatorState79742blendTreeBlendTree80562Child2.directBlendParameter = "HorizontalMovement";
			unequipFromIdleWaterAnimatorState79742blendTreeBlendTree80562Child2.mirror = false;
			unequipFromIdleWaterAnimatorState79742blendTreeBlendTree80562Child2.position = new Vector2(0f, 0f);
			unequipFromIdleWaterAnimatorState79742blendTreeBlendTree80562Child2.threshold = 0.5f;
			unequipFromIdleWaterAnimatorState79742blendTreeBlendTree80562Child2.timeScale = 1f;
			var unequipFromIdleWaterAnimatorState79742blendTreeBlendTree80562Child3 =  new ChildMotion();
			unequipFromIdleWaterAnimatorState79742blendTreeBlendTree80562Child3.motion = tridentUnequipFromIdleStrafeAnimationClip64790;
			unequipFromIdleWaterAnimatorState79742blendTreeBlendTree80562Child3.cycleOffset = 0f;
			unequipFromIdleWaterAnimatorState79742blendTreeBlendTree80562Child3.directBlendParameter = "HorizontalMovement";
			unequipFromIdleWaterAnimatorState79742blendTreeBlendTree80562Child3.mirror = false;
			unequipFromIdleWaterAnimatorState79742blendTreeBlendTree80562Child3.position = new Vector2(1f, 0f);
			unequipFromIdleWaterAnimatorState79742blendTreeBlendTree80562Child3.threshold = 0.75f;
			unequipFromIdleWaterAnimatorState79742blendTreeBlendTree80562Child3.timeScale = 1f;
			var unequipFromIdleWaterAnimatorState79742blendTreeBlendTree80562Child4 =  new ChildMotion();
			unequipFromIdleWaterAnimatorState79742blendTreeBlendTree80562Child4.motion = tridentUnequipFromIdleAnimationClip64778;
			unequipFromIdleWaterAnimatorState79742blendTreeBlendTree80562Child4.cycleOffset = 0f;
			unequipFromIdleWaterAnimatorState79742blendTreeBlendTree80562Child4.directBlendParameter = "HorizontalMovement";
			unequipFromIdleWaterAnimatorState79742blendTreeBlendTree80562Child4.mirror = false;
			unequipFromIdleWaterAnimatorState79742blendTreeBlendTree80562Child4.position = new Vector2(0f, 1f);
			unequipFromIdleWaterAnimatorState79742blendTreeBlendTree80562Child4.threshold = 1f;
			unequipFromIdleWaterAnimatorState79742blendTreeBlendTree80562Child4.timeScale = 1f;
			unequipFromIdleWaterAnimatorState79742blendTreeBlendTree80562.children = new ChildMotion[] {
				unequipFromIdleWaterAnimatorState79742blendTreeBlendTree80562Child0,
				unequipFromIdleWaterAnimatorState79742blendTreeBlendTree80562Child1,
				unequipFromIdleWaterAnimatorState79742blendTreeBlendTree80562Child2,
				unequipFromIdleWaterAnimatorState79742blendTreeBlendTree80562Child3,
				unequipFromIdleWaterAnimatorState79742blendTreeBlendTree80562Child4
			};
			unequipFromIdleWaterAnimatorState79742.motion = unequipFromIdleWaterAnimatorState79742blendTreeBlendTree80562;
			unequipFromIdleWaterAnimatorState79742.cycleOffset = 0f;
			unequipFromIdleWaterAnimatorState79742.cycleOffsetParameterActive = false;
			unequipFromIdleWaterAnimatorState79742.iKOnFeet = false;
			unequipFromIdleWaterAnimatorState79742.mirror = false;
			unequipFromIdleWaterAnimatorState79742.mirrorParameterActive = false;
			unequipFromIdleWaterAnimatorState79742.speed = 2.25f;
			unequipFromIdleWaterAnimatorState79742.speedParameterActive = false;
			unequipFromIdleWaterAnimatorState79742.writeDefaultValues = true;

			var dropWaterAnimatorState79744 = tridentAnimatorStateMachine79144.AddState("Drop Water", new Vector3(144f, 432f, 0f));
			var dropWaterAnimatorState79744blendTreeBlendTree80566 = new BlendTree();
			AssetDatabase.AddObjectToAsset(dropWaterAnimatorState79744blendTreeBlendTree80566, animatorController);
			dropWaterAnimatorState79744blendTreeBlendTree80566.hideFlags = HideFlags.HideInHierarchy;
			dropWaterAnimatorState79744blendTreeBlendTree80566.blendParameter = "HorizontalMovement";
			dropWaterAnimatorState79744blendTreeBlendTree80566.blendParameterY = "ForwardMovement";
			dropWaterAnimatorState79744blendTreeBlendTree80566.blendType = BlendTreeType.FreeformCartesian2D;
			dropWaterAnimatorState79744blendTreeBlendTree80566.maxThreshold = 1f;
			dropWaterAnimatorState79744blendTreeBlendTree80566.minThreshold = 0f;
			dropWaterAnimatorState79744blendTreeBlendTree80566.name = "Blend Tree";
			dropWaterAnimatorState79744blendTreeBlendTree80566.useAutomaticThresholds = true;
			var dropWaterAnimatorState79744blendTreeBlendTree80566Child0 =  new ChildMotion();
			dropWaterAnimatorState79744blendTreeBlendTree80566Child0.motion = tridentDropLandAnimationClip64694;
			dropWaterAnimatorState79744blendTreeBlendTree80566Child0.cycleOffset = 0f;
			dropWaterAnimatorState79744blendTreeBlendTree80566Child0.directBlendParameter = "HorizontalMovement";
			dropWaterAnimatorState79744blendTreeBlendTree80566Child0.mirror = false;
			dropWaterAnimatorState79744blendTreeBlendTree80566Child0.position = new Vector2(0f, -1f);
			dropWaterAnimatorState79744blendTreeBlendTree80566Child0.threshold = 0f;
			dropWaterAnimatorState79744blendTreeBlendTree80566Child0.timeScale = 1f;
			var dropWaterAnimatorState79744blendTreeBlendTree80566Child1 =  new ChildMotion();
			dropWaterAnimatorState79744blendTreeBlendTree80566Child1.motion = tridentDropStrafeAnimationClip64700;
			dropWaterAnimatorState79744blendTreeBlendTree80566Child1.cycleOffset = 0f;
			dropWaterAnimatorState79744blendTreeBlendTree80566Child1.directBlendParameter = "HorizontalMovement";
			dropWaterAnimatorState79744blendTreeBlendTree80566Child1.mirror = false;
			dropWaterAnimatorState79744blendTreeBlendTree80566Child1.position = new Vector2(-1f, 0f);
			dropWaterAnimatorState79744blendTreeBlendTree80566Child1.threshold = 0.25f;
			dropWaterAnimatorState79744blendTreeBlendTree80566Child1.timeScale = 1f;
			var dropWaterAnimatorState79744blendTreeBlendTree80566Child2 =  new ChildMotion();
			dropWaterAnimatorState79744blendTreeBlendTree80566Child2.motion = tridentDropAnimationClip64688;
			dropWaterAnimatorState79744blendTreeBlendTree80566Child2.cycleOffset = 0f;
			dropWaterAnimatorState79744blendTreeBlendTree80566Child2.directBlendParameter = "HorizontalMovement";
			dropWaterAnimatorState79744blendTreeBlendTree80566Child2.mirror = false;
			dropWaterAnimatorState79744blendTreeBlendTree80566Child2.position = new Vector2(0f, 0f);
			dropWaterAnimatorState79744blendTreeBlendTree80566Child2.threshold = 0.5f;
			dropWaterAnimatorState79744blendTreeBlendTree80566Child2.timeScale = 1f;
			var dropWaterAnimatorState79744blendTreeBlendTree80566Child3 =  new ChildMotion();
			dropWaterAnimatorState79744blendTreeBlendTree80566Child3.motion = tridentDropStrafeAnimationClip64700;
			dropWaterAnimatorState79744blendTreeBlendTree80566Child3.cycleOffset = 0f;
			dropWaterAnimatorState79744blendTreeBlendTree80566Child3.directBlendParameter = "HorizontalMovement";
			dropWaterAnimatorState79744blendTreeBlendTree80566Child3.mirror = false;
			dropWaterAnimatorState79744blendTreeBlendTree80566Child3.position = new Vector2(1f, 0f);
			dropWaterAnimatorState79744blendTreeBlendTree80566Child3.threshold = 0.75f;
			dropWaterAnimatorState79744blendTreeBlendTree80566Child3.timeScale = 1f;
			var dropWaterAnimatorState79744blendTreeBlendTree80566Child4 =  new ChildMotion();
			dropWaterAnimatorState79744blendTreeBlendTree80566Child4.motion = tridentDropAnimationClip64688;
			dropWaterAnimatorState79744blendTreeBlendTree80566Child4.cycleOffset = 0f;
			dropWaterAnimatorState79744blendTreeBlendTree80566Child4.directBlendParameter = "HorizontalMovement";
			dropWaterAnimatorState79744blendTreeBlendTree80566Child4.mirror = false;
			dropWaterAnimatorState79744blendTreeBlendTree80566Child4.position = new Vector2(0f, 1f);
			dropWaterAnimatorState79744blendTreeBlendTree80566Child4.threshold = 1f;
			dropWaterAnimatorState79744blendTreeBlendTree80566Child4.timeScale = 1f;
			dropWaterAnimatorState79744blendTreeBlendTree80566.children = new ChildMotion[] {
				dropWaterAnimatorState79744blendTreeBlendTree80566Child0,
				dropWaterAnimatorState79744blendTreeBlendTree80566Child1,
				dropWaterAnimatorState79744blendTreeBlendTree80566Child2,
				dropWaterAnimatorState79744blendTreeBlendTree80566Child3,
				dropWaterAnimatorState79744blendTreeBlendTree80566Child4
			};
			dropWaterAnimatorState79744.motion = dropWaterAnimatorState79744blendTreeBlendTree80566;
			dropWaterAnimatorState79744.cycleOffset = 0f;
			dropWaterAnimatorState79744.cycleOffsetParameterActive = false;
			dropWaterAnimatorState79744.iKOnFeet = false;
			dropWaterAnimatorState79744.mirror = false;
			dropWaterAnimatorState79744.mirrorParameterActive = false;
			dropWaterAnimatorState79744.speed = 1f;
			dropWaterAnimatorState79744.speedParameterActive = false;
			dropWaterAnimatorState79744.writeDefaultValues = true;

			var attackFromIdleAnimatorState79732 = tridentAnimatorStateMachine79144.AddState("Attack From Idle", new Vector3(144f, -288f, 0f));
			var attackFromIdleAnimatorState79732blendTreeBlendTree80570 = new BlendTree();
			AssetDatabase.AddObjectToAsset(attackFromIdleAnimatorState79732blendTreeBlendTree80570, animatorController);
			attackFromIdleAnimatorState79732blendTreeBlendTree80570.hideFlags = HideFlags.HideInHierarchy;
			attackFromIdleAnimatorState79732blendTreeBlendTree80570.blendParameter = "HorizontalMovement";
			attackFromIdleAnimatorState79732blendTreeBlendTree80570.blendParameterY = "ForwardMovement";
			attackFromIdleAnimatorState79732blendTreeBlendTree80570.blendType = BlendTreeType.FreeformCartesian2D;
			attackFromIdleAnimatorState79732blendTreeBlendTree80570.maxThreshold = 1f;
			attackFromIdleAnimatorState79732blendTreeBlendTree80570.minThreshold = 0f;
			attackFromIdleAnimatorState79732blendTreeBlendTree80570.name = "Blend Tree";
			attackFromIdleAnimatorState79732blendTreeBlendTree80570.useAutomaticThresholds = true;
			var attackFromIdleAnimatorState79732blendTreeBlendTree80570Child0 =  new ChildMotion();
			attackFromIdleAnimatorState79732blendTreeBlendTree80570Child0.motion = tridentAttackFromIdleBwdAnimationClip64676;
			attackFromIdleAnimatorState79732blendTreeBlendTree80570Child0.cycleOffset = 0f;
			attackFromIdleAnimatorState79732blendTreeBlendTree80570Child0.directBlendParameter = "HorizontalMovement";
			attackFromIdleAnimatorState79732blendTreeBlendTree80570Child0.mirror = false;
			attackFromIdleAnimatorState79732blendTreeBlendTree80570Child0.position = new Vector2(0f, -1f);
			attackFromIdleAnimatorState79732blendTreeBlendTree80570Child0.threshold = 0f;
			attackFromIdleAnimatorState79732blendTreeBlendTree80570Child0.timeScale = 1f;
			var attackFromIdleAnimatorState79732blendTreeBlendTree80570Child1 =  new ChildMotion();
			attackFromIdleAnimatorState79732blendTreeBlendTree80570Child1.motion = tridentAttackFromIdleStrafeAnimationClip64682;
			attackFromIdleAnimatorState79732blendTreeBlendTree80570Child1.cycleOffset = 0f;
			attackFromIdleAnimatorState79732blendTreeBlendTree80570Child1.directBlendParameter = "HorizontalMovement";
			attackFromIdleAnimatorState79732blendTreeBlendTree80570Child1.mirror = false;
			attackFromIdleAnimatorState79732blendTreeBlendTree80570Child1.position = new Vector2(-1f, 0f);
			attackFromIdleAnimatorState79732blendTreeBlendTree80570Child1.threshold = 0.25f;
			attackFromIdleAnimatorState79732blendTreeBlendTree80570Child1.timeScale = 1f;
			var attackFromIdleAnimatorState79732blendTreeBlendTree80570Child2 =  new ChildMotion();
			attackFromIdleAnimatorState79732blendTreeBlendTree80570Child2.motion = tridentAttackFromIdleAnimationClip64670;
			attackFromIdleAnimatorState79732blendTreeBlendTree80570Child2.cycleOffset = 0f;
			attackFromIdleAnimatorState79732blendTreeBlendTree80570Child2.directBlendParameter = "HorizontalMovement";
			attackFromIdleAnimatorState79732blendTreeBlendTree80570Child2.mirror = false;
			attackFromIdleAnimatorState79732blendTreeBlendTree80570Child2.position = new Vector2(0f, 0f);
			attackFromIdleAnimatorState79732blendTreeBlendTree80570Child2.threshold = 0.5f;
			attackFromIdleAnimatorState79732blendTreeBlendTree80570Child2.timeScale = 1f;
			var attackFromIdleAnimatorState79732blendTreeBlendTree80570Child3 =  new ChildMotion();
			attackFromIdleAnimatorState79732blendTreeBlendTree80570Child3.motion = tridentAttackFromIdleStrafeAnimationClip64682;
			attackFromIdleAnimatorState79732blendTreeBlendTree80570Child3.cycleOffset = 0f;
			attackFromIdleAnimatorState79732blendTreeBlendTree80570Child3.directBlendParameter = "HorizontalMovement";
			attackFromIdleAnimatorState79732blendTreeBlendTree80570Child3.mirror = false;
			attackFromIdleAnimatorState79732blendTreeBlendTree80570Child3.position = new Vector2(1f, 0f);
			attackFromIdleAnimatorState79732blendTreeBlendTree80570Child3.threshold = 0.75f;
			attackFromIdleAnimatorState79732blendTreeBlendTree80570Child3.timeScale = 1f;
			var attackFromIdleAnimatorState79732blendTreeBlendTree80570Child4 =  new ChildMotion();
			attackFromIdleAnimatorState79732blendTreeBlendTree80570Child4.motion = tridentAttackFromIdleAnimationClip64670;
			attackFromIdleAnimatorState79732blendTreeBlendTree80570Child4.cycleOffset = 0f;
			attackFromIdleAnimatorState79732blendTreeBlendTree80570Child4.directBlendParameter = "HorizontalMovement";
			attackFromIdleAnimatorState79732blendTreeBlendTree80570Child4.mirror = false;
			attackFromIdleAnimatorState79732blendTreeBlendTree80570Child4.position = new Vector2(0f, 1f);
			attackFromIdleAnimatorState79732blendTreeBlendTree80570Child4.threshold = 1f;
			attackFromIdleAnimatorState79732blendTreeBlendTree80570Child4.timeScale = 1f;
			attackFromIdleAnimatorState79732blendTreeBlendTree80570.children = new ChildMotion[] {
				attackFromIdleAnimatorState79732blendTreeBlendTree80570Child0,
				attackFromIdleAnimatorState79732blendTreeBlendTree80570Child1,
				attackFromIdleAnimatorState79732blendTreeBlendTree80570Child2,
				attackFromIdleAnimatorState79732blendTreeBlendTree80570Child3,
				attackFromIdleAnimatorState79732blendTreeBlendTree80570Child4
			};
			attackFromIdleAnimatorState79732.motion = attackFromIdleAnimatorState79732blendTreeBlendTree80570;
			attackFromIdleAnimatorState79732.cycleOffset = 0f;
			attackFromIdleAnimatorState79732.cycleOffsetParameterActive = false;
			attackFromIdleAnimatorState79732.iKOnFeet = false;
			attackFromIdleAnimatorState79732.mirror = false;
			attackFromIdleAnimatorState79732.mirrorParameterActive = false;
			attackFromIdleAnimatorState79732.speed = 3f;
			attackFromIdleAnimatorState79732.speedParameterActive = false;
			attackFromIdleAnimatorState79732.writeDefaultValues = true;

			var equipFromAimWaterAnimatorState79736 = tridentAnimatorStateMachine79144.AddState("Equip From Aim Water", new Vector3(144f, 192f, 0f));
			var equipFromAimWaterAnimatorState79736blendTreeBlendTree80574 = new BlendTree();
			AssetDatabase.AddObjectToAsset(equipFromAimWaterAnimatorState79736blendTreeBlendTree80574, animatorController);
			equipFromAimWaterAnimatorState79736blendTreeBlendTree80574.hideFlags = HideFlags.HideInHierarchy;
			equipFromAimWaterAnimatorState79736blendTreeBlendTree80574.blendParameter = "HorizontalMovement";
			equipFromAimWaterAnimatorState79736blendTreeBlendTree80574.blendParameterY = "ForwardMovement";
			equipFromAimWaterAnimatorState79736blendTreeBlendTree80574.blendType = BlendTreeType.FreeformCartesian2D;
			equipFromAimWaterAnimatorState79736blendTreeBlendTree80574.maxThreshold = 1f;
			equipFromAimWaterAnimatorState79736blendTreeBlendTree80574.minThreshold = 0f;
			equipFromAimWaterAnimatorState79736blendTreeBlendTree80574.name = "Blend Tree";
			equipFromAimWaterAnimatorState79736blendTreeBlendTree80574.useAutomaticThresholds = true;
			var equipFromAimWaterAnimatorState79736blendTreeBlendTree80574Child0 =  new ChildMotion();
			equipFromAimWaterAnimatorState79736blendTreeBlendTree80574Child0.motion = tridentEquipFromAimLandAnimationClip64712;
			equipFromAimWaterAnimatorState79736blendTreeBlendTree80574Child0.cycleOffset = 0f;
			equipFromAimWaterAnimatorState79736blendTreeBlendTree80574Child0.directBlendParameter = "HorizontalMovement";
			equipFromAimWaterAnimatorState79736blendTreeBlendTree80574Child0.mirror = false;
			equipFromAimWaterAnimatorState79736blendTreeBlendTree80574Child0.position = new Vector2(0f, -1f);
			equipFromAimWaterAnimatorState79736blendTreeBlendTree80574Child0.threshold = 0f;
			equipFromAimWaterAnimatorState79736blendTreeBlendTree80574Child0.timeScale = 1f;
			var equipFromAimWaterAnimatorState79736blendTreeBlendTree80574Child1 =  new ChildMotion();
			equipFromAimWaterAnimatorState79736blendTreeBlendTree80574Child1.motion = tridentEquipFromAimStrafeAnimationClip64718;
			equipFromAimWaterAnimatorState79736blendTreeBlendTree80574Child1.cycleOffset = 0f;
			equipFromAimWaterAnimatorState79736blendTreeBlendTree80574Child1.directBlendParameter = "HorizontalMovement";
			equipFromAimWaterAnimatorState79736blendTreeBlendTree80574Child1.mirror = false;
			equipFromAimWaterAnimatorState79736blendTreeBlendTree80574Child1.position = new Vector2(-1f, 0f);
			equipFromAimWaterAnimatorState79736blendTreeBlendTree80574Child1.threshold = 0.25f;
			equipFromAimWaterAnimatorState79736blendTreeBlendTree80574Child1.timeScale = 1f;
			var equipFromAimWaterAnimatorState79736blendTreeBlendTree80574Child2 =  new ChildMotion();
			equipFromAimWaterAnimatorState79736blendTreeBlendTree80574Child2.motion = tridentEquipFromAimAnimationClip64706;
			equipFromAimWaterAnimatorState79736blendTreeBlendTree80574Child2.cycleOffset = 0f;
			equipFromAimWaterAnimatorState79736blendTreeBlendTree80574Child2.directBlendParameter = "HorizontalMovement";
			equipFromAimWaterAnimatorState79736blendTreeBlendTree80574Child2.mirror = false;
			equipFromAimWaterAnimatorState79736blendTreeBlendTree80574Child2.position = new Vector2(0f, 0f);
			equipFromAimWaterAnimatorState79736blendTreeBlendTree80574Child2.threshold = 0.5f;
			equipFromAimWaterAnimatorState79736blendTreeBlendTree80574Child2.timeScale = 1f;
			var equipFromAimWaterAnimatorState79736blendTreeBlendTree80574Child3 =  new ChildMotion();
			equipFromAimWaterAnimatorState79736blendTreeBlendTree80574Child3.motion = tridentEquipFromAimStrafeAnimationClip64718;
			equipFromAimWaterAnimatorState79736blendTreeBlendTree80574Child3.cycleOffset = 0f;
			equipFromAimWaterAnimatorState79736blendTreeBlendTree80574Child3.directBlendParameter = "HorizontalMovement";
			equipFromAimWaterAnimatorState79736blendTreeBlendTree80574Child3.mirror = false;
			equipFromAimWaterAnimatorState79736blendTreeBlendTree80574Child3.position = new Vector2(1f, 0f);
			equipFromAimWaterAnimatorState79736blendTreeBlendTree80574Child3.threshold = 0.75f;
			equipFromAimWaterAnimatorState79736blendTreeBlendTree80574Child3.timeScale = 1f;
			var equipFromAimWaterAnimatorState79736blendTreeBlendTree80574Child4 =  new ChildMotion();
			equipFromAimWaterAnimatorState79736blendTreeBlendTree80574Child4.motion = tridentEquipFromAimAnimationClip64706;
			equipFromAimWaterAnimatorState79736blendTreeBlendTree80574Child4.cycleOffset = 0f;
			equipFromAimWaterAnimatorState79736blendTreeBlendTree80574Child4.directBlendParameter = "HorizontalMovement";
			equipFromAimWaterAnimatorState79736blendTreeBlendTree80574Child4.mirror = false;
			equipFromAimWaterAnimatorState79736blendTreeBlendTree80574Child4.position = new Vector2(0f, 1f);
			equipFromAimWaterAnimatorState79736blendTreeBlendTree80574Child4.threshold = 1f;
			equipFromAimWaterAnimatorState79736blendTreeBlendTree80574Child4.timeScale = 1f;
			equipFromAimWaterAnimatorState79736blendTreeBlendTree80574.children = new ChildMotion[] {
				equipFromAimWaterAnimatorState79736blendTreeBlendTree80574Child0,
				equipFromAimWaterAnimatorState79736blendTreeBlendTree80574Child1,
				equipFromAimWaterAnimatorState79736blendTreeBlendTree80574Child2,
				equipFromAimWaterAnimatorState79736blendTreeBlendTree80574Child3,
				equipFromAimWaterAnimatorState79736blendTreeBlendTree80574Child4
			};
			equipFromAimWaterAnimatorState79736.motion = equipFromAimWaterAnimatorState79736blendTreeBlendTree80574;
			equipFromAimWaterAnimatorState79736.cycleOffset = 0f;
			equipFromAimWaterAnimatorState79736.cycleOffsetParameterActive = false;
			equipFromAimWaterAnimatorState79736.iKOnFeet = false;
			equipFromAimWaterAnimatorState79736.mirror = false;
			equipFromAimWaterAnimatorState79736.mirrorParameterActive = false;
			equipFromAimWaterAnimatorState79736.speed = 2.75f;
			equipFromAimWaterAnimatorState79736.speedParameterActive = false;
			equipFromAimWaterAnimatorState79736.writeDefaultValues = true;

			var unequipFromAimWaterAnimatorState79738 = tridentAnimatorStateMachine79144.AddState("Unequip From Aim Water", new Vector3(144f, 252f, 0f));
			var unequipFromAimWaterAnimatorState79738blendTreeBlendTree80578 = new BlendTree();
			AssetDatabase.AddObjectToAsset(unequipFromAimWaterAnimatorState79738blendTreeBlendTree80578, animatorController);
			unequipFromAimWaterAnimatorState79738blendTreeBlendTree80578.hideFlags = HideFlags.HideInHierarchy;
			unequipFromAimWaterAnimatorState79738blendTreeBlendTree80578.blendParameter = "HorizontalMovement";
			unequipFromAimWaterAnimatorState79738blendTreeBlendTree80578.blendParameterY = "ForwardMovement";
			unequipFromAimWaterAnimatorState79738blendTreeBlendTree80578.blendType = BlendTreeType.FreeformCartesian2D;
			unequipFromAimWaterAnimatorState79738blendTreeBlendTree80578.maxThreshold = 1f;
			unequipFromAimWaterAnimatorState79738blendTreeBlendTree80578.minThreshold = 0f;
			unequipFromAimWaterAnimatorState79738blendTreeBlendTree80578.name = "Blend Tree";
			unequipFromAimWaterAnimatorState79738blendTreeBlendTree80578.useAutomaticThresholds = true;
			var unequipFromAimWaterAnimatorState79738blendTreeBlendTree80578Child0 =  new ChildMotion();
			unequipFromAimWaterAnimatorState79738blendTreeBlendTree80578Child0.motion = tridentUnequipFromAimLandAnimationClip64766;
			unequipFromAimWaterAnimatorState79738blendTreeBlendTree80578Child0.cycleOffset = 0f;
			unequipFromAimWaterAnimatorState79738blendTreeBlendTree80578Child0.directBlendParameter = "HorizontalMovement";
			unequipFromAimWaterAnimatorState79738blendTreeBlendTree80578Child0.mirror = false;
			unequipFromAimWaterAnimatorState79738blendTreeBlendTree80578Child0.position = new Vector2(0f, -1f);
			unequipFromAimWaterAnimatorState79738blendTreeBlendTree80578Child0.threshold = 0f;
			unequipFromAimWaterAnimatorState79738blendTreeBlendTree80578Child0.timeScale = 1f;
			var unequipFromAimWaterAnimatorState79738blendTreeBlendTree80578Child1 =  new ChildMotion();
			unequipFromAimWaterAnimatorState79738blendTreeBlendTree80578Child1.motion = tridentUnequipFromAimStrafeAnimationClip64772;
			unequipFromAimWaterAnimatorState79738blendTreeBlendTree80578Child1.cycleOffset = 0f;
			unequipFromAimWaterAnimatorState79738blendTreeBlendTree80578Child1.directBlendParameter = "HorizontalMovement";
			unequipFromAimWaterAnimatorState79738blendTreeBlendTree80578Child1.mirror = false;
			unequipFromAimWaterAnimatorState79738blendTreeBlendTree80578Child1.position = new Vector2(-1f, 0f);
			unequipFromAimWaterAnimatorState79738blendTreeBlendTree80578Child1.threshold = 0.25f;
			unequipFromAimWaterAnimatorState79738blendTreeBlendTree80578Child1.timeScale = 1f;
			var unequipFromAimWaterAnimatorState79738blendTreeBlendTree80578Child2 =  new ChildMotion();
			unequipFromAimWaterAnimatorState79738blendTreeBlendTree80578Child2.motion = tridentUnequipFromAimAnimationClip64760;
			unequipFromAimWaterAnimatorState79738blendTreeBlendTree80578Child2.cycleOffset = 0f;
			unequipFromAimWaterAnimatorState79738blendTreeBlendTree80578Child2.directBlendParameter = "HorizontalMovement";
			unequipFromAimWaterAnimatorState79738blendTreeBlendTree80578Child2.mirror = false;
			unequipFromAimWaterAnimatorState79738blendTreeBlendTree80578Child2.position = new Vector2(0f, 0f);
			unequipFromAimWaterAnimatorState79738blendTreeBlendTree80578Child2.threshold = 0.5f;
			unequipFromAimWaterAnimatorState79738blendTreeBlendTree80578Child2.timeScale = 1f;
			var unequipFromAimWaterAnimatorState79738blendTreeBlendTree80578Child3 =  new ChildMotion();
			unequipFromAimWaterAnimatorState79738blendTreeBlendTree80578Child3.motion = tridentUnequipFromAimStrafeAnimationClip64772;
			unequipFromAimWaterAnimatorState79738blendTreeBlendTree80578Child3.cycleOffset = 0f;
			unequipFromAimWaterAnimatorState79738blendTreeBlendTree80578Child3.directBlendParameter = "HorizontalMovement";
			unequipFromAimWaterAnimatorState79738blendTreeBlendTree80578Child3.mirror = false;
			unequipFromAimWaterAnimatorState79738blendTreeBlendTree80578Child3.position = new Vector2(1f, 0f);
			unequipFromAimWaterAnimatorState79738blendTreeBlendTree80578Child3.threshold = 0.75f;
			unequipFromAimWaterAnimatorState79738blendTreeBlendTree80578Child3.timeScale = 1f;
			var unequipFromAimWaterAnimatorState79738blendTreeBlendTree80578Child4 =  new ChildMotion();
			unequipFromAimWaterAnimatorState79738blendTreeBlendTree80578Child4.motion = tridentUnequipFromAimAnimationClip64760;
			unequipFromAimWaterAnimatorState79738blendTreeBlendTree80578Child4.cycleOffset = 0f;
			unequipFromAimWaterAnimatorState79738blendTreeBlendTree80578Child4.directBlendParameter = "HorizontalMovement";
			unequipFromAimWaterAnimatorState79738blendTreeBlendTree80578Child4.mirror = false;
			unequipFromAimWaterAnimatorState79738blendTreeBlendTree80578Child4.position = new Vector2(0f, 1f);
			unequipFromAimWaterAnimatorState79738blendTreeBlendTree80578Child4.threshold = 1f;
			unequipFromAimWaterAnimatorState79738blendTreeBlendTree80578Child4.timeScale = 1f;
			unequipFromAimWaterAnimatorState79738blendTreeBlendTree80578.children = new ChildMotion[] {
				unequipFromAimWaterAnimatorState79738blendTreeBlendTree80578Child0,
				unequipFromAimWaterAnimatorState79738blendTreeBlendTree80578Child1,
				unequipFromAimWaterAnimatorState79738blendTreeBlendTree80578Child2,
				unequipFromAimWaterAnimatorState79738blendTreeBlendTree80578Child3,
				unequipFromAimWaterAnimatorState79738blendTreeBlendTree80578Child4
			};
			unequipFromAimWaterAnimatorState79738.motion = unequipFromAimWaterAnimatorState79738blendTreeBlendTree80578;
			unequipFromAimWaterAnimatorState79738.cycleOffset = 0f;
			unequipFromAimWaterAnimatorState79738.cycleOffsetParameterActive = false;
			unequipFromAimWaterAnimatorState79738.iKOnFeet = false;
			unequipFromAimWaterAnimatorState79738.mirror = false;
			unequipFromAimWaterAnimatorState79738.mirrorParameterActive = false;
			unequipFromAimWaterAnimatorState79738.speed = 2.25f;
			unequipFromAimWaterAnimatorState79738.speedParameterActive = false;
			unequipFromAimWaterAnimatorState79738.writeDefaultValues = true;

			var equipFromAimLandAnimatorState79764 = tridentAnimatorStateMachine79144.AddState("Equip From Aim Land", new Vector3(144f, -108f, 0f));
			equipFromAimLandAnimatorState79764.motion = tridentEquipFromAimLandAnimationClip64712;
			equipFromAimLandAnimatorState79764.cycleOffset = 0f;
			equipFromAimLandAnimatorState79764.cycleOffsetParameterActive = false;
			equipFromAimLandAnimatorState79764.iKOnFeet = false;
			equipFromAimLandAnimatorState79764.mirror = false;
			equipFromAimLandAnimatorState79764.mirrorParameterActive = false;
			equipFromAimLandAnimatorState79764.speed = 2.75f;
			equipFromAimLandAnimatorState79764.speedParameterActive = false;
			equipFromAimLandAnimatorState79764.writeDefaultValues = true;

			var unequipFromAimLandAnimatorState79766 = tridentAnimatorStateMachine79144.AddState("Unequip From Aim Land", new Vector3(144f, -48f, 0f));
			unequipFromAimLandAnimatorState79766.motion = tridentUnequipFromAimLandAnimationClip64766;
			unequipFromAimLandAnimatorState79766.cycleOffset = 0f;
			unequipFromAimLandAnimatorState79766.cycleOffsetParameterActive = false;
			unequipFromAimLandAnimatorState79766.iKOnFeet = false;
			unequipFromAimLandAnimatorState79766.mirror = false;
			unequipFromAimLandAnimatorState79766.mirrorParameterActive = false;
			unequipFromAimLandAnimatorState79766.speed = 2.25f;
			unequipFromAimLandAnimatorState79766.speedParameterActive = false;
			unequipFromAimLandAnimatorState79766.writeDefaultValues = true;

			var equipFromIdleLandAnimatorState79768 = tridentAnimatorStateMachine79144.AddState("Equip From Idle Land", new Vector3(144f, 12f, 0f));
			equipFromIdleLandAnimatorState79768.motion = tridentEquipFromIdleLandAnimationClip64730;
			equipFromIdleLandAnimatorState79768.cycleOffset = 0f;
			equipFromIdleLandAnimatorState79768.cycleOffsetParameterActive = false;
			equipFromIdleLandAnimatorState79768.iKOnFeet = false;
			equipFromIdleLandAnimatorState79768.mirror = false;
			equipFromIdleLandAnimatorState79768.mirrorParameterActive = false;
			equipFromIdleLandAnimatorState79768.speed = 2.75f;
			equipFromIdleLandAnimatorState79768.speedParameterActive = false;
			equipFromIdleLandAnimatorState79768.writeDefaultValues = true;

			var unequipFromIdleLandAnimatorState79770 = tridentAnimatorStateMachine79144.AddState("Unequip From Idle Land", new Vector3(144f, 72f, 0f));
			unequipFromIdleLandAnimatorState79770.motion = tridentUnequipFromIdleLandAnimationClip64784;
			unequipFromIdleLandAnimatorState79770.cycleOffset = 0f;
			unequipFromIdleLandAnimatorState79770.cycleOffsetParameterActive = false;
			unequipFromIdleLandAnimatorState79770.iKOnFeet = false;
			unequipFromIdleLandAnimatorState79770.mirror = false;
			unequipFromIdleLandAnimatorState79770.mirrorParameterActive = false;
			unequipFromIdleLandAnimatorState79770.speed = 2.25f;
			unequipFromIdleLandAnimatorState79770.speedParameterActive = false;
			unequipFromIdleLandAnimatorState79770.writeDefaultValues = true;

			var dropWaterLandAnimatorState79772 = tridentAnimatorStateMachine79144.AddState("Drop Water Land", new Vector3(144f, 132f, 0f));
			dropWaterLandAnimatorState79772.motion = tridentDropAnimationClip64688;
			dropWaterLandAnimatorState79772.cycleOffset = 0f;
			dropWaterLandAnimatorState79772.cycleOffsetParameterActive = false;
			dropWaterLandAnimatorState79772.iKOnFeet = false;
			dropWaterLandAnimatorState79772.mirror = false;
			dropWaterLandAnimatorState79772.mirrorParameterActive = false;
			dropWaterLandAnimatorState79772.speed = 1f;
			dropWaterLandAnimatorState79772.speedParameterActive = false;
			dropWaterLandAnimatorState79772.writeDefaultValues = true;

			// State Machine Defaults.
			tridentAnimatorStateMachine79144.anyStatePosition = new Vector3(-192f, 36f, 0f);
			tridentAnimatorStateMachine79144.defaultState = attackFromIdleAnimatorState79732;
			tridentAnimatorStateMachine79144.entryPosition = new Vector3(-192f, -36f, 0f);
			tridentAnimatorStateMachine79144.exitPosition = new Vector3(516f, 36f, 0f);
			tridentAnimatorStateMachine79144.parentStateMachinePosition = new Vector3(504f, -60f, 0f);

			if (animatorController.layers.Length <= 4) {
				Debug.LogWarning("Warning: The animator controller does not contain the same number of layers as the demo animator. All of the animations cannot be added.");
				return;
			}

			var baseStateMachine1715710442 = animatorController.layers[4].stateMachine;

			// The state machine should start fresh.
			for (int i = 0; i < animatorController.layers.Length; ++i) {
				for (int j = 0; j < baseStateMachine1715710442.stateMachines.Length; ++j) {
					if (baseStateMachine1715710442.stateMachines[j].stateMachine.name == "Underwater Gun") {
						baseStateMachine1715710442.RemoveStateMachine(baseStateMachine1715710442.stateMachines[j].stateMachine);
						break;
					}
				}
			}

			// AnimationClip references.

			// State Machine.
			var underwaterGunAnimatorStateMachine79146 = baseStateMachine1715710442.AddStateMachine("Underwater Gun", new Vector3(384f, 396f, 0f));

			// States.
			var unequipFromIdleWaterAnimatorState79746 = underwaterGunAnimatorStateMachine79146.AddState("Unequip From Idle Water", new Vector3(264f, 240f, 0f));
			var unequipFromIdleWaterAnimatorState79746blendTreeBlendTree80592 = new BlendTree();
			AssetDatabase.AddObjectToAsset(unequipFromIdleWaterAnimatorState79746blendTreeBlendTree80592, animatorController);
			unequipFromIdleWaterAnimatorState79746blendTreeBlendTree80592.hideFlags = HideFlags.HideInHierarchy;
			unequipFromIdleWaterAnimatorState79746blendTreeBlendTree80592.blendParameter = "HorizontalMovement";
			unequipFromIdleWaterAnimatorState79746blendTreeBlendTree80592.blendParameterY = "ForwardMovement";
			unequipFromIdleWaterAnimatorState79746blendTreeBlendTree80592.blendType = BlendTreeType.FreeformCartesian2D;
			unequipFromIdleWaterAnimatorState79746blendTreeBlendTree80592.maxThreshold = 1f;
			unequipFromIdleWaterAnimatorState79746blendTreeBlendTree80592.minThreshold = 0f;
			unequipFromIdleWaterAnimatorState79746blendTreeBlendTree80592.name = "Blend Tree";
			unequipFromIdleWaterAnimatorState79746blendTreeBlendTree80592.useAutomaticThresholds = true;
			var unequipFromIdleWaterAnimatorState79746blendTreeBlendTree80592Child0 =  new ChildMotion();
			unequipFromIdleWaterAnimatorState79746blendTreeBlendTree80592Child0.motion = underwaterGunUnequipFromIdleLandAnimationClip65012;
			unequipFromIdleWaterAnimatorState79746blendTreeBlendTree80592Child0.cycleOffset = 0f;
			unequipFromIdleWaterAnimatorState79746blendTreeBlendTree80592Child0.directBlendParameter = "HorizontalMovement";
			unequipFromIdleWaterAnimatorState79746blendTreeBlendTree80592Child0.mirror = false;
			unequipFromIdleWaterAnimatorState79746blendTreeBlendTree80592Child0.position = new Vector2(0f, -1f);
			unequipFromIdleWaterAnimatorState79746blendTreeBlendTree80592Child0.threshold = 0f;
			unequipFromIdleWaterAnimatorState79746blendTreeBlendTree80592Child0.timeScale = 1f;
			var unequipFromIdleWaterAnimatorState79746blendTreeBlendTree80592Child1 =  new ChildMotion();
			unequipFromIdleWaterAnimatorState79746blendTreeBlendTree80592Child1.motion = underwaterGunUnequipFromIdleStrafeAnimationClip65018;
			unequipFromIdleWaterAnimatorState79746blendTreeBlendTree80592Child1.cycleOffset = 0f;
			unequipFromIdleWaterAnimatorState79746blendTreeBlendTree80592Child1.directBlendParameter = "HorizontalMovement";
			unequipFromIdleWaterAnimatorState79746blendTreeBlendTree80592Child1.mirror = false;
			unequipFromIdleWaterAnimatorState79746blendTreeBlendTree80592Child1.position = new Vector2(-1f, 0f);
			unequipFromIdleWaterAnimatorState79746blendTreeBlendTree80592Child1.threshold = 0.25f;
			unequipFromIdleWaterAnimatorState79746blendTreeBlendTree80592Child1.timeScale = 1f;
			var unequipFromIdleWaterAnimatorState79746blendTreeBlendTree80592Child2 =  new ChildMotion();
			unequipFromIdleWaterAnimatorState79746blendTreeBlendTree80592Child2.motion = underwaterGunUnequipFromIdleAnimationClip65006;
			unequipFromIdleWaterAnimatorState79746blendTreeBlendTree80592Child2.cycleOffset = 0f;
			unequipFromIdleWaterAnimatorState79746blendTreeBlendTree80592Child2.directBlendParameter = "HorizontalMovement";
			unequipFromIdleWaterAnimatorState79746blendTreeBlendTree80592Child2.mirror = false;
			unequipFromIdleWaterAnimatorState79746blendTreeBlendTree80592Child2.position = new Vector2(0f, 0f);
			unequipFromIdleWaterAnimatorState79746blendTreeBlendTree80592Child2.threshold = 0.5f;
			unequipFromIdleWaterAnimatorState79746blendTreeBlendTree80592Child2.timeScale = 1f;
			var unequipFromIdleWaterAnimatorState79746blendTreeBlendTree80592Child3 =  new ChildMotion();
			unequipFromIdleWaterAnimatorState79746blendTreeBlendTree80592Child3.motion = underwaterGunUnequipFromIdleStrafeAnimationClip65018;
			unequipFromIdleWaterAnimatorState79746blendTreeBlendTree80592Child3.cycleOffset = 0f;
			unequipFromIdleWaterAnimatorState79746blendTreeBlendTree80592Child3.directBlendParameter = "HorizontalMovement";
			unequipFromIdleWaterAnimatorState79746blendTreeBlendTree80592Child3.mirror = false;
			unequipFromIdleWaterAnimatorState79746blendTreeBlendTree80592Child3.position = new Vector2(1f, 0f);
			unequipFromIdleWaterAnimatorState79746blendTreeBlendTree80592Child3.threshold = 0.75f;
			unequipFromIdleWaterAnimatorState79746blendTreeBlendTree80592Child3.timeScale = 1f;
			var unequipFromIdleWaterAnimatorState79746blendTreeBlendTree80592Child4 =  new ChildMotion();
			unequipFromIdleWaterAnimatorState79746blendTreeBlendTree80592Child4.motion = underwaterGunUnequipFromIdleAnimationClip65006;
			unequipFromIdleWaterAnimatorState79746blendTreeBlendTree80592Child4.cycleOffset = 0f;
			unequipFromIdleWaterAnimatorState79746blendTreeBlendTree80592Child4.directBlendParameter = "HorizontalMovement";
			unequipFromIdleWaterAnimatorState79746blendTreeBlendTree80592Child4.mirror = false;
			unequipFromIdleWaterAnimatorState79746blendTreeBlendTree80592Child4.position = new Vector2(0f, 1f);
			unequipFromIdleWaterAnimatorState79746blendTreeBlendTree80592Child4.threshold = 1f;
			unequipFromIdleWaterAnimatorState79746blendTreeBlendTree80592Child4.timeScale = 1f;
			unequipFromIdleWaterAnimatorState79746blendTreeBlendTree80592.children = new ChildMotion[] {
				unequipFromIdleWaterAnimatorState79746blendTreeBlendTree80592Child0,
				unequipFromIdleWaterAnimatorState79746blendTreeBlendTree80592Child1,
				unequipFromIdleWaterAnimatorState79746blendTreeBlendTree80592Child2,
				unequipFromIdleWaterAnimatorState79746blendTreeBlendTree80592Child3,
				unequipFromIdleWaterAnimatorState79746blendTreeBlendTree80592Child4
			};
			unequipFromIdleWaterAnimatorState79746.motion = unequipFromIdleWaterAnimatorState79746blendTreeBlendTree80592;
			unequipFromIdleWaterAnimatorState79746.cycleOffset = 0f;
			unequipFromIdleWaterAnimatorState79746.cycleOffsetParameterActive = false;
			unequipFromIdleWaterAnimatorState79746.iKOnFeet = false;
			unequipFromIdleWaterAnimatorState79746.mirror = false;
			unequipFromIdleWaterAnimatorState79746.mirrorParameterActive = false;
			unequipFromIdleWaterAnimatorState79746.speed = 3f;
			unequipFromIdleWaterAnimatorState79746.speedParameterActive = false;
			unequipFromIdleWaterAnimatorState79746.writeDefaultValues = true;

			var unequipFromAimWaterAnimatorState79748 = underwaterGunAnimatorStateMachine79146.AddState("Unequip From Aim Water", new Vector3(264f, 120f, 0f));
			var unequipFromAimWaterAnimatorState79748blendTreeBlendTree80596 = new BlendTree();
			AssetDatabase.AddObjectToAsset(unequipFromAimWaterAnimatorState79748blendTreeBlendTree80596, animatorController);
			unequipFromAimWaterAnimatorState79748blendTreeBlendTree80596.hideFlags = HideFlags.HideInHierarchy;
			unequipFromAimWaterAnimatorState79748blendTreeBlendTree80596.blendParameter = "HorizontalMovement";
			unequipFromAimWaterAnimatorState79748blendTreeBlendTree80596.blendParameterY = "ForwardMovement";
			unequipFromAimWaterAnimatorState79748blendTreeBlendTree80596.blendType = BlendTreeType.FreeformCartesian2D;
			unequipFromAimWaterAnimatorState79748blendTreeBlendTree80596.maxThreshold = 1f;
			unequipFromAimWaterAnimatorState79748blendTreeBlendTree80596.minThreshold = 0f;
			unequipFromAimWaterAnimatorState79748blendTreeBlendTree80596.name = "Blend Tree";
			unequipFromAimWaterAnimatorState79748blendTreeBlendTree80596.useAutomaticThresholds = true;
			var unequipFromAimWaterAnimatorState79748blendTreeBlendTree80596Child0 =  new ChildMotion();
			unequipFromAimWaterAnimatorState79748blendTreeBlendTree80596Child0.motion = underwaterGunUnequipFromAimLandAnimationClip64994;
			unequipFromAimWaterAnimatorState79748blendTreeBlendTree80596Child0.cycleOffset = 0f;
			unequipFromAimWaterAnimatorState79748blendTreeBlendTree80596Child0.directBlendParameter = "HorizontalMovement";
			unequipFromAimWaterAnimatorState79748blendTreeBlendTree80596Child0.mirror = false;
			unequipFromAimWaterAnimatorState79748blendTreeBlendTree80596Child0.position = new Vector2(0f, -1f);
			unequipFromAimWaterAnimatorState79748blendTreeBlendTree80596Child0.threshold = 0f;
			unequipFromAimWaterAnimatorState79748blendTreeBlendTree80596Child0.timeScale = 1f;
			var unequipFromAimWaterAnimatorState79748blendTreeBlendTree80596Child1 =  new ChildMotion();
			unequipFromAimWaterAnimatorState79748blendTreeBlendTree80596Child1.motion = underwaterGunUnequipFromAimStrafeAnimationClip65000;
			unequipFromAimWaterAnimatorState79748blendTreeBlendTree80596Child1.cycleOffset = 0f;
			unequipFromAimWaterAnimatorState79748blendTreeBlendTree80596Child1.directBlendParameter = "HorizontalMovement";
			unequipFromAimWaterAnimatorState79748blendTreeBlendTree80596Child1.mirror = false;
			unequipFromAimWaterAnimatorState79748blendTreeBlendTree80596Child1.position = new Vector2(-1f, 0f);
			unequipFromAimWaterAnimatorState79748blendTreeBlendTree80596Child1.threshold = 0.25f;
			unequipFromAimWaterAnimatorState79748blendTreeBlendTree80596Child1.timeScale = 1f;
			var unequipFromAimWaterAnimatorState79748blendTreeBlendTree80596Child2 =  new ChildMotion();
			unequipFromAimWaterAnimatorState79748blendTreeBlendTree80596Child2.motion = underwaterGunUnequipFromAimAnimationClip64988;
			unequipFromAimWaterAnimatorState79748blendTreeBlendTree80596Child2.cycleOffset = 0f;
			unequipFromAimWaterAnimatorState79748blendTreeBlendTree80596Child2.directBlendParameter = "HorizontalMovement";
			unequipFromAimWaterAnimatorState79748blendTreeBlendTree80596Child2.mirror = false;
			unequipFromAimWaterAnimatorState79748blendTreeBlendTree80596Child2.position = new Vector2(0f, 0f);
			unequipFromAimWaterAnimatorState79748blendTreeBlendTree80596Child2.threshold = 0.5f;
			unequipFromAimWaterAnimatorState79748blendTreeBlendTree80596Child2.timeScale = 1f;
			var unequipFromAimWaterAnimatorState79748blendTreeBlendTree80596Child3 =  new ChildMotion();
			unequipFromAimWaterAnimatorState79748blendTreeBlendTree80596Child3.motion = underwaterGunUnequipFromAimStrafeAnimationClip65000;
			unequipFromAimWaterAnimatorState79748blendTreeBlendTree80596Child3.cycleOffset = 0.5f;
			unequipFromAimWaterAnimatorState79748blendTreeBlendTree80596Child3.directBlendParameter = "HorizontalMovement";
			unequipFromAimWaterAnimatorState79748blendTreeBlendTree80596Child3.mirror = true;
			unequipFromAimWaterAnimatorState79748blendTreeBlendTree80596Child3.position = new Vector2(1f, 0f);
			unequipFromAimWaterAnimatorState79748blendTreeBlendTree80596Child3.threshold = 0.75f;
			unequipFromAimWaterAnimatorState79748blendTreeBlendTree80596Child3.timeScale = 1f;
			var unequipFromAimWaterAnimatorState79748blendTreeBlendTree80596Child4 =  new ChildMotion();
			unequipFromAimWaterAnimatorState79748blendTreeBlendTree80596Child4.motion = underwaterGunUnequipFromAimAnimationClip64988;
			unequipFromAimWaterAnimatorState79748blendTreeBlendTree80596Child4.cycleOffset = 0f;
			unequipFromAimWaterAnimatorState79748blendTreeBlendTree80596Child4.directBlendParameter = "HorizontalMovement";
			unequipFromAimWaterAnimatorState79748blendTreeBlendTree80596Child4.mirror = false;
			unequipFromAimWaterAnimatorState79748blendTreeBlendTree80596Child4.position = new Vector2(0f, 1f);
			unequipFromAimWaterAnimatorState79748blendTreeBlendTree80596Child4.threshold = 1f;
			unequipFromAimWaterAnimatorState79748blendTreeBlendTree80596Child4.timeScale = 1f;
			unequipFromAimWaterAnimatorState79748blendTreeBlendTree80596.children = new ChildMotion[] {
				unequipFromAimWaterAnimatorState79748blendTreeBlendTree80596Child0,
				unequipFromAimWaterAnimatorState79748blendTreeBlendTree80596Child1,
				unequipFromAimWaterAnimatorState79748blendTreeBlendTree80596Child2,
				unequipFromAimWaterAnimatorState79748blendTreeBlendTree80596Child3,
				unequipFromAimWaterAnimatorState79748blendTreeBlendTree80596Child4
			};
			unequipFromAimWaterAnimatorState79748.motion = unequipFromAimWaterAnimatorState79748blendTreeBlendTree80596;
			unequipFromAimWaterAnimatorState79748.cycleOffset = 0f;
			unequipFromAimWaterAnimatorState79748.cycleOffsetParameterActive = false;
			unequipFromAimWaterAnimatorState79748.iKOnFeet = false;
			unequipFromAimWaterAnimatorState79748.mirror = false;
			unequipFromAimWaterAnimatorState79748.mirrorParameterActive = false;
			unequipFromAimWaterAnimatorState79748.speed = 3f;
			unequipFromAimWaterAnimatorState79748.speedParameterActive = false;
			unequipFromAimWaterAnimatorState79748.writeDefaultValues = true;

			var equipFromAimWaterAnimatorState79750 = underwaterGunAnimatorStateMachine79146.AddState("Equip From Aim Water", new Vector3(264f, 60f, 0f));
			var equipFromAimWaterAnimatorState79750blendTreeBlendTree80600 = new BlendTree();
			AssetDatabase.AddObjectToAsset(equipFromAimWaterAnimatorState79750blendTreeBlendTree80600, animatorController);
			equipFromAimWaterAnimatorState79750blendTreeBlendTree80600.hideFlags = HideFlags.HideInHierarchy;
			equipFromAimWaterAnimatorState79750blendTreeBlendTree80600.blendParameter = "HorizontalMovement";
			equipFromAimWaterAnimatorState79750blendTreeBlendTree80600.blendParameterY = "ForwardMovement";
			equipFromAimWaterAnimatorState79750blendTreeBlendTree80600.blendType = BlendTreeType.FreeformCartesian2D;
			equipFromAimWaterAnimatorState79750blendTreeBlendTree80600.maxThreshold = 1f;
			equipFromAimWaterAnimatorState79750blendTreeBlendTree80600.minThreshold = 0f;
			equipFromAimWaterAnimatorState79750blendTreeBlendTree80600.name = "Blend Tree";
			equipFromAimWaterAnimatorState79750blendTreeBlendTree80600.useAutomaticThresholds = true;
			var equipFromAimWaterAnimatorState79750blendTreeBlendTree80600Child0 =  new ChildMotion();
			equipFromAimWaterAnimatorState79750blendTreeBlendTree80600Child0.motion = underwaterGunEquipFromAimLandAnimationClip64922;
			equipFromAimWaterAnimatorState79750blendTreeBlendTree80600Child0.cycleOffset = 0f;
			equipFromAimWaterAnimatorState79750blendTreeBlendTree80600Child0.directBlendParameter = "HorizontalMovement";
			equipFromAimWaterAnimatorState79750blendTreeBlendTree80600Child0.mirror = false;
			equipFromAimWaterAnimatorState79750blendTreeBlendTree80600Child0.position = new Vector2(0f, -1f);
			equipFromAimWaterAnimatorState79750blendTreeBlendTree80600Child0.threshold = 0f;
			equipFromAimWaterAnimatorState79750blendTreeBlendTree80600Child0.timeScale = 1f;
			var equipFromAimWaterAnimatorState79750blendTreeBlendTree80600Child1 =  new ChildMotion();
			equipFromAimWaterAnimatorState79750blendTreeBlendTree80600Child1.motion = underwaterGunEquipFromAimStrafeAnimationClip64928;
			equipFromAimWaterAnimatorState79750blendTreeBlendTree80600Child1.cycleOffset = 0f;
			equipFromAimWaterAnimatorState79750blendTreeBlendTree80600Child1.directBlendParameter = "HorizontalMovement";
			equipFromAimWaterAnimatorState79750blendTreeBlendTree80600Child1.mirror = false;
			equipFromAimWaterAnimatorState79750blendTreeBlendTree80600Child1.position = new Vector2(-1f, 0f);
			equipFromAimWaterAnimatorState79750blendTreeBlendTree80600Child1.threshold = 0.25f;
			equipFromAimWaterAnimatorState79750blendTreeBlendTree80600Child1.timeScale = 1f;
			var equipFromAimWaterAnimatorState79750blendTreeBlendTree80600Child2 =  new ChildMotion();
			equipFromAimWaterAnimatorState79750blendTreeBlendTree80600Child2.motion = underwaterGunEquipFromAimAnimationClip64916;
			equipFromAimWaterAnimatorState79750blendTreeBlendTree80600Child2.cycleOffset = 0f;
			equipFromAimWaterAnimatorState79750blendTreeBlendTree80600Child2.directBlendParameter = "HorizontalMovement";
			equipFromAimWaterAnimatorState79750blendTreeBlendTree80600Child2.mirror = false;
			equipFromAimWaterAnimatorState79750blendTreeBlendTree80600Child2.position = new Vector2(0f, 0f);
			equipFromAimWaterAnimatorState79750blendTreeBlendTree80600Child2.threshold = 0.5f;
			equipFromAimWaterAnimatorState79750blendTreeBlendTree80600Child2.timeScale = 1f;
			var equipFromAimWaterAnimatorState79750blendTreeBlendTree80600Child3 =  new ChildMotion();
			equipFromAimWaterAnimatorState79750blendTreeBlendTree80600Child3.motion = underwaterGunEquipFromAimStrafeAnimationClip64928;
			equipFromAimWaterAnimatorState79750blendTreeBlendTree80600Child3.cycleOffset = 0.5f;
			equipFromAimWaterAnimatorState79750blendTreeBlendTree80600Child3.directBlendParameter = "HorizontalMovement";
			equipFromAimWaterAnimatorState79750blendTreeBlendTree80600Child3.mirror = true;
			equipFromAimWaterAnimatorState79750blendTreeBlendTree80600Child3.position = new Vector2(1f, 0f);
			equipFromAimWaterAnimatorState79750blendTreeBlendTree80600Child3.threshold = 0.75f;
			equipFromAimWaterAnimatorState79750blendTreeBlendTree80600Child3.timeScale = 1f;
			var equipFromAimWaterAnimatorState79750blendTreeBlendTree80600Child4 =  new ChildMotion();
			equipFromAimWaterAnimatorState79750blendTreeBlendTree80600Child4.motion = underwaterGunEquipFromAimAnimationClip64916;
			equipFromAimWaterAnimatorState79750blendTreeBlendTree80600Child4.cycleOffset = 0f;
			equipFromAimWaterAnimatorState79750blendTreeBlendTree80600Child4.directBlendParameter = "HorizontalMovement";
			equipFromAimWaterAnimatorState79750blendTreeBlendTree80600Child4.mirror = false;
			equipFromAimWaterAnimatorState79750blendTreeBlendTree80600Child4.position = new Vector2(0f, 1f);
			equipFromAimWaterAnimatorState79750blendTreeBlendTree80600Child4.threshold = 1f;
			equipFromAimWaterAnimatorState79750blendTreeBlendTree80600Child4.timeScale = 1f;
			equipFromAimWaterAnimatorState79750blendTreeBlendTree80600.children = new ChildMotion[] {
				equipFromAimWaterAnimatorState79750blendTreeBlendTree80600Child0,
				equipFromAimWaterAnimatorState79750blendTreeBlendTree80600Child1,
				equipFromAimWaterAnimatorState79750blendTreeBlendTree80600Child2,
				equipFromAimWaterAnimatorState79750blendTreeBlendTree80600Child3,
				equipFromAimWaterAnimatorState79750blendTreeBlendTree80600Child4
			};
			equipFromAimWaterAnimatorState79750.motion = equipFromAimWaterAnimatorState79750blendTreeBlendTree80600;
			equipFromAimWaterAnimatorState79750.cycleOffset = 0f;
			equipFromAimWaterAnimatorState79750.cycleOffsetParameterActive = false;
			equipFromAimWaterAnimatorState79750.iKOnFeet = false;
			equipFromAimWaterAnimatorState79750.mirror = false;
			equipFromAimWaterAnimatorState79750.mirrorParameterActive = false;
			equipFromAimWaterAnimatorState79750.speed = 3f;
			equipFromAimWaterAnimatorState79750.speedParameterActive = false;
			equipFromAimWaterAnimatorState79750.writeDefaultValues = true;

			var equipFromIdleWaterAnimatorState79774 = underwaterGunAnimatorStateMachine79146.AddState("Equip From Idle Water", new Vector3(264f, 180f, 0f));
			var equipFromIdleWaterAnimatorState79774blendTreeBlendTree80604 = new BlendTree();
			AssetDatabase.AddObjectToAsset(equipFromIdleWaterAnimatorState79774blendTreeBlendTree80604, animatorController);
			equipFromIdleWaterAnimatorState79774blendTreeBlendTree80604.hideFlags = HideFlags.HideInHierarchy;
			equipFromIdleWaterAnimatorState79774blendTreeBlendTree80604.blendParameter = "HorizontalMovement";
			equipFromIdleWaterAnimatorState79774blendTreeBlendTree80604.blendParameterY = "ForwardMovement";
			equipFromIdleWaterAnimatorState79774blendTreeBlendTree80604.blendType = BlendTreeType.FreeformCartesian2D;
			equipFromIdleWaterAnimatorState79774blendTreeBlendTree80604.maxThreshold = 1f;
			equipFromIdleWaterAnimatorState79774blendTreeBlendTree80604.minThreshold = 0f;
			equipFromIdleWaterAnimatorState79774blendTreeBlendTree80604.name = "Blend Tree";
			equipFromIdleWaterAnimatorState79774blendTreeBlendTree80604.useAutomaticThresholds = true;
			var equipFromIdleWaterAnimatorState79774blendTreeBlendTree80604Child0 =  new ChildMotion();
			equipFromIdleWaterAnimatorState79774blendTreeBlendTree80604Child0.motion = underwaterGunEquipFromIdleLandAnimationClip64940;
			equipFromIdleWaterAnimatorState79774blendTreeBlendTree80604Child0.cycleOffset = 0f;
			equipFromIdleWaterAnimatorState79774blendTreeBlendTree80604Child0.directBlendParameter = "HorizontalMovement";
			equipFromIdleWaterAnimatorState79774blendTreeBlendTree80604Child0.mirror = false;
			equipFromIdleWaterAnimatorState79774blendTreeBlendTree80604Child0.position = new Vector2(0f, -1f);
			equipFromIdleWaterAnimatorState79774blendTreeBlendTree80604Child0.threshold = 0f;
			equipFromIdleWaterAnimatorState79774blendTreeBlendTree80604Child0.timeScale = 1f;
			var equipFromIdleWaterAnimatorState79774blendTreeBlendTree80604Child1 =  new ChildMotion();
			equipFromIdleWaterAnimatorState79774blendTreeBlendTree80604Child1.motion = underwaterGunEquipFromIdleStrafeAnimationClip64946;
			equipFromIdleWaterAnimatorState79774blendTreeBlendTree80604Child1.cycleOffset = 0f;
			equipFromIdleWaterAnimatorState79774blendTreeBlendTree80604Child1.directBlendParameter = "HorizontalMovement";
			equipFromIdleWaterAnimatorState79774blendTreeBlendTree80604Child1.mirror = false;
			equipFromIdleWaterAnimatorState79774blendTreeBlendTree80604Child1.position = new Vector2(-1f, 0f);
			equipFromIdleWaterAnimatorState79774blendTreeBlendTree80604Child1.threshold = 0.25f;
			equipFromIdleWaterAnimatorState79774blendTreeBlendTree80604Child1.timeScale = 1f;
			var equipFromIdleWaterAnimatorState79774blendTreeBlendTree80604Child2 =  new ChildMotion();
			equipFromIdleWaterAnimatorState79774blendTreeBlendTree80604Child2.motion = underwaterGunEquipFromIdleAnimationClip64934;
			equipFromIdleWaterAnimatorState79774blendTreeBlendTree80604Child2.cycleOffset = 0f;
			equipFromIdleWaterAnimatorState79774blendTreeBlendTree80604Child2.directBlendParameter = "HorizontalMovement";
			equipFromIdleWaterAnimatorState79774blendTreeBlendTree80604Child2.mirror = false;
			equipFromIdleWaterAnimatorState79774blendTreeBlendTree80604Child2.position = new Vector2(0f, 0f);
			equipFromIdleWaterAnimatorState79774blendTreeBlendTree80604Child2.threshold = 0.5f;
			equipFromIdleWaterAnimatorState79774blendTreeBlendTree80604Child2.timeScale = 1f;
			var equipFromIdleWaterAnimatorState79774blendTreeBlendTree80604Child3 =  new ChildMotion();
			equipFromIdleWaterAnimatorState79774blendTreeBlendTree80604Child3.motion = underwaterGunEquipFromIdleStrafeAnimationClip64946;
			equipFromIdleWaterAnimatorState79774blendTreeBlendTree80604Child3.cycleOffset = 0f;
			equipFromIdleWaterAnimatorState79774blendTreeBlendTree80604Child3.directBlendParameter = "HorizontalMovement";
			equipFromIdleWaterAnimatorState79774blendTreeBlendTree80604Child3.mirror = false;
			equipFromIdleWaterAnimatorState79774blendTreeBlendTree80604Child3.position = new Vector2(1f, 0f);
			equipFromIdleWaterAnimatorState79774blendTreeBlendTree80604Child3.threshold = 0.75f;
			equipFromIdleWaterAnimatorState79774blendTreeBlendTree80604Child3.timeScale = 1f;
			var equipFromIdleWaterAnimatorState79774blendTreeBlendTree80604Child4 =  new ChildMotion();
			equipFromIdleWaterAnimatorState79774blendTreeBlendTree80604Child4.motion = underwaterGunEquipFromIdleAnimationClip64934;
			equipFromIdleWaterAnimatorState79774blendTreeBlendTree80604Child4.cycleOffset = 0f;
			equipFromIdleWaterAnimatorState79774blendTreeBlendTree80604Child4.directBlendParameter = "HorizontalMovement";
			equipFromIdleWaterAnimatorState79774blendTreeBlendTree80604Child4.mirror = false;
			equipFromIdleWaterAnimatorState79774blendTreeBlendTree80604Child4.position = new Vector2(0f, 1f);
			equipFromIdleWaterAnimatorState79774blendTreeBlendTree80604Child4.threshold = 1f;
			equipFromIdleWaterAnimatorState79774blendTreeBlendTree80604Child4.timeScale = 1f;
			equipFromIdleWaterAnimatorState79774blendTreeBlendTree80604.children = new ChildMotion[] {
				equipFromIdleWaterAnimatorState79774blendTreeBlendTree80604Child0,
				equipFromIdleWaterAnimatorState79774blendTreeBlendTree80604Child1,
				equipFromIdleWaterAnimatorState79774blendTreeBlendTree80604Child2,
				equipFromIdleWaterAnimatorState79774blendTreeBlendTree80604Child3,
				equipFromIdleWaterAnimatorState79774blendTreeBlendTree80604Child4
			};
			equipFromIdleWaterAnimatorState79774.motion = equipFromIdleWaterAnimatorState79774blendTreeBlendTree80604;
			equipFromIdleWaterAnimatorState79774.cycleOffset = 0f;
			equipFromIdleWaterAnimatorState79774.cycleOffsetParameterActive = false;
			equipFromIdleWaterAnimatorState79774.iKOnFeet = false;
			equipFromIdleWaterAnimatorState79774.mirror = false;
			equipFromIdleWaterAnimatorState79774.mirrorParameterActive = false;
			equipFromIdleWaterAnimatorState79774.speed = 3f;
			equipFromIdleWaterAnimatorState79774.speedParameterActive = false;
			equipFromIdleWaterAnimatorState79774.writeDefaultValues = true;

			var dropWaterAnimatorState79752 = underwaterGunAnimatorStateMachine79146.AddState("Drop Water", new Vector3(264f, 300f, 0f));
			dropWaterAnimatorState79752.motion = underwaterGunDropAnimationClip64898;
			dropWaterAnimatorState79752.cycleOffset = 0f;
			dropWaterAnimatorState79752.cycleOffsetParameterActive = false;
			dropWaterAnimatorState79752.iKOnFeet = false;
			dropWaterAnimatorState79752.mirror = false;
			dropWaterAnimatorState79752.mirrorParameterActive = false;
			dropWaterAnimatorState79752.speed = 1f;
			dropWaterAnimatorState79752.speedParameterActive = false;
			dropWaterAnimatorState79752.writeDefaultValues = true;

			var dropLandAnimatorState79754 = underwaterGunAnimatorStateMachine79146.AddState("Drop Land", new Vector3(264f, 0f, 0f));
			dropLandAnimatorState79754.motion = underwaterGunDropLandAnimationClip64904;
			dropLandAnimatorState79754.cycleOffset = 0f;
			dropLandAnimatorState79754.cycleOffsetParameterActive = false;
			dropLandAnimatorState79754.iKOnFeet = false;
			dropLandAnimatorState79754.mirror = false;
			dropLandAnimatorState79754.mirrorParameterActive = false;
			dropLandAnimatorState79754.speed = 1f;
			dropLandAnimatorState79754.speedParameterActive = false;
			dropLandAnimatorState79754.writeDefaultValues = true;

			var equipFromIdleLandAnimatorState79756 = underwaterGunAnimatorStateMachine79146.AddState("Equip From Idle Land", new Vector3(264f, -120f, 0f));
			equipFromIdleLandAnimatorState79756.motion = underwaterGunEquipFromIdleLandAnimationClip64940;
			equipFromIdleLandAnimatorState79756.cycleOffset = 0f;
			equipFromIdleLandAnimatorState79756.cycleOffsetParameterActive = false;
			equipFromIdleLandAnimatorState79756.iKOnFeet = false;
			equipFromIdleLandAnimatorState79756.mirror = false;
			equipFromIdleLandAnimatorState79756.mirrorParameterActive = false;
			equipFromIdleLandAnimatorState79756.speed = 3f;
			equipFromIdleLandAnimatorState79756.speedParameterActive = false;
			equipFromIdleLandAnimatorState79756.writeDefaultValues = true;

			var equipFromAimLandAnimatorState79758 = underwaterGunAnimatorStateMachine79146.AddState("Equip From Aim Land", new Vector3(264f, -240f, 0f));
			equipFromAimLandAnimatorState79758.motion = underwaterGunEquipFromAimLandAnimationClip64922;
			equipFromAimLandAnimatorState79758.cycleOffset = 0f;
			equipFromAimLandAnimatorState79758.cycleOffsetParameterActive = false;
			equipFromAimLandAnimatorState79758.iKOnFeet = false;
			equipFromAimLandAnimatorState79758.mirror = false;
			equipFromAimLandAnimatorState79758.mirrorParameterActive = false;
			equipFromAimLandAnimatorState79758.speed = 3f;
			equipFromAimLandAnimatorState79758.speedParameterActive = false;
			equipFromAimLandAnimatorState79758.writeDefaultValues = true;

			var unequipFromAimLandAnimatorState79760 = underwaterGunAnimatorStateMachine79146.AddState("Unequip From Aim Land", new Vector3(264f, -180f, 0f));
			unequipFromAimLandAnimatorState79760.motion = underwaterGunUnequipFromAimLandAnimationClip64994;
			unequipFromAimLandAnimatorState79760.cycleOffset = 0f;
			unequipFromAimLandAnimatorState79760.cycleOffsetParameterActive = false;
			unequipFromAimLandAnimatorState79760.iKOnFeet = false;
			unequipFromAimLandAnimatorState79760.mirror = false;
			unequipFromAimLandAnimatorState79760.mirrorParameterActive = false;
			unequipFromAimLandAnimatorState79760.speed = 3f;
			unequipFromAimLandAnimatorState79760.speedParameterActive = false;
			unequipFromAimLandAnimatorState79760.writeDefaultValues = true;

			var unequipFromIdleLandAnimatorState79762 = underwaterGunAnimatorStateMachine79146.AddState("Unequip From Idle Land", new Vector3(264f, -60f, 0f));
			unequipFromIdleLandAnimatorState79762.motion = underwaterGunUnequipFromAimLandAnimationClip64994;
			unequipFromIdleLandAnimatorState79762.cycleOffset = 0f;
			unequipFromIdleLandAnimatorState79762.cycleOffsetParameterActive = false;
			unequipFromIdleLandAnimatorState79762.iKOnFeet = false;
			unequipFromIdleLandAnimatorState79762.mirror = false;
			unequipFromIdleLandAnimatorState79762.mirrorParameterActive = false;
			unequipFromIdleLandAnimatorState79762.speed = 3f;
			unequipFromIdleLandAnimatorState79762.speedParameterActive = false;
			unequipFromIdleLandAnimatorState79762.writeDefaultValues = true;

			// State Machine Defaults.
			underwaterGunAnimatorStateMachine79146.anyStatePosition = new Vector3(-84f, 36f, 0f);
			underwaterGunAnimatorStateMachine79146.defaultState = unequipFromIdleWaterAnimatorState79746;
			underwaterGunAnimatorStateMachine79146.entryPosition = new Vector3(-84f, -36f, 0f);
			underwaterGunAnimatorStateMachine79146.exitPosition = new Vector3(636f, 36f, 0f);
			underwaterGunAnimatorStateMachine79146.parentStateMachinePosition = new Vector3(624f, -48f, 0f);

			// State Transitions.
			var animatorStateTransition80552 = attackFromAimAnimatorState79734.AddExitTransition();
			animatorStateTransition80552.canTransitionToSelf = true;
			animatorStateTransition80552.duration = 0.25f;
			animatorStateTransition80552.exitTime = 0.8f;
			animatorStateTransition80552.hasExitTime = false;
			animatorStateTransition80552.hasFixedDuration = true;
			animatorStateTransition80552.interruptionSource = TransitionInterruptionSource.Source;
			animatorStateTransition80552.offset = 0f;
			animatorStateTransition80552.orderedInterruption = true;
			animatorStateTransition80552.isExit = true;
			animatorStateTransition80552.mute = false;
			animatorStateTransition80552.solo = false;
			animatorStateTransition80552.AddCondition(AnimatorConditionMode.NotEqual, 2f, "Slot0ItemStateIndex");

			var animatorStateTransition80556 = equipFromIdleWaterAnimatorState79740.AddExitTransition();
			animatorStateTransition80556.canTransitionToSelf = true;
			animatorStateTransition80556.duration = 0.2f;
			animatorStateTransition80556.exitTime = 0.75f;
			animatorStateTransition80556.hasExitTime = false;
			animatorStateTransition80556.hasFixedDuration = true;
			animatorStateTransition80556.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition80556.offset = 0f;
			animatorStateTransition80556.orderedInterruption = true;
			animatorStateTransition80556.isExit = true;
			animatorStateTransition80556.mute = false;
			animatorStateTransition80556.solo = false;
			animatorStateTransition80556.AddCondition(AnimatorConditionMode.NotEqual, 4f, "Slot0ItemStateIndex");

			var animatorStateTransition80560 = unequipFromIdleWaterAnimatorState79742.AddExitTransition();
			animatorStateTransition80560.canTransitionToSelf = true;
			animatorStateTransition80560.duration = 0.2f;
			animatorStateTransition80560.exitTime = 0.75f;
			animatorStateTransition80560.hasExitTime = false;
			animatorStateTransition80560.hasFixedDuration = true;
			animatorStateTransition80560.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition80560.offset = 0f;
			animatorStateTransition80560.orderedInterruption = true;
			animatorStateTransition80560.isExit = true;
			animatorStateTransition80560.mute = false;
			animatorStateTransition80560.solo = false;
			animatorStateTransition80560.AddCondition(AnimatorConditionMode.NotEqual, 5f, "Slot0ItemStateIndex");

			var animatorStateTransition80564 = dropWaterAnimatorState79744.AddExitTransition();
			animatorStateTransition80564.canTransitionToSelf = true;
			animatorStateTransition80564.duration = 0.1f;
			animatorStateTransition80564.exitTime = 0.9f;
			animatorStateTransition80564.hasExitTime = true;
			animatorStateTransition80564.hasFixedDuration = true;
			animatorStateTransition80564.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition80564.offset = 0f;
			animatorStateTransition80564.orderedInterruption = true;
			animatorStateTransition80564.isExit = true;
			animatorStateTransition80564.mute = false;
			animatorStateTransition80564.solo = false;

			var animatorStateTransition80568 = attackFromIdleAnimatorState79732.AddExitTransition();
			animatorStateTransition80568.canTransitionToSelf = true;
			animatorStateTransition80568.duration = 0.25f;
			animatorStateTransition80568.exitTime = 0.8f;
			animatorStateTransition80568.hasExitTime = false;
			animatorStateTransition80568.hasFixedDuration = true;
			animatorStateTransition80568.interruptionSource = TransitionInterruptionSource.Source;
			animatorStateTransition80568.offset = 0f;
			animatorStateTransition80568.orderedInterruption = true;
			animatorStateTransition80568.isExit = true;
			animatorStateTransition80568.mute = false;
			animatorStateTransition80568.solo = false;
			animatorStateTransition80568.AddCondition(AnimatorConditionMode.NotEqual, 2f, "Slot0ItemStateIndex");

			var animatorStateTransition80572 = equipFromAimWaterAnimatorState79736.AddExitTransition();
			animatorStateTransition80572.canTransitionToSelf = true;
			animatorStateTransition80572.duration = 0.2f;
			animatorStateTransition80572.exitTime = 0.85f;
			animatorStateTransition80572.hasExitTime = false;
			animatorStateTransition80572.hasFixedDuration = true;
			animatorStateTransition80572.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition80572.offset = 0f;
			animatorStateTransition80572.orderedInterruption = true;
			animatorStateTransition80572.isExit = true;
			animatorStateTransition80572.mute = false;
			animatorStateTransition80572.solo = false;
			animatorStateTransition80572.AddCondition(AnimatorConditionMode.NotEqual, 4f, "Slot0ItemStateIndex");

			var animatorStateTransition80576 = unequipFromAimWaterAnimatorState79738.AddExitTransition();
			animatorStateTransition80576.canTransitionToSelf = true;
			animatorStateTransition80576.duration = 0.2f;
			animatorStateTransition80576.exitTime = 0.8f;
			animatorStateTransition80576.hasExitTime = false;
			animatorStateTransition80576.hasFixedDuration = true;
			animatorStateTransition80576.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition80576.offset = 0f;
			animatorStateTransition80576.orderedInterruption = true;
			animatorStateTransition80576.isExit = true;
			animatorStateTransition80576.mute = false;
			animatorStateTransition80576.solo = false;
			animatorStateTransition80576.AddCondition(AnimatorConditionMode.NotEqual, 5f, "Slot0ItemStateIndex");

			var animatorStateTransition80580 = equipFromAimLandAnimatorState79764.AddExitTransition();
			animatorStateTransition80580.canTransitionToSelf = true;
			animatorStateTransition80580.duration = 0.2f;
			animatorStateTransition80580.exitTime = 0.85f;
			animatorStateTransition80580.hasExitTime = false;
			animatorStateTransition80580.hasFixedDuration = true;
			animatorStateTransition80580.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition80580.offset = 0f;
			animatorStateTransition80580.orderedInterruption = true;
			animatorStateTransition80580.isExit = true;
			animatorStateTransition80580.mute = false;
			animatorStateTransition80580.solo = false;
			animatorStateTransition80580.AddCondition(AnimatorConditionMode.NotEqual, 4f, "Slot0ItemStateIndex");

			var animatorStateTransition80582 = unequipFromAimLandAnimatorState79766.AddExitTransition();
			animatorStateTransition80582.canTransitionToSelf = true;
			animatorStateTransition80582.duration = 0.2f;
			animatorStateTransition80582.exitTime = 0.8f;
			animatorStateTransition80582.hasExitTime = false;
			animatorStateTransition80582.hasFixedDuration = true;
			animatorStateTransition80582.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition80582.offset = 0f;
			animatorStateTransition80582.orderedInterruption = true;
			animatorStateTransition80582.isExit = true;
			animatorStateTransition80582.mute = false;
			animatorStateTransition80582.solo = false;
			animatorStateTransition80582.AddCondition(AnimatorConditionMode.NotEqual, 5f, "Slot0ItemStateIndex");

			var animatorStateTransition80584 = equipFromIdleLandAnimatorState79768.AddExitTransition();
			animatorStateTransition80584.canTransitionToSelf = true;
			animatorStateTransition80584.duration = 0.2f;
			animatorStateTransition80584.exitTime = 0.75f;
			animatorStateTransition80584.hasExitTime = false;
			animatorStateTransition80584.hasFixedDuration = true;
			animatorStateTransition80584.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition80584.offset = 0f;
			animatorStateTransition80584.orderedInterruption = true;
			animatorStateTransition80584.isExit = true;
			animatorStateTransition80584.mute = false;
			animatorStateTransition80584.solo = false;
			animatorStateTransition80584.AddCondition(AnimatorConditionMode.NotEqual, 4f, "Slot0ItemStateIndex");

			var animatorStateTransition80586 = unequipFromIdleLandAnimatorState79770.AddExitTransition();
			animatorStateTransition80586.canTransitionToSelf = true;
			animatorStateTransition80586.duration = 0.2f;
			animatorStateTransition80586.exitTime = 0.75f;
			animatorStateTransition80586.hasExitTime = false;
			animatorStateTransition80586.hasFixedDuration = true;
			animatorStateTransition80586.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition80586.offset = 0f;
			animatorStateTransition80586.orderedInterruption = true;
			animatorStateTransition80586.isExit = true;
			animatorStateTransition80586.mute = false;
			animatorStateTransition80586.solo = false;
			animatorStateTransition80586.AddCondition(AnimatorConditionMode.NotEqual, 5f, "Slot0ItemStateIndex");

			var animatorStateTransition80588 = dropWaterLandAnimatorState79772.AddExitTransition();
			animatorStateTransition80588.canTransitionToSelf = true;
			animatorStateTransition80588.duration = 0.1f;
			animatorStateTransition80588.exitTime = 0.9f;
			animatorStateTransition80588.hasExitTime = true;
			animatorStateTransition80588.hasFixedDuration = true;
			animatorStateTransition80588.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition80588.offset = 0f;
			animatorStateTransition80588.orderedInterruption = true;
			animatorStateTransition80588.isExit = true;
			animatorStateTransition80588.mute = false;
			animatorStateTransition80588.solo = false;


			// State Machine Transitions.
			var animatorStateTransition79440 = baseStateMachine1668786664.AddAnyStateTransition(equipFromAimWaterAnimatorState79736);
			animatorStateTransition79440.canTransitionToSelf = false;
			animatorStateTransition79440.duration = 0.15f;
			animatorStateTransition79440.exitTime = 0.75f;
			animatorStateTransition79440.hasExitTime = false;
			animatorStateTransition79440.hasFixedDuration = true;
			animatorStateTransition79440.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition79440.offset = 0f;
			animatorStateTransition79440.orderedInterruption = true;
			animatorStateTransition79440.isExit = false;
			animatorStateTransition79440.mute = false;
			animatorStateTransition79440.solo = false;
			animatorStateTransition79440.AddCondition(AnimatorConditionMode.If, 0f, "Slot0ItemStateIndexChange");
			animatorStateTransition79440.AddCondition(AnimatorConditionMode.Equals, 26f, "Slot0ItemID");
			animatorStateTransition79440.AddCondition(AnimatorConditionMode.Equals, 4f, "Slot0ItemStateIndex");
			animatorStateTransition79440.AddCondition(AnimatorConditionMode.IfNot, 0f, "Moving");
			animatorStateTransition79440.AddCondition(AnimatorConditionMode.If, 0f, "Aiming");
			animatorStateTransition79440.AddCondition(AnimatorConditionMode.Equals, 301f, "AbilityIndex");
			animatorStateTransition79440.AddCondition(AnimatorConditionMode.NotEqual, 1f, "AbilityIntData");

			var animatorStateTransition79442 = baseStateMachine1668786664.AddAnyStateTransition(unequipFromAimWaterAnimatorState79738);
			animatorStateTransition79442.canTransitionToSelf = false;
			animatorStateTransition79442.duration = 0.15f;
			animatorStateTransition79442.exitTime = 0.75f;
			animatorStateTransition79442.hasExitTime = false;
			animatorStateTransition79442.hasFixedDuration = true;
			animatorStateTransition79442.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition79442.offset = 0f;
			animatorStateTransition79442.orderedInterruption = true;
			animatorStateTransition79442.isExit = false;
			animatorStateTransition79442.mute = false;
			animatorStateTransition79442.solo = false;
			animatorStateTransition79442.AddCondition(AnimatorConditionMode.If, 0f, "Slot0ItemStateIndexChange");
			animatorStateTransition79442.AddCondition(AnimatorConditionMode.Equals, 26f, "Slot0ItemID");
			animatorStateTransition79442.AddCondition(AnimatorConditionMode.Equals, 5f, "Slot0ItemStateIndex");
			animatorStateTransition79442.AddCondition(AnimatorConditionMode.IfNot, 0f, "Moving");
			animatorStateTransition79442.AddCondition(AnimatorConditionMode.If, 0f, "Aiming");
			animatorStateTransition79442.AddCondition(AnimatorConditionMode.Equals, 301f, "AbilityIndex");
			animatorStateTransition79442.AddCondition(AnimatorConditionMode.NotEqual, 1f, "AbilityIntData");

			var animatorStateTransition79444 = baseStateMachine1668786664.AddAnyStateTransition(equipFromIdleWaterAnimatorState79740);
			animatorStateTransition79444.canTransitionToSelf = false;
			animatorStateTransition79444.duration = 0.15f;
			animatorStateTransition79444.exitTime = 0.75f;
			animatorStateTransition79444.hasExitTime = false;
			animatorStateTransition79444.hasFixedDuration = true;
			animatorStateTransition79444.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition79444.offset = 0f;
			animatorStateTransition79444.orderedInterruption = true;
			animatorStateTransition79444.isExit = false;
			animatorStateTransition79444.mute = false;
			animatorStateTransition79444.solo = false;
			animatorStateTransition79444.AddCondition(AnimatorConditionMode.If, 0f, "Slot0ItemStateIndexChange");
			animatorStateTransition79444.AddCondition(AnimatorConditionMode.Equals, 26f, "Slot0ItemID");
			animatorStateTransition79444.AddCondition(AnimatorConditionMode.Equals, 4f, "Slot0ItemStateIndex");
			animatorStateTransition79444.AddCondition(AnimatorConditionMode.IfNot, 0f, "Moving");
			animatorStateTransition79444.AddCondition(AnimatorConditionMode.IfNot, 0f, "Aiming");
			animatorStateTransition79444.AddCondition(AnimatorConditionMode.Equals, 301f, "AbilityIndex");
			animatorStateTransition79444.AddCondition(AnimatorConditionMode.NotEqual, 1f, "AbilityIntData");

			var animatorStateTransition79446 = baseStateMachine1668786664.AddAnyStateTransition(unequipFromIdleWaterAnimatorState79742);
			animatorStateTransition79446.canTransitionToSelf = false;
			animatorStateTransition79446.duration = 0.15f;
			animatorStateTransition79446.exitTime = 0.75f;
			animatorStateTransition79446.hasExitTime = false;
			animatorStateTransition79446.hasFixedDuration = true;
			animatorStateTransition79446.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition79446.offset = 0f;
			animatorStateTransition79446.orderedInterruption = true;
			animatorStateTransition79446.isExit = false;
			animatorStateTransition79446.mute = false;
			animatorStateTransition79446.solo = false;
			animatorStateTransition79446.AddCondition(AnimatorConditionMode.If, 0f, "Slot0ItemStateIndexChange");
			animatorStateTransition79446.AddCondition(AnimatorConditionMode.Equals, 26f, "Slot0ItemID");
			animatorStateTransition79446.AddCondition(AnimatorConditionMode.Equals, 5f, "Slot0ItemStateIndex");
			animatorStateTransition79446.AddCondition(AnimatorConditionMode.IfNot, 0f, "Moving");
			animatorStateTransition79446.AddCondition(AnimatorConditionMode.IfNot, 0f, "Aiming");
			animatorStateTransition79446.AddCondition(AnimatorConditionMode.Equals, 301f, "AbilityIndex");
			animatorStateTransition79446.AddCondition(AnimatorConditionMode.NotEqual, 1f, "AbilityIntData");

			var animatorStateTransition79448 = baseStateMachine1668786664.AddAnyStateTransition(dropWaterAnimatorState79744);
			animatorStateTransition79448.canTransitionToSelf = false;
			animatorStateTransition79448.duration = 0.1f;
			animatorStateTransition79448.exitTime = 0.75f;
			animatorStateTransition79448.hasExitTime = false;
			animatorStateTransition79448.hasFixedDuration = true;
			animatorStateTransition79448.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition79448.offset = 0f;
			animatorStateTransition79448.orderedInterruption = true;
			animatorStateTransition79448.isExit = false;
			animatorStateTransition79448.mute = false;
			animatorStateTransition79448.solo = false;
			animatorStateTransition79448.AddCondition(AnimatorConditionMode.If, 0f, "Slot0ItemStateIndexChange");
			animatorStateTransition79448.AddCondition(AnimatorConditionMode.Equals, 26f, "Slot0ItemID");
			animatorStateTransition79448.AddCondition(AnimatorConditionMode.Equals, 6f, "Slot0ItemStateIndex");
			animatorStateTransition79448.AddCondition(AnimatorConditionMode.IfNot, 0f, "Moving");
			animatorStateTransition79448.AddCondition(AnimatorConditionMode.Equals, 301f, "AbilityIndex");
			animatorStateTransition79448.AddCondition(AnimatorConditionMode.NotEqual, 1f, "AbilityIntData");

			var animatorStateTransition79490 = baseStateMachine1668786664.AddAnyStateTransition(equipFromAimLandAnimatorState79764);
			animatorStateTransition79490.canTransitionToSelf = false;
			animatorStateTransition79490.duration = 0.15f;
			animatorStateTransition79490.exitTime = 0.75f;
			animatorStateTransition79490.hasExitTime = false;
			animatorStateTransition79490.hasFixedDuration = true;
			animatorStateTransition79490.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition79490.offset = 0f;
			animatorStateTransition79490.orderedInterruption = true;
			animatorStateTransition79490.isExit = false;
			animatorStateTransition79490.mute = false;
			animatorStateTransition79490.solo = false;
			animatorStateTransition79490.AddCondition(AnimatorConditionMode.If, 0f, "Slot0ItemStateIndexChange");
			animatorStateTransition79490.AddCondition(AnimatorConditionMode.Equals, 26f, "Slot0ItemID");
			animatorStateTransition79490.AddCondition(AnimatorConditionMode.Equals, 4f, "Slot0ItemStateIndex");
			animatorStateTransition79490.AddCondition(AnimatorConditionMode.IfNot, 0f, "Moving");
			animatorStateTransition79490.AddCondition(AnimatorConditionMode.If, 0f, "Aiming");
			animatorStateTransition79490.AddCondition(AnimatorConditionMode.Equals, 301f, "AbilityIndex");
			animatorStateTransition79490.AddCondition(AnimatorConditionMode.Equals, 1f, "AbilityIntData");

			var animatorStateTransition79492 = baseStateMachine1668786664.AddAnyStateTransition(unequipFromAimLandAnimatorState79766);
			animatorStateTransition79492.canTransitionToSelf = false;
			animatorStateTransition79492.duration = 0.15f;
			animatorStateTransition79492.exitTime = 0.75f;
			animatorStateTransition79492.hasExitTime = false;
			animatorStateTransition79492.hasFixedDuration = false;
			animatorStateTransition79492.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition79492.offset = 0f;
			animatorStateTransition79492.orderedInterruption = true;
			animatorStateTransition79492.isExit = false;
			animatorStateTransition79492.mute = false;
			animatorStateTransition79492.solo = false;
			animatorStateTransition79492.AddCondition(AnimatorConditionMode.If, 0f, "Slot0ItemStateIndexChange");
			animatorStateTransition79492.AddCondition(AnimatorConditionMode.Equals, 26f, "Slot0ItemID");
			animatorStateTransition79492.AddCondition(AnimatorConditionMode.Equals, 5f, "Slot0ItemStateIndex");
			animatorStateTransition79492.AddCondition(AnimatorConditionMode.IfNot, 0f, "Moving");
			animatorStateTransition79492.AddCondition(AnimatorConditionMode.If, 0f, "Aiming");
			animatorStateTransition79492.AddCondition(AnimatorConditionMode.Equals, 301f, "AbilityIndex");
			animatorStateTransition79492.AddCondition(AnimatorConditionMode.Equals, 1f, "AbilityIntData");

			var animatorStateTransition79494 = baseStateMachine1668786664.AddAnyStateTransition(equipFromIdleLandAnimatorState79768);
			animatorStateTransition79494.canTransitionToSelf = false;
			animatorStateTransition79494.duration = 0.15f;
			animatorStateTransition79494.exitTime = 0.75f;
			animatorStateTransition79494.hasExitTime = false;
			animatorStateTransition79494.hasFixedDuration = true;
			animatorStateTransition79494.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition79494.offset = 0f;
			animatorStateTransition79494.orderedInterruption = true;
			animatorStateTransition79494.isExit = false;
			animatorStateTransition79494.mute = false;
			animatorStateTransition79494.solo = false;
			animatorStateTransition79494.AddCondition(AnimatorConditionMode.If, 0f, "Slot0ItemStateIndexChange");
			animatorStateTransition79494.AddCondition(AnimatorConditionMode.Equals, 26f, "Slot0ItemID");
			animatorStateTransition79494.AddCondition(AnimatorConditionMode.Equals, 4f, "Slot0ItemStateIndex");
			animatorStateTransition79494.AddCondition(AnimatorConditionMode.IfNot, 0f, "Moving");
			animatorStateTransition79494.AddCondition(AnimatorConditionMode.IfNot, 0f, "Aiming");
			animatorStateTransition79494.AddCondition(AnimatorConditionMode.Equals, 301f, "AbilityIndex");
			animatorStateTransition79494.AddCondition(AnimatorConditionMode.Equals, 1f, "AbilityIntData");

			var animatorStateTransition79496 = baseStateMachine1668786664.AddAnyStateTransition(unequipFromIdleLandAnimatorState79770);
			animatorStateTransition79496.canTransitionToSelf = false;
			animatorStateTransition79496.duration = 0.15f;
			animatorStateTransition79496.exitTime = 0.75f;
			animatorStateTransition79496.hasExitTime = false;
			animatorStateTransition79496.hasFixedDuration = true;
			animatorStateTransition79496.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition79496.offset = 0f;
			animatorStateTransition79496.orderedInterruption = true;
			animatorStateTransition79496.isExit = false;
			animatorStateTransition79496.mute = false;
			animatorStateTransition79496.solo = false;
			animatorStateTransition79496.AddCondition(AnimatorConditionMode.If, 0f, "Slot0ItemStateIndexChange");
			animatorStateTransition79496.AddCondition(AnimatorConditionMode.Equals, 26f, "Slot0ItemID");
			animatorStateTransition79496.AddCondition(AnimatorConditionMode.Equals, 5f, "Slot0ItemStateIndex");
			animatorStateTransition79496.AddCondition(AnimatorConditionMode.IfNot, 0f, "Moving");
			animatorStateTransition79496.AddCondition(AnimatorConditionMode.IfNot, 0f, "Aiming");
			animatorStateTransition79496.AddCondition(AnimatorConditionMode.Equals, 301f, "AbilityIndex");
			animatorStateTransition79496.AddCondition(AnimatorConditionMode.Equals, 1f, "AbilityIntData");

			var animatorStateTransition79498 = baseStateMachine1668786664.AddAnyStateTransition(dropWaterLandAnimatorState79772);
			animatorStateTransition79498.canTransitionToSelf = false;
			animatorStateTransition79498.duration = 0.1f;
			animatorStateTransition79498.exitTime = 0.75f;
			animatorStateTransition79498.hasExitTime = false;
			animatorStateTransition79498.hasFixedDuration = true;
			animatorStateTransition79498.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition79498.offset = 0f;
			animatorStateTransition79498.orderedInterruption = true;
			animatorStateTransition79498.isExit = false;
			animatorStateTransition79498.mute = false;
			animatorStateTransition79498.solo = false;
			animatorStateTransition79498.AddCondition(AnimatorConditionMode.If, 0f, "Slot0ItemStateIndexChange");
			animatorStateTransition79498.AddCondition(AnimatorConditionMode.Equals, 26f, "Slot0ItemID");
			animatorStateTransition79498.AddCondition(AnimatorConditionMode.Equals, 6f, "Slot0ItemStateIndex");
			animatorStateTransition79498.AddCondition(AnimatorConditionMode.IfNot, 0f, "Moving");
			animatorStateTransition79498.AddCondition(AnimatorConditionMode.Equals, 301f, "AbilityIndex");
			animatorStateTransition79498.AddCondition(AnimatorConditionMode.Equals, 1f, "AbilityIntData");
			// State Transitions.
			var animatorStateTransition80590 = unequipFromIdleWaterAnimatorState79746.AddExitTransition();
			animatorStateTransition80590.canTransitionToSelf = true;
			animatorStateTransition80590.duration = 0.2f;
			animatorStateTransition80590.exitTime = 0.75f;
			animatorStateTransition80590.hasExitTime = false;
			animatorStateTransition80590.hasFixedDuration = true;
			animatorStateTransition80590.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition80590.offset = 0f;
			animatorStateTransition80590.orderedInterruption = true;
			animatorStateTransition80590.isExit = true;
			animatorStateTransition80590.mute = false;
			animatorStateTransition80590.solo = false;
			animatorStateTransition80590.AddCondition(AnimatorConditionMode.NotEqual, 5f, "Slot0ItemStateIndex");

			var animatorStateTransition80594 = unequipFromAimWaterAnimatorState79748.AddExitTransition();
			animatorStateTransition80594.canTransitionToSelf = true;
			animatorStateTransition80594.duration = 0.2f;
			animatorStateTransition80594.exitTime = 0.8846154f;
			animatorStateTransition80594.hasExitTime = false;
			animatorStateTransition80594.hasFixedDuration = true;
			animatorStateTransition80594.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition80594.offset = 0f;
			animatorStateTransition80594.orderedInterruption = true;
			animatorStateTransition80594.isExit = true;
			animatorStateTransition80594.mute = false;
			animatorStateTransition80594.solo = false;
			animatorStateTransition80594.AddCondition(AnimatorConditionMode.NotEqual, 5f, "Slot0ItemStateIndex");

			var animatorStateTransition80598 = equipFromAimWaterAnimatorState79750.AddExitTransition();
			animatorStateTransition80598.canTransitionToSelf = true;
			animatorStateTransition80598.duration = 0.2f;
			animatorStateTransition80598.exitTime = 0.8846154f;
			animatorStateTransition80598.hasExitTime = false;
			animatorStateTransition80598.hasFixedDuration = true;
			animatorStateTransition80598.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition80598.offset = 0f;
			animatorStateTransition80598.orderedInterruption = true;
			animatorStateTransition80598.isExit = true;
			animatorStateTransition80598.mute = false;
			animatorStateTransition80598.solo = false;
			animatorStateTransition80598.AddCondition(AnimatorConditionMode.NotEqual, 4f, "Slot0ItemStateIndex");

			var animatorStateTransition80602 = equipFromIdleWaterAnimatorState79774.AddExitTransition();
			animatorStateTransition80602.canTransitionToSelf = true;
			animatorStateTransition80602.duration = 0.2f;
			animatorStateTransition80602.exitTime = 0.75f;
			animatorStateTransition80602.hasExitTime = false;
			animatorStateTransition80602.hasFixedDuration = true;
			animatorStateTransition80602.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition80602.offset = 0f;
			animatorStateTransition80602.orderedInterruption = true;
			animatorStateTransition80602.isExit = true;
			animatorStateTransition80602.mute = false;
			animatorStateTransition80602.solo = false;
			animatorStateTransition80602.AddCondition(AnimatorConditionMode.NotEqual, 4f, "Slot0ItemStateIndex");

			var animatorStateTransition80606 = dropWaterAnimatorState79752.AddExitTransition();
			animatorStateTransition80606.canTransitionToSelf = true;
			animatorStateTransition80606.duration = 0.1f;
			animatorStateTransition80606.exitTime = 0.9f;
			animatorStateTransition80606.hasExitTime = true;
			animatorStateTransition80606.hasFixedDuration = true;
			animatorStateTransition80606.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition80606.offset = 0f;
			animatorStateTransition80606.orderedInterruption = true;
			animatorStateTransition80606.isExit = true;
			animatorStateTransition80606.mute = false;
			animatorStateTransition80606.solo = false;

			var animatorStateTransition80608 = dropLandAnimatorState79754.AddExitTransition();
			animatorStateTransition80608.canTransitionToSelf = true;
			animatorStateTransition80608.duration = 0.1f;
			animatorStateTransition80608.exitTime = 0.9f;
			animatorStateTransition80608.hasExitTime = true;
			animatorStateTransition80608.hasFixedDuration = true;
			animatorStateTransition80608.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition80608.offset = 0f;
			animatorStateTransition80608.orderedInterruption = true;
			animatorStateTransition80608.isExit = true;
			animatorStateTransition80608.mute = false;
			animatorStateTransition80608.solo = false;

			var animatorStateTransition80610 = equipFromIdleLandAnimatorState79756.AddExitTransition();
			animatorStateTransition80610.canTransitionToSelf = true;
			animatorStateTransition80610.duration = 0.2f;
			animatorStateTransition80610.exitTime = 0.75f;
			animatorStateTransition80610.hasExitTime = false;
			animatorStateTransition80610.hasFixedDuration = true;
			animatorStateTransition80610.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition80610.offset = 0f;
			animatorStateTransition80610.orderedInterruption = true;
			animatorStateTransition80610.isExit = true;
			animatorStateTransition80610.mute = false;
			animatorStateTransition80610.solo = false;
			animatorStateTransition80610.AddCondition(AnimatorConditionMode.NotEqual, 4f, "Slot0ItemStateIndex");

			var animatorStateTransition80612 = equipFromAimLandAnimatorState79758.AddExitTransition();
			animatorStateTransition80612.canTransitionToSelf = true;
			animatorStateTransition80612.duration = 0.2f;
			animatorStateTransition80612.exitTime = 0.8846154f;
			animatorStateTransition80612.hasExitTime = false;
			animatorStateTransition80612.hasFixedDuration = true;
			animatorStateTransition80612.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition80612.offset = 0f;
			animatorStateTransition80612.orderedInterruption = true;
			animatorStateTransition80612.isExit = true;
			animatorStateTransition80612.mute = false;
			animatorStateTransition80612.solo = false;
			animatorStateTransition80612.AddCondition(AnimatorConditionMode.NotEqual, 4f, "Slot0ItemStateIndex");

			var animatorStateTransition80614 = unequipFromAimLandAnimatorState79760.AddExitTransition();
			animatorStateTransition80614.canTransitionToSelf = true;
			animatorStateTransition80614.duration = 0.2f;
			animatorStateTransition80614.exitTime = 0.8846154f;
			animatorStateTransition80614.hasExitTime = false;
			animatorStateTransition80614.hasFixedDuration = true;
			animatorStateTransition80614.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition80614.offset = 0f;
			animatorStateTransition80614.orderedInterruption = true;
			animatorStateTransition80614.isExit = true;
			animatorStateTransition80614.mute = false;
			animatorStateTransition80614.solo = false;
			animatorStateTransition80614.AddCondition(AnimatorConditionMode.NotEqual, 5f, "Slot0ItemStateIndex");

			var animatorStateTransition80616 = unequipFromIdleLandAnimatorState79762.AddExitTransition();
			animatorStateTransition80616.canTransitionToSelf = true;
			animatorStateTransition80616.duration = 0.2f;
			animatorStateTransition80616.exitTime = 0.75f;
			animatorStateTransition80616.hasExitTime = false;
			animatorStateTransition80616.hasFixedDuration = true;
			animatorStateTransition80616.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition80616.offset = 0f;
			animatorStateTransition80616.orderedInterruption = true;
			animatorStateTransition80616.isExit = true;
			animatorStateTransition80616.mute = false;
			animatorStateTransition80616.solo = false;
			animatorStateTransition80616.AddCondition(AnimatorConditionMode.NotEqual, 5f, "Slot0ItemStateIndex");


			// State Machine Transitions.
			var animatorStateTransition79450 = baseStateMachine1715710442.AddAnyStateTransition(unequipFromIdleWaterAnimatorState79746);
			animatorStateTransition79450.canTransitionToSelf = false;
			animatorStateTransition79450.duration = 0.15f;
			animatorStateTransition79450.exitTime = 0.75f;
			animatorStateTransition79450.hasExitTime = false;
			animatorStateTransition79450.hasFixedDuration = true;
			animatorStateTransition79450.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition79450.offset = 0f;
			animatorStateTransition79450.orderedInterruption = true;
			animatorStateTransition79450.isExit = false;
			animatorStateTransition79450.mute = false;
			animatorStateTransition79450.solo = false;
			animatorStateTransition79450.AddCondition(AnimatorConditionMode.If, 0f, "Slot0ItemStateIndexChange");
			animatorStateTransition79450.AddCondition(AnimatorConditionMode.Equals, 7f, "Slot0ItemID");
			animatorStateTransition79450.AddCondition(AnimatorConditionMode.Equals, 5f, "Slot0ItemStateIndex");
			animatorStateTransition79450.AddCondition(AnimatorConditionMode.IfNot, 0f, "Aiming");
			animatorStateTransition79450.AddCondition(AnimatorConditionMode.IfNot, 0f, "Moving");
			animatorStateTransition79450.AddCondition(AnimatorConditionMode.Equals, 301f, "AbilityIndex");
			animatorStateTransition79450.AddCondition(AnimatorConditionMode.NotEqual, 1f, "AbilityIntData");

			var animatorStateTransition79452 = baseStateMachine1715710442.AddAnyStateTransition(unequipFromAimWaterAnimatorState79748);
			animatorStateTransition79452.canTransitionToSelf = false;
			animatorStateTransition79452.duration = 0.15f;
			animatorStateTransition79452.exitTime = 0.75f;
			animatorStateTransition79452.hasExitTime = false;
			animatorStateTransition79452.hasFixedDuration = true;
			animatorStateTransition79452.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition79452.offset = 0f;
			animatorStateTransition79452.orderedInterruption = true;
			animatorStateTransition79452.isExit = false;
			animatorStateTransition79452.mute = false;
			animatorStateTransition79452.solo = false;
			animatorStateTransition79452.AddCondition(AnimatorConditionMode.If, 0f, "Slot0ItemStateIndexChange");
			animatorStateTransition79452.AddCondition(AnimatorConditionMode.Equals, 7f, "Slot0ItemID");
			animatorStateTransition79452.AddCondition(AnimatorConditionMode.Equals, 5f, "Slot0ItemStateIndex");
			animatorStateTransition79452.AddCondition(AnimatorConditionMode.If, 0f, "Aiming");
			animatorStateTransition79452.AddCondition(AnimatorConditionMode.IfNot, 0f, "Moving");
			animatorStateTransition79452.AddCondition(AnimatorConditionMode.Equals, 301f, "AbilityIndex");
			animatorStateTransition79452.AddCondition(AnimatorConditionMode.NotEqual, 1f, "AbilityIntData");

			var animatorStateTransition79454 = baseStateMachine1715710442.AddAnyStateTransition(equipFromAimWaterAnimatorState79750);
			animatorStateTransition79454.canTransitionToSelf = false;
			animatorStateTransition79454.duration = 0.15f;
			animatorStateTransition79454.exitTime = 0.75f;
			animatorStateTransition79454.hasExitTime = false;
			animatorStateTransition79454.hasFixedDuration = true;
			animatorStateTransition79454.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition79454.offset = 0f;
			animatorStateTransition79454.orderedInterruption = true;
			animatorStateTransition79454.isExit = false;
			animatorStateTransition79454.mute = false;
			animatorStateTransition79454.solo = false;
			animatorStateTransition79454.AddCondition(AnimatorConditionMode.If, 0f, "Slot0ItemStateIndexChange");
			animatorStateTransition79454.AddCondition(AnimatorConditionMode.Equals, 7f, "Slot0ItemID");
			animatorStateTransition79454.AddCondition(AnimatorConditionMode.Equals, 4f, "Slot0ItemStateIndex");
			animatorStateTransition79454.AddCondition(AnimatorConditionMode.If, 0f, "Aiming");
			animatorStateTransition79454.AddCondition(AnimatorConditionMode.IfNot, 0f, "Moving");
			animatorStateTransition79454.AddCondition(AnimatorConditionMode.Equals, 301f, "AbilityIndex");
			animatorStateTransition79454.AddCondition(AnimatorConditionMode.NotEqual, 1f, "AbilityIntData");

			var animatorStateTransition79456 = baseStateMachine1715710442.AddAnyStateTransition(dropWaterAnimatorState79752);
			animatorStateTransition79456.canTransitionToSelf = false;
			animatorStateTransition79456.duration = 0.1f;
			animatorStateTransition79456.exitTime = 0.75f;
			animatorStateTransition79456.hasExitTime = false;
			animatorStateTransition79456.hasFixedDuration = true;
			animatorStateTransition79456.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition79456.offset = 0f;
			animatorStateTransition79456.orderedInterruption = true;
			animatorStateTransition79456.isExit = false;
			animatorStateTransition79456.mute = false;
			animatorStateTransition79456.solo = false;
			animatorStateTransition79456.AddCondition(AnimatorConditionMode.If, 0f, "Slot0ItemStateIndexChange");
			animatorStateTransition79456.AddCondition(AnimatorConditionMode.Equals, 7f, "Slot0ItemID");
			animatorStateTransition79456.AddCondition(AnimatorConditionMode.Equals, 6f, "Slot0ItemStateIndex");
			animatorStateTransition79456.AddCondition(AnimatorConditionMode.IfNot, 0f, "Moving");
			animatorStateTransition79456.AddCondition(AnimatorConditionMode.Equals, 301f, "AbilityIndex");
			animatorStateTransition79456.AddCondition(AnimatorConditionMode.NotEqual, 1f, "AbilityIntData");

			var animatorStateTransition79478 = baseStateMachine1715710442.AddAnyStateTransition(equipFromIdleWaterAnimatorState79774);
			animatorStateTransition79478.canTransitionToSelf = false;
			animatorStateTransition79478.duration = 0.15f;
			animatorStateTransition79478.exitTime = 0.75f;
			animatorStateTransition79478.hasExitTime = false;
			animatorStateTransition79478.hasFixedDuration = true;
			animatorStateTransition79478.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition79478.offset = 0f;
			animatorStateTransition79478.orderedInterruption = true;
			animatorStateTransition79478.isExit = false;
			animatorStateTransition79478.mute = false;
			animatorStateTransition79478.solo = false;
			animatorStateTransition79478.AddCondition(AnimatorConditionMode.If, 0f, "Slot0ItemStateIndexChange");
			animatorStateTransition79478.AddCondition(AnimatorConditionMode.Equals, 7f, "Slot0ItemID");
			animatorStateTransition79478.AddCondition(AnimatorConditionMode.Equals, 4f, "Slot0ItemStateIndex");
			animatorStateTransition79478.AddCondition(AnimatorConditionMode.IfNot, 0f, "Aiming");
			animatorStateTransition79478.AddCondition(AnimatorConditionMode.IfNot, 0f, "Moving");
			animatorStateTransition79478.AddCondition(AnimatorConditionMode.Equals, 301f, "AbilityIndex");
			animatorStateTransition79478.AddCondition(AnimatorConditionMode.NotEqual, 1f, "AbilityIntData");

			var animatorStateTransition79480 = baseStateMachine1715710442.AddAnyStateTransition(dropLandAnimatorState79754);
			animatorStateTransition79480.canTransitionToSelf = false;
			animatorStateTransition79480.duration = 0.1f;
			animatorStateTransition79480.exitTime = 0.75f;
			animatorStateTransition79480.hasExitTime = false;
			animatorStateTransition79480.hasFixedDuration = true;
			animatorStateTransition79480.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition79480.offset = 0f;
			animatorStateTransition79480.orderedInterruption = true;
			animatorStateTransition79480.isExit = false;
			animatorStateTransition79480.mute = false;
			animatorStateTransition79480.solo = false;
			animatorStateTransition79480.AddCondition(AnimatorConditionMode.If, 0f, "Slot0ItemStateIndexChange");
			animatorStateTransition79480.AddCondition(AnimatorConditionMode.Equals, 7f, "Slot0ItemID");
			animatorStateTransition79480.AddCondition(AnimatorConditionMode.Equals, 6f, "Slot0ItemStateIndex");
			animatorStateTransition79480.AddCondition(AnimatorConditionMode.IfNot, 0f, "Moving");
			animatorStateTransition79480.AddCondition(AnimatorConditionMode.Equals, 301f, "AbilityIndex");
			animatorStateTransition79480.AddCondition(AnimatorConditionMode.Equals, 1f, "AbilityIntData");

			var animatorStateTransition79482 = baseStateMachine1715710442.AddAnyStateTransition(unequipFromIdleLandAnimatorState79762);
			animatorStateTransition79482.canTransitionToSelf = false;
			animatorStateTransition79482.duration = 0.15f;
			animatorStateTransition79482.exitTime = 0.75f;
			animatorStateTransition79482.hasExitTime = false;
			animatorStateTransition79482.hasFixedDuration = true;
			animatorStateTransition79482.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition79482.offset = 0f;
			animatorStateTransition79482.orderedInterruption = true;
			animatorStateTransition79482.isExit = false;
			animatorStateTransition79482.mute = false;
			animatorStateTransition79482.solo = false;
			animatorStateTransition79482.AddCondition(AnimatorConditionMode.If, 0f, "Slot0ItemStateIndexChange");
			animatorStateTransition79482.AddCondition(AnimatorConditionMode.Equals, 7f, "Slot0ItemID");
			animatorStateTransition79482.AddCondition(AnimatorConditionMode.Equals, 5f, "Slot0ItemStateIndex");
			animatorStateTransition79482.AddCondition(AnimatorConditionMode.IfNot, 0f, "Moving");
			animatorStateTransition79482.AddCondition(AnimatorConditionMode.IfNot, 0f, "Aiming");
			animatorStateTransition79482.AddCondition(AnimatorConditionMode.Equals, 301f, "AbilityIndex");
			animatorStateTransition79482.AddCondition(AnimatorConditionMode.Equals, 1f, "AbilityIntData");

			var animatorStateTransition79484 = baseStateMachine1715710442.AddAnyStateTransition(equipFromIdleLandAnimatorState79756);
			animatorStateTransition79484.canTransitionToSelf = false;
			animatorStateTransition79484.duration = 0.15f;
			animatorStateTransition79484.exitTime = 0.75f;
			animatorStateTransition79484.hasExitTime = false;
			animatorStateTransition79484.hasFixedDuration = true;
			animatorStateTransition79484.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition79484.offset = 0f;
			animatorStateTransition79484.orderedInterruption = true;
			animatorStateTransition79484.isExit = false;
			animatorStateTransition79484.mute = false;
			animatorStateTransition79484.solo = false;
			animatorStateTransition79484.AddCondition(AnimatorConditionMode.If, 0f, "Slot0ItemStateIndexChange");
			animatorStateTransition79484.AddCondition(AnimatorConditionMode.Equals, 7f, "Slot0ItemID");
			animatorStateTransition79484.AddCondition(AnimatorConditionMode.Equals, 4f, "Slot0ItemStateIndex");
			animatorStateTransition79484.AddCondition(AnimatorConditionMode.IfNot, 0f, "Moving");
			animatorStateTransition79484.AddCondition(AnimatorConditionMode.IfNot, 0f, "Aiming");
			animatorStateTransition79484.AddCondition(AnimatorConditionMode.Equals, 301f, "AbilityIndex");
			animatorStateTransition79484.AddCondition(AnimatorConditionMode.Equals, 1f, "AbilityIntData");

			var animatorStateTransition79486 = baseStateMachine1715710442.AddAnyStateTransition(unequipFromAimLandAnimatorState79760);
			animatorStateTransition79486.canTransitionToSelf = false;
			animatorStateTransition79486.duration = 0.15f;
			animatorStateTransition79486.exitTime = 0.75f;
			animatorStateTransition79486.hasExitTime = false;
			animatorStateTransition79486.hasFixedDuration = true;
			animatorStateTransition79486.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition79486.offset = 0f;
			animatorStateTransition79486.orderedInterruption = true;
			animatorStateTransition79486.isExit = false;
			animatorStateTransition79486.mute = false;
			animatorStateTransition79486.solo = false;
			animatorStateTransition79486.AddCondition(AnimatorConditionMode.If, 0f, "Slot0ItemStateIndexChange");
			animatorStateTransition79486.AddCondition(AnimatorConditionMode.Equals, 7f, "Slot0ItemID");
			animatorStateTransition79486.AddCondition(AnimatorConditionMode.Equals, 5f, "Slot0ItemStateIndex");
			animatorStateTransition79486.AddCondition(AnimatorConditionMode.If, 0f, "Moving");
			animatorStateTransition79486.AddCondition(AnimatorConditionMode.IfNot, 0f, "Aiming");
			animatorStateTransition79486.AddCondition(AnimatorConditionMode.Equals, 301f, "AbilityIndex");
			animatorStateTransition79486.AddCondition(AnimatorConditionMode.Equals, 1f, "AbilityIntData");

			var animatorStateTransition79488 = baseStateMachine1715710442.AddAnyStateTransition(equipFromAimLandAnimatorState79758);
			animatorStateTransition79488.canTransitionToSelf = false;
			animatorStateTransition79488.duration = 0.15f;
			animatorStateTransition79488.exitTime = 0.75f;
			animatorStateTransition79488.hasExitTime = false;
			animatorStateTransition79488.hasFixedDuration = true;
			animatorStateTransition79488.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition79488.offset = 0f;
			animatorStateTransition79488.orderedInterruption = true;
			animatorStateTransition79488.isExit = false;
			animatorStateTransition79488.mute = false;
			animatorStateTransition79488.solo = false;
			animatorStateTransition79488.AddCondition(AnimatorConditionMode.If, 0f, "Slot0ItemStateIndexChange");
			animatorStateTransition79488.AddCondition(AnimatorConditionMode.Equals, 7f, "Slot0ItemID");
			animatorStateTransition79488.AddCondition(AnimatorConditionMode.Equals, 4f, "Slot0ItemStateIndex");
			animatorStateTransition79488.AddCondition(AnimatorConditionMode.If, 0f, "Moving");
			animatorStateTransition79488.AddCondition(AnimatorConditionMode.IfNot, 0f, "Aiming");
			animatorStateTransition79488.AddCondition(AnimatorConditionMode.Equals, 301f, "AbilityIndex");
			animatorStateTransition79488.AddCondition(AnimatorConditionMode.Equals, 1f, "AbilityIntData");


			if (animatorController.layers.Length <= 6) {
				Debug.LogWarning("Warning: The animator controller does not contain the same number of layers as the demo animator. All of the animations cannot be added.");
				return;
			}

			var baseStateMachine1709680398 = animatorController.layers[6].stateMachine;

			// The state machine should start fresh.
			for (int i = 0; i < animatorController.layers.Length; ++i) {
				for (int j = 0; j < baseStateMachine1709680398.stateMachines.Length; ++j) {
					if (baseStateMachine1709680398.stateMachines[j].stateMachine.name == "Trident") {
						baseStateMachine1709680398.RemoveStateMachine(baseStateMachine1709680398.stateMachines[j].stateMachine);
						break;
					}
				}
			}

			// AnimationClip references.
			var tridentIdleLandAnimationClip64748Path = AssetDatabase.GUIDToAssetPath("664f5614e71a779429822b87be463208"); 
			var tridentIdleLandAnimationClip64748 = AnimatorBuilder.GetAnimationClip(tridentIdleLandAnimationClip64748Path, "TridentIdleLand");
			var tridentIdleStrafeAnimationClip64754Path = AssetDatabase.GUIDToAssetPath("96ff63c6525571940b7406e08ecdd02b"); 
			var tridentIdleStrafeAnimationClip64754 = AnimatorBuilder.GetAnimationClip(tridentIdleStrafeAnimationClip64754Path, "TridentIdleStrafe");
			var tridentIdleAnimationClip64742Path = AssetDatabase.GUIDToAssetPath("2351243658e3dc34898ce26659e281f4"); 
			var tridentIdleAnimationClip64742 = AnimatorBuilder.GetAnimationClip(tridentIdleAnimationClip64742Path, "TridentIdle");

			// State Machine.
			var tridentAnimatorStateMachine80846 = baseStateMachine1709680398.AddStateMachine("Trident", new Vector3(624f, 108f, 0f));

			// States.
			var dropWaterAnimatorState80990 = tridentAnimatorStateMachine80846.AddState("Drop Water", new Vector3(384f, 348f, 0f));
			var dropWaterAnimatorState80990blendTreeBlendTree81142 = new BlendTree();
			AssetDatabase.AddObjectToAsset(dropWaterAnimatorState80990blendTreeBlendTree81142, animatorController);
			dropWaterAnimatorState80990blendTreeBlendTree81142.hideFlags = HideFlags.HideInHierarchy;
			dropWaterAnimatorState80990blendTreeBlendTree81142.blendParameter = "HorizontalMovement";
			dropWaterAnimatorState80990blendTreeBlendTree81142.blendParameterY = "ForwardMovement";
			dropWaterAnimatorState80990blendTreeBlendTree81142.blendType = BlendTreeType.FreeformCartesian2D;
			dropWaterAnimatorState80990blendTreeBlendTree81142.maxThreshold = 1f;
			dropWaterAnimatorState80990blendTreeBlendTree81142.minThreshold = 0f;
			dropWaterAnimatorState80990blendTreeBlendTree81142.name = "Blend Tree";
			dropWaterAnimatorState80990blendTreeBlendTree81142.useAutomaticThresholds = true;
			var dropWaterAnimatorState80990blendTreeBlendTree81142Child0 =  new ChildMotion();
			dropWaterAnimatorState80990blendTreeBlendTree81142Child0.motion = tridentDropLandAnimationClip64694;
			dropWaterAnimatorState80990blendTreeBlendTree81142Child0.cycleOffset = 0f;
			dropWaterAnimatorState80990blendTreeBlendTree81142Child0.directBlendParameter = "HorizontalMovement";
			dropWaterAnimatorState80990blendTreeBlendTree81142Child0.mirror = false;
			dropWaterAnimatorState80990blendTreeBlendTree81142Child0.position = new Vector2(0f, -1f);
			dropWaterAnimatorState80990blendTreeBlendTree81142Child0.threshold = 0f;
			dropWaterAnimatorState80990blendTreeBlendTree81142Child0.timeScale = 1f;
			var dropWaterAnimatorState80990blendTreeBlendTree81142Child1 =  new ChildMotion();
			dropWaterAnimatorState80990blendTreeBlendTree81142Child1.motion = tridentDropStrafeAnimationClip64700;
			dropWaterAnimatorState80990blendTreeBlendTree81142Child1.cycleOffset = 0f;
			dropWaterAnimatorState80990blendTreeBlendTree81142Child1.directBlendParameter = "HorizontalMovement";
			dropWaterAnimatorState80990blendTreeBlendTree81142Child1.mirror = false;
			dropWaterAnimatorState80990blendTreeBlendTree81142Child1.position = new Vector2(-1f, 0f);
			dropWaterAnimatorState80990blendTreeBlendTree81142Child1.threshold = 0.25f;
			dropWaterAnimatorState80990blendTreeBlendTree81142Child1.timeScale = 1f;
			var dropWaterAnimatorState80990blendTreeBlendTree81142Child2 =  new ChildMotion();
			dropWaterAnimatorState80990blendTreeBlendTree81142Child2.motion = tridentDropAnimationClip64688;
			dropWaterAnimatorState80990blendTreeBlendTree81142Child2.cycleOffset = 0f;
			dropWaterAnimatorState80990blendTreeBlendTree81142Child2.directBlendParameter = "HorizontalMovement";
			dropWaterAnimatorState80990blendTreeBlendTree81142Child2.mirror = false;
			dropWaterAnimatorState80990blendTreeBlendTree81142Child2.position = new Vector2(0f, 0f);
			dropWaterAnimatorState80990blendTreeBlendTree81142Child2.threshold = 0.5f;
			dropWaterAnimatorState80990blendTreeBlendTree81142Child2.timeScale = 1f;
			var dropWaterAnimatorState80990blendTreeBlendTree81142Child3 =  new ChildMotion();
			dropWaterAnimatorState80990blendTreeBlendTree81142Child3.motion = tridentDropStrafeAnimationClip64700;
			dropWaterAnimatorState80990blendTreeBlendTree81142Child3.cycleOffset = 0f;
			dropWaterAnimatorState80990blendTreeBlendTree81142Child3.directBlendParameter = "HorizontalMovement";
			dropWaterAnimatorState80990blendTreeBlendTree81142Child3.mirror = false;
			dropWaterAnimatorState80990blendTreeBlendTree81142Child3.position = new Vector2(1f, 0f);
			dropWaterAnimatorState80990blendTreeBlendTree81142Child3.threshold = 0.75f;
			dropWaterAnimatorState80990blendTreeBlendTree81142Child3.timeScale = 1f;
			var dropWaterAnimatorState80990blendTreeBlendTree81142Child4 =  new ChildMotion();
			dropWaterAnimatorState80990blendTreeBlendTree81142Child4.motion = tridentDropAnimationClip64688;
			dropWaterAnimatorState80990blendTreeBlendTree81142Child4.cycleOffset = 0f;
			dropWaterAnimatorState80990blendTreeBlendTree81142Child4.directBlendParameter = "HorizontalMovement";
			dropWaterAnimatorState80990blendTreeBlendTree81142Child4.mirror = false;
			dropWaterAnimatorState80990blendTreeBlendTree81142Child4.position = new Vector2(0f, 1f);
			dropWaterAnimatorState80990blendTreeBlendTree81142Child4.threshold = 1f;
			dropWaterAnimatorState80990blendTreeBlendTree81142Child4.timeScale = 1f;
			dropWaterAnimatorState80990blendTreeBlendTree81142.children = new ChildMotion[] {
				dropWaterAnimatorState80990blendTreeBlendTree81142Child0,
				dropWaterAnimatorState80990blendTreeBlendTree81142Child1,
				dropWaterAnimatorState80990blendTreeBlendTree81142Child2,
				dropWaterAnimatorState80990blendTreeBlendTree81142Child3,
				dropWaterAnimatorState80990blendTreeBlendTree81142Child4
			};
			dropWaterAnimatorState80990.motion = dropWaterAnimatorState80990blendTreeBlendTree81142;
			dropWaterAnimatorState80990.cycleOffset = 0f;
			dropWaterAnimatorState80990.cycleOffsetParameterActive = false;
			dropWaterAnimatorState80990.iKOnFeet = false;
			dropWaterAnimatorState80990.mirror = false;
			dropWaterAnimatorState80990.mirrorParameterActive = false;
			dropWaterAnimatorState80990.speed = 1f;
			dropWaterAnimatorState80990.speedParameterActive = false;
			dropWaterAnimatorState80990.writeDefaultValues = true;

			var equipFromAimWaterAnimatorState80998 = tridentAnimatorStateMachine80846.AddState("Equip From Aim Water", new Vector3(384f, 108f, 0f));
			var equipFromAimWaterAnimatorState80998blendTreeBlendTree81146 = new BlendTree();
			AssetDatabase.AddObjectToAsset(equipFromAimWaterAnimatorState80998blendTreeBlendTree81146, animatorController);
			equipFromAimWaterAnimatorState80998blendTreeBlendTree81146.hideFlags = HideFlags.HideInHierarchy;
			equipFromAimWaterAnimatorState80998blendTreeBlendTree81146.blendParameter = "HorizontalMovement";
			equipFromAimWaterAnimatorState80998blendTreeBlendTree81146.blendParameterY = "ForwardMovement";
			equipFromAimWaterAnimatorState80998blendTreeBlendTree81146.blendType = BlendTreeType.FreeformCartesian2D;
			equipFromAimWaterAnimatorState80998blendTreeBlendTree81146.maxThreshold = 1.333333f;
			equipFromAimWaterAnimatorState80998blendTreeBlendTree81146.minThreshold = 0f;
			equipFromAimWaterAnimatorState80998blendTreeBlendTree81146.name = "Blend Tree";
			equipFromAimWaterAnimatorState80998blendTreeBlendTree81146.useAutomaticThresholds = false;
			var equipFromAimWaterAnimatorState80998blendTreeBlendTree81146Child0 =  new ChildMotion();
			equipFromAimWaterAnimatorState80998blendTreeBlendTree81146Child0.motion = tridentEquipFromAimLandAnimationClip64712;
			equipFromAimWaterAnimatorState80998blendTreeBlendTree81146Child0.cycleOffset = 0f;
			equipFromAimWaterAnimatorState80998blendTreeBlendTree81146Child0.directBlendParameter = "HorizontalMovement";
			equipFromAimWaterAnimatorState80998blendTreeBlendTree81146Child0.mirror = false;
			equipFromAimWaterAnimatorState80998blendTreeBlendTree81146Child0.position = new Vector2(0f, -1f);
			equipFromAimWaterAnimatorState80998blendTreeBlendTree81146Child0.threshold = 0f;
			equipFromAimWaterAnimatorState80998blendTreeBlendTree81146Child0.timeScale = 1f;
			var equipFromAimWaterAnimatorState80998blendTreeBlendTree81146Child1 =  new ChildMotion();
			equipFromAimWaterAnimatorState80998blendTreeBlendTree81146Child1.motion = tridentEquipFromAimStrafeAnimationClip64718;
			equipFromAimWaterAnimatorState80998blendTreeBlendTree81146Child1.cycleOffset = 0f;
			equipFromAimWaterAnimatorState80998blendTreeBlendTree81146Child1.directBlendParameter = "HorizontalMovement";
			equipFromAimWaterAnimatorState80998blendTreeBlendTree81146Child1.mirror = false;
			equipFromAimWaterAnimatorState80998blendTreeBlendTree81146Child1.position = new Vector2(-1f, 0f);
			equipFromAimWaterAnimatorState80998blendTreeBlendTree81146Child1.threshold = 0.3333333f;
			equipFromAimWaterAnimatorState80998blendTreeBlendTree81146Child1.timeScale = 1f;
			var equipFromAimWaterAnimatorState80998blendTreeBlendTree81146Child2 =  new ChildMotion();
			equipFromAimWaterAnimatorState80998blendTreeBlendTree81146Child2.motion = tridentEquipFromAimAnimationClip64706;
			equipFromAimWaterAnimatorState80998blendTreeBlendTree81146Child2.cycleOffset = 0f;
			equipFromAimWaterAnimatorState80998blendTreeBlendTree81146Child2.directBlendParameter = "HorizontalMovement";
			equipFromAimWaterAnimatorState80998blendTreeBlendTree81146Child2.mirror = false;
			equipFromAimWaterAnimatorState80998blendTreeBlendTree81146Child2.position = new Vector2(0f, 0f);
			equipFromAimWaterAnimatorState80998blendTreeBlendTree81146Child2.threshold = 0.6666667f;
			equipFromAimWaterAnimatorState80998blendTreeBlendTree81146Child2.timeScale = 1f;
			var equipFromAimWaterAnimatorState80998blendTreeBlendTree81146Child3 =  new ChildMotion();
			equipFromAimWaterAnimatorState80998blendTreeBlendTree81146Child3.motion = tridentEquipFromAimStrafeAnimationClip64718;
			equipFromAimWaterAnimatorState80998blendTreeBlendTree81146Child3.cycleOffset = 0f;
			equipFromAimWaterAnimatorState80998blendTreeBlendTree81146Child3.directBlendParameter = "HorizontalMovement";
			equipFromAimWaterAnimatorState80998blendTreeBlendTree81146Child3.mirror = false;
			equipFromAimWaterAnimatorState80998blendTreeBlendTree81146Child3.position = new Vector2(1f, 0f);
			equipFromAimWaterAnimatorState80998blendTreeBlendTree81146Child3.threshold = 1f;
			equipFromAimWaterAnimatorState80998blendTreeBlendTree81146Child3.timeScale = 1f;
			var equipFromAimWaterAnimatorState80998blendTreeBlendTree81146Child4 =  new ChildMotion();
			equipFromAimWaterAnimatorState80998blendTreeBlendTree81146Child4.motion = tridentEquipFromAimAnimationClip64706;
			equipFromAimWaterAnimatorState80998blendTreeBlendTree81146Child4.cycleOffset = 0f;
			equipFromAimWaterAnimatorState80998blendTreeBlendTree81146Child4.directBlendParameter = "HorizontalMovement";
			equipFromAimWaterAnimatorState80998blendTreeBlendTree81146Child4.mirror = false;
			equipFromAimWaterAnimatorState80998blendTreeBlendTree81146Child4.position = new Vector2(0f, 1f);
			equipFromAimWaterAnimatorState80998blendTreeBlendTree81146Child4.threshold = 1.333333f;
			equipFromAimWaterAnimatorState80998blendTreeBlendTree81146Child4.timeScale = 1f;
			equipFromAimWaterAnimatorState80998blendTreeBlendTree81146.children = new ChildMotion[] {
				equipFromAimWaterAnimatorState80998blendTreeBlendTree81146Child0,
				equipFromAimWaterAnimatorState80998blendTreeBlendTree81146Child1,
				equipFromAimWaterAnimatorState80998blendTreeBlendTree81146Child2,
				equipFromAimWaterAnimatorState80998blendTreeBlendTree81146Child3,
				equipFromAimWaterAnimatorState80998blendTreeBlendTree81146Child4
			};
			equipFromAimWaterAnimatorState80998.motion = equipFromAimWaterAnimatorState80998blendTreeBlendTree81146;
			equipFromAimWaterAnimatorState80998.cycleOffset = 0f;
			equipFromAimWaterAnimatorState80998.cycleOffsetParameterActive = false;
			equipFromAimWaterAnimatorState80998.iKOnFeet = false;
			equipFromAimWaterAnimatorState80998.mirror = false;
			equipFromAimWaterAnimatorState80998.mirrorParameterActive = false;
			equipFromAimWaterAnimatorState80998.speed = 2.75f;
			equipFromAimWaterAnimatorState80998.speedParameterActive = false;
			equipFromAimWaterAnimatorState80998.writeDefaultValues = true;

			var equipFromIdleWaterAnimatorState80994 = tridentAnimatorStateMachine80846.AddState("Equip From Idle Water", new Vector3(384f, 228f, 0f));
			var equipFromIdleWaterAnimatorState80994blendTreeBlendTree81150 = new BlendTree();
			AssetDatabase.AddObjectToAsset(equipFromIdleWaterAnimatorState80994blendTreeBlendTree81150, animatorController);
			equipFromIdleWaterAnimatorState80994blendTreeBlendTree81150.hideFlags = HideFlags.HideInHierarchy;
			equipFromIdleWaterAnimatorState80994blendTreeBlendTree81150.blendParameter = "HorizontalMovement";
			equipFromIdleWaterAnimatorState80994blendTreeBlendTree81150.blendParameterY = "ForwardMovement";
			equipFromIdleWaterAnimatorState80994blendTreeBlendTree81150.blendType = BlendTreeType.FreeformCartesian2D;
			equipFromIdleWaterAnimatorState80994blendTreeBlendTree81150.maxThreshold = 1f;
			equipFromIdleWaterAnimatorState80994blendTreeBlendTree81150.minThreshold = 0f;
			equipFromIdleWaterAnimatorState80994blendTreeBlendTree81150.name = "Blend Tree";
			equipFromIdleWaterAnimatorState80994blendTreeBlendTree81150.useAutomaticThresholds = true;
			var equipFromIdleWaterAnimatorState80994blendTreeBlendTree81150Child0 =  new ChildMotion();
			equipFromIdleWaterAnimatorState80994blendTreeBlendTree81150Child0.motion = tridentEquipFromIdleLandAnimationClip64730;
			equipFromIdleWaterAnimatorState80994blendTreeBlendTree81150Child0.cycleOffset = 0f;
			equipFromIdleWaterAnimatorState80994blendTreeBlendTree81150Child0.directBlendParameter = "HorizontalMovement";
			equipFromIdleWaterAnimatorState80994blendTreeBlendTree81150Child0.mirror = false;
			equipFromIdleWaterAnimatorState80994blendTreeBlendTree81150Child0.position = new Vector2(0f, -1f);
			equipFromIdleWaterAnimatorState80994blendTreeBlendTree81150Child0.threshold = 0f;
			equipFromIdleWaterAnimatorState80994blendTreeBlendTree81150Child0.timeScale = 1f;
			var equipFromIdleWaterAnimatorState80994blendTreeBlendTree81150Child1 =  new ChildMotion();
			equipFromIdleWaterAnimatorState80994blendTreeBlendTree81150Child1.motion = tridentEquipFromIdleStrafeAnimationClip64736;
			equipFromIdleWaterAnimatorState80994blendTreeBlendTree81150Child1.cycleOffset = 0f;
			equipFromIdleWaterAnimatorState80994blendTreeBlendTree81150Child1.directBlendParameter = "HorizontalMovement";
			equipFromIdleWaterAnimatorState80994blendTreeBlendTree81150Child1.mirror = false;
			equipFromIdleWaterAnimatorState80994blendTreeBlendTree81150Child1.position = new Vector2(-1f, 0f);
			equipFromIdleWaterAnimatorState80994blendTreeBlendTree81150Child1.threshold = 0.25f;
			equipFromIdleWaterAnimatorState80994blendTreeBlendTree81150Child1.timeScale = 1f;
			var equipFromIdleWaterAnimatorState80994blendTreeBlendTree81150Child2 =  new ChildMotion();
			equipFromIdleWaterAnimatorState80994blendTreeBlendTree81150Child2.motion = tridentEquipFromIdleAnimationClip64724;
			equipFromIdleWaterAnimatorState80994blendTreeBlendTree81150Child2.cycleOffset = 0f;
			equipFromIdleWaterAnimatorState80994blendTreeBlendTree81150Child2.directBlendParameter = "HorizontalMovement";
			equipFromIdleWaterAnimatorState80994blendTreeBlendTree81150Child2.mirror = false;
			equipFromIdleWaterAnimatorState80994blendTreeBlendTree81150Child2.position = new Vector2(0f, 0f);
			equipFromIdleWaterAnimatorState80994blendTreeBlendTree81150Child2.threshold = 0.5f;
			equipFromIdleWaterAnimatorState80994blendTreeBlendTree81150Child2.timeScale = 1f;
			var equipFromIdleWaterAnimatorState80994blendTreeBlendTree81150Child3 =  new ChildMotion();
			equipFromIdleWaterAnimatorState80994blendTreeBlendTree81150Child3.motion = tridentEquipFromIdleStrafeAnimationClip64736;
			equipFromIdleWaterAnimatorState80994blendTreeBlendTree81150Child3.cycleOffset = 0f;
			equipFromIdleWaterAnimatorState80994blendTreeBlendTree81150Child3.directBlendParameter = "HorizontalMovement";
			equipFromIdleWaterAnimatorState80994blendTreeBlendTree81150Child3.mirror = false;
			equipFromIdleWaterAnimatorState80994blendTreeBlendTree81150Child3.position = new Vector2(1f, 0f);
			equipFromIdleWaterAnimatorState80994blendTreeBlendTree81150Child3.threshold = 0.75f;
			equipFromIdleWaterAnimatorState80994blendTreeBlendTree81150Child3.timeScale = 1f;
			var equipFromIdleWaterAnimatorState80994blendTreeBlendTree81150Child4 =  new ChildMotion();
			equipFromIdleWaterAnimatorState80994blendTreeBlendTree81150Child4.motion = tridentEquipFromIdleAnimationClip64724;
			equipFromIdleWaterAnimatorState80994blendTreeBlendTree81150Child4.cycleOffset = 0f;
			equipFromIdleWaterAnimatorState80994blendTreeBlendTree81150Child4.directBlendParameter = "HorizontalMovement";
			equipFromIdleWaterAnimatorState80994blendTreeBlendTree81150Child4.mirror = false;
			equipFromIdleWaterAnimatorState80994blendTreeBlendTree81150Child4.position = new Vector2(0f, 1f);
			equipFromIdleWaterAnimatorState80994blendTreeBlendTree81150Child4.threshold = 1f;
			equipFromIdleWaterAnimatorState80994blendTreeBlendTree81150Child4.timeScale = 1f;
			equipFromIdleWaterAnimatorState80994blendTreeBlendTree81150.children = new ChildMotion[] {
				equipFromIdleWaterAnimatorState80994blendTreeBlendTree81150Child0,
				equipFromIdleWaterAnimatorState80994blendTreeBlendTree81150Child1,
				equipFromIdleWaterAnimatorState80994blendTreeBlendTree81150Child2,
				equipFromIdleWaterAnimatorState80994blendTreeBlendTree81150Child3,
				equipFromIdleWaterAnimatorState80994blendTreeBlendTree81150Child4
			};
			equipFromIdleWaterAnimatorState80994.motion = equipFromIdleWaterAnimatorState80994blendTreeBlendTree81150;
			equipFromIdleWaterAnimatorState80994.cycleOffset = 0f;
			equipFromIdleWaterAnimatorState80994.cycleOffsetParameterActive = false;
			equipFromIdleWaterAnimatorState80994.iKOnFeet = false;
			equipFromIdleWaterAnimatorState80994.mirror = false;
			equipFromIdleWaterAnimatorState80994.mirrorParameterActive = false;
			equipFromIdleWaterAnimatorState80994.speed = 2.75f;
			equipFromIdleWaterAnimatorState80994.speedParameterActive = false;
			equipFromIdleWaterAnimatorState80994.writeDefaultValues = true;

			var unequipFromAimWaterAnimatorState80996 = tridentAnimatorStateMachine80846.AddState("Unequip From Aim Water", new Vector3(384f, 168f, 0f));
			var unequipFromAimWaterAnimatorState80996blendTreeBlendTree81154 = new BlendTree();
			AssetDatabase.AddObjectToAsset(unequipFromAimWaterAnimatorState80996blendTreeBlendTree81154, animatorController);
			unequipFromAimWaterAnimatorState80996blendTreeBlendTree81154.hideFlags = HideFlags.HideInHierarchy;
			unequipFromAimWaterAnimatorState80996blendTreeBlendTree81154.blendParameter = "HorizontalMovement";
			unequipFromAimWaterAnimatorState80996blendTreeBlendTree81154.blendParameterY = "ForwardMovement";
			unequipFromAimWaterAnimatorState80996blendTreeBlendTree81154.blendType = BlendTreeType.FreeformCartesian2D;
			unequipFromAimWaterAnimatorState80996blendTreeBlendTree81154.maxThreshold = 1f;
			unequipFromAimWaterAnimatorState80996blendTreeBlendTree81154.minThreshold = 0f;
			unequipFromAimWaterAnimatorState80996blendTreeBlendTree81154.name = "Blend Tree";
			unequipFromAimWaterAnimatorState80996blendTreeBlendTree81154.useAutomaticThresholds = true;
			var unequipFromAimWaterAnimatorState80996blendTreeBlendTree81154Child0 =  new ChildMotion();
			unequipFromAimWaterAnimatorState80996blendTreeBlendTree81154Child0.motion = tridentUnequipFromAimLandAnimationClip64766;
			unequipFromAimWaterAnimatorState80996blendTreeBlendTree81154Child0.cycleOffset = 0f;
			unequipFromAimWaterAnimatorState80996blendTreeBlendTree81154Child0.directBlendParameter = "HorizontalMovement";
			unequipFromAimWaterAnimatorState80996blendTreeBlendTree81154Child0.mirror = false;
			unequipFromAimWaterAnimatorState80996blendTreeBlendTree81154Child0.position = new Vector2(0f, -1f);
			unequipFromAimWaterAnimatorState80996blendTreeBlendTree81154Child0.threshold = 0f;
			unequipFromAimWaterAnimatorState80996blendTreeBlendTree81154Child0.timeScale = 1f;
			var unequipFromAimWaterAnimatorState80996blendTreeBlendTree81154Child1 =  new ChildMotion();
			unequipFromAimWaterAnimatorState80996blendTreeBlendTree81154Child1.motion = tridentUnequipFromAimStrafeAnimationClip64772;
			unequipFromAimWaterAnimatorState80996blendTreeBlendTree81154Child1.cycleOffset = 0f;
			unequipFromAimWaterAnimatorState80996blendTreeBlendTree81154Child1.directBlendParameter = "HorizontalMovement";
			unequipFromAimWaterAnimatorState80996blendTreeBlendTree81154Child1.mirror = false;
			unequipFromAimWaterAnimatorState80996blendTreeBlendTree81154Child1.position = new Vector2(-1f, 0f);
			unequipFromAimWaterAnimatorState80996blendTreeBlendTree81154Child1.threshold = 0.25f;
			unequipFromAimWaterAnimatorState80996blendTreeBlendTree81154Child1.timeScale = 1f;
			var unequipFromAimWaterAnimatorState80996blendTreeBlendTree81154Child2 =  new ChildMotion();
			unequipFromAimWaterAnimatorState80996blendTreeBlendTree81154Child2.motion = tridentUnequipFromAimAnimationClip64760;
			unequipFromAimWaterAnimatorState80996blendTreeBlendTree81154Child2.cycleOffset = 0f;
			unequipFromAimWaterAnimatorState80996blendTreeBlendTree81154Child2.directBlendParameter = "HorizontalMovement";
			unequipFromAimWaterAnimatorState80996blendTreeBlendTree81154Child2.mirror = false;
			unequipFromAimWaterAnimatorState80996blendTreeBlendTree81154Child2.position = new Vector2(0f, 0f);
			unequipFromAimWaterAnimatorState80996blendTreeBlendTree81154Child2.threshold = 0.5f;
			unequipFromAimWaterAnimatorState80996blendTreeBlendTree81154Child2.timeScale = 1f;
			var unequipFromAimWaterAnimatorState80996blendTreeBlendTree81154Child3 =  new ChildMotion();
			unequipFromAimWaterAnimatorState80996blendTreeBlendTree81154Child3.motion = tridentUnequipFromAimStrafeAnimationClip64772;
			unequipFromAimWaterAnimatorState80996blendTreeBlendTree81154Child3.cycleOffset = 0f;
			unequipFromAimWaterAnimatorState80996blendTreeBlendTree81154Child3.directBlendParameter = "HorizontalMovement";
			unequipFromAimWaterAnimatorState80996blendTreeBlendTree81154Child3.mirror = false;
			unequipFromAimWaterAnimatorState80996blendTreeBlendTree81154Child3.position = new Vector2(1f, 0f);
			unequipFromAimWaterAnimatorState80996blendTreeBlendTree81154Child3.threshold = 0.75f;
			unequipFromAimWaterAnimatorState80996blendTreeBlendTree81154Child3.timeScale = 1f;
			var unequipFromAimWaterAnimatorState80996blendTreeBlendTree81154Child4 =  new ChildMotion();
			unequipFromAimWaterAnimatorState80996blendTreeBlendTree81154Child4.motion = tridentUnequipFromAimAnimationClip64760;
			unequipFromAimWaterAnimatorState80996blendTreeBlendTree81154Child4.cycleOffset = 0f;
			unequipFromAimWaterAnimatorState80996blendTreeBlendTree81154Child4.directBlendParameter = "HorizontalMovement";
			unequipFromAimWaterAnimatorState80996blendTreeBlendTree81154Child4.mirror = false;
			unequipFromAimWaterAnimatorState80996blendTreeBlendTree81154Child4.position = new Vector2(0f, 1f);
			unequipFromAimWaterAnimatorState80996blendTreeBlendTree81154Child4.threshold = 1f;
			unequipFromAimWaterAnimatorState80996blendTreeBlendTree81154Child4.timeScale = 1f;
			unequipFromAimWaterAnimatorState80996blendTreeBlendTree81154.children = new ChildMotion[] {
				unequipFromAimWaterAnimatorState80996blendTreeBlendTree81154Child0,
				unequipFromAimWaterAnimatorState80996blendTreeBlendTree81154Child1,
				unequipFromAimWaterAnimatorState80996blendTreeBlendTree81154Child2,
				unequipFromAimWaterAnimatorState80996blendTreeBlendTree81154Child3,
				unequipFromAimWaterAnimatorState80996blendTreeBlendTree81154Child4
			};
			unequipFromAimWaterAnimatorState80996.motion = unequipFromAimWaterAnimatorState80996blendTreeBlendTree81154;
			unequipFromAimWaterAnimatorState80996.cycleOffset = 0f;
			unequipFromAimWaterAnimatorState80996.cycleOffsetParameterActive = false;
			unequipFromAimWaterAnimatorState80996.iKOnFeet = false;
			unequipFromAimWaterAnimatorState80996.mirror = false;
			unequipFromAimWaterAnimatorState80996.mirrorParameterActive = false;
			unequipFromAimWaterAnimatorState80996.speed = 2.25f;
			unequipFromAimWaterAnimatorState80996.speedParameterActive = false;
			unequipFromAimWaterAnimatorState80996.writeDefaultValues = true;

			var unequipFromIdleWaterAnimatorState80992 = tridentAnimatorStateMachine80846.AddState("Unequip From Idle Water", new Vector3(384f, 288f, 0f));
			var unequipFromIdleWaterAnimatorState80992blendTreeBlendTree81158 = new BlendTree();
			AssetDatabase.AddObjectToAsset(unequipFromIdleWaterAnimatorState80992blendTreeBlendTree81158, animatorController);
			unequipFromIdleWaterAnimatorState80992blendTreeBlendTree81158.hideFlags = HideFlags.HideInHierarchy;
			unequipFromIdleWaterAnimatorState80992blendTreeBlendTree81158.blendParameter = "HorizontalMovement";
			unequipFromIdleWaterAnimatorState80992blendTreeBlendTree81158.blendParameterY = "ForwardMovement";
			unequipFromIdleWaterAnimatorState80992blendTreeBlendTree81158.blendType = BlendTreeType.FreeformCartesian2D;
			unequipFromIdleWaterAnimatorState80992blendTreeBlendTree81158.maxThreshold = 1f;
			unequipFromIdleWaterAnimatorState80992blendTreeBlendTree81158.minThreshold = 0f;
			unequipFromIdleWaterAnimatorState80992blendTreeBlendTree81158.name = "Blend Tree";
			unequipFromIdleWaterAnimatorState80992blendTreeBlendTree81158.useAutomaticThresholds = true;
			var unequipFromIdleWaterAnimatorState80992blendTreeBlendTree81158Child0 =  new ChildMotion();
			unequipFromIdleWaterAnimatorState80992blendTreeBlendTree81158Child0.motion = tridentUnequipFromIdleLandAnimationClip64784;
			unequipFromIdleWaterAnimatorState80992blendTreeBlendTree81158Child0.cycleOffset = 0f;
			unequipFromIdleWaterAnimatorState80992blendTreeBlendTree81158Child0.directBlendParameter = "HorizontalMovement";
			unequipFromIdleWaterAnimatorState80992blendTreeBlendTree81158Child0.mirror = false;
			unequipFromIdleWaterAnimatorState80992blendTreeBlendTree81158Child0.position = new Vector2(0f, -1f);
			unequipFromIdleWaterAnimatorState80992blendTreeBlendTree81158Child0.threshold = 0f;
			unequipFromIdleWaterAnimatorState80992blendTreeBlendTree81158Child0.timeScale = 1f;
			var unequipFromIdleWaterAnimatorState80992blendTreeBlendTree81158Child1 =  new ChildMotion();
			unequipFromIdleWaterAnimatorState80992blendTreeBlendTree81158Child1.motion = tridentUnequipFromIdleStrafeAnimationClip64790;
			unequipFromIdleWaterAnimatorState80992blendTreeBlendTree81158Child1.cycleOffset = 0f;
			unequipFromIdleWaterAnimatorState80992blendTreeBlendTree81158Child1.directBlendParameter = "HorizontalMovement";
			unequipFromIdleWaterAnimatorState80992blendTreeBlendTree81158Child1.mirror = false;
			unequipFromIdleWaterAnimatorState80992blendTreeBlendTree81158Child1.position = new Vector2(-1f, 0f);
			unequipFromIdleWaterAnimatorState80992blendTreeBlendTree81158Child1.threshold = 0.25f;
			unequipFromIdleWaterAnimatorState80992blendTreeBlendTree81158Child1.timeScale = 1f;
			var unequipFromIdleWaterAnimatorState80992blendTreeBlendTree81158Child2 =  new ChildMotion();
			unequipFromIdleWaterAnimatorState80992blendTreeBlendTree81158Child2.motion = tridentUnequipFromIdleAnimationClip64778;
			unequipFromIdleWaterAnimatorState80992blendTreeBlendTree81158Child2.cycleOffset = 0f;
			unequipFromIdleWaterAnimatorState80992blendTreeBlendTree81158Child2.directBlendParameter = "HorizontalMovement";
			unequipFromIdleWaterAnimatorState80992blendTreeBlendTree81158Child2.mirror = false;
			unequipFromIdleWaterAnimatorState80992blendTreeBlendTree81158Child2.position = new Vector2(0f, 0f);
			unequipFromIdleWaterAnimatorState80992blendTreeBlendTree81158Child2.threshold = 0.5f;
			unequipFromIdleWaterAnimatorState80992blendTreeBlendTree81158Child2.timeScale = 1f;
			var unequipFromIdleWaterAnimatorState80992blendTreeBlendTree81158Child3 =  new ChildMotion();
			unequipFromIdleWaterAnimatorState80992blendTreeBlendTree81158Child3.motion = tridentUnequipFromIdleStrafeAnimationClip64790;
			unequipFromIdleWaterAnimatorState80992blendTreeBlendTree81158Child3.cycleOffset = 0f;
			unequipFromIdleWaterAnimatorState80992blendTreeBlendTree81158Child3.directBlendParameter = "HorizontalMovement";
			unequipFromIdleWaterAnimatorState80992blendTreeBlendTree81158Child3.mirror = false;
			unequipFromIdleWaterAnimatorState80992blendTreeBlendTree81158Child3.position = new Vector2(1f, 0f);
			unequipFromIdleWaterAnimatorState80992blendTreeBlendTree81158Child3.threshold = 0.75f;
			unequipFromIdleWaterAnimatorState80992blendTreeBlendTree81158Child3.timeScale = 1f;
			var unequipFromIdleWaterAnimatorState80992blendTreeBlendTree81158Child4 =  new ChildMotion();
			unequipFromIdleWaterAnimatorState80992blendTreeBlendTree81158Child4.motion = tridentUnequipFromIdleAnimationClip64778;
			unequipFromIdleWaterAnimatorState80992blendTreeBlendTree81158Child4.cycleOffset = 0f;
			unequipFromIdleWaterAnimatorState80992blendTreeBlendTree81158Child4.directBlendParameter = "HorizontalMovement";
			unequipFromIdleWaterAnimatorState80992blendTreeBlendTree81158Child4.mirror = false;
			unequipFromIdleWaterAnimatorState80992blendTreeBlendTree81158Child4.position = new Vector2(0f, 1f);
			unequipFromIdleWaterAnimatorState80992blendTreeBlendTree81158Child4.threshold = 1f;
			unequipFromIdleWaterAnimatorState80992blendTreeBlendTree81158Child4.timeScale = 1f;
			unequipFromIdleWaterAnimatorState80992blendTreeBlendTree81158.children = new ChildMotion[] {
				unequipFromIdleWaterAnimatorState80992blendTreeBlendTree81158Child0,
				unequipFromIdleWaterAnimatorState80992blendTreeBlendTree81158Child1,
				unequipFromIdleWaterAnimatorState80992blendTreeBlendTree81158Child2,
				unequipFromIdleWaterAnimatorState80992blendTreeBlendTree81158Child3,
				unequipFromIdleWaterAnimatorState80992blendTreeBlendTree81158Child4
			};
			unequipFromIdleWaterAnimatorState80992.motion = unequipFromIdleWaterAnimatorState80992blendTreeBlendTree81158;
			unequipFromIdleWaterAnimatorState80992.cycleOffset = 0f;
			unequipFromIdleWaterAnimatorState80992.cycleOffsetParameterActive = false;
			unequipFromIdleWaterAnimatorState80992.iKOnFeet = false;
			unequipFromIdleWaterAnimatorState80992.mirror = false;
			unequipFromIdleWaterAnimatorState80992.mirrorParameterActive = false;
			unequipFromIdleWaterAnimatorState80992.speed = 2.25f;
			unequipFromIdleWaterAnimatorState80992.speedParameterActive = false;
			unequipFromIdleWaterAnimatorState80992.writeDefaultValues = true;

			var idleWaterAnimatorState81000 = tridentAnimatorStateMachine80846.AddState("Idle Water", new Vector3(384f, 48f, 0f));
			var idleWaterAnimatorState81000blendTreeBlendTree81164 = new BlendTree();
			AssetDatabase.AddObjectToAsset(idleWaterAnimatorState81000blendTreeBlendTree81164, animatorController);
			idleWaterAnimatorState81000blendTreeBlendTree81164.hideFlags = HideFlags.HideInHierarchy;
			idleWaterAnimatorState81000blendTreeBlendTree81164.blendParameter = "HorizontalMovement";
			idleWaterAnimatorState81000blendTreeBlendTree81164.blendParameterY = "ForwardMovement";
			idleWaterAnimatorState81000blendTreeBlendTree81164.blendType = BlendTreeType.FreeformCartesian2D;
			idleWaterAnimatorState81000blendTreeBlendTree81164.maxThreshold = 1f;
			idleWaterAnimatorState81000blendTreeBlendTree81164.minThreshold = 0f;
			idleWaterAnimatorState81000blendTreeBlendTree81164.name = "Blend Tree";
			idleWaterAnimatorState81000blendTreeBlendTree81164.useAutomaticThresholds = true;
			var idleWaterAnimatorState81000blendTreeBlendTree81164Child0 =  new ChildMotion();
			idleWaterAnimatorState81000blendTreeBlendTree81164Child0.motion = tridentIdleLandAnimationClip64748;
			idleWaterAnimatorState81000blendTreeBlendTree81164Child0.cycleOffset = 0f;
			idleWaterAnimatorState81000blendTreeBlendTree81164Child0.directBlendParameter = "HorizontalMovement";
			idleWaterAnimatorState81000blendTreeBlendTree81164Child0.mirror = false;
			idleWaterAnimatorState81000blendTreeBlendTree81164Child0.position = new Vector2(0f, -1f);
			idleWaterAnimatorState81000blendTreeBlendTree81164Child0.threshold = 0f;
			idleWaterAnimatorState81000blendTreeBlendTree81164Child0.timeScale = 1f;
			var idleWaterAnimatorState81000blendTreeBlendTree81164Child1 =  new ChildMotion();
			idleWaterAnimatorState81000blendTreeBlendTree81164Child1.motion = tridentIdleStrafeAnimationClip64754;
			idleWaterAnimatorState81000blendTreeBlendTree81164Child1.cycleOffset = 0f;
			idleWaterAnimatorState81000blendTreeBlendTree81164Child1.directBlendParameter = "HorizontalMovement";
			idleWaterAnimatorState81000blendTreeBlendTree81164Child1.mirror = false;
			idleWaterAnimatorState81000blendTreeBlendTree81164Child1.position = new Vector2(-1f, 0f);
			idleWaterAnimatorState81000blendTreeBlendTree81164Child1.threshold = 0.25f;
			idleWaterAnimatorState81000blendTreeBlendTree81164Child1.timeScale = 1f;
			var idleWaterAnimatorState81000blendTreeBlendTree81164Child2 =  new ChildMotion();
			idleWaterAnimatorState81000blendTreeBlendTree81164Child2.motion = tridentIdleAnimationClip64742;
			idleWaterAnimatorState81000blendTreeBlendTree81164Child2.cycleOffset = 0f;
			idleWaterAnimatorState81000blendTreeBlendTree81164Child2.directBlendParameter = "HorizontalMovement";
			idleWaterAnimatorState81000blendTreeBlendTree81164Child2.mirror = false;
			idleWaterAnimatorState81000blendTreeBlendTree81164Child2.position = new Vector2(0f, 0f);
			idleWaterAnimatorState81000blendTreeBlendTree81164Child2.threshold = 0.5f;
			idleWaterAnimatorState81000blendTreeBlendTree81164Child2.timeScale = 1f;
			var idleWaterAnimatorState81000blendTreeBlendTree81164Child3 =  new ChildMotion();
			idleWaterAnimatorState81000blendTreeBlendTree81164Child3.motion = tridentIdleStrafeAnimationClip64754;
			idleWaterAnimatorState81000blendTreeBlendTree81164Child3.cycleOffset = 0.5f;
			idleWaterAnimatorState81000blendTreeBlendTree81164Child3.directBlendParameter = "HorizontalMovement";
			idleWaterAnimatorState81000blendTreeBlendTree81164Child3.mirror = true;
			idleWaterAnimatorState81000blendTreeBlendTree81164Child3.position = new Vector2(1f, 0f);
			idleWaterAnimatorState81000blendTreeBlendTree81164Child3.threshold = 0.75f;
			idleWaterAnimatorState81000blendTreeBlendTree81164Child3.timeScale = 1f;
			var idleWaterAnimatorState81000blendTreeBlendTree81164Child4 =  new ChildMotion();
			idleWaterAnimatorState81000blendTreeBlendTree81164Child4.motion = tridentIdleAnimationClip64742;
			idleWaterAnimatorState81000blendTreeBlendTree81164Child4.cycleOffset = 0f;
			idleWaterAnimatorState81000blendTreeBlendTree81164Child4.directBlendParameter = "HorizontalMovement";
			idleWaterAnimatorState81000blendTreeBlendTree81164Child4.mirror = false;
			idleWaterAnimatorState81000blendTreeBlendTree81164Child4.position = new Vector2(0f, 1f);
			idleWaterAnimatorState81000blendTreeBlendTree81164Child4.threshold = 1f;
			idleWaterAnimatorState81000blendTreeBlendTree81164Child4.timeScale = 1f;
			idleWaterAnimatorState81000blendTreeBlendTree81164.children = new ChildMotion[] {
				idleWaterAnimatorState81000blendTreeBlendTree81164Child0,
				idleWaterAnimatorState81000blendTreeBlendTree81164Child1,
				idleWaterAnimatorState81000blendTreeBlendTree81164Child2,
				idleWaterAnimatorState81000blendTreeBlendTree81164Child3,
				idleWaterAnimatorState81000blendTreeBlendTree81164Child4
			};
			idleWaterAnimatorState81000.motion = idleWaterAnimatorState81000blendTreeBlendTree81164;
			idleWaterAnimatorState81000.cycleOffset = 0f;
			idleWaterAnimatorState81000.cycleOffsetParameterActive = false;
			idleWaterAnimatorState81000.iKOnFeet = true;
			idleWaterAnimatorState81000.mirror = false;
			idleWaterAnimatorState81000.mirrorParameterActive = false;
			idleWaterAnimatorState81000.speed = 1f;
			idleWaterAnimatorState81000.speedParameterActive = false;
			idleWaterAnimatorState81000.writeDefaultValues = true;

			var dropWaterLandAnimatorState81002 = tridentAnimatorStateMachine80846.AddState("Drop Water Land", new Vector3(384f, -12f, 0f));
			dropWaterLandAnimatorState81002.motion = tridentDropLandAnimationClip64694;
			dropWaterLandAnimatorState81002.cycleOffset = 0f;
			dropWaterLandAnimatorState81002.cycleOffsetParameterActive = false;
			dropWaterLandAnimatorState81002.iKOnFeet = false;
			dropWaterLandAnimatorState81002.mirror = false;
			dropWaterLandAnimatorState81002.mirrorParameterActive = false;
			dropWaterLandAnimatorState81002.speed = 1f;
			dropWaterLandAnimatorState81002.speedParameterActive = false;
			dropWaterLandAnimatorState81002.writeDefaultValues = true;

			var unequipFromIdleLandAnimatorState81004 = tridentAnimatorStateMachine80846.AddState("Unequip From Idle Land", new Vector3(384f, -72f, 0f));
			unequipFromIdleLandAnimatorState81004.motion = tridentUnequipFromIdleLandAnimationClip64784;
			unequipFromIdleLandAnimatorState81004.cycleOffset = 0f;
			unequipFromIdleLandAnimatorState81004.cycleOffsetParameterActive = false;
			unequipFromIdleLandAnimatorState81004.iKOnFeet = false;
			unequipFromIdleLandAnimatorState81004.mirror = false;
			unequipFromIdleLandAnimatorState81004.mirrorParameterActive = false;
			unequipFromIdleLandAnimatorState81004.speed = 2.25f;
			unequipFromIdleLandAnimatorState81004.speedParameterActive = false;
			unequipFromIdleLandAnimatorState81004.writeDefaultValues = true;

			var equipFromIdleLandAnimatorState81006 = tridentAnimatorStateMachine80846.AddState("Equip From Idle Land", new Vector3(384f, -132f, 0f));
			equipFromIdleLandAnimatorState81006.motion = tridentEquipFromIdleLandAnimationClip64730;
			equipFromIdleLandAnimatorState81006.cycleOffset = 0f;
			equipFromIdleLandAnimatorState81006.cycleOffsetParameterActive = false;
			equipFromIdleLandAnimatorState81006.iKOnFeet = false;
			equipFromIdleLandAnimatorState81006.mirror = false;
			equipFromIdleLandAnimatorState81006.mirrorParameterActive = false;
			equipFromIdleLandAnimatorState81006.speed = 2.75f;
			equipFromIdleLandAnimatorState81006.speedParameterActive = false;
			equipFromIdleLandAnimatorState81006.writeDefaultValues = true;

			var unequipFromAimLandAnimatorState81008 = tridentAnimatorStateMachine80846.AddState("Unequip From Aim Land", new Vector3(384f, -192f, 0f));
			unequipFromAimLandAnimatorState81008.motion = tridentUnequipFromAimLandAnimationClip64766;
			unequipFromAimLandAnimatorState81008.cycleOffset = 0f;
			unequipFromAimLandAnimatorState81008.cycleOffsetParameterActive = false;
			unequipFromAimLandAnimatorState81008.iKOnFeet = false;
			unequipFromAimLandAnimatorState81008.mirror = false;
			unequipFromAimLandAnimatorState81008.mirrorParameterActive = false;
			unequipFromAimLandAnimatorState81008.speed = 2.25f;
			unequipFromAimLandAnimatorState81008.speedParameterActive = false;
			unequipFromAimLandAnimatorState81008.writeDefaultValues = true;

			var equipFromAimLandAnimatorState81010 = tridentAnimatorStateMachine80846.AddState("Equip From Aim Land", new Vector3(384f, -252f, 0f));
			equipFromAimLandAnimatorState81010.motion = tridentEquipFromAimLandAnimationClip64712;
			equipFromAimLandAnimatorState81010.cycleOffset = 0f;
			equipFromAimLandAnimatorState81010.cycleOffsetParameterActive = false;
			equipFromAimLandAnimatorState81010.iKOnFeet = false;
			equipFromAimLandAnimatorState81010.mirror = false;
			equipFromAimLandAnimatorState81010.mirrorParameterActive = false;
			equipFromAimLandAnimatorState81010.speed = 2.75f;
			equipFromAimLandAnimatorState81010.speedParameterActive = false;
			equipFromAimLandAnimatorState81010.writeDefaultValues = true;

			var idleLandAnimatorState81012 = tridentAnimatorStateMachine80846.AddState("Idle Land", new Vector3(384f, -312f, 0f));
			idleLandAnimatorState81012.motion = tridentIdleLandAnimationClip64748;
			idleLandAnimatorState81012.cycleOffset = 0f;
			idleLandAnimatorState81012.cycleOffsetParameterActive = false;
			idleLandAnimatorState81012.iKOnFeet = true;
			idleLandAnimatorState81012.mirror = false;
			idleLandAnimatorState81012.mirrorParameterActive = false;
			idleLandAnimatorState81012.speed = 1f;
			idleLandAnimatorState81012.speedParameterActive = false;
			idleLandAnimatorState81012.writeDefaultValues = true;

			// State Machine Defaults.
			tridentAnimatorStateMachine80846.anyStatePosition = new Vector3(50f, 20f, 0f);
			tridentAnimatorStateMachine80846.defaultState = idleWaterAnimatorState81000;
			tridentAnimatorStateMachine80846.entryPosition = new Vector3(50f, 120f, 0f);
			tridentAnimatorStateMachine80846.exitPosition = new Vector3(800f, 120f, 0f);
			tridentAnimatorStateMachine80846.parentStateMachinePosition = new Vector3(800f, 20f, 0f);

			// State Transitions.
			var animatorStateTransition81140 = dropWaterAnimatorState80990.AddExitTransition();
			animatorStateTransition81140.canTransitionToSelf = true;
			animatorStateTransition81140.duration = 0.1f;
			animatorStateTransition81140.exitTime = 0.9f;
			animatorStateTransition81140.hasExitTime = true;
			animatorStateTransition81140.hasFixedDuration = true;
			animatorStateTransition81140.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition81140.offset = 0f;
			animatorStateTransition81140.orderedInterruption = true;
			animatorStateTransition81140.isExit = true;
			animatorStateTransition81140.mute = false;
			animatorStateTransition81140.solo = false;

			var animatorStateTransition81144 = equipFromAimWaterAnimatorState80998.AddExitTransition();
			animatorStateTransition81144.canTransitionToSelf = true;
			animatorStateTransition81144.duration = 0.2f;
			animatorStateTransition81144.exitTime = 0.85f;
			animatorStateTransition81144.hasExitTime = false;
			animatorStateTransition81144.hasFixedDuration = true;
			animatorStateTransition81144.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition81144.offset = 0f;
			animatorStateTransition81144.orderedInterruption = true;
			animatorStateTransition81144.isExit = true;
			animatorStateTransition81144.mute = false;
			animatorStateTransition81144.solo = false;
			animatorStateTransition81144.AddCondition(AnimatorConditionMode.NotEqual, 4f, "Slot0ItemStateIndex");

			var animatorStateTransition81148 = equipFromIdleWaterAnimatorState80994.AddExitTransition();
			animatorStateTransition81148.canTransitionToSelf = true;
			animatorStateTransition81148.duration = 0.2f;
			animatorStateTransition81148.exitTime = 0.75f;
			animatorStateTransition81148.hasExitTime = false;
			animatorStateTransition81148.hasFixedDuration = true;
			animatorStateTransition81148.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition81148.offset = 0f;
			animatorStateTransition81148.orderedInterruption = true;
			animatorStateTransition81148.isExit = true;
			animatorStateTransition81148.mute = false;
			animatorStateTransition81148.solo = false;
			animatorStateTransition81148.AddCondition(AnimatorConditionMode.NotEqual, 4f, "Slot0ItemStateIndex");

			var animatorStateTransition81152 = unequipFromAimWaterAnimatorState80996.AddExitTransition();
			animatorStateTransition81152.canTransitionToSelf = true;
			animatorStateTransition81152.duration = 0.2f;
			animatorStateTransition81152.exitTime = 0.8f;
			animatorStateTransition81152.hasExitTime = false;
			animatorStateTransition81152.hasFixedDuration = true;
			animatorStateTransition81152.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition81152.offset = 0f;
			animatorStateTransition81152.orderedInterruption = true;
			animatorStateTransition81152.isExit = true;
			animatorStateTransition81152.mute = false;
			animatorStateTransition81152.solo = false;
			animatorStateTransition81152.AddCondition(AnimatorConditionMode.NotEqual, 5f, "Slot0ItemStateIndex");

			var animatorStateTransition81156 = unequipFromIdleWaterAnimatorState80992.AddExitTransition();
			animatorStateTransition81156.canTransitionToSelf = true;
			animatorStateTransition81156.duration = 0.2f;
			animatorStateTransition81156.exitTime = 0.75f;
			animatorStateTransition81156.hasExitTime = false;
			animatorStateTransition81156.hasFixedDuration = true;
			animatorStateTransition81156.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition81156.offset = 0f;
			animatorStateTransition81156.orderedInterruption = true;
			animatorStateTransition81156.isExit = true;
			animatorStateTransition81156.mute = false;
			animatorStateTransition81156.solo = false;
			animatorStateTransition81156.AddCondition(AnimatorConditionMode.NotEqual, 5f, "Slot0ItemStateIndex");

			var animatorStateTransition81160 = idleWaterAnimatorState81000.AddExitTransition();
			animatorStateTransition81160.canTransitionToSelf = true;
			animatorStateTransition81160.duration = 0.15f;
			animatorStateTransition81160.exitTime = 0.7f;
			animatorStateTransition81160.hasExitTime = false;
			animatorStateTransition81160.hasFixedDuration = true;
			animatorStateTransition81160.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition81160.offset = 0f;
			animatorStateTransition81160.orderedInterruption = true;
			animatorStateTransition81160.isExit = true;
			animatorStateTransition81160.mute = false;
			animatorStateTransition81160.solo = false;
			animatorStateTransition81160.AddCondition(AnimatorConditionMode.NotEqual, 26f, "Slot0ItemID");

			var animatorStateTransition81162 = idleWaterAnimatorState81000.AddExitTransition();
			animatorStateTransition81162.canTransitionToSelf = true;
			animatorStateTransition81162.duration = 0.15f;
			animatorStateTransition81162.exitTime = 0.7f;
			animatorStateTransition81162.hasExitTime = false;
			animatorStateTransition81162.hasFixedDuration = true;
			animatorStateTransition81162.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition81162.offset = 0f;
			animatorStateTransition81162.orderedInterruption = true;
			animatorStateTransition81162.isExit = true;
			animatorStateTransition81162.mute = false;
			animatorStateTransition81162.solo = false;
			animatorStateTransition81162.AddCondition(AnimatorConditionMode.NotEqual, 0f, "Slot0ItemStateIndex");

			var animatorStateTransition81166 = dropWaterLandAnimatorState81002.AddExitTransition();
			animatorStateTransition81166.canTransitionToSelf = true;
			animatorStateTransition81166.duration = 0.1f;
			animatorStateTransition81166.exitTime = 0.9f;
			animatorStateTransition81166.hasExitTime = true;
			animatorStateTransition81166.hasFixedDuration = true;
			animatorStateTransition81166.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition81166.offset = 0f;
			animatorStateTransition81166.orderedInterruption = true;
			animatorStateTransition81166.isExit = true;
			animatorStateTransition81166.mute = false;
			animatorStateTransition81166.solo = false;

			var animatorStateTransition81168 = unequipFromIdleLandAnimatorState81004.AddExitTransition();
			animatorStateTransition81168.canTransitionToSelf = true;
			animatorStateTransition81168.duration = 0.2f;
			animatorStateTransition81168.exitTime = 0.75f;
			animatorStateTransition81168.hasExitTime = false;
			animatorStateTransition81168.hasFixedDuration = true;
			animatorStateTransition81168.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition81168.offset = 0f;
			animatorStateTransition81168.orderedInterruption = true;
			animatorStateTransition81168.isExit = true;
			animatorStateTransition81168.mute = false;
			animatorStateTransition81168.solo = false;
			animatorStateTransition81168.AddCondition(AnimatorConditionMode.NotEqual, 5f, "Slot0ItemStateIndex");

			var animatorStateTransition81170 = equipFromIdleLandAnimatorState81006.AddExitTransition();
			animatorStateTransition81170.canTransitionToSelf = true;
			animatorStateTransition81170.duration = 0.2f;
			animatorStateTransition81170.exitTime = 0.75f;
			animatorStateTransition81170.hasExitTime = false;
			animatorStateTransition81170.hasFixedDuration = true;
			animatorStateTransition81170.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition81170.offset = 0f;
			animatorStateTransition81170.orderedInterruption = true;
			animatorStateTransition81170.isExit = true;
			animatorStateTransition81170.mute = false;
			animatorStateTransition81170.solo = false;
			animatorStateTransition81170.AddCondition(AnimatorConditionMode.NotEqual, 4f, "Slot0ItemStateIndex");

			var animatorStateTransition81172 = unequipFromAimLandAnimatorState81008.AddExitTransition();
			animatorStateTransition81172.canTransitionToSelf = true;
			animatorStateTransition81172.duration = 0.2f;
			animatorStateTransition81172.exitTime = 0.8f;
			animatorStateTransition81172.hasExitTime = false;
			animatorStateTransition81172.hasFixedDuration = true;
			animatorStateTransition81172.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition81172.offset = 0f;
			animatorStateTransition81172.orderedInterruption = true;
			animatorStateTransition81172.isExit = true;
			animatorStateTransition81172.mute = false;
			animatorStateTransition81172.solo = false;
			animatorStateTransition81172.AddCondition(AnimatorConditionMode.NotEqual, 5f, "Slot0ItemStateIndex");

			var animatorStateTransition81174 = equipFromAimLandAnimatorState81010.AddExitTransition();
			animatorStateTransition81174.canTransitionToSelf = true;
			animatorStateTransition81174.duration = 0.2f;
			animatorStateTransition81174.exitTime = 0.85f;
			animatorStateTransition81174.hasExitTime = false;
			animatorStateTransition81174.hasFixedDuration = true;
			animatorStateTransition81174.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition81174.offset = 0f;
			animatorStateTransition81174.orderedInterruption = true;
			animatorStateTransition81174.isExit = true;
			animatorStateTransition81174.mute = false;
			animatorStateTransition81174.solo = false;
			animatorStateTransition81174.AddCondition(AnimatorConditionMode.NotEqual, 4f, "Slot0ItemStateIndex");

			var animatorStateTransition81176 = idleLandAnimatorState81012.AddExitTransition();
			animatorStateTransition81176.canTransitionToSelf = true;
			animatorStateTransition81176.duration = 0.15f;
			animatorStateTransition81176.exitTime = 0.7f;
			animatorStateTransition81176.hasExitTime = false;
			animatorStateTransition81176.hasFixedDuration = true;
			animatorStateTransition81176.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition81176.offset = 0f;
			animatorStateTransition81176.orderedInterruption = true;
			animatorStateTransition81176.isExit = true;
			animatorStateTransition81176.mute = false;
			animatorStateTransition81176.solo = false;
			animatorStateTransition81176.AddCondition(AnimatorConditionMode.NotEqual, 26f, "Slot0ItemID");

			var animatorStateTransition81178 = idleLandAnimatorState81012.AddExitTransition();
			animatorStateTransition81178.canTransitionToSelf = true;
			animatorStateTransition81178.duration = 0.15f;
			animatorStateTransition81178.exitTime = 0.7f;
			animatorStateTransition81178.hasExitTime = false;
			animatorStateTransition81178.hasFixedDuration = true;
			animatorStateTransition81178.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition81178.offset = 0f;
			animatorStateTransition81178.orderedInterruption = true;
			animatorStateTransition81178.isExit = true;
			animatorStateTransition81178.mute = false;
			animatorStateTransition81178.solo = false;
			animatorStateTransition81178.AddCondition(AnimatorConditionMode.NotEqual, 0f, "Slot0ItemStateIndex");


			// State Machine Transitions.
			var animatorStateTransition80902 = baseStateMachine1709680398.AddAnyStateTransition(dropWaterAnimatorState80990);
			animatorStateTransition80902.canTransitionToSelf = false;
			animatorStateTransition80902.duration = 0.1f;
			animatorStateTransition80902.exitTime = 0.75f;
			animatorStateTransition80902.hasExitTime = false;
			animatorStateTransition80902.hasFixedDuration = true;
			animatorStateTransition80902.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition80902.offset = 0f;
			animatorStateTransition80902.orderedInterruption = true;
			animatorStateTransition80902.isExit = false;
			animatorStateTransition80902.mute = false;
			animatorStateTransition80902.solo = false;
			animatorStateTransition80902.AddCondition(AnimatorConditionMode.If, 0f, "Slot0ItemStateIndexChange");
			animatorStateTransition80902.AddCondition(AnimatorConditionMode.Equals, 26f, "Slot0ItemID");
			animatorStateTransition80902.AddCondition(AnimatorConditionMode.Equals, 6f, "Slot0ItemStateIndex");
			animatorStateTransition80902.AddCondition(AnimatorConditionMode.If, 0f, "Moving");
			animatorStateTransition80902.AddCondition(AnimatorConditionMode.Equals, 301f, "AbilityIndex");
			animatorStateTransition80902.AddCondition(AnimatorConditionMode.NotEqual, 1f, "AbilityIntData");

			var animatorStateTransition80904 = baseStateMachine1709680398.AddAnyStateTransition(unequipFromIdleWaterAnimatorState80992);
			animatorStateTransition80904.canTransitionToSelf = false;
			animatorStateTransition80904.duration = 0.15f;
			animatorStateTransition80904.exitTime = 0.75f;
			animatorStateTransition80904.hasExitTime = false;
			animatorStateTransition80904.hasFixedDuration = true;
			animatorStateTransition80904.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition80904.offset = 0f;
			animatorStateTransition80904.orderedInterruption = true;
			animatorStateTransition80904.isExit = false;
			animatorStateTransition80904.mute = false;
			animatorStateTransition80904.solo = false;
			animatorStateTransition80904.AddCondition(AnimatorConditionMode.If, 0f, "Slot0ItemStateIndexChange");
			animatorStateTransition80904.AddCondition(AnimatorConditionMode.Equals, 26f, "Slot0ItemID");
			animatorStateTransition80904.AddCondition(AnimatorConditionMode.Equals, 5f, "Slot0ItemStateIndex");
			animatorStateTransition80904.AddCondition(AnimatorConditionMode.If, 0f, "Moving");
			animatorStateTransition80904.AddCondition(AnimatorConditionMode.IfNot, 0f, "Aiming");
			animatorStateTransition80904.AddCondition(AnimatorConditionMode.Equals, 301f, "AbilityIndex");
			animatorStateTransition80904.AddCondition(AnimatorConditionMode.NotEqual, 1f, "AbilityIntData");

			var animatorStateTransition80906 = baseStateMachine1709680398.AddAnyStateTransition(equipFromIdleWaterAnimatorState80994);
			animatorStateTransition80906.canTransitionToSelf = false;
			animatorStateTransition80906.duration = 0.15f;
			animatorStateTransition80906.exitTime = 0.75f;
			animatorStateTransition80906.hasExitTime = false;
			animatorStateTransition80906.hasFixedDuration = true;
			animatorStateTransition80906.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition80906.offset = 0f;
			animatorStateTransition80906.orderedInterruption = true;
			animatorStateTransition80906.isExit = false;
			animatorStateTransition80906.mute = false;
			animatorStateTransition80906.solo = false;
			animatorStateTransition80906.AddCondition(AnimatorConditionMode.If, 0f, "Slot0ItemStateIndexChange");
			animatorStateTransition80906.AddCondition(AnimatorConditionMode.Equals, 26f, "Slot0ItemID");
			animatorStateTransition80906.AddCondition(AnimatorConditionMode.Equals, 4f, "Slot0ItemStateIndex");
			animatorStateTransition80906.AddCondition(AnimatorConditionMode.If, 0f, "Moving");
			animatorStateTransition80906.AddCondition(AnimatorConditionMode.IfNot, 0f, "Aiming");
			animatorStateTransition80906.AddCondition(AnimatorConditionMode.Equals, 301f, "AbilityIndex");
			animatorStateTransition80906.AddCondition(AnimatorConditionMode.NotEqual, 1f, "AbilityIntData");

			var animatorStateTransition80908 = baseStateMachine1709680398.AddAnyStateTransition(unequipFromAimWaterAnimatorState80996);
			animatorStateTransition80908.canTransitionToSelf = false;
			animatorStateTransition80908.duration = 0.15f;
			animatorStateTransition80908.exitTime = 0.75f;
			animatorStateTransition80908.hasExitTime = false;
			animatorStateTransition80908.hasFixedDuration = true;
			animatorStateTransition80908.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition80908.offset = 0f;
			animatorStateTransition80908.orderedInterruption = true;
			animatorStateTransition80908.isExit = false;
			animatorStateTransition80908.mute = false;
			animatorStateTransition80908.solo = false;
			animatorStateTransition80908.AddCondition(AnimatorConditionMode.If, 0f, "Slot0ItemStateIndexChange");
			animatorStateTransition80908.AddCondition(AnimatorConditionMode.Equals, 26f, "Slot0ItemID");
			animatorStateTransition80908.AddCondition(AnimatorConditionMode.Equals, 5f, "Slot0ItemStateIndex");
			animatorStateTransition80908.AddCondition(AnimatorConditionMode.If, 0f, "Moving");
			animatorStateTransition80908.AddCondition(AnimatorConditionMode.If, 0f, "Aiming");
			animatorStateTransition80908.AddCondition(AnimatorConditionMode.Equals, 301f, "AbilityIndex");
			animatorStateTransition80908.AddCondition(AnimatorConditionMode.NotEqual, 1f, "AbilityIntData");

			var animatorStateTransition80910 = baseStateMachine1709680398.AddAnyStateTransition(equipFromAimWaterAnimatorState80998);
			animatorStateTransition80910.canTransitionToSelf = false;
			animatorStateTransition80910.duration = 0.15f;
			animatorStateTransition80910.exitTime = 0.75f;
			animatorStateTransition80910.hasExitTime = false;
			animatorStateTransition80910.hasFixedDuration = true;
			animatorStateTransition80910.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition80910.offset = 0f;
			animatorStateTransition80910.orderedInterruption = true;
			animatorStateTransition80910.isExit = false;
			animatorStateTransition80910.mute = false;
			animatorStateTransition80910.solo = false;
			animatorStateTransition80910.AddCondition(AnimatorConditionMode.If, 0f, "Slot0ItemStateIndexChange");
			animatorStateTransition80910.AddCondition(AnimatorConditionMode.Equals, 26f, "Slot0ItemID");
			animatorStateTransition80910.AddCondition(AnimatorConditionMode.Equals, 4f, "Slot0ItemStateIndex");
			animatorStateTransition80910.AddCondition(AnimatorConditionMode.If, 0f, "Moving");
			animatorStateTransition80910.AddCondition(AnimatorConditionMode.If, 0f, "Aiming");
			animatorStateTransition80910.AddCondition(AnimatorConditionMode.Equals, 301f, "AbilityIndex");
			animatorStateTransition80910.AddCondition(AnimatorConditionMode.NotEqual, 1f, "AbilityIntData");

			var animatorStateTransition80912 = baseStateMachine1709680398.AddAnyStateTransition(idleWaterAnimatorState81000);
			animatorStateTransition80912.canTransitionToSelf = false;
			animatorStateTransition80912.duration = 0.25f;
			animatorStateTransition80912.exitTime = 0.75f;
			animatorStateTransition80912.hasExitTime = false;
			animatorStateTransition80912.hasFixedDuration = true;
			animatorStateTransition80912.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition80912.offset = 0f;
			animatorStateTransition80912.orderedInterruption = true;
			animatorStateTransition80912.isExit = false;
			animatorStateTransition80912.mute = false;
			animatorStateTransition80912.solo = false;
			animatorStateTransition80912.AddCondition(AnimatorConditionMode.Equals, 26f, "Slot0ItemID");
			animatorStateTransition80912.AddCondition(AnimatorConditionMode.Equals, 0f, "Slot0ItemStateIndex");
			animatorStateTransition80912.AddCondition(AnimatorConditionMode.Equals, 301f, "AbilityIndex");
			animatorStateTransition80912.AddCondition(AnimatorConditionMode.NotEqual, 1f, "AbilityIntData");

			var animatorStateTransition80926 = baseStateMachine1709680398.AddAnyStateTransition(idleLandAnimatorState81012);
			animatorStateTransition80926.canTransitionToSelf = false;
			animatorStateTransition80926.duration = 0.08f;
			animatorStateTransition80926.exitTime = 0.75f;
			animatorStateTransition80926.hasExitTime = false;
			animatorStateTransition80926.hasFixedDuration = true;
			animatorStateTransition80926.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition80926.offset = 0f;
			animatorStateTransition80926.orderedInterruption = true;
			animatorStateTransition80926.isExit = false;
			animatorStateTransition80926.mute = false;
			animatorStateTransition80926.solo = false;
			animatorStateTransition80926.AddCondition(AnimatorConditionMode.Equals, 26f, "Slot0ItemID");
			animatorStateTransition80926.AddCondition(AnimatorConditionMode.Equals, 0f, "Slot0ItemStateIndex");
			animatorStateTransition80926.AddCondition(AnimatorConditionMode.Equals, 301f, "AbilityIndex");
			animatorStateTransition80926.AddCondition(AnimatorConditionMode.Equals, 1f, "AbilityIntData");

			var animatorStateTransition80928 = baseStateMachine1709680398.AddAnyStateTransition(equipFromAimLandAnimatorState81010);
			animatorStateTransition80928.canTransitionToSelf = false;
			animatorStateTransition80928.duration = 0.15f;
			animatorStateTransition80928.exitTime = 0.75f;
			animatorStateTransition80928.hasExitTime = false;
			animatorStateTransition80928.hasFixedDuration = true;
			animatorStateTransition80928.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition80928.offset = 0f;
			animatorStateTransition80928.orderedInterruption = true;
			animatorStateTransition80928.isExit = false;
			animatorStateTransition80928.mute = false;
			animatorStateTransition80928.solo = false;
			animatorStateTransition80928.AddCondition(AnimatorConditionMode.If, 0f, "Slot0ItemStateIndexChange");
			animatorStateTransition80928.AddCondition(AnimatorConditionMode.Equals, 26f, "Slot0ItemID");
			animatorStateTransition80928.AddCondition(AnimatorConditionMode.Equals, 4f, "Slot0ItemStateIndex");
			animatorStateTransition80928.AddCondition(AnimatorConditionMode.If, 0f, "Moving");
			animatorStateTransition80928.AddCondition(AnimatorConditionMode.If, 0f, "Aiming");
			animatorStateTransition80928.AddCondition(AnimatorConditionMode.Equals, 301f, "AbilityIndex");
			animatorStateTransition80928.AddCondition(AnimatorConditionMode.Equals, 1f, "AbilityIntData");

			var animatorStateTransition80930 = baseStateMachine1709680398.AddAnyStateTransition(unequipFromAimLandAnimatorState81008);
			animatorStateTransition80930.canTransitionToSelf = false;
			animatorStateTransition80930.duration = 0.15f;
			animatorStateTransition80930.exitTime = 0.75f;
			animatorStateTransition80930.hasExitTime = false;
			animatorStateTransition80930.hasFixedDuration = true;
			animatorStateTransition80930.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition80930.offset = 0f;
			animatorStateTransition80930.orderedInterruption = true;
			animatorStateTransition80930.isExit = false;
			animatorStateTransition80930.mute = false;
			animatorStateTransition80930.solo = false;
			animatorStateTransition80930.AddCondition(AnimatorConditionMode.If, 0f, "Slot0ItemStateIndexChange");
			animatorStateTransition80930.AddCondition(AnimatorConditionMode.Equals, 26f, "Slot0ItemID");
			animatorStateTransition80930.AddCondition(AnimatorConditionMode.Equals, 5f, "Slot0ItemStateIndex");
			animatorStateTransition80930.AddCondition(AnimatorConditionMode.If, 0f, "Moving");
			animatorStateTransition80930.AddCondition(AnimatorConditionMode.If, 0f, "Aiming");
			animatorStateTransition80930.AddCondition(AnimatorConditionMode.Equals, 301f, "AbilityIndex");
			animatorStateTransition80930.AddCondition(AnimatorConditionMode.Equals, 1f, "AbilityIntData");

			var animatorStateTransition80932 = baseStateMachine1709680398.AddAnyStateTransition(equipFromIdleLandAnimatorState81006);
			animatorStateTransition80932.canTransitionToSelf = false;
			animatorStateTransition80932.duration = 0.15f;
			animatorStateTransition80932.exitTime = 0.75f;
			animatorStateTransition80932.hasExitTime = false;
			animatorStateTransition80932.hasFixedDuration = true;
			animatorStateTransition80932.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition80932.offset = 0f;
			animatorStateTransition80932.orderedInterruption = true;
			animatorStateTransition80932.isExit = false;
			animatorStateTransition80932.mute = false;
			animatorStateTransition80932.solo = false;
			animatorStateTransition80932.AddCondition(AnimatorConditionMode.If, 0f, "Slot0ItemStateIndexChange");
			animatorStateTransition80932.AddCondition(AnimatorConditionMode.Equals, 26f, "Slot0ItemID");
			animatorStateTransition80932.AddCondition(AnimatorConditionMode.Equals, 4f, "Slot0ItemStateIndex");
			animatorStateTransition80932.AddCondition(AnimatorConditionMode.If, 0f, "Moving");
			animatorStateTransition80932.AddCondition(AnimatorConditionMode.IfNot, 0f, "Aiming");
			animatorStateTransition80932.AddCondition(AnimatorConditionMode.Equals, 301f, "AbilityIndex");
			animatorStateTransition80932.AddCondition(AnimatorConditionMode.Equals, 1f, "AbilityIntData");

			var animatorStateTransition80934 = baseStateMachine1709680398.AddAnyStateTransition(unequipFromIdleLandAnimatorState81004);
			animatorStateTransition80934.canTransitionToSelf = false;
			animatorStateTransition80934.duration = 0.15f;
			animatorStateTransition80934.exitTime = 0.75f;
			animatorStateTransition80934.hasExitTime = false;
			animatorStateTransition80934.hasFixedDuration = true;
			animatorStateTransition80934.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition80934.offset = 0f;
			animatorStateTransition80934.orderedInterruption = true;
			animatorStateTransition80934.isExit = false;
			animatorStateTransition80934.mute = false;
			animatorStateTransition80934.solo = false;
			animatorStateTransition80934.AddCondition(AnimatorConditionMode.If, 0f, "Slot0ItemStateIndexChange");
			animatorStateTransition80934.AddCondition(AnimatorConditionMode.Equals, 26f, "Slot0ItemID");
			animatorStateTransition80934.AddCondition(AnimatorConditionMode.Equals, 5f, "Slot0ItemStateIndex");
			animatorStateTransition80934.AddCondition(AnimatorConditionMode.If, 0f, "Moving");
			animatorStateTransition80934.AddCondition(AnimatorConditionMode.IfNot, 0f, "Aiming");
			animatorStateTransition80934.AddCondition(AnimatorConditionMode.Equals, 301f, "AbilityIndex");
			animatorStateTransition80934.AddCondition(AnimatorConditionMode.Equals, 1f, "AbilityIntData");

			var animatorStateTransition80936 = baseStateMachine1709680398.AddAnyStateTransition(dropWaterLandAnimatorState81002);
			animatorStateTransition80936.canTransitionToSelf = false;
			animatorStateTransition80936.duration = 0.1f;
			animatorStateTransition80936.exitTime = 0.75f;
			animatorStateTransition80936.hasExitTime = false;
			animatorStateTransition80936.hasFixedDuration = true;
			animatorStateTransition80936.interruptionSource = TransitionInterruptionSource.None;
			animatorStateTransition80936.offset = 0f;
			animatorStateTransition80936.orderedInterruption = true;
			animatorStateTransition80936.isExit = false;
			animatorStateTransition80936.mute = false;
			animatorStateTransition80936.solo = false;
			animatorStateTransition80936.AddCondition(AnimatorConditionMode.If, 0f, "Slot0ItemStateIndexChange");
			animatorStateTransition80936.AddCondition(AnimatorConditionMode.Equals, 26f, "Slot0ItemID");
			animatorStateTransition80936.AddCondition(AnimatorConditionMode.Equals, 6f, "Slot0ItemStateIndex");
			animatorStateTransition80936.AddCondition(AnimatorConditionMode.If, 0f, "Moving");
			animatorStateTransition80936.AddCondition(AnimatorConditionMode.Equals, 301f, "AbilityIndex");
			animatorStateTransition80936.AddCondition(AnimatorConditionMode.Equals, 1f, "AbilityIntData");
		}
	}
}
