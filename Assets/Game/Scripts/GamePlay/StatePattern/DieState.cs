using System.Collections;
using PrehistoricPlatformer.Agents;
using UnityEngine;

namespace PrehistoricPlatformer.StatePattern
{
    public class DieState : State
    {
        public float timeToWaitBeforeRespawn = 2.0F;
        protected override void EnterState()
        {
            agent.AgentAnimation.PlayAnimation(AnimationType.Die);
            agent.AgentAnimation.OnAnimationEnd.AddListener(WaitBeforeDieAction);
            
        }

        private void WaitBeforeDieAction()
        {
            agent.AgentAnimation.OnAnimationEnd.RemoveListener(WaitBeforeDieAction);
            StartCoroutine(WaitCoroutine());
        }

        IEnumerator WaitCoroutine()
        {
            yield return new WaitForSeconds(timeToWaitBeforeRespawn);
            agent.OnAgentDie?.Invoke();
        }

        protected override void ExitState()
        {
            StopAllCoroutines();
            agent.AgentAnimation.ResetEvents();
        }

        protected override void HandleAttack()
        {
            // Prevent Attack
        }

        protected override void HandleMovement(Vector2 input)
        {
            // Prevent Moving
        }

        public override void StateFixedUpdate()
        {
            agent.Rb2D.velocity = new Vector2(0, agent.Rb2D.velocity.y);
        }

        protected override void HandleJumpPressed()
        {
            // Prevent Jump Pressed 
        }

        protected override void HandleJumpReleased()
        {
            // Prevent Jump Released
        }

        protected override void HandleWeaponChange()
        {
            //Prevent Weapon Chenage
        }

        public override void GetHit()
        {
            // Prevent Get Hit
        }
    }
}