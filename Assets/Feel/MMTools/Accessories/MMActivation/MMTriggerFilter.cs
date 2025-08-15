using UnityEngine;

namespace MoreMountains.Tools
{
    public abstract class MMTriggerFilter : MonoBehaviour
    {
        public TriggerAndCollisionMask TriggerFilter = TriggerAndCollisionMask.All;

        protected virtual void OnValidate()
        {
            // Only allow trigger related bits
            TriggerFilter &= TriggerAndCollisionMask.OnAnyTrigger;
        }

        protected virtual bool UseEvent(TriggerAndCollisionMask value) => 0 != (TriggerFilter & value);

        // Trigger 2D ------------------------------------------------------------------------------------

        protected abstract void OnTriggerEnter2D_(Collider2D collider);
        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (UseEvent(TriggerAndCollisionMask.OnTriggerEnter2D))
            {
                OnTriggerEnter2D_(collider);
            }
        }

        protected abstract void OnTriggerExit2D_(Collider2D collider);
        private void OnTriggerExit2D(Collider2D collider)
        {
            if (UseEvent(TriggerAndCollisionMask.OnTriggerExit2D))
            {
                OnTriggerExit2D_(collider);
            }
        }

        protected abstract void OnTriggerStay2D_(Collider2D collider);
        private void OnTriggerStay2D(Collider2D collider)
        {
            if (UseEvent(TriggerAndCollisionMask.OnTriggerStay2D))
            {
                OnTriggerStay2D_(collider);
            }
        }


        // Trigger  ------------------------------------------------------------------------------------

        protected abstract void OnTriggerEnter_(Collider collider);
        private void OnTriggerEnter(Collider collider)
        {
            if (UseEvent(TriggerAndCollisionMask.OnTriggerEnter))
            {
                OnTriggerEnter_(collider);
            }
        }

        protected abstract void OnTriggerExit_(Collider collider);
        private void OnTriggerExit(Collider collider)
        {
            if (UseEvent(TriggerAndCollisionMask.OnTriggerExit))
            {
                OnTriggerExit_(collider);
            }
        }

        protected abstract void OnTriggerStay_(Collider collider);
        private void OnTriggerStay(Collider collider)
        {
            if (UseEvent(TriggerAndCollisionMask.OnTriggerStay))
            {
                OnTriggerStay_(collider);
            }
        }
    }
}