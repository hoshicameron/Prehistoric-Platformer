using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using PrehistoricPlatformer.Agents;
using UnityEngine;
using UnityEngine.Events;

namespace PrehistoricPlatformer.StatePattern
{
    public class MovementState:State
    {
        [SerializeField] protected MovementData movementData;


        [field:SerializeField]
        private UnityEvent OnStep { get; set; }

        private void Awake()
        {
            movementData = GetComponentInParent<MovementData>();
        }

        protected override void EnterState()
        {
            agent.AgentAnimation.PlayAnimation(AnimationType.Run);
            agent.AgentAnimation.OnAnimationAction.AddListener(()=>OnStep?.Invoke());

            movementData.horizontalMovementDirection = 0;
            movementData.currentSpeed = 0f;
            movementData.currentVelocity = Vector2.zero;
        }

        public override void StateFixedUpdate()
        {
            if(TestFallState())    return;

            CalculateVelocity();
            SetAgentVelocity();
            if (Mathf.Abs(agent.Rb2D.velocity.x) < 0.01f)
            {
                agent.TransitionToState(agent.StateFactory.GetState(StateType.Idle));
            }
        }
        protected void CalculateVelocity()
        {
            CalculateSpeed(agent.AgentInput.MovementVector, movementData);
            CalculateHorizontalDirection(movementData);
            movementData.currentVelocity =
                Vector2.right * movementData.horizontalMovementDirection * movementData.currentSpeed;
            movementData.currentVelocity.y = agent.Rb2D.velocity.y;
        }

        protected void CalculateSpeed(Vector2 movementVector, MovementData movementData)
        {
            if (Mathf.Abs(movementVector.x) > 0)
            {
                movementData.currentSpeed += agent.AgentData.acceleration * Time.deltaTime;
            } else
            {
                movementData.currentSpeed -= agent.AgentData.deacceleration * Time.deltaTime;
            }

            movementData.currentSpeed = Mathf.Clamp(movementData.currentSpeed, 0, agent.AgentData.maxSpeed);
        }

        protected void CalculateHorizontalDirection(MovementData movementData)
        {
            if (agent.AgentInput.MovementVector.x > 0)
            {
                movementData.horizontalMovementDirection = 1;
            }
            else if (agent.AgentInput.MovementVector.x < 0)
            {
                movementData.horizontalMovementDirection = -1;
            }
        }

        protected void SetAgentVelocity()
        {
            agent.Rb2D.velocity = movementData.currentVelocity;
        }

        protected override void ExitState()
        {
            agent.AgentAnimation.ResetEvents(); // this will not remove callbacks that added from Inspector
        }
    }// class
}// namespace