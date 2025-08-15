using UnityEngine;

namespace Gamekit3D
{
    public class FPSTarget : MonoBehaviour
    {
        public int targetFPS = 60;

        // Use this for initialization
        private void OnEnable()
        {
            SetTargetFPS(targetFPS);
        }

        public void SetTargetFPS(int fps)
        {
            Application.targetFrameRate = fps;
        }
    }
}
