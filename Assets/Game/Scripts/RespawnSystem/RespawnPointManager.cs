using System;
using System.Collections.Generic;
using UnityEngine;

namespace PrehistoricPlatformer.RespawnSystem
{
    public class RespawnPointManager:MonoBehaviour
    {
        private List<RespawnPoint> respawnPoints=new List<RespawnPoint>();
        private RespawnPoint currentRespawnPoint;

        private void Awake()
        {
            foreach (Transform item in transform)
            {
                respawnPoints.Add(item.GetComponent<RespawnPoint>());
            }

            currentRespawnPoint = respawnPoints[0];
        }

        public void UpdateRespawnPoint(RespawnPoint newRespawnPoint)
        {
            currentRespawnPoint.DisableRespawnPoint();
            currentRespawnPoint = newRespawnPoint;
        }

        public void Respawn(GameObject objectToRespawn)
        {
            currentRespawnPoint.SetPlayerGO(objectToRespawn);
            currentRespawnPoint.RespawnPlayer();
            objectToRespawn.SetActive(true);
        }

        public void RespawnAt(RespawnPoint spawnPoint, GameObject playerGO)
        {
            spawnPoint.SetPlayerGO(playerGO);
            Respawn(playerGO);
        }

        public void ResetAllSpawnPoint()
        {
            foreach (RespawnPoint spawnPoint in respawnPoints)
            {
                spawnPoint.ResetRespawnPoint();
            }

            currentRespawnPoint=respawnPoints[0];
        }
    }// class
}// namespace