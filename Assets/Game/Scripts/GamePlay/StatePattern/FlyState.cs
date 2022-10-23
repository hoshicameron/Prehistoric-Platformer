using UnityEngine;

namespace PrehistoricPlatformer.StatePattern
{
    public class FlyState : MovementState
    {
        protected Vector2 movementDirection;
        
        public override void StateFixedUpdate()
        {
            CalculateVelocity();
            SetAgentVelocity();
            
            /*if (Mathf.Abs(agent.Rb2D.velocity.x) < 0.01f)
            {
                agent.TransitionToState(agent.StateFactory.GetState(StateType.Idle));
            }*/
        }
        
        protected new void CalculateVelocity()
        {
            CalculateSpeed(agent.AgentInput.MovementVector, movementData);
            CalculateHorizontalDirection(movementData);
            movementData.currentVelocity = movementDirection * movementData.currentSpeed;
        }

        protected new void CalculateSpeed(Vector2 movementVector, MovementData movementData)
        {
            movementDirection = movementVector.normalized;
            if (Mathf.Abs(movementVector.magnitude) > 0)
            {
                movementData.currentSpeed += agent.AgentData.acceleration * Time.deltaTime;
            } else
            {
                movementData.currentSpeed -= agent.AgentData.deacceleration * Time.deltaTime;
            }

            movementData.currentSpeed = Mathf.Clamp(movementData.currentSpeed, 0, agent.AgentData.maxSpeed);
        }
    }
}