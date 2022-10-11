using PrehistoricPlatformer.Agents;
using UnityEngine;

namespace PrehistoricPlatformer.StatePattern
{
    public class IdleState:State
    {

        protected override void EnterState()
        {
            agent.AgentAnimation.PlayAnimation(AnimationType.Idle);
            if(agent.GroundDetector.isGrounded)
                agent.Rb2D.velocity=new Vector2(0,agent.Rb2D.velocity.y);
        }

        public override void StateFixedUpdate()
        {
            if(TestFallState()) return;
            
            if (agent.ClimbingDetector.CanClimb &&  Mathf.Abs(agent.AgentInput.MovementVector.y) > 0)
            {
                agent.TransitionToState(agent.StateFactory.GetState(StateType.Climbing));
            }
            else if (Mathf.Abs(agent.AgentInput.MovementVector.x) > 0)
            {
                agent.TransitionToState(agent.StateFactory.GetState(StateType.Move));
            }
        }

    }// class

}// namespace