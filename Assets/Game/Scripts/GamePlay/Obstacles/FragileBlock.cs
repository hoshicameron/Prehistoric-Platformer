using System.Collections;
using System.Collections.Generic;
using PrehistoricPlatformer.WeaponSystem;
using UnityEngine;
using UnityEngine.Events;

namespace PrehistoricPlatformer
{
    public class FragileBlock : MonoBehaviour,IHittable
    {
        [field:SerializeField] private UnityEvent OnHit { get; set; }
        public void GetHit(GameObject agentGameObject, int weaponDamage)
        {
            OnHit?.Invoke();
        }

        public void DestroySelf() => Destroy(gameObject);
    }
}
