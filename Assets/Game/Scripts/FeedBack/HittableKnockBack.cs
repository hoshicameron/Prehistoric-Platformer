using System;
using PrehistoricPlatformer.WeaponSystem;
using UnityEngine;

namespace PrehistoricPlatformer.Feedback
{
    public class HittableKnockBack : MonoBehaviour,IHittable
    {
        [SerializeField] private float force;
        
        private Rigidbody2D rb2d;

        private void Awake()
        {
            TryGetComponent<Rigidbody2D>(out rb2d);
        }

        public void GetHit(GameObject opponent, int weaponDamage)
        {
            Vector2 direction = (transform.position - opponent.transform.position).normalized;
            rb2d.AddForce(new Vector2(direction.x,0) * force , ForceMode2D.Impulse);
            
            
        }
    }
}