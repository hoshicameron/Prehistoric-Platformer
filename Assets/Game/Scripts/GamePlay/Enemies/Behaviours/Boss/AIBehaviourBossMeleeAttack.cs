using UnityEngine;

namespace PrehistoricPlatformer.AI
{
    public class AIBehaviourBossMeleeAttack : AIBehaviour
    {
        [SerializeField] private AIDataBoard aiBoard;
        public override void PerformAction(AIEnemy enemyAI)
        {
            enemyAI.MovementVector=Vector2.zero;
            enemyAI.CallAttack();
            
            aiBoard.SetBoard(AIDataTypes.Arrived,true);
            aiBoard.SetBoard(AIDataTypes.Waiting,true);
        }
    }
}