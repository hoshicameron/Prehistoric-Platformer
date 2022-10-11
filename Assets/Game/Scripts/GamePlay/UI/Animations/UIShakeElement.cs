using DG.Tweening;
using UnityEngine;

namespace PrehistoricPlatformer.UI
{
    public class UIShakeElement : MonoBehaviour
    {
        [SerializeField] private RectTransform element;
        [Header("Shake animation settings")]
        [SerializeField] private float animationTime = 0.5f, shakeStrength = 90, randomness = 90;
        [SerializeField] private int   vibrato = 90;
        [SerializeField] private bool  fadeOut = true;
        [SerializeField] private float delayBetweenShakes = 3;

        Sequence sequence;

        void Start()
        {
            sequence = DOTween.Sequence()
                .Append(element.DOShakeRotation(animationTime, shakeStrength, vibrato, randomness, fadeOut));
            sequence.SetLoops(-1, LoopType.Restart);
            sequence.AppendInterval(delayBetweenShakes);
            sequence.Play();
        }
        private void OnDestroy()
        {
            sequence.Kill();
        }
    }
}