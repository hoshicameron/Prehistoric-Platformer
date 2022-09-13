using PrehistoricPlatformer.Utilities;
using UnityEngine;
using UnityEngine.Events;

namespace PrehistoricPlatformer.RespawnSystem
{
    public class RespawnPoint:MonoBehaviour
    {
        [SerializeField] private GameObject respawnTarget;

        [field:SerializeField] private UnityEvent OnSpawnPointActivated { get; set; }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(GameConstants.PlayerTag))
            {
                respawnTarget = other.gameObject;
                OnSpawnPointActivated?.Invoke();
            }
        }

        public void RespawnPlayer()
        {
            respawnTarget.transform.position = transform.position;
        }

        public void SetPlayerGO(GameObject player)
        {
            respawnTarget = player;
            GetComponent<Collider2D>().enabled = false;
        }

        public void DisableRespawnPoint()
        {
            GetComponent<Collider2D>().enabled = false;
        }

        public void ResetRespawnPoint()
        {
            respawnTarget = null;
            GetComponent<Collider2D>().enabled = true;
        }


    }// class
}// namespace