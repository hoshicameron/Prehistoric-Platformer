using System;
using PrehistoricPlatformer.Agents;
using PrehistoricPlatformer.Utilities;
using UnityEngine;

namespace PrehistoricPlatformer.Pickables
{
    public abstract class Pickable : MonoBehaviour
    {
        protected SpriteRenderer spriteRenderer;
        [SerializeField] private BoxCollider2D col;

        [SerializeField] protected Color gizmoColor = Color.magenta;

        private void Awake()
        {
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            if(col == null)    TryGetComponent<BoxCollider2D>(out col);
        }

        public abstract void PickUp(Agent agent);

        private void OnTriggerEnter2D(Collider2D col)
        {
            if(!col.CompareTag(GameConstants.PlayerTag))    return;
            
            PickUp(col.gameObject.GetComponent<Agents.Agent>());
            Destroy(gameObject);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = gizmoColor;
            Gizmos.DrawCube(col.bounds.center,col.bounds.size);
        }
    }
}