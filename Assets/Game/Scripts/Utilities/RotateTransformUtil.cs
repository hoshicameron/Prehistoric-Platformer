using UnityEngine;

namespace PrehistoricPlatformer.Utilities
{
    public class RotateTransformUtil : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed = 1;
        
        public void Fly(Vector2 movementDirection)
        {
            transform.rotation *= 
                Quaternion.Euler(0, 0, Time.deltaTime * rotationSpeed * -movementDirection.x);
        }
    }
}