#if PRIME_TWEEN_INSTALLED && UNITY_UGUI_INSTALLED
using PrimeTween;
using UnityEngine.UI;
#endif
using UnityEngine;

namespace PrimeTweenDemo
{
    public class Demo : MonoBehaviour
    {
#if PRIME_TWEEN_INSTALLED && UNITY_UGUI_INSTALLED
        [SerializeField] private AnimateAllType animateAllType; private enum AnimateAllType
        { Sequence, Async, Coroutine }
        [SerializeField] private Slider sequenceTimelineSlider;
        [SerializeField] private Text pausedLabel;
        [SerializeField] private Button animateAllPartsButton;
        [SerializeField] private TypewriterAnimatorExample typewriterAnimatorExample;
        [SerializeField] private Animatable[] animatables;
        [SerializeField] private Wheels wheels;
        [SerializeField, Range(0.5f, 5f)] private float timeScale = 1;
        private bool isAnimatingWithCoroutineOrAsync;
        public Sequence animateAllSequence;

        private void Awake()
        {
            PrimeTweenConfig.SetTweensCapacity(100);
        }

        private void OnEnable()
        {
            sequenceTimelineSlider.fillRect.gameObject.SetActive(false);
            sequenceTimelineSlider.onValueChanged.AddListener(SequenceTimelineSliderChanged);
        }

        private void OnDisable() => sequenceTimelineSlider.onValueChanged.RemoveListener(SequenceTimelineSliderChanged);

        private void SequenceTimelineSliderChanged(float sliderValue)
        {
            if (!notifySliderChanged)
            {
                return;
            }
            if (!animateAllSequence.isAlive)
            {
                wheels.OnClick();
            }
            animateAllSequence.isPaused = true;
            animateAllSequence.progressTotal = sliderValue;
        }

        private bool notifySliderChanged = true;

        private void UpdateSlider()
        {
            var isSliderVisible = animateAllType == AnimateAllType.Sequence && !isAnimatingWithCoroutineOrAsync;
            sequenceTimelineSlider.gameObject.SetActive(isSliderVisible);
            if (!isSliderVisible)
            {
                return;
            }
            pausedLabel.gameObject.SetActive(animateAllSequence.isAlive && animateAllSequence.isPaused);
            var isSequenceAlive = animateAllSequence.isAlive;
            sequenceTimelineSlider.handleRect.gameObject.SetActive(isSequenceAlive);
            if (isSequenceAlive)
            {
                notifySliderChanged = false;
                sequenceTimelineSlider.value = animateAllSequence.progressTotal; // Unity 2018 doesn't have SetValueWithoutNotify(), so use notifySliderChanged instead
                notifySliderChanged = true;
            }
        }

        private void Update()
        {
            Time.timeScale = timeScale;

            animateAllPartsButton.GetComponent<Image>().enabled = !isAnimatingWithCoroutineOrAsync;
            animateAllPartsButton.GetComponentInChildren<Text>().enabled = !isAnimatingWithCoroutineOrAsync;

            UpdateSlider();
        }

        public void AnimateAll(bool toEndValue)
        {
            if (isAnimatingWithCoroutineOrAsync)
            {
                return;
            }
            switch (animateAllType)
            {
                case AnimateAllType.Sequence:
                    AnimateAllSequence(toEndValue);
                    break;
                case AnimateAllType.Async:
                    AnimateAllAsync(toEndValue);
                    break;
                case AnimateAllType.Coroutine:
                    StartCoroutine(AnimateAllCoroutine(toEndValue));
                    break;
            }
        }

        /// Tweens and sequences can be grouped with and chained to other tweens and sequences.
        /// The advantage of using this method instead of <see cref="AnimateAllAsync"/> and <see cref="AnimateAllCoroutine"/> is the ability to stop/complete/pause the combined sequence.
        /// Also, this method doesn't generate garbage related to starting a coroutine or awaiting an async method.
        private void AnimateAllSequence(bool toEndValue)
        {
            if (animateAllSequence.isAlive)
            {
                animateAllSequence.isPaused = !animateAllSequence.isPaused;
                return;
            }
            animateAllSequence = Sequence.Create();
#if TEXT_MESH_PRO_INSTALLED
            animateAllSequence.Group(typewriterAnimatorExample.Animate());
#endif
            float delay = 0f;
            foreach (var animatable in animatables)
            {
                animateAllSequence.Insert(delay, animatable.Animate(toEndValue));
                delay += 0.6f;
            }
        }

        /// Tweens and sequences can be awaited in async methods.
        private async void AnimateAllAsync(bool toEndValue)
        {
            isAnimatingWithCoroutineOrAsync = true;
            foreach (var animatable in animatables)
            {
                await animatable.Animate(toEndValue);
            }
            isAnimatingWithCoroutineOrAsync = false;
        }

        /// Tweens and sequences can also be used in coroutines with the help of ToYieldInstruction() method.
        private System.Collections.IEnumerator AnimateAllCoroutine(bool toEndValue)
        {
            isAnimatingWithCoroutineOrAsync = true;
            foreach (var animatable in animatables)
            {
                yield return animatable.Animate(toEndValue).ToYieldInstruction();
            }
            isAnimatingWithCoroutineOrAsync = false;
        }
#else // PRIME_TWEEN_INSTALLED
        void Awake() {
            Debug.LogError("Please install PrimeTween via 'Assets/Plugins/PrimeTween/PrimeTweenInstaller'.");
#if !UNITY_2019_1_OR_NEWER
            Debug.LogError("And add the 'PRIME_TWEEN_INSTALLED' define to the 'Project Settings/Player/Scripting Define Symbols' to run the Demo in Unity 2018.");
#endif
        }
#endif
    }
}
