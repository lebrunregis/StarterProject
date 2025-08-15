using UnityEngine;

namespace Abiogenesis3d
{
    public class MultiCameraRaycastTest : MonoBehaviour
    {
        public MultiCameraEvents multiCameraEvents;

        private void Start()
        {
            if (!multiCameraEvents)
                multiCameraEvents = FindObjectOfType<MultiCameraEvents>();
        }

        private void Update()
        {
            var hit = multiCameraEvents.raycastHit;
            Debug.Log((hit.collider?.name ?? "null") + ", " + hit.point);
        }
    }
}
