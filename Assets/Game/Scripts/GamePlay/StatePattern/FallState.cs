using PrehistoricPlatformer.Agents;
using UnityEngine;
using UnityEngine.Events;

namespace PrehistoricPlatformer.StatePattern
{
    public class FallState:MovementState
    {
        protected override void EnterState()
        {
            agent.AgentAnimation.PlayAnimation(AnimationType.Fall);

        }

        protected override void HandleJumpPressed()
        {
            // Don't Allow jumping in fall State
        }

        public override void StateFixedUpdate()
        {
            ControlFallSpeed();
            CalculateVelocity();
            SetAgentVelocity();
            if (agent.GroundDetector.isGrounded)
            {
                agent.TransitionToState(agent.StateFactory.GetState(StateType.Idle));
            }
            else if(agent.ClimbingDetector.CanClimb &&  Mathf.Abs(agent.AgentInput.MovementVector.y) > 0)
            {
                agent.TransitionToState(agent.StateFactory.GetState(StateType.Climbing));
            }
        }

        private void ControlFallSpeed()
        {
            movementData.currentVelocity = agent.Rb2D.velocity;
            movementData.currentVelocity.y += agent.AgentData.gravityModifier *Physics2D.gravity.y *  Time.fixedDeltaTime;
            agent.Rb2D.velocity = movementData.currentVelocity;
        }
    }
}