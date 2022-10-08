using PrehistoricPlatformer.Agents;
using UnityEngine;
using UnityEngine.Events;

namespace PrehistoricPlatformer.Game.Scripts.GamePlay.Agent
{
    public class IsGroundedCheck : MonoBehaviour
    {
        [SerializeField]
        private GroundDetector groundDetector;

        public UnityEvent OnConditionValidAction;

        public void TryPerformingAction()
        {
            if (groundDetector.isGrounded)
            {
                OnConditionValidAction?.Invoke();
            }
        }
    }
}
