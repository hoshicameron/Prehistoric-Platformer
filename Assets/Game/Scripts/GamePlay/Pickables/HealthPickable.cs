using PrehistoricPlatformer.Agents;
using UnityEngine;

namespace PrehistoricPlatformer.Pickables
{
    public class HealthPickable : Pickable
    {
        [SerializeField] private int healthBoost = 1;
        public override void PickUp(Agent agent)
        {
            Damagable damagable = agent.GetComponent<Damagable>();
            
            damagable.AddHealth(healthBoost);
        }
    }
}