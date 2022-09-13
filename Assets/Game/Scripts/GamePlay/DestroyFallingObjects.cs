using UnityEngine;

namespace PrehistoricPlatformer
{
    public class DestroyFallingObjects:MonoBehaviour
    {
        [SerializeField] private LayerMask objectToDestroyLayerMask;
        [SerializeField] private Vector2 size;

        [Header("Gizmos")] [SerializeField] private Color gizmoColor = Color.red;
        [SerializeField] private bool showGizmo = true;

        private void FixedUpdate()
        {
            Collider2D collider = Physics2D.OverlapBox(transform.position, size, 0, objectToDestroyLayerMask);
            if (collider != null)
            {
                collider.TryGetComponent<Agent.Agent>(out var agent);
                if (agent == null)
                {
                    Destroy(collider.gameObject);
                    return;
                }

                agent.AgentDie();
            }
        }

        private void OnDrawGizmos()
        {
            if (showGizmo)
            {
                Gizmos.color = gizmoColor;
                Gizmos.DrawCube(transform.position, size);
            }
        }
    }
}