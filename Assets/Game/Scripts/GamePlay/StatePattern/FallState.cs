using PrehistoricPlatformer.Agent;
using UnityEngine;

namespace PrehistoricPlatformer.StatePattern
{
    public class FallState:MovementState
    {
        protected override void EnterState()
        {
            agent.agentAnimation.PlayAnimation(AnimationType.Fall);

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
            if (agent.groundDetector.isGrounded)
            {
                agent.TransitionToState(idleState);
            }
            else if(agent.climbingDetector.CanClimb &&  Mathf.Abs(agent.agentInput.MovementVector.y) > 0)
            {
                agent.TransitionToState(climbState);
            }
        }

        private void ControlFallSpeed()
        {
            movementData.currentVelocity = agent.rb2d.velocity;
            movementData.currentVelocity.y += agent.agentData.gravityModifier *Physics2D.gravity.y *  Time.fixedDeltaTime;
            agent.rb2d.velocity = movementData.currentVelocity;
        }
    }
}