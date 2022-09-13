using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace PrehistoricPlatformer.UI
{
    public class LifeElementUI:MonoBehaviour
    {
        private Image image;

        [SerializeField] private UnityEvent OnSpriteChange;

        private void Awake()
        {
            TryGetComponent<Image>(out image);
        }

        public void SetSprite(Sprite sprite)
        {
            if (image.sprite != sprite)
            {
                OnSpriteChange?.Invoke();
                image.sprite = sprite;
            }
        }
    }
}