using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PrehistoricPlatformer.WeaponSystem
{
    public class AgentWeaponManager:MonoBehaviour
    {
        private SpriteRenderer spriteRenderer;

        private WeaponStorage weaponStorage;

        public UnityEvent<Sprite> OnWeaponSwap;
        public UnityEvent OnMultipleWeapons;
        public UnityEvent OnWeaponPickup;

        private void Awake()
        {
            weaponStorage=new WeaponStorage();
            TryGetComponent<SpriteRenderer>(out spriteRenderer);
            ToggleWeaponVisibility(false);
        }

        public void ToggleWeaponVisibility(bool value)
        {
            if (value)
            {
                SwapWeaponSprite(GetCurrentWeapon().weaponSprite);
            }

            spriteRenderer.enabled = value;
        }

        public WeaponData GetCurrentWeapon()
        {
            return weaponStorage.GetCurrentWeapon();
        }

        private void SwapWeaponSprite(Sprite weaponSprite)
        {
            spriteRenderer.sprite = weaponSprite;
            OnWeaponSwap?.Invoke(weaponSprite);
        }

        public void SwapWeapon()
        {
            if(weaponStorage.WeaponCount<=1)    return;
            
            SwapWeaponSprite(weaponStorage.SwapWeapon().weaponSprite);
        }

        public void AddWeaponData(WeaponData weaponData)
        {
            if(!weaponStorage.AddWeaponData(weaponData))    return;

            if(weaponStorage.WeaponCount==2)    OnMultipleWeapons?.Invoke();

            SwapWeaponSprite(weaponData.weaponSprite);
        }

        public void PickupWeapon(WeaponData weaponData)
        {
            AddWeaponData(weaponData);
            OnWeaponPickup?.Invoke();
        }

        public bool CanIUseWeapon(bool isGrounded)
        {
            return weaponStorage.WeaponCount <= 0 ?
                false : weaponStorage.GetCurrentWeapon().CanBeUsed(isGrounded);
        }

        public List<string> GetPlayerWeaponNames()
        {
            return weaponStorage.GetPlayerWeaponNames();
        }
    }
}