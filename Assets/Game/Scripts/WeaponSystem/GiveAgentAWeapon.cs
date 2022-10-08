using System.Collections.Generic;
using UnityEngine;

namespace PrehistoricPlatformer.WeaponSystem
{
    public class GiveAgentAWeapon:MonoBehaviour
    {
        public List<WeaponData> weaponDataList=new List<WeaponData>();

        private void Start()
        {
            Agents.Agent agent = GetComponentInChildren<Agents.Agent>();

            if(agent==null)    return;

            foreach (var weaponData in weaponDataList)
            {
                agent.agentWeapon.AddWeaponData(weaponData);
            }
        }
    }
}