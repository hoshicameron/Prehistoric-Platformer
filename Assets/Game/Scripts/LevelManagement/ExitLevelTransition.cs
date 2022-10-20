using PrehistoricPlatformer.Utilities;
using UnityEngine;
using UnityEngine.Events;

namespace PrehistoricPlatformer.LevelManagement
{
    public class ExitLevelTransition : MonoBehaviour
    {
        [SerializeField]
        private string inputAxisName = "Vertical";
        [SerializeField]
        private int inputAxisValue = 1;

        private bool playerInRange = false;

        public UnityEvent OnPlayerEnter, OnPlayerExit, OnTransition;

        private void Update()
        {
            if (playerInRange)
            {
                if ((int)Input.GetAxisRaw(inputAxisName) >= inputAxisValue)
                {
                    OnTransition?.Invoke();
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag(GameConstants.PlayerTag))
            {
                playerInRange = true;
                OnPlayerEnter?.Invoke();

            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag(GameConstants.PlayerTag))
            {
                OnPlayerExit?.Invoke();
            }
        }
    }
}