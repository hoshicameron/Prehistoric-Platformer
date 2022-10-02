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
                agent.TransitionToState(agent.StateFactory.GetState(StateType.Jump));
            }
        }

        protected virtual void HandleMovement(Vector2 input)
        {

        }

        protected virtual void HandleAttack()
        {
            TestAttackTransition();
        }

        protected virtual void TestAttackTransition()
        {
            if (agent.agentWeapon.CanIUseWeapon(agent.GroundDetector.isGrounded))
            {
                agent.TransitionToState(agent.StateFactory.GetState(StateType.Attack));
            }
        }

        public virtual void StateUpdate(){}

        public virtual void StateFixedUpdate()
        {
            TestFallState();
        }
        protected bool TestFallState()
        {
            if (!agent.GroundDetector.isGrounded)
            {
                agent.TransitionToState(agent.StateFactory.GetState(StateType.Fall));
                return true;
            }

            return false;
        }
        
        public virtual  void GetHit()
        {
            agent.TransitionToState(agent.StateFactory.GetState(StateType.GetHit));
        }

        public virtual void Die()
        {
            agent.TransitionToState(agent.StateFactory.GetState(StateType.Die));
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