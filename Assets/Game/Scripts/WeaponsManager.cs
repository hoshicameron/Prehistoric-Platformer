using System.Collections.Generic;
using PrehistoricPlatformer.WeaponSystem;
using UnityEngine;

namespace PrehistoricPlatformer
{
    public class WeaponsManager : MonoBehaviour
    {
        [SerializeField] private List<WeaponData> weaponList;
        [field:SerializeField] private Dictionary<string, WeaponData> weaponDictionary = new Dictionary<string, WeaponData>();

        private void Awake()
        {
            AddToDictionary(weaponList);
        }

        private void AddToDictionary(List<WeaponData> weaponList)
        {
            foreach (WeaponData item in weaponList)
            {
                if (weaponDictionary.ContainsKey(item.name))
                    continue;
                weaponDictionary.Add(item.weaponName, item);
            }
        }

        public WeaponData GetWeaponWithName(string name)
        {
            if (weaponDictionary.ContainsKey(name))
                return weaponDictionary[name];
            return null;
        }
    }
}