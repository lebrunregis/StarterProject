using UnityEngine;

namespace Abiogenesis3d
{
    public class ChangeColorOnEvents : MonoBehaviour
    {
        private Renderer rend;
        private Color originalColor;
        public Color hoveredColor = new(20, 50, 100);
        public bool log;

        private Color color;
        private float alpha = 1;
        private float emission = 0.5f;

        private void Start()
        {
            rend = GetComponent<Renderer>();
            originalColor = rend.material.color;
            color = originalColor;
        }

        // Color GetInvertedColor(Color color)
        // {
        //     return new Color (1 - color.r, 1 - color.g, 1 - color.b, color.a);
        // }

        private Color GetColor()
        {
            return new Color(color.r, color.g, color.b, alpha);
        }

        private void OnMouseEnter()
        {
            if (log) Debug.Log("OnMouseEnter: " + name);
            color = hoveredColor;
            UpdateColor();
        }

        private void OnMouseExit()
        {
            if (log) Debug.Log("OnMouseExit: " + name);
            color = originalColor;
            emission = 0.5f;
            UpdateColor();
        }

        private void UpdateColor()
        {
            rend.material.color = GetColor();
            Color emissionColor = new(emission, emission, emission);
            rend.material.SetColor("_EmissionColor", emissionColor);

        }

        private void OnMouseDrag()
        {
            if (log) Debug.Log("OnMouseDrag: " + name);
            alpha = 0.5f + Mathf.PingPong(Time.time, 0.5f);
            UpdateColor();
        }

        private void OnMouseOver()
        {
            if (log) Debug.Log("OnMouseOver: " + name);
            emission = 0.5f - Mathf.PingPong(Time.time * 0.5f, 0.5f);
            UpdateColor();
        }

        private void OnMouseDown()
        {
            if (log) Debug.Log("OnMouseDown: " + name);
            color = GetRandomColor();
            UpdateColor();
        }

        private void OnMouseUp()
        {
            if (log) Debug.Log("OnMouseUp: " + name);
            color = GetRandomColor();
            UpdateColor();
        }

        private void OnMouseUpAsButton()
        {
            if (log) Debug.Log("OnMouseUpAsButton: " + name);
            alpha = 1;
            emission = 0;
            UpdateColor();
        }

        private Color GetRandomColor()
        {
            return Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        }
    }
}
