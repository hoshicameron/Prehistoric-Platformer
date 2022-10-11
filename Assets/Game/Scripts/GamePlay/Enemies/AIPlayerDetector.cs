using System;
using System.Collections;
using UnityEngine;

namespace PrehistoricPlatformer.AI
{
    public class AIPlayerDetector : MonoBehaviour
    {
        [field:SerializeField] public bool PlayerDetected { get; private set; }
        
        [SerializeField] private Transform detectorOrigin;

        [SerializeField] private Vector2 detectorSize;
        [SerializeField] private Vector2 detectorOriginOffset = Vector2.zero;
        [SerializeField] private float detectionDelay = 0.3f;
        [SerializeField] private LayerMask detectionLayerMask;
        
        [Header("Gizmo Parameters")]
        [SerializeField] private Color gizmoIdleColor=Color.green;
        [SerializeField] private Color gizmoDetectedColor = Color.red;
        [SerializeField] private bool showGizmo = true;
        
        
        private GameObject target;
        public GameObject Target
        {
            get => target;
            set
            {
                target = value;
                PlayerDetected = target != null;
            }
        }
        
        public Vector2 DirectionToTarget => target.transform.position - detectorOrigin.position;

        private void Start()
        {
            StartCoroutine(DetectionCoroutine());
        }

        private IEnumerator DetectionCoroutine()
        {
            yield return new WaitForSeconds(detectionDelay);
            var col = 
                Physics2D.OverlapBox((Vector2)detectorOrigin.position + detectorOriginOffset,
                    detectorSize, 0, detectionLayerMask);
            
            Target = col != null ? col.gameObject : null;

            StartCoroutine(DetectionCoroutine());
        }

        private void OnDrawGizmos()
        {
            if(!showGizmo) return;

            Gizmos.color = PlayerDetected ? gizmoDetectedColor : gizmoIdleColor;
            Gizmos.DrawCube((Vector2)detectorOrigin.position+detectorOriginOffset,detectorSize);
        }
    }
}