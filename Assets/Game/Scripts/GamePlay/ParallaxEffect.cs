using UnityEngine;

namespace PrehistoricPlatformer
{
    public class ParallaxEffect:MonoBehaviour
    {
        public Camera mainCamera;
        [Range(0f, 1.0f)] public float speed = 0.3f;

        private void Awake()
        {
            mainCamera = (mainCamera == null) ? Camera.main : mainCamera;
        }

        private void FixedUpdate()
        {
            transform.position = new Vector3(mainCamera.transform.position.x * speed, 0, 0);
        }
    }
}