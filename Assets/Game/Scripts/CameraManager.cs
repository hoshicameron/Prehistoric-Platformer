using System;
using Cinemachine;
using UnityEngine;

namespace PrehistoricPlatformer
{
    public class CameraManager:MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera cm_Vcam;

        private void Awake()
        {
            if(cm_Vcam ==null)
                cm_Vcam = FindObjectOfType<CinemachineVirtualCamera>();
        }

        public void SetCameraTarget(Transform playerTransform)
        {
            cm_Vcam.Follow = playerTransform;
            cm_Vcam.LookAt = playerTransform;
        }
    }
}