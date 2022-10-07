using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PrehistoricPlatformer.Agent
{
    public class PlayerInput : MonoBehaviour, IAgentInput
    {
        [field:SerializeField]
        public Vector2 MovementVector { get; private set; }
        public event Action OnAttack;
        public event Action OnJumpPressed;
        public event Action OnJumpReleased;
        public event Action OnWeaponChange;
        public event Action<Vector2> OnMovement;
        public KeyCode jumpKey, AttackKey,swapWeaponKey, menuKey;

        public UnityEvent OnMenuKeyPressed;

        private void Update()
        {
            if (Time.timeScale > 0)
            {
                GetMovementInput();
                GetJumpInput();
                GetAttackInput();
                GetWeaponSwapInput();
            }

            GetMenuInput();
        }

        private void GetMovementInput()
        {
            MovementVector = GetMovementVector();
            OnMovement?.Invoke(MovementVector);
        }

        private Vector2 GetMovementVector()
        {
            return new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        }

        private void GetJumpInput()
        {
            if (Input.GetKeyDown(jumpKey))
            {
                OnJumpPressed?.Invoke();
            }

            if (Input.GetKeyUp(jumpKey))
            {
                OnJumpReleased?.Invoke();
            }
        }

        private void GetAttackInput()
        {
            if (Input.GetKeyDown(AttackKey))
            {
                OnAttack?.Invoke();
            }
        }

        private void GetWeaponSwapInput()
        {
            if (Input.GetKeyDown(swapWeaponKey))
            {
                OnWeaponChange?.Invoke();
            }
        }

        private void GetMenuInput()
        {
            if (Input.GetKeyDown(menuKey))
            {
                OnMenuKeyPressed?.Invoke();
            }
        }
    }//class
}// namespace
