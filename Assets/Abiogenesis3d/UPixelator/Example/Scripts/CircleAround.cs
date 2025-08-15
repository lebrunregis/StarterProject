// modified https://gamedev.stackexchange.com/questions/126427/draw-circle-around-gameobject-to-indicate-radius
using UnityEngine;

namespace Abiogenesis3d.UPixelator_Demo
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(LineRenderer))]
    public class CircleAround : MonoBehaviour
    {
        [Range(0.1f, 100)] public float radius = 1;
        private float lastRadius = 0;

        [Range(0.1f, 1)] public float thickness = 0.5f;
        private float lastThickness = 0;

        [Range(3, 256)] public int numSegments = 128;
        private float lastNumSegments = 0;

        private void Start()
        {
            DoRenderer();
        }

        private bool IsDirty()
        {
            if (radius != lastRadius ||
                numSegments != lastNumSegments ||
                thickness != lastThickness)
            {
                lastRadius = radius;
                lastNumSegments = numSegments;
                lastThickness = thickness;
                return true;
            }
            return false;
        }

        private void Update()
        {
            if (IsDirty())
                DoRenderer();
        }

        public void DoRenderer()
        {
            LineRenderer lineRenderer = gameObject.GetComponent<LineRenderer>();
            Color c1 = new(0.5f, 0.5f, 0.5f, 1);
            lineRenderer.startColor = c1;
            lineRenderer.endColor = c1;
            lineRenderer.startWidth = thickness;
            lineRenderer.endWidth = thickness;
            lineRenderer.positionCount = numSegments + 1;
            lineRenderer.useWorldSpace = false;
            lineRenderer.alignment = LineAlignment.View;
            transform.rotation = Quaternion.Euler(90, 0, 0);

            float deltaTheta = (float)(2.0 * Mathf.PI) / numSegments;
            float theta = 0;

            for (int i = 0; i < numSegments + 1; ++i)
            {
                float x = radius * Mathf.Cos(theta);
                float z = radius * Mathf.Sin(theta);
                Vector3 pos = new(x, z, 0);
                lineRenderer.SetPosition(i, pos);
                theta += deltaTheta;
            }
        }
    }
}
