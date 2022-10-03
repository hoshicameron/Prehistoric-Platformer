using System;
using UnityEngine;

namespace PrehistoricPlatformer.AI
{
    public abstract class AIBehaviour : AIEnemy
    {
        public abstract void PerformAction(AIEnemy enemyAI);
        
    }// class
}// namespace