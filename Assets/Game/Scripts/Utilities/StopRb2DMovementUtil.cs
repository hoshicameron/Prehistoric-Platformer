using System;
using UnityEngine;

namespace PrehistoricPlatformer.Utilities
{
    public class StopRBb2DMovementUtil : MonoBehaviour
    {
        private Rigidbody2D rb2d;

        private void Awake()
        {
            TryGetComponent<Rigidbody2D>(out rb2d);
        }

        public void StopMovement()
        {
            rb2d.velocity=Vector2.zero;
        }
    }
}