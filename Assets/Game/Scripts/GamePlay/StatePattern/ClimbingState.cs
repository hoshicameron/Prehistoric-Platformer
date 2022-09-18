using PrehistoricPlatformer.Agent;
using UnityEngine;

namespace PrehistoricPlatformer.StatePattern
{
    public class ClimbingState:State
    {
        private float previousGravity;
        protected override void EnterState()
        {
            agent.AgentAnimation.PlayAnimation(AnimationType.Climb);
            agent.AgentAnimation.StopAnimation();

            previousGravity = agent.Rb2D.gravityScale;

            agent.Rb2D.gravityScale = 0;
            agent.Rb2D.velocity=Vector2.zero;

        }

        protected override void HandleAttack()
        {
            // Prevent Attack
        }

        protected override void ExitState()
        {
            agent.Rb2D.gravityScale = previousGravity;
        }

        public override void StateFixedUpdate()
        {
            if (agent.AgentInput.MovementVector.magnitude > 0)
            {
                agent.AgentAnimation.StartAnimation();

                agent.Rb2D.velocity = new Vector2(
                    agent.AgentInput.MovementVector.x * agent.AgentData.ClimbHorizontalSpeed,
                    agent.AgentInput.MovementVector.y * agent.AgentData.ClimbVerticalSpeed);
            } else
            {
                agent.AgentAnimation.StopAnimation();
                agent.Rb2D.velocity=Vector2.zero;
            }
            if (!agent.ClimbingDetector.CanClimb)
            {
                agent.TransitionToState(agent.StateFactory.GetState(StateType.Idle));
            }
        }
        protected override void HandleJumpPressed()
        {
            agent.TransitionToState(agent.StateFactory.GetState(StateType.Jump));
            agent.AgentAnimation.StartAnimation();
        }


    }
}