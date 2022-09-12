using PrehistoricPlatformer.Agent;
using UnityEngine;

namespace PrehistoricPlatformer.StatePattern
{
    public class ClimbingState:State
    {
        [SerializeField] protected State idleState;
        private float previousGravity;
        protected override void EnterState()
        {
            agent.agentAnimation.PlayAnimation(AnimationType.Climb);
            agent.agentAnimation.StopAnimation();

            previousGravity = agent.rb2d.gravityScale;

            agent.rb2d.gravityScale = 0;
            agent.rb2d.velocity=Vector2.zero;

        }

        protected override void ExitState()
        {
            agent.rb2d.gravityScale = previousGravity;
        }

        public override void StateFixedUpdate()
        {
            if (agent.agentInput.MovementVector.magnitude > 0)
            {
                agent.agentAnimation.StartAnimation();

                agent.rb2d.velocity = new Vector2(
                    agent.agentInput.MovementVector.x * agent.agentData.ClimbHorizontalSpeed,
                    agent.agentInput.MovementVector.y * agent.agentData.ClimbVerticalSpeed);
            } else
            {
                agent.agentAnimation.StopAnimation();
                agent.rb2d.velocity=Vector2.zero;
            }
            if (!agent.climbingDetector.CanClimb)
            {
                agent.TransitionToState(idleState);
            }
        }
        protected override void HandleJumpPressed()
        {
            agent.TransitionToState(jumpState);
            agent.agentAnimation.StartAnimation();
        }


    }
}