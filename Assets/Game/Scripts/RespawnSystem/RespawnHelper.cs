using UnityEngine;

namespace PrehistoricPlatformer.RespawnSystem
{
    public class RespawnHelper:MonoBehaviour
    {
        private RespawnPointManager manager;

        private void Awake()
        {
            manager = FindObjectOfType<RespawnPointManager>();
        }

        public void RespawnPlayer() => manager.Respawn(gameObject);

        public void ResetPlayer()
        {
            manager.ResetAllSpawnPoint();
            manager.Respawn(gameObject);
        }
    }// class
}// namespace