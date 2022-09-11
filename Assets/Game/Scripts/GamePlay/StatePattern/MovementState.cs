using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using PrehistoricPlatformer.Agent;
using UnityEngine;

namespace PrehistoricPlatformer.StatePattern
{
    public class MovementState:State
    {
        [SerializeField] protected MovementData movementData;
        [SerializeField] protected State idleState;

        public float acceleration, deacceleration, maxSpeed;
        private void Awake()
        {
            movementData = GetComponentInParent<MovementData>();
        }

        protected override void EnterState()
        {
            agent.agentAnimation.PlayAnimation(AnimationType.Run);

            movementData.horizontalMovementDirection = 0;
            movementData.currentSpeed = 0f;
            movementData.currentVelocity = Vector2.zero;
        }

        public override void StateFixedUpdate()
        {
            if(TestFallState())    return;

            CalculateVelocity();
            SetAgentVelocity();
            if (Mathf.Abs(agent.rb2d.velocity.x) < 0.01f)
            {
                agent.TransitionToState(idleState);
            }
        }
        protected void CalculateVelocity()
        {
            CalculateSpeed(agent.agentInput.MovementVector, movementData);
            CalculateHorizontalDirection(movementData);
            movementData.currentVelocity =
                Vector2.right * movementData.horizontalMovementDirection * movementData.currentSpeed;
            movementData.currentVelocity.y = agent.rb2d.velocity.y;
        }

        protected void CalculateSpeed(Vector2 movementVector, MovementData movementData)
        {
            if (Mathf.Abs(movementVector.x) > 0)
            {
                movementData.currentSpeed += acceleration * Time.deltaTime;
            } else
            {
                movementData.currentSpeed -= deacceleration * Time.deltaTime;
            }

            movementData.currentSpeed = Mathf.Clamp(movementData.currentSpeed, 0, maxSpeed);
        }

        protected void CalculateHorizontalDirection(MovementData movementData)
        {
            if (agent.agentInput.MovementVector.x > 0)
            {
                movementData.horizontalMovementDirection = 1;
            }
            else if (agent.agentInput.MovementVector.x < 0)
            {
                movementData.horizontalMovementDirection = -1;
            }
        }

        protected void SetAgentVelocity()
        {
            agent.rb2d.velocity = movementData.currentVelocity;
        }


    }// class
}// namespace