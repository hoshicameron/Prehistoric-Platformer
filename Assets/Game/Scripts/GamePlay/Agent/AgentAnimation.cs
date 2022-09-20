using System;
using PrehistoricPlatformer.Utilities;
using UnityEngine;
using UnityEngine.Events;

namespace PrehistoricPlatformer.Agent
{
    public class AgentAnimation:MonoBehaviour
    {
        private Animator animator;
        [field:SerializeField]
        public UnityEvent OnAnimationAction { get; set; }
        [field:SerializeField]
        public UnityEvent OnAnimationEnd { get; set; }

        private void Awake()
        {
            TryGetComponent(out animator);
        }

        public void PlayAnimation(AnimationType animationType)
        {
            switch (animationType)
            {
                case AnimationType.Die:
                    Play(GameConstants.DieAnimation);
                    break;
                case AnimationType.Hit:
                    Play(GameConstants.HitAnimation);
                    break;
                case AnimationType.Idle:
                    Play(GameConstants.IdleAnimation);
                    break;
                case AnimationType.Attack:
                    Play(GameConstants.AttackAnimation);
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
                    Play(GameConstants.ClimbAnimation);
                    break;
                case AnimationType.Land:
                    break;
            }
        }

        public void Play(string name)
        {
            animator.Play(name,-1,0f);
        }

        public void StopAnimation()
        {
            animator.enabled = false;
        }

        public void StartAnimation()
        {
            animator.enabled = true;
        }

        public void ResetEvents()
        {
            OnAnimationAction.RemoveAllListeners();
            OnAnimationEnd.RemoveAllListeners();
        }

        public void InvokeAnimationAction()
        {
            OnAnimationAction?.Invoke();
        }

        public void InvokeAnimationEnd()
        {
            OnAnimationEnd?.Invoke();
        }


    }// class
}// namespace