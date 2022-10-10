using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace PrehistoricPlatformer.UI
{
    public class PointsUI:MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI pointsText = null;
        [SerializeField] private UnityEvent OnTextChange;

        public void SetPoints(int value)
        {
            OnTextChange?.Invoke();
            pointsText.SetText(value.ToString());
        }
    }
}