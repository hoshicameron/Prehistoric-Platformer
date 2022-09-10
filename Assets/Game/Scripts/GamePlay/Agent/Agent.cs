using PrehistoricPlatformer.StatePattern;
using UnityEngine;

namespace PrehistoricPlatformer.Agent
{
    public class Agent:MonoBehaviour
    {
        public Rigidbody2D rb2d;
        public AgentInput agentInput;
        public AgentAnimation agentAnimation;
        public AgentRenderer agentRenderer;

        private void Awake()
        {
            TryGetComponent<Rigidbody2D>(out rb2d);
            agentInput = GetComponentInParent<AgentInput>();
            agentAnimation = GetComponentInChildren<AgentAnimation>();
            agentRenderer = GetComponentInChildren<AgentRenderer>();

        }

        private void OnEnable()
        {
            agentInput.OnMovement += HandleMovement;
            agentInput.OnMovement += agentRenderer.faceDirection;
        }

        private void OnDisable()
        {
            agentInput.OnMovement -= HandleMovement;
            agentInput.OnMovement -= agentRenderer.faceDirection;
        }

        public void HandleMovement(Vector2 input)
        {
            if (Mathf.Abs(input.x) > 0)
            {
                if (Mathf.Abs(rb2d.velocity.x) < 0.01f)
                {
                    agentAnimation.PlayAnimation(AnimationType.Run);
                }
                rb2d.velocity = new Vector2(input.x*5,rb2d.velocity.y);
            } else
            {
                if (Mathf.Abs(rb2d.velocity.x) > 0f)
                {
                    agentAnimation.PlayAnimation(AnimationType.Idle);
                }
                rb2d.velocity = new Vector2(0,rb2d.velocity.y);
            }
        }

        public void TransitionToState(State desireState, State callingState)
        {

        }
    }// class
}// namespace