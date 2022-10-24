using System;
using System.Collections;
using PrehistoricPlatformer.Utilities;
using UnityEngine;

namespace PrehistoricPlatformer.AI
{
    public class AIEndPlatformDetector:MonoBehaviour
    {
        [SerializeField] private BoxCollider2D detectorCollider;
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private float groundRaycastLength=2f;
        [Range(0f, 1f)] 
        [SerializeField] private float groundRaycastDelay = 0.1f;
        public bool PathBlocked { get; private set; }
        
        public event Action OnPathBlocked;

        [Header("Gizmo Parameters")] 
        [SerializeField] private Color colliderColor = Color.magenta;
        [SerializeField] private Color groundRaycastColor = Color.blue;
        [SerializeField] private bool showGizmos = true;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if(col.gameObject.layer== LayerMask.NameToLayer(GameConstants.ClimbingStuffLayer)
               || col.gameObject.layer== LayerMask.NameToLayer(GameConstants.DefaultLayer))  return;
            Debug.Log(col.name);
            OnPathBlocked?.Invoke();
        }

        private void Start()
        {
            StartCoroutine(CheckGroundCoroutine());
        }

        private IEnumerator CheckGroundCoroutine()
        {
            yield return new WaitForSeconds(groundRaycastDelay);
            var hit = Physics2D.Raycast(detectorCollider.bounds.center, 
                Vector2.down, groundRaycastLength, groundLayer);
            if (hit.collider == null)
            {
                Debug.Log("Routine");
                OnPathBlocked?.Invoke();
            }

            PathBlocked = hit.collider == null;
            StartCoroutine(CheckGroundCoroutine());
        }

        private void OnDrawGizmos()
        {
            if (!showGizmos || detectorCollider == null) return;
            
            Gizmos.color = groundRaycastColor;
            Gizmos.DrawRay(detectorCollider.bounds.center,Vector3.down * groundRaycastLength);
            Gizmos.color = colliderColor;
            Gizmos.DrawCube(detectorCollider.bounds.center,detectorCollider.bounds.size);
        }
    }
}