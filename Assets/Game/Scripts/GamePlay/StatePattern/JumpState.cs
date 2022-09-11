using PrehistoricPlatformer.Agent;
using UnityEngine;

namespace PrehistoricPlatformer.StatePattern
{
    public class JumpState:MovementState
    {
        public float jumpForce;
        public float lowJumpMultiplier = 2;

        private bool jumpPressed = false;
        protected override void EnterState()
        {
            agent.agentAnimation.PlayAnimation(AnimationType.Jump);

            movementData.currentVelocity = agent.rb2d.velocity;
            movementData.currentVelocity.y = jumpForce;
            agent.rb2d.velocity = movementData.currentVelocity;

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

            if (agent.rb2d.velocity.y <= 0)
            {
                agent.TransitionToState(fallState);
            }
        }

        private void ControlJumpHeight()
        {
            if (!jumpPressed)
            {
                movementData.currentVelocity = agent.rb2d.velocity;
                movementData.currentVelocity.y += lowJumpMultiplier * Physics2D.gravity.y * Time.fixedDeltaTime;
                agent.rb2d.velocity = movementData.currentVelocity;
            }
        }
    }// class
}// namespace