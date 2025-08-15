using UnityEngine;

namespace Abiogenesis3d
{
    [ExecuteInEditMode]
    [DefaultExecutionOrder(999)]
    public class LookAtCamera : MonoBehaviour
    {
        public Camera cam;

        private void LateUpdate()
        {
            if (cam == null) cam = Camera.main;

            transform.LookAt(transform.position + cam.transform.rotation * Vector3.forward,
                cam.transform.rotation * Vector3.up);
        }
    }
}
