using PrehistoricPlatformer.WeaponSystem;
using UnityEngine;
using UnityEngine.Events;

namespace PrehistoricPlatformer.Agents
{
    public class Damagable : MonoBehaviour,IHittable
    {
        [SerializeField] private int maxHealth;
        [SerializeField] private int currentHealth;

        
        public int CurrentHealth
        {
            get => currentHealth;
            set
            {
                currentHealth = value;
                OnHealthValueChange?.Invoke(currentHealth);
            }
        }

        [field: SerializeField] public UnityEvent OnGetHit;
        [field: SerializeField] public UnityEvent OnDie;
        [field: SerializeField] public UnityEvent OnAddHealth;
        [field:SerializeField] public UnityEvent<int> OnInitializeMaxHealth;
        [field:SerializeField] public UnityEvent<int> OnHealthValueChange;
        public void GetHit(GameObject agentGameObject, int weaponDamage)
        {
            GetHit(weaponDamage);
        }

        public void GetHit(int weaponDamage)
        {
            CurrentHealth -= weaponDamage;
            if(CurrentHealth<=0)    OnDie?.Invoke();
            else                    OnGetHit?.Invoke();

            
        }

        public void AddHealth(int value)
        {
            CurrentHealth = Mathf.Clamp(CurrentHealth + value, 0, maxHealth);
            OnAddHealth?.Invoke();
        }

        public void Initialize(int health)
        {
            maxHealth = health;
            OnInitializeMaxHealth?.Invoke(maxHealth);
            CurrentHealth = maxHealth;
        }
    }// class 
}// namespace