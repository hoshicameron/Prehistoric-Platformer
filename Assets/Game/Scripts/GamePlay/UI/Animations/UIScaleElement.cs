using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;

namespace PrehistoricPlatformer.UI
{
    public class UIScaleElement : MonoBehaviour
    {
        private Sequence sequence;

        [SerializeField] private RectTransform element;
        [SerializeField] private float animationEndScale;
        [SerializeField] private float animationTime;
        private float baseScaleValue;
        private Vector3 baseScale, endScale;
        [SerializeField] private bool playConstantly = false;

        private void Start()
        {
            baseScale = element.localScale;
            
            if(baseScale.magnitude<=0)
                baseScale=Vector3.one;
            
            endScale = Vector3.one * animationEndScale;

            if (playConstantly)
            {
                sequence = DOTween.Sequence()
                    .Append(element.DOScale(baseScale,animationTime))
                    .Append(element.DOScale(endScale,animationTime));
                sequence.SetLoops(-1, LoopType.Yoyo);
                sequence.Play();
            }
        }

        public void PlayAnimation()
        {
            StopAllCoroutines();
            element.localScale = baseScale;
            StartCoroutine(ScaleImage(true));
        }

        private IEnumerator ScaleImage(bool scaleUp)
        {
            float time = 0;
            while (time<animationTime)
            {
                time += Time.deltaTime;
                float value = (time / animationTime);
                Vector3 currentScale;
                if (scaleUp)
                    currentScale = baseScale + value * (endScale - baseScale);
                else
                    currentScale = endScale - value * (endScale - baseScale);

                element.localScale = currentScale;
                yield return null;
            }

            element.localScale = scaleUp ? endScale : baseScale;
            if (playConstantly || scaleUp)
                StartCoroutine(ScaleImage(!scaleUp));
        }

        private void OnDestroy()
        {
            if(sequence!=null)  sequence.Kill();
        }
    }
}