using System.Collections.Generic;
using System.Linq;

namespace PrehistoricPlatformer.WeaponSystem
{
    public class WeaponStorage
    {
        private List<WeaponData> weaponDataList = new List<WeaponData>();
        private int currentWeaponIndex = -1;

        public int WeaponCount => weaponDataList.Count;

        public WeaponData GetCurrentWeapon()
        {
            return currentWeaponIndex == -1 ? null : weaponDataList[currentWeaponIndex];
        }
        public WeaponData SwapWeapon()
        {
            if (currentWeaponIndex == -1) return null;

            currentWeaponIndex = (currentWeaponIndex + 1) % (weaponDataList.Count-1);
            return weaponDataList[currentWeaponIndex];
        }

        public bool AddWeaponData(WeaponData weaponData)
        {
            if(weaponDataList.Contains(weaponData))    return false;

            weaponDataList.Add(weaponData);
            currentWeaponIndex = weaponDataList.Count - 1;

            return true;
        }

        public List<string> GetPlayerWeaponNames()
        {
            return weaponDataList.Select(weapon => weapon.weaponName).ToList();
        }
    }
}