using UnityEngine;

namespace Abiogenesis3d
{
    public class RotateOnHover : MonoBehaviour
    {
        private bool isRotating;

        private void Update()
        {
            if (isRotating)
            {
                transform.Rotate(Vector3.up, 90 * Time.deltaTime);
            }
        }

        private void OnMouseEnter()
        {
            isRotating = true;
        }

        private void OnMouseExit()
        {
            isRotating = false;
        }
    }
}
