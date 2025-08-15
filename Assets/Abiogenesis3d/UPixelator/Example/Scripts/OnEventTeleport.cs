using UnityEngine;

namespace Abiogenesis3d.UPixelator_Demo
{
    public class OnEventTeleport : MonoBehaviour
    {
        public Transform target;
        public Transform destination;
        public float delay;

        private bool shouldTeleport;
        private float eventTime;

        private void Update()
        {
            if (!shouldTeleport) return;

            if (Time.time - eventTime >= delay)
                Teleport();
        }

        public void OnEvent()
        {
            shouldTeleport = true;
            eventTime = Time.time;
        }

        private void Teleport()
        {
            target.position = destination.position;
            shouldTeleport = false;
        }
    }
}
