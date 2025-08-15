#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace Gamekit3D
{
    [CustomEditor(typeof(PlayerController))]
    public class PlayerControllerEditor : Editor
    {
        private SerializedProperty m_ScriptProp;

        private SerializedProperty m_MaxForwardSpeedProp;
        private SerializedProperty m_GravityProp;
        private SerializedProperty m_JumpSpeedProp;
        private SerializedProperty m_MinTurnSpeedProp;
        private SerializedProperty m_MaxTurnSpeedProp;
        private SerializedProperty m_IdleTimeoutProp;
        private SerializedProperty m_CanAttackProp;

        private SerializedProperty m_MeleeWeaponProp;
        private SerializedProperty m_FootstepPlayerProp;
        private SerializedProperty m_HurtAudioPlayerProp;
        private SerializedProperty m_LandingPlayerProp;
        private SerializedProperty m_EmoteLandingPlayerProp;
        private SerializedProperty m_EmoteDeathPlayerProp;
        private SerializedProperty m_EmoteAttackPlayerProp;
        private SerializedProperty m_EmoteJumpPlayerProp;

        private readonly GUIContent m_ScriptContent = new("Script");

        private readonly GUIContent m_MaxForwardSpeedContent = new("Max Forward Speed", "How fast Ellen can run.");
        private readonly GUIContent m_GravityContent = new("Gravity", "How fast Ellen falls when in the air.");
        private readonly GUIContent m_JumpSpeedContent = new("Jump Speed", "How fast Ellen takes off when jumping.");
        private readonly GUIContent m_TurnSpeedContent = new("Turn Speed", "How fast Ellen turns.  This varies depending on how fast she is moving.  When stationary the maximum will be used and when running at Max Forward Speed the minimum will be used.");
        private readonly GUIContent m_IdleTimeoutContent = new("Idle Timeout", "How many seconds before Ellen starts considering random Idle poses.");
        private readonly GUIContent m_CanAttackContent = new("Can Attack", "Whether or not Ellen can attack with her staff.  This can be set externally.");

        private readonly GUIContent m_MeleeWeaponContent = new("Melee Weapon", "Used for damaging enemies when Ellen swings her staff.");
        private readonly GUIContent m_FootstepPlayerContent = new("Footstep Random Audio Player", "Used to play a random sound when Ellen takes a step.");
        private readonly GUIContent m_HurtAudioPlayerContent = new("Hurt Random Audio Player", "Used to play a random sound when Ellen gets hurt.");
        private readonly GUIContent m_LandingPlayerContent = new("Landing Random Audio Player", "Used to play a random sound when Ellen lands.");
        private readonly GUIContent m_EmoteLandingPlayerContent = new("Emote Landing Player", "Used to play a random vocal sound when Ellen lands.");
        private readonly GUIContent m_EmoteDeathPlayerContent = new("Emote Death Player", "Used to play a random vocal sound when Ellen dies.");
        private readonly GUIContent m_EmoteAttackPlayerContent = new("Emote Attack Player", "Used to play a random vocal sound when Ellen attacks.");
        private readonly GUIContent m_EmoteJumpPlayerContent = new("Emote Jump Player", "Used to play a random vocal sound when Ellen jumps.");

        private void OnEnable()
        {
            m_ScriptProp = serializedObject.FindProperty("m_Script");

            m_MaxForwardSpeedProp = serializedObject.FindProperty("maxForwardSpeed");
            m_GravityProp = serializedObject.FindProperty("gravity");
            m_JumpSpeedProp = serializedObject.FindProperty("jumpSpeed");
            m_MinTurnSpeedProp = serializedObject.FindProperty("minTurnSpeed");
            m_MaxTurnSpeedProp = serializedObject.FindProperty("maxTurnSpeed");
            m_IdleTimeoutProp = serializedObject.FindProperty("idleTimeout");
            m_CanAttackProp = serializedObject.FindProperty("canAttack");

            m_MeleeWeaponProp = serializedObject.FindProperty("meleeWeapon");
            m_FootstepPlayerProp = serializedObject.FindProperty("footstepPlayer");
            m_HurtAudioPlayerProp = serializedObject.FindProperty("hurtAudioPlayer");
            m_LandingPlayerProp = serializedObject.FindProperty("landingPlayer");
            m_EmoteLandingPlayerProp = serializedObject.FindProperty("emoteLandingPlayer");
            m_EmoteDeathPlayerProp = serializedObject.FindProperty("emoteDeathPlayer");
            m_EmoteAttackPlayerProp = serializedObject.FindProperty("emoteAttackPlayer");
            m_EmoteJumpPlayerProp = serializedObject.FindProperty("emoteJumpPlayer");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            GUI.enabled = false;
            EditorGUILayout.PropertyField(m_ScriptProp, m_ScriptContent);
            GUI.enabled = true;

            m_MaxForwardSpeedProp.floatValue = EditorGUILayout.Slider(m_MaxForwardSpeedContent, m_MaxForwardSpeedProp.floatValue, 4f, 12f);
            m_GravityProp.floatValue = EditorGUILayout.Slider(m_GravityContent, m_GravityProp.floatValue, 10f, 30f);
            m_JumpSpeedProp.floatValue = EditorGUILayout.Slider(m_JumpSpeedContent, m_JumpSpeedProp.floatValue, 5f, 20f);

            MinMaxTurnSpeed();

            EditorGUILayout.PropertyField(m_IdleTimeoutProp, m_IdleTimeoutContent);
            EditorGUILayout.PropertyField(m_CanAttackProp, m_CanAttackContent);

            EditorGUILayout.Space();

            m_MeleeWeaponProp.isExpanded = EditorGUILayout.Foldout(m_MeleeWeaponProp.isExpanded, "References");

            serializedObject.ApplyModifiedProperties();
        }

        private void MinMaxTurnSpeed()
        {
            Rect position = EditorGUILayout.GetControlRect(false, EditorGUIUtility.singleLineHeight);

            const float spacing = 4f;
            const float intFieldWidth = 50f;

            position.width -= spacing * 3f + intFieldWidth * 2f;

            Rect labelRect = position;
            labelRect.width *= 0.48f;

            Rect minRect = position;
            minRect.width = 50f;
            minRect.x += labelRect.width + spacing;

            Rect sliderRect = position;
            sliderRect.width *= 0.52f;
            sliderRect.x += labelRect.width + minRect.width + spacing * 2f;

            Rect maxRect = position;
            maxRect.width = minRect.width;
            maxRect.x += labelRect.width + minRect.width + sliderRect.width + spacing * 3f;

            EditorGUI.LabelField(labelRect, m_TurnSpeedContent);
            m_MinTurnSpeedProp.floatValue = EditorGUI.IntField(minRect, (int)m_MinTurnSpeedProp.floatValue);

            float minTurnSpeed = m_MinTurnSpeedProp.floatValue;
            float maxTurnSpeed = m_MaxTurnSpeedProp.floatValue;
            EditorGUI.MinMaxSlider(sliderRect, GUIContent.none, ref minTurnSpeed, ref maxTurnSpeed, 100f, 1500f);
            m_MinTurnSpeedProp.floatValue = minTurnSpeed;
            m_MaxTurnSpeedProp.floatValue = maxTurnSpeed;

            m_MaxTurnSpeedProp.floatValue = EditorGUI.IntField(maxRect, (int)m_MaxTurnSpeedProp.floatValue);
        }
    }
}
#endif
