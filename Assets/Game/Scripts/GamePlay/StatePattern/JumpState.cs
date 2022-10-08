using PrehistoricPlatformer.Agents;
using UnityEngine;

namespace PrehistoricPlatformer.StatePattern
{
    public class JumpState:MovementState
    {
        private bool jumpPressed = false;

        protected override void EnterState()
        {
            agent.AgentAnimation.PlayAnimation(AnimationType.Jump);

            movementData.currentVelocity = agent.Rb2D.velocity;
            movementData.currentVelocity.y = agent.AgentData.jumpForce;
            agent.Rb2D.velocity = movementData.currentVelocity;

            jumpPressed = true;
        }

        protected override void HandleJumpPressed()
        {
            jumpPressed = true;
        }

        protected override void HandleJumpReleased()
        {
            jumpPressed = false;
        }

        public override void StateFixedUpdate()
        {
            ControlJumpHeight();
            CalculateVelocity();
            SetAgentVelocity();

            if (agent.Rb2D.velocity.y <= 0)
            {
                agent.TransitionToState(agent.StateFactory.GetState(StateType.Fall));
            }
            else if(agent.ClimbingDetector.CanClimb &&  Mathf.Abs(agent.AgentInput.MovementVector.y) > 0)
            {
                agent.TransitionToState(agent.StateFactory.GetState(StateType.Climbing));
            }
        }

        private void ControlJumpHeight()
        {
            if (!jumpPressed)
            {
                movementData.currentVelocity = agent.Rb2D.velocity;
                movementData.currentVelocity.y += agent.AgentData.lowJumpMultiplier * Physics2D.gravity.y * Time.fixedDeltaTime;
                agent.Rb2D.velocity = movementData.currentVelocity;
            }
        }
    }// class
}// namespace