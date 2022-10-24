using UnityEngine;

namespace PrehistoricPlatformer.AI
{
    public class AIBossEnemyBrain : AIEnemy
    {
        //public AIBehaviour BossPattern_1;
        [SerializeField] private AIPlayerEnterAreaDetector playerDetector;
        [SerializeField] private AIMeleeAttackDetector meleeRangeDetector;
        [SerializeField] private AIEndPlatformDetector endPlatformDetector;

        [SerializeField] private AIBehaviour IdleBehaviour, ChargeBehaviour, MeleeAttackBehaviour, WaitBehaviour;
        [SerializeField] private AIDataBoard aiBoard;

        private void Update()
        {
            aiBoard.SetBoard(AIDataTypes.PlayerDetected, playerDetector.PlayerInArea);
            aiBoard.SetBoard(AIDataTypes.InMeleeRange, meleeRangeDetector.PlayerDetected);
            aiBoard.SetBoard(AIDataTypes.PathBlocked, endPlatformDetector.PathBlocked);

            if (aiBoard.CheckBoard(AIDataTypes.PlayerDetected))
            {
                if (aiBoard.CheckBoard(AIDataTypes.Waiting))
                {
                    WaitBehaviour.PerformAction(this);
                }
                else
                {
                    if (aiBoard.CheckBoard(AIDataTypes.InMeleeRange))
                    {
                        MeleeAttackBehaviour.PerformAction(this);
                    }
                    else
                    {
                        ChargeBehaviour.PerformAction(this);
                    }
                }
            }
            else
            {
                IdleBehaviour.PerformAction(this);
            }

        }
    }
}