// Copyright (c) Meta Platforms, Inc. and affiliates. 

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Lofelt.NiceVibrations
{
    [Serializable]
    public class HapticClipsDemoItem
    {
        public string Name;
        public HapticClip HapticClip;
        public Sprite AssociatedSprite;
        public AudioSource AssociatedSound;

    }

    public class HapticClipsDemoManager : DemoManager
    {
        [Header("Image")]
        public Image IconImage;
        public Animator IconImageAnimator;
        public List<HapticClipsDemoItem> DemoItems;
        protected WaitForSeconds _iconChangeDelay;
        protected int _idleAnimationParameter;

        protected virtual void Awake()
        {
            _iconChangeDelay = new WaitForSeconds(0.02f);
            _idleAnimationParameter = Animator.StringToHash("Idle");
            IconImageAnimator.SetBool(_idleAnimationParameter, true);
        }

        // Haptic Clip -----------------------------------------------------------------------------

        public virtual void PlayHapticClip(int index)
        {
            Logo.Shaking = true;

            HapticController.fallbackPreset = HapticPatterns.PresetType.LightImpact;
            HapticController.Play(DemoItems[index].HapticClip);
            DemoItems[index].AssociatedSound.Play();
            StopAllCoroutines();
            StartCoroutine(ChangeIcon(DemoItems[index].AssociatedSprite));
        }

        // ICON ------------------------------------------------------------------------------------

        protected virtual IEnumerator ChangeIcon(Sprite newSprite)
        {
            IconImageAnimator.SetBool(_idleAnimationParameter, false);
            yield return _iconChangeDelay;
            IconImage.sprite = newSprite;
        }

        // CALLBACKS -------------------------------------------------------------------------------

        protected virtual IEnumerator BackToIdle()
        {
            Logo.Shaking = false;
            IconImageAnimator.SetBool(_idleAnimationParameter, true);
            yield return _iconChangeDelay;
            IconImage.sprite = DemoItems[0].AssociatedSprite;
        }

        private void OnHapticsStopped()
        {
            StartCoroutine(BackToIdle());
        }

        private void OnDisable()
        {
            HapticController.PlaybackStopped -= OnHapticsStopped;
            if (HapticController.IsPlaying())
            {
                HapticController.Stop();
            }
        }

        private void OnEnable()
        {
            HapticController.PlaybackStopped += OnHapticsStopped;
            StartCoroutine(BackToIdle());
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            if (hasFocus)
            {
                StartCoroutine(BackToIdle());
            }
        }

    }
}
