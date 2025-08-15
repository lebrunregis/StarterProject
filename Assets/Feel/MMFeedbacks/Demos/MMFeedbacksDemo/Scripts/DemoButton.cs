﻿using UnityEngine;
#if MM_UI
using UnityEngine.UI;

#if UNITY_EDITOR
#endif
namespace MoreMountains.Feedbacks
{
    /// <summary>
    /// A simple class used to handle demo buttons in the MMF_PlayerDemo and MMFeedbacksDemo scenes
    /// </summary>
    [ExecuteAlways]
    [AddComponentMenu("")]
    public class DemoButton : MonoBehaviour
    {
        [Header("Behaviour")]
        public bool NotSupportedInWebGL = false;

        [Header("Bindings")]
        public Button TargetButton;
        public Text ButtonText;
        public Text WebGL;
        public MMF_Player TargetMMF_Player;

        protected Color _disabledColor = new(255, 255, 255, 0.5f);

        protected virtual void OnEnable()
        {
            HandleWebGL();
            TargetButton.onClick.AddListener(OnClickEvent);
        }

        protected void OnDisable()
        {
            TargetButton.onClick.RemoveListener(OnClickEvent);
        }

        public void OnClickEvent()
        {
            TargetMMF_Player?.PlayFeedbacks();
        }

        protected virtual void HandleWebGL()
        {
            if (WebGL != null)
            {
#if UNITY_WEBGL
					TargetButton.interactable = !NotSupportedInWebGL;    
                    WebGL.gameObject.SetActive(NotSupportedInWebGL);   
					ButtonText.color = NotSupportedInWebGL ? _disabledColor : Color.white;
#else
                WebGL.gameObject.SetActive(false);
                TargetButton.interactable = true;
                ButtonText.color = Color.white;
#endif
            }
        }
    }
}
#endif