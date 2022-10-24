using Cinemachine;
using UnityEngine;

namespace PrehistoricPlatformer.Utilities
{
    public class CmCameraConfineUtil : MonoBehaviour
    {
        [SerializeField] private PolygonCollider2D cameraConfiner;
        [SerializeField] private CinemachineConfiner cm_Confiner;

        public void SetConfiner()
        {
            cm_Confiner.m_BoundingShape2D = cameraConfiner;
        }
    }
}