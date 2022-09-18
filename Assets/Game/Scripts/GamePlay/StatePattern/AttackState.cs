using PrehistoricPlatformer.Agent;
using UnityEngine;
using UnityEngine.Events;

namespace PrehistoricPlatformer.StatePattern
{
    public class AttackState:State
    {
        [SerializeField] private LayerMask hittableLayerMask;

        protected Vector2 direction;

        [field: SerializeField] private UnityEvent<AudioClip> OnWeaponSound;
        [SerializeField] private bool showGizmos = false;

        protected override void EnterState()
        {
            agent.AgentAnimation.ResetEvents();
            agent.AgentAnimation.PlayAnimation(AnimationType.Attack);
            agent.AgentAnimation.OnAnimationEnd.AddListener(TransitionToIdleState);
            agent.AgentAnimation.OnAnimationAction.AddListener(PerformAttack);

            agent.agentWeapon.ToggleWeaponVisibility(true);
            direction = agent.transform.right * (agent.transform.localScale.x > 0 ? 1 : -1);
            if(agent.GroundDetector.isGrounded)
                agent.Rb2D.velocity=Vector2.zero;

        }

        private void PerformAttack()
        {
            OnWeaponSound?.Invoke(agent.agentWeapon.GetCurrentWeapon().weaponSwingSound);
            agent.AgentAnimation.OnAnimationAction.RemoveListener(PerformAttack);
            agent.agentWeapon.GetCurrentWeapon().PerformAttack(agent,hittableLayerMask,direction);

        }

        private void TransitionToIdleState()
        {
            agent.AgentAnimation.OnAnimationEnd.RemoveListener(TransitionToIdleState);
            if (agent.GroundDetector.isGrounded)
                agent.TransitionToState(agent.StateFactory.GetState(StateType.Idle));
            else
                agent.TransitionToState(agent.StateFactory.GetState(StateType.Fall));

        }

        protected override void ExitState()
        {
            agent.agentWeapon.ToggleWeaponVisibility(false);
        }

        private void OnDrawGizmos()
        {
            if(Application.isPlaying == false)    return;
            if (showGizmos==false)                return;

            Gizmos.color=Color.red;
            var pos = agent.agentWeapon.transform.position;
            agent.agentWeapon.GetCurrentWeapon().DrawWeaponGizmo(pos,direction);
        }

        protected override void HandleAttack()
        {
            // Prevent attacking
        }

        protected override void HandleJumpPressed()
        {
            // Prevent Jumping
        }

        protected override void HandleJumpReleased()
        {
            // Prevent Jump Release
        }

        protected override void HandleMovement(Vector2 input)
        {
            // Prevent Flipping / Rotation
        }

        public override void StateUpdate()
        {
            // Prevent Update
        }

        public override void StateFixedUpdate()
        {
            // Prevent Fixed Update
        }
    }//class
}//namespace