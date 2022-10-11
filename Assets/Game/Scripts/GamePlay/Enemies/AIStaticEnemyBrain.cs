using System;
using PrehistoricPlatformer.Agents;
using UnityEngine;

namespace PrehistoricPlatformer.AI
{
    public class AIStaticEnemyBrain : AIEnemy
    {
        [SerializeField] private AIBehaviour attackBehaviour;

        private void FixedUpdate()
        {
            attackBehaviour.PerformAction(this);
        }
    }
}