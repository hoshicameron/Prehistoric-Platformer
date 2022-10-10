using System.Collections;
using System.Collections.Generic;
using PrehistoricPlatformer.Agents;
using UnityEngine;
using UnityEngine.Events;

namespace PrehistoricPlatformer.Pickables
{
    public class PointPickable : Pickable
    {
        [SerializeField] private UnityEvent OnPickUp;
        [SerializeField] private int pointsToAdd = 1;
        public override void PickUp(Agent agent)
        {
            agent.PlayerPoints.AddPoint(pointsToAdd);
            OnPickUp?.Invoke(); 
        }
    }
}
