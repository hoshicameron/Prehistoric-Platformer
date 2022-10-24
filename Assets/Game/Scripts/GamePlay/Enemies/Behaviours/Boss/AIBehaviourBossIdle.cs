using UnityEngine;

namespace PrehistoricPlatformer.AI
{
    public class AIBehaviourBossIdle : AIBehaviour
    {
        public override void PerformAction(AIEnemy enemyAI)
        {
            enemyAI.CallOnMovement(Vector2.zero);
            enemyAI.MovementVector = Vector2.zero;
            
        }
    }
}