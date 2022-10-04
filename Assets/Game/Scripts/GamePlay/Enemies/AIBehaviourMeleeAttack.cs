using System;
using System.Collections;
using UnityEngine;

namespace PrehistoricPlatformer.AI
{
    public class AIBehaviourMeleeAttack : AIBehaviour
    {
        [SerializeField] private AIMeleeAttackDetector meleeAttackDetector;
        [SerializeField] private bool isWaiting;
        [SerializeField] private float delay = 1.0f;
        private void Awake()
        {
            if (meleeAttackDetector == null)
                meleeAttackDetector = FindObjectOfType<AIMeleeAttackDetector>();
        }
        
        public override void PerformAction(AIEnemy enemyAI)
        {
            if(isWaiting || !meleeAttackDetector.PlayerDetected) return;
            
            enemyAI.CallOnAttack();
            isWaiting = true;
            StartCoroutine(AttackCoroutine());
        }
        
        private IEnumerator AttackCoroutine()
        {
            yield return new WaitForSeconds(delay);
            isWaiting = false;
        }
    }
}