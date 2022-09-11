using UnityEngine;

namespace PrehistoricPlatformer.Agent
{
    public class GroundDetector:MonoBehaviour
    {
        public Collider2D agentCollider;
        public LayerMask groundMask;

        public bool isGrounded = false;

        [Header("Gizmo Parameters")] [Range(-2f, 2f)]
        public float boxCastYOffset = -0.01f;
        [Range(-2f, 2f)]
        public float boxCastXOffset = -0.01f;
        [Range(-2f, 2f)] public float boxCastWidth = 1, boxCastHeight = 1;
        public Color gizmoColorIsNotGrounded = Color.red ,gizmoColorIsGrounded = Color.green;

        private void Awake()
        {
            if (agentCollider == null)
            {
                TryGetComponent<Collider2D>(out agentCollider);
            }
        }

        public void CheckIsGrounded()
        {
            RaycastHit2D raycastHit = Physics2D.BoxCast(
                agentCollider.bounds.center + new Vector3(boxCastXOffset, boxCastYOffset, 0),
                new Vector3(boxCastWidth, boxCastHeight, 0), 0, Vector2.down, 0, groundMask
                );

            if (raycastHit.collider != null)
            {
                if(raycastHit.collider.IsTouching(agentCollider))
                    isGrounded = true;
            } else
            {
                isGrounded = false;
            }
        }

        private void OnDrawGizmos()
        {
            if(agentCollider==null)    return;

            Gizmos.color = isGrounded ? gizmoColorIsGrounded : gizmoColorIsNotGrounded;
            Gizmos.DrawWireCube(agentCollider.bounds.center + new Vector3(boxCastXOffset, boxCastYOffset, 0),
                new Vector3(boxCastWidth, boxCastHeight, 0));


        }
    }
}