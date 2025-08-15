using UnityEngine;

namespace Abiogenesis3d
{
    public class MouseEventsPropagator : MonoBehaviour
    {
        private const SendMessageOptions msgOpts = SendMessageOptions.DontRequireReceiver;

        private void OnMouseEnter()
        { transform.parent.SendMessageUpwards("OnMouseEnter", msgOpts); }
        private void OnMouseExit()
        { transform.parent.SendMessageUpwards("OnMouseExit", msgOpts); }
        private void OnMouseOver()
        { transform.parent.SendMessageUpwards("OnMouseOver", msgOpts); }
        private void OnMouseDown()
        { transform.parent.SendMessageUpwards("OnMouseDown", msgOpts); }
        private void OnMouseUp()
        { transform.parent.SendMessageUpwards("OnMouseUp", msgOpts); }
        private void OnMouseUpAsButton()
        { transform.parent.SendMessageUpwards("OnMouseUpAsButton", msgOpts); }

        // NOTE: adding this to enable script checkbox
        private void Start()
        { }
    }
}
