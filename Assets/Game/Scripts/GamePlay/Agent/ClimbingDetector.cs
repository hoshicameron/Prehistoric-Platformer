using UnityEngine;

namespace PrehistoricPlatformer.Agents
{
    public class ClimbingDetector:MonoBehaviour
    {
        [SerializeField] public LayerMask climbingLayerMask;

        [field:SerializeField]
        public bool CanClimb { get; private set; }

        private void OnTriggerEnter2D(Collider2D other)
        {
            LayerMask collisionLayerMask = 1 << other.gameObject.layer; // Create layer mask from collision game object layer

            if ((collisionLayerMask & climbingLayerMask) != 0)
            {
                CanClimb = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            LayerMask collisionLayerMask = 1 << other.gameObject.layer; // Create layer mask from collision game object

            if ((collisionLayerMask & climbingLayerMask) != 0)
            {
                CanClimb = false;
            }
        }
    }// class
}// namespace