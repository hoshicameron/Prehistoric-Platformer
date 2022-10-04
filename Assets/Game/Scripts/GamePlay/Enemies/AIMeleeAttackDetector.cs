using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;

namespace PrehistoricPlatformer.AI
{
    public class AIMeleeAttackDetector : MonoBehaviour
    {
        [Range(0.1f,1f)]
        [SerializeField] private float radius;
        [SerializeField] private LayerMask targetLayer;
        [field:SerializeField] public UnityEvent<GameObject> OnPlayerDetected { get; set; }

        [Header("Gizmos")]
        
        [SerializeField] private Color gizmoColor;
        [SerializeField] private bool showGizmo = true;
        public bool PlayerDetected { get;  private set; }

        private void FixedUpdate()
        {
            var collider = Physics2D.OverlapCircle(transform.position, radius, targetLayer);
            PlayerDetected = collider != null;
            if(PlayerDetected)      OnPlayerDetected?.Invoke(collider.gameObject);
        }

        private void OnDrawGizmos()
        {
            if (showGizmo)
            {
                Gizmos.color = gizmoColor;
                Gizmos.DrawSphere(transform.position,radius);
            }
        }
    }
}