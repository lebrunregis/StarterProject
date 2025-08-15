using UnityEngine;

namespace Abiogenesis3d
{
    [ExecuteInEditMode]
    public class UPixelatorSnappableCanvasOverlay : MonoBehaviour
    {
        private Camera cam;
        private UPixelator uPixelator;
        private RectTransform rectTransform;
        private Vector3 storedPosition;
        public bool scaleFactorFromPixelMultiplier = true;
        public float snapSize = 1;

        private void OnEnable()
        {
            var canvas = GetComponentInParent<Canvas>();
            if (!canvas)
            {
                Debug.LogWarning("No canvas found for " + name + ", disabling.");
                enabled = false;
                return;
            }

            // cam = canvas.worldCamera;
            // if (!cam)
            // {
            //     Debug.LogWarning("No World Camera found on canvas " + canvas.name + ", disabling.");
            //     enabled = false;
            //     return;
            // }

            rectTransform = GetComponent<RectTransform>();
            if (!rectTransform)
            {
                Debug.LogWarning("No RectTransform found for " + name + ", disabling.");
                enabled = false;
                return;
            }

            uPixelator = FindObjectOfType<UPixelator>();
            if (!uPixelator)
            {
                Debug.LogWarning("No UPixelator found for " + name + ", disabling.");
                enabled = false;
                return;
            }

            cam = uPixelator.uPixelatorCam;

            storedPosition = rectTransform.anchoredPosition;
            Utils.RunAtEndOfFrameOrdered(() => RestorePosition(), 0, this);
        }

        private void RestorePosition()
        {
            rectTransform.anchoredPosition = storedPosition;
        }

        private void SnapPosition()
        {
            storedPosition = rectTransform.anchoredPosition;

            if (scaleFactorFromPixelMultiplier) snapSize = uPixelator.pixelMultiplier;

            Vector2 position = rectTransform.anchoredPosition;

            float x = Mathf.Round(position.x);
            float y = Mathf.Round(position.y);

            rectTransform.anchoredPosition = new Vector2(x, y);
        }

        private void LateUpdate()
        {
            if (!cam) return;
            if (!uPixelator) return;

            SnapPosition();
        }
    }
}
