using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PrehistoricPlatformer.AI
{
    public class AIBehaviourPatrol : AIBehaviour
    {
        [SerializeField] private AIEndPlatformDetector changeDirectionDetector;

        private Vector2 movementVector = Vector2.zero;

        private void Awake()
        {
            if (changeDirectionDetector == null)
                changeDirectionDetector = FindObjectOfType<AIEndPlatformDetector>();
        }

        private void Start()
        {
            changeDirectionDetector.OnPathBlocked += HandlePathBlocked;
            movementVector = new Vector2(Random.value > 0.5 ? 1 : -1, 0);
        }

        private void HandlePathBlocked()
        {
            movementVector *= new Vector2(-1, 0);
        }

        public override void PerformAction(AIEnemy enemyAI)
        {
            enemyAI.MovementVector = movementVector;
            enemyAI.CallOnMovement(movementVector);
        }
    }
}