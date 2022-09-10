using UnityEngine;
using UnityEngine.Events;

namespace PrehistoricPlatformer.StatePattern
{
    public abstract class State:MonoBehaviour
    {
        protected Agent.Agent agent;
        public UnityEvent OnEnter, OnExit;

        public void InitializeState(Agent.Agent agent)
        {
            this.agent = agent;
        }

        public void Enter()
        {
            agent.agentInput.OnAttack += HandleAttack;
            agent.agentInput.OnMovement += HandleMovement;
            agent.agentInput.OnJumpPressed += HandleJumpPressed;
            agent.agentInput.OnJumpReleased += HandleJumpReleased;
            agent.agentInput.OnWeaponChange += HandleWeaponChange;

            OnEnter?.Invoke();
            EnterState();

        }

        protected virtual void EnterState(){}
        protected virtual void HandleWeaponChange(){}
        protected virtual void HandleJumpReleased(){}

        protected virtual void HandleJumpPressed(){}

        protected virtual void HandleMovement(Vector2 input){}

        protected virtual void HandleAttack(){}
        protected virtual void StateUpdate(){}

        public void Exit()
        {
            agent.agentInput.OnAttack -= HandleAttack;
            agent.agentInput.OnMovement -= HandleMovement;
            agent.agentInput.OnJumpPressed -= HandleJumpPressed;
            agent.agentInput.OnJumpReleased -= HandleJumpReleased;
            agent.agentInput.OnWeaponChange -= HandleWeaponChange;

            OnExit?.Invoke();
            ExitState();
        }

        protected virtual void ExitState(){}
    }
}