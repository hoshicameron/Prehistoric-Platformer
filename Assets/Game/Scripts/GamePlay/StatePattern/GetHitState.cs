using PrehistoricPlatformer.Agent;
using UnityEngine.Events;

namespace PrehistoricPlatformer.StatePattern
{
    public class GetHitState: State
    {
        protected override void EnterState()
        {
            agent.AgentAnimation.PlayAnimation(AnimationType.Hit);
            agent.AgentAnimation.OnAnimationEnd.AddListener(TransitionToIdle);
        }

        protected override void HandleAttack()
        {
            //Prevent Attack
        }

        protected override void HandleJumpPressed()
        {
            // Prevent Jumping Pressed
        }

        protected override void HandleJumpReleased()
        {
            // Prevent Jump Released
        }

        public override void StateFixedUpdate()
        {
            //Prevent Fixed Update
        }

        public override void GetHit()
        {
            // Prevent get hit 
        }

        private void TransitionToIdle()
        {
            agent.AgentAnimation.OnAnimationEnd.RemoveListener(TransitionToIdle);
            agent.TransitionToState(agent.StateFactory.GetState(StateType.Idle));
        }
    }
}