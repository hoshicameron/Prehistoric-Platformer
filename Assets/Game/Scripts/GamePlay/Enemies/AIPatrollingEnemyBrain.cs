using PrehistoricPlatformer.Agents;
using UnityEngine;

namespace PrehistoricPlatformer.AI
{
    public class AIPatrollingEnemyBrain : AIEnemy
    {
        [SerializeField] private GroundDetector groundDetector;
        [SerializeField] private AIBehaviour attackBehaviour, patrolBehaviour;

        private void Awake()
        {
            groundDetector = GetComponentInChildren<GroundDetector>();
        }

        private void FixedUpdate()
        {
            if(!groundDetector.isGrounded)  return;

            attackBehaviour.PerformAction(this);
            patrolBehaviour.PerformAction(this);

        }
    }
}