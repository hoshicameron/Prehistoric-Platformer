using System;
using System.Collections;
using System.Collections.Generic;
using PrehistoricPlatformer.LevelManagement;
using PrehistoricPlatformer.WeaponSystem;
using UnityEngine;

namespace PrehistoricPlatformer.Player
{
    public class Player : MonoBehaviour,ISaveData
    {
        private WeaponsManager weaponsManager;
        [SerializeField] private AgentWeaponManager playerWeapons;

        private void Awake()
        {
            weaponsManager = FindObjectOfType<WeaponsManager>();

            if (playerWeapons == null)
                playerWeapons = GetComponentInChildren<AgentWeaponManager>();
        }

        public void SaveData()
        {
            var weaponNames = playerWeapons.GetPlayerWeaponNames();
            if(weaponNames !=null && weaponNames.Count>0)
                SaveSystem.SaveWeapons(weaponNames);
        }

        public void LoadData()
        {
            var weaponsName = SaveSystem.LoadWeapons();
            if (weaponsName != null)
            {
                foreach (string name in weaponsName)
                {
                    Debug.Log($"Loading Weapon {name} ");
                    var weapon = weaponsManager.GetWeaponWithName(name);
                    playerWeapons.AddWeaponData(weapon);
                }
            } else
            {
                Debug.Log("No Weapon Data to Load ");
            }
        }
    }
}
