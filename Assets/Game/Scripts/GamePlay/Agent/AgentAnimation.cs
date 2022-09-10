using System;
using PrehistoricPlatformer.Utilities;
using UnityEngine;

namespace PrehistoricPlatformer.Agent
{
    public class AgentAnimation:MonoBehaviour
    {
        private Animator animator;

        private void Awake()
        {
            TryGetComponent(out animator);
        }

        public void PlayAnimation(AnimationType animationType)
        {
            switch (animationType)
            {
                case AnimationType.Die:
                    break;
                case AnimationType.Hit:
                    break;
                case AnimationType.Idle:
                    Play(GameConstants.IdleAnimation);
                    break;
                case AnimationType.Attack:
                    break;
                case AnimationType.Run:
                    Play(GameConstants.RunAnimation);
                    break;
                case AnimationType.Jump:
                    Play(GameConstants.JumpAnimation);
                    break;
                case AnimationType.Fall:
                    Play(GameConstants.FallAnimation);
                    break;
                case AnimationType.Climb:
                    break;
                case AnimationType.Land:
                    break;
            }
        }

        public void Play(string name)
        {
            animator.Play(name,-1,0f);
        }


    }// class
}// namespace