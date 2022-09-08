using UnityEngine;

namespace PrehistoricPlatformer.Player
{
    public class Agent:MonoBehaviour
    {
        public Rigidbody2D rb2d;
        public PlayerInput PlayerInput;

        private void Awake()
        {
            rb2d = GetComponent<Rigidbody2D>();
            PlayerInput = GetComponentInParent<PlayerInput>();
        }

        private void OnEnable()
        {
            PlayerInput.OnMovement += HandleMovement;
        }

        private void OnDisable()
        {
            PlayerInput.OnMovement -= HandleMovement;
        }

        public void HandleMovement(Vector2 input)
        {
            if (Mathf.Abs(input.x) > 0)
            {
                rb2d.velocity = new Vector2(input.x*5,rb2d.velocity.y);
            } else
            {
                rb2d.velocity = new Vector2(0,rb2d.velocity.y);
            }
        }
    }// class
}// namespace