using System;
using System.Collections;
using PrehistoricPlatformer.WeaponSystem;
using UnityEngine;

namespace PrehistoricPlatformer.Feedback
{
    public class HittableTempImmortality : MonoBehaviour,IHittable
    {
        [SerializeField] private float immortalityTime = 1.0f;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private float flashDelay = .1f;
        [Range(0f,1f)]
        [SerializeField] private float flashAlpha = .5f;
        [Header("For Debug Purpose")] [SerializeField]
        private bool isImmortal = false;
        
        private Collider2D[] colliders=Array.Empty<Collider2D>();

        private void Awake()
        {
            if (colliders.Length == 0)
                colliders = GetComponents<Collider2D>();
        }

        public void GetHit(GameObject agentGameObject, int weaponDamage)
        {
            if(this.enabled==false) return;
            
            ToggleColliders(false);
            StartCoroutine(ResetColliders());
            StartCoroutine(Flash(flashAlpha));
        }

        private void ToggleColliders(bool val)
        {
            isImmortal = !val;
            foreach (Collider2D col in colliders)
            {
                col.enabled = val;
            }
        }

        private IEnumerator Flash(float alpha)
        {
            alpha = Mathf.Clamp01(alpha);
            ChangeSpriteRendererColorAlpha(alpha);
            yield return new WaitForSeconds(flashDelay);
            StartCoroutine(Flash(alpha < 1 ? 1 : flashAlpha));
        }

        private IEnumerator ResetColliders()
        {
            yield return new WaitForSeconds(immortalityTime);
            StopAllCoroutines();
            ToggleColliders(true);
            ChangeSpriteRendererColorAlpha(1);
        }

        private void ChangeSpriteRendererColorAlpha(float alpha)
        {
            Color color = spriteRenderer.color;
            color.a = alpha;
            spriteRenderer.color = color;
        }
    }
}