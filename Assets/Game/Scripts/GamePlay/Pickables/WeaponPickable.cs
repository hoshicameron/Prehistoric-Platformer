using System;
using PrehistoricPlatformer.Agents;
using PrehistoricPlatformer.WeaponSystem;
using UnityEngine;

namespace PrehistoricPlatformer.Pickables
{
    public class WeaponPickable : Pickable
    {
        [SerializeField] private WeaponData weaponData;

        private void Start()
        {
            spriteRenderer.sprite = weaponData.weaponSprite;
        }

        public override void PickUp(Agent agent)
        {
            agent.PickUp(weaponData);
        }
    }
}