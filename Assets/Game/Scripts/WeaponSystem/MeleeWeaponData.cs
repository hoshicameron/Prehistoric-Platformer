using UnityEngine;

namespace PrehistoricPlatformer.WeaponSystem
{
    [CreateAssetMenu(fileName = "New Melee Weapon Data", menuName = "Weapon/MeleeWeaponData")]
    public class MeleeWeaponData:WeaponData
    {
        public float attackRange = 2.0f;
        public override bool CanBeUsed(bool isGrounded)
        {
            return isGrounded == true;
        }

        public override void PerformAttack(Agent.Agent agent, LayerMask hittableMask, Vector3 direction)
        {
            Debug.Log("Weapon Used:"+weaponName);
            RaycastHit2D hit =
                Physics2D.Raycast(agent.agentWeapon.transform.position, direction, attackRange,hittableMask);
            if (hit.collider != null)
            {
                foreach (var hittable in hit.collider.GetComponents<IHittable>())
                {
                    hittable.GetHit(agent.gameObject, weaponDamage);
                }
            }
        }

        public override void DrawWeaponGizmo(Vector3 origin, Vector3 direction)
        {
            Gizmos.color=Color.red;
            Gizmos.DrawLine(origin,origin+direction * attackRange);
        }
    }
}