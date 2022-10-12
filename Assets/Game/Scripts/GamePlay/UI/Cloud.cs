using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PrehistoricPlatformer.UI
{
    public class Cloud : MonoBehaviour
    {
        [SerializeField] private float minScale = 1f, maxScale = 1.5f;

        [field: SerializeField] public float Speed { get; set; } = 70;

        [SerializeField] private event Action OnOutsideScreen;
        [SerializeField] private float outsideScreenDistance;

        private void Update()
        {
            transform.position += Vector3.right * (Time.deltaTime * Speed);
            if (Vector2.Distance(transform.parent.position, transform.position) > outsideScreenDistance)
            {
                OnOutsideScreen?.Invoke();
                Destroy(gameObject);
            }
        }

        public float GetCloudScale()
        {
            return Random.Range(minScale, maxScale);
        }

        public void Initialize(float distance, Action onOutsideScreenHandler)
        {
            outsideScreenDistance = distance;
            OnOutsideScreen += onOutsideScreenHandler;
        }
    }
}