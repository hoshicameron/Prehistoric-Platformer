using UnityEngine;

namespace PrehistoricPlatformer.Utilities
{
    public class DestroyUtil : MonoBehaviour
    {
        public void DestroySelf() => Destroy(gameObject);
        public void DestroyObject(GameObject objectToDestroy) => Destroy(objectToDestroy);
    }
}