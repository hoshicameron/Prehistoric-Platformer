using System.Collections;
using UnityEngine;

namespace PrehistoricPlatformer.AI
{
    public class AIBehaviourBossWait : AIBehaviour
    {
        [SerializeField] private AIDataBoard aiBoard;
        [SerializeField] private float waitTime = 1.0f;
        public override void PerformAction(AIEnemy enemyAI)
        {
            enemyAI.MovementVector=Vector2.zero;
            StartCoroutine(WaitCoroutine());
        }

        private IEnumerator WaitCoroutine()
        {
            yield return new WaitForSeconds(waitTime);
            aiBoard.SetBoard(AIDataTypes.Waiting,false);
        }
    }
}