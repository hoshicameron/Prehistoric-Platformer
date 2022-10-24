using PrehistoricPlatformer.Utilities;
using UnityEngine;

namespace PrehistoricPlatformer.AI
{
    public class AIPlayerEnterAreaDetector : MonoBehaviour
    {
        
        [field: SerializeField]
        public bool PlayerInArea { get; private set; }
        public Transform Player { get; private set; }

        public bool GetDetectorValue()
        {
            return PlayerInArea;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag(GameConstants.PlayerTag))
            {
                PlayerInArea = true;
                Player = collision.gameObject.transform;
            }
            
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag(GameConstants.PlayerTag))
            {
                PlayerInArea = false;
                Player = null;
            }
        }
    }
}