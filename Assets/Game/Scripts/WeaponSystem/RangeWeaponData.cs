using PrehistoricPlatformer.Agents;
using Unity.Mathematics;
using UnityEngine;

namespace PrehistoricPlatformer.WeaponSystem
{
    [CreateAssetMenu(fileName = "New Range Weapon Data", menuName = "Weapons/RangeWeaponData")]
    public  class RangeWeaponData:WeaponData
    {
        public float weaponThrowSpeed;
        public GameObject rangeWeaponPrefab;

        public override bool CanBeUsed(bool isGrounded)
        {
            return true;
        }

        public override void PerformAttack(Agent agent, LayerMask hittableMask, Vector3 direction)
        {
            agent.agentWeapon.ToggleWeaponVisibility(false);
            var throwable = Instantiate(rangeWeaponPrefab, agent.agentWeapon.transform.position, quaternion.identity);
            throwable.GetComponent<ThrowableWeapon>().Intialize(this,direction,hittableMask);
        }
    }
}