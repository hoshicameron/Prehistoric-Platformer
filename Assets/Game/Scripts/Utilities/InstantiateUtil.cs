using UnityEngine;

namespace PrehistoricPlatformer.Utilities
{
    public class InstantiateUtil : MonoBehaviour
    {
        [SerializeField] private GameObject objectToSpawnPrefab;

        public void SpawnObject() 
            => Instantiate(objectToSpawnPrefab, transform.position, Quaternion.identity);
    }
}