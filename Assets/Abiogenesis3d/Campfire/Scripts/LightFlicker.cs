// https://answers.unity.com/questions/742466/camp-fire-light-flicker-control.html
using UnityEngine;

namespace Abiogenesis3d
{
    [RequireComponent(typeof(Light))]
    public class LightFlicker : MonoBehaviour
    {
        private new Light light;
        [Header("Intensity")]
        public float intensity;
        private float nextIntensity;
        [SerializeField, Range(0, 5)] private float difference = 1;
        [SerializeField, Range(0.1f, 1)] private float maxFrequency = 1f;
        [SerializeField, Range(0.01f, 1)] private float minFrequency = 0.1f;
        [SerializeField, Range(0, 20)] private float lerpSpeed = 100f;
        private float frequency;

        [Header("Position")]
        public Vector3 localPosition;
        [SerializeField, Range(0, 0.1f)] private float maxOffset = 0.05f;

        private float lastTime;

        private void OnEnable()
        {
            light = GetComponent<Light>();
            lastTime = Time.time;
            Store();
        }

        private void OnDisable()
        {
            Restore();
        }

        private void Store()
        {
            intensity = light.intensity;
            localPosition = transform.localPosition;
        }

        private void Restore()
        {
            light.intensity = intensity;
            transform.localPosition = localPosition;
        }

        private void Update()
        {
            if (lastTime + frequency < Time.time)
            {
                lastTime = Time.time;
                nextIntensity = Random.Range(intensity - difference, intensity + difference);
                frequency = Random.Range(minFrequency, maxFrequency);

                transform.localPosition = localPosition + new Vector3(
                    Random.Range(-maxOffset, maxOffset),
                    Random.Range(-maxOffset, maxOffset),
                    Random.Range(-maxOffset, maxOffset));
            }
            else
            {
                var diff = Mathf.Sin(Time.time) * 0.001f;
                transform.localPosition += Vector3.one * diff;
            }

            light.intensity = Mathf.Lerp(light.intensity, nextIntensity, lerpSpeed * Time.deltaTime);
        }
    }
}
