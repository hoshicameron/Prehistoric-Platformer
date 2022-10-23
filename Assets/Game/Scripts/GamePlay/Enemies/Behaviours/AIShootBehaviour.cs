using System;
using System.Collections;
using UnityEngine;

namespace PrehistoricPlatformer.AI
{
    public class AIShootBehaviour : AIBehaviour
    {
        [SerializeField] private AIPlayerDetector playerDetector;
        [SerializeField] private float delay;
        [SerializeField] private bool isWaiting;

        private void Awake()
        {
            if (playerDetector == null)
                playerDetector = GetComponentInChildren<AIPlayerDetector>();
        }

        public override void PerformAction(AIEnemy enemyAI)
        {
            if(isWaiting || playerDetector.PlayerDetected==false)   return;
            
            isWaiting = true;
            enemyAI.CallOnMovement(playerDetector.DirectionToTarget);
            enemyAI.CallAttack();
            
            StartCoroutine(AttackCoroutine());
        }

        private IEnumerator AttackCoroutine()
        {
            yield return new WaitForSeconds(delay);
            isWaiting = false;
        }
    }
}