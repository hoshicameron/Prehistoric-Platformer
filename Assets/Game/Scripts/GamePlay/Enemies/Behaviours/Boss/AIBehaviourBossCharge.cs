using PrehistoricPlatformer.Agents;
using UnityEngine;

namespace PrehistoricPlatformer.AI
{
    public class AIBehaviourBossCharge : AIBehaviour
    {
        [SerializeField] private AIDataBoard aiBoard;
        [SerializeField] private AIPlayerEnterAreaDetector playerDetector;
        [SerializeField] private Agent bossAgent;

        private Vector3 tempPosition;
        private Vector2 direction;

        private bool initialized = false;
        public override void PerformAction(AIEnemy enemyAI)
        {
            if (aiBoard.CheckBoard(AIDataTypes.Arrived))
                initialized = false;

            SetChargeDestination();
            ChargeAtPlayer(enemyAI);

            if (aiBoard.CheckBoard(AIDataTypes.PathBlocked))
            {
                                initialized = false;
                enemyAI.CallOnMovement(MovementVector);
                enemyAI.MovementVector=Vector2.zero;
                aiBoard.SetBoard(AIDataTypes.Waiting,true);
                aiBoard.SetBoard(AIDataTypes.Arrived,true);
            }
        }

        private void ChargeAtPlayer(AIEnemy enemyAI)
        {
            enemyAI.CallOnMovement(direction);
            enemyAI.MovementVector = direction;
        }

        private void SetChargeDestination()
        {
             if(initialized == true)    return;

             tempPosition = new Vector2(playerDetector.Player.transform.position.x, bossAgent.transform.position.y);
             direction = (tempPosition - bossAgent.transform.position).normalized;
             aiBoard.SetBoard(AIDataTypes.Arrived,false);
             initialized = true;
        }
    }
}