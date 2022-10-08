using System;
using UnityEngine;
using UnityEngine.Events;

namespace PrehistoricPlatformer.Utilities
{
    public class OnTrigger2DUtil : MonoBehaviour
    {
        [SerializeField] private LayerMask collisionMask;
        [SerializeField] private UnityEvent OnTriggerEnterEvent, OnTriggerExitEvent;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if((1<<col.gameObject.layer & collisionMask)!=0)
                OnTriggerEnterEvent?.Invoke();
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            if((1<<col.gameObject.layer & collisionMask)!=0)
                OnTriggerExitEvent?.Invoke();
        }
    }
}