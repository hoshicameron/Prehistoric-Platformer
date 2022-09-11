using UnityEngine;

namespace PrehistoricPlatformer
{
    [CreateAssetMenu(fileName = "Agent Data", menuName = "Agent/Data", order = 1)]
    public class AgentDataSO : ScriptableObject
    {
        [Header("Move Data")][Space]
        public float acceleration= 50;
        public float deacceleration = 40;
        public float maxSpeed = 6;

        [Header("Jump Data")][Space]
        public float jumpForce = 12;
        public float lowJumpMultiplier = 2;
        public float gravityModifier = 0.5f;

    }
}