using System;
using UnityEngine;

namespace PrehistoricPlatformer.WeaponSystem
{

    public abstract class WeaponData : ScriptableObject,IEquatable<WeaponData>
    {
        public Sprite weaponSprite;
        public string weaponName;
        public int weaponDamage = 1;
        public AudioClip weaponSwingSound;

        public abstract bool CanBeUsed(bool isGrounded);
        public abstract void PerformAttack(Agents.Agent agent, LayerMask hittableMask, Vector3 direction);

        public bool Equals(WeaponData other)
        {
            if (ReferenceEquals(null, other)) return false;

            return string.Equals(weaponName, other.weaponName);
        }

        public virtual void DrawWeaponGizmo(Vector3 origin, Vector3 direction)
        {

        }
    }// calss
}// namespace