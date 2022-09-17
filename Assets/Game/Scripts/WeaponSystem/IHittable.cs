using UnityEngine;

namespace PrehistoricPlatformer.WeaponSystem
{
    public interface IHittable
    {
        void GetHit(GameObject agentGameObject, int weaponDamage);
    }
}