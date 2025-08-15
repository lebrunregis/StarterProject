using UnityEngine;
using UnityEngine.UI;

namespace Abiogenesis3d
{
    [ExecuteInEditMode]
    public class SetFramesToText : MonoBehaviour
    {
        public Text text;
        public FakeStopMotion fakeStopMotion;

        private void Update()
        {
            if (!text) text = GetComponent<Text>();
            if (!fakeStopMotion) fakeStopMotion = GetComponentInParent<FakeStopMotion>();

            if (fakeStopMotion)
                text.text = fakeStopMotion.framesPerSecond + "fps";
        }
    }
}
