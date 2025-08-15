﻿using UnityEngine;
using UnityEngine.Events;

namespace Gamekit3D
{
    [RequireComponent(typeof(SphereCollider))]
    public class InteractionTrigger : MonoBehaviour
    {
        public LayerMask layers;
        public UnityEvent OnEnter, OnExit;
        public new SphereCollider collider;

        private void Reset()
        {
            layers = LayerMask.NameToLayer("Everything");
            collider = GetComponent<SphereCollider>();
            collider.radius = 5;
            collider.isTrigger = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (0 != (layers.value & 1 << other.gameObject.layer))
            {
                OnEnter.Invoke();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (0 != (layers.value & 1 << other.gameObject.layer))
            {
                OnExit.Invoke();
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawIcon(transform.position, "InteractionTrigger", false);
        }

        private void OnDrawGizmosSelected()
        {
            //need to inspect events and draw arrows to relevant gameObjects.
        }

    }
}
