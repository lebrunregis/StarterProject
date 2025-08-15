using UnityEngine;

namespace Abiogenesis3d
{
    [ExecuteInEditMode]
    [DefaultExecutionOrder(int.MinValue)]
    public class EarlyMonoBehaviour : MonoBehaviour
    {
        public delegate void FixedUpdateAction();

        public event FixedUpdateAction OnEarlyFixedUpdate;

        private void FixedUpdate()
        {
            OnEarlyFixedUpdate?.Invoke();
        }
    }
}
