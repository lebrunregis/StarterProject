using UnityEngine;

namespace Abiogenesis3d
{
    [DefaultExecutionOrder(int.MinValue)]
    public class FreezePosition : MonoBehaviour
    {
        public Vector3 position;

        private void OnEnable()
        {
            position = transform.position;
        }

        private void Update()
        {
            position = transform.position;
        }

        private void LateUpdate()
        {
            transform.position = position;
        }
    }
}
