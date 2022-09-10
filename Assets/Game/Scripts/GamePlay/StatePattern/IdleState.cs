using PrehistoricPlatformer.Agent;
using UnityEngine;

namespace PrehistoricPlatformer.StatePattern
{
    public class IdleState:State
    {
        public State moveState;
        protected override void EnterState()
        {
            agent.agentAnimation.PlayAnimation(AnimationType.Idle);
        }

        protected override void HandleMovement(Vector2 input)
        {
            if (Mathf.Abs(input.x) > 0)
            {
                agent.TransitionToState(moveState, this);
            }
        }
    }

}