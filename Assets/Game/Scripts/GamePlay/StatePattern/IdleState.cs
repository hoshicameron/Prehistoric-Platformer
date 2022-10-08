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

        protected override void HandleMovement(Vector2 input)
        {
            if (agent.ClimbingDetector.CanClimb &&  Mathf.Abs(input.y) > 0)
            {
                agent.TransitionToState(agent.StateFactory.GetState(StateType.Climbing));
            }
            else if (Mathf.Abs(input.x) > 0)
            {
                agent.TransitionToState(agent.StateFactory.GetState(StateType.Move));
            }
        }
    }// class

}// namespace