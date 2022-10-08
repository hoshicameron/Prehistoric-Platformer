using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace PrehistoricPlatformer.Animation
{
    public class HooverAnimation : MonoBehaviour
    {
        [SerializeField] private float movementDistance = .5f;
        [SerializeField] private float animationDuration = 1.0f;
        [SerializeField] private Ease animationEase;

        private void Start()
        {
            transform
                .DOMoveY(transform.position.y + movementDistance, animationDuration)
                .SetEase(animationEase)
                .SetLoops(-1, LoopType.Yoyo);
        }

        private void OnDisable()
        {
            DOTween.Kill(transform);
        }
    }
}
