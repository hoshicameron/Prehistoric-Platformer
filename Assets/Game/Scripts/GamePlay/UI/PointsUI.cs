using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace PrehistoricPlatformer.UI
{
    public class PointsUI:MonoBehaviour
    {
        private TextMeshProUGUI pointsText = null;
        [SerializeField] private UnityEvent OnTextChange;

        private void Awake()
        {
            pointsText = GetComponentInChildren<TextMeshProUGUI>();
        }

        private void Start()
        {
            SetPoints(99);
        }

        public void SetPoints(int value)
        {
            OnTextChange?.Invoke();
            pointsText.SetText(value.ToString());
        }
    }
}