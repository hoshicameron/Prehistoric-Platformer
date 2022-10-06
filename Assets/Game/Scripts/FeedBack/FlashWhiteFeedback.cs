using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrehistoricPlatformer.Feedback
{
    public class FlashWhiteFeedback : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private float feedbackTime = .1f;
        private static readonly int MakeColorSolid = Shader.PropertyToID("_MakeColorSolid");

        public void PlayFeedback()
        {
            if(spriteRenderer==null || !spriteRenderer.material.HasProperty("_MakeColorSolid"))
                return;

            ToggleMaterial(1);
            StopAllCoroutines();
            StartCoroutine(ResetColor());
        }

        private void ToggleMaterial(int value)
        {
            value = Mathf.Clamp(value,0,1);
            print(value);
            spriteRenderer.material.SetInt(MakeColorSolid,value);
        }

        private IEnumerator ResetColor()
        {
            yield return new WaitForSeconds(feedbackTime);
            ToggleMaterial(0);
        }
    }
}
