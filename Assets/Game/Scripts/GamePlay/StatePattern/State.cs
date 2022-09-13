using UnityEngine;
using UnityEngine.Events;

namespace PrehistoricPlatformer.StatePattern
{
    public abstract class State:MonoBehaviour
    {
        [SerializeField] protected State jumpState, fallState,climbState;
        protected Agent.Agent agent;
        public UnityEvent OnEnter, OnExit;

        public void InitializeState(Agent.Agent agent)
        {
            this.agent = agent;
        }

        public void Enter()
        {
            agent.AgentInput.OnAttack += HandleAttack;
            agent.AgentInput.OnMovement += HandleMovement;
            agent.AgentInput.OnJumpPressed += HandleJumpPressed;
            agent.AgentInput.OnJumpReleased += HandleJumpReleased;
            agent.AgentInput.OnWeaponChange += HandleWeaponChange;

            OnEnter?.Invoke();
            EnterState();

        }

        protected virtual void EnterState(){}
        protected virtual void HandleWeaponChange(){}
        protected virtual void HandleJumpReleased(){}

        protected virtual void HandleJumpPressed()
        {
            TestJumpTransition();
        }

        private void TestJumpTransition()
        {
            if (agent.GroundDetector.isGrounded )
            {
                agent.TransitionToState(jumpState);
            }
        }

        protected virtual void HandleMovement(Vector2 input)
        {

        }

        protected virtual void HandleAttack(){}

        public virtual void StateUpdate(){}

        public virtual void StateFixedUpdate()
        {
            TestFallState();
        }
        protected bool TestFallState()
        {
            if (!agent.GroundDetector.isGrounded)
            {
                agent.TransitionToState(fallState);
                return true;
            }

            return false;
        }


        public void Exit()
        {
            agent.AgentInput.OnAttack -= HandleAttack;
            agent.AgentInput.OnMovement -= HandleMovement;
            agent.AgentInput.OnJumpPressed -= HandleJumpPressed;
            agent.AgentInput.OnJumpReleased -= HandleJumpReleased;
            agent.AgentInput.OnWeaponChange -= HandleWeaponChange;

            OnExit?.Invoke();
            ExitState();
        }

        protected virtual void ExitState(){}

    }// class
}// namespace