using UnityEngine;

namespace PrehistoricPlatformer.Player
{
    public class Agent:MonoBehaviour
    {
        public Rigidbody2D rb2d;
        public PlayerInput playerInput;
        public AgentAnimation agentAnimation;

        private void Awake()
        {
            TryGetComponent<Rigidbody2D>(out rb2d);
            playerInput = GetComponentInParent<PlayerInput>();
            agentAnimation = GetComponentInChildren<AgentAnimation>();

        }

        private void OnEnable()
        {
            playerInput.OnMovement += HandleMovement;
        }

        private void OnDisable()
        {
            playerInput.OnMovement -= HandleMovement;
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
    }// class
}// namespace