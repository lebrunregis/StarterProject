using UnityEngine;
using UnityEngine.EventSystems;

namespace Abiogenesis3d
{
    public class MouseDragUI : MonoBehaviour, IDragHandler, IBeginDragHandler
    {
        private readonly KeyCode dragKey = KeyCode.Mouse0;
        private Vector2 lastMousePosition;
        private RectTransform rectTransform;

        private void Start()
        {
            rectTransform = GetComponent<RectTransform>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (!Input.GetKey(dragKey)) return;

            lastMousePosition = eventData.position;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (!Input.GetKey(dragKey)) return;

            Vector2 currentMousePosition = eventData.position;

            currentMousePosition.x = Mathf.Clamp(currentMousePosition.x, 0, Screen.width);
            currentMousePosition.y = Mathf.Clamp(currentMousePosition.y, 0, Screen.height);

            Vector2 diff = currentMousePosition - lastMousePosition;

            rectTransform.position += (Vector3)diff;
            lastMousePosition = currentMousePosition;
        }
    }
}
