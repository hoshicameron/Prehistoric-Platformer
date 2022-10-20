using System;
using PrehistoricPlatformer.LevelManagement;
using UnityEngine;
using UnityEngine.Events;

namespace PrehistoricPlatformer.Player
{
    public class PlayerPoints : MonoBehaviour , ISaveData
    {
        [SerializeField] private UnityEvent<int> OnPointsValueChange;
        [SerializeField] private UnityEvent OnPickUpPoints;

        public int Points { get; private set; } = 0;

        private void OnEnable()
        {
            OnPointsValueChange?.Invoke(Points);
        }

        public void AddPoint(int amount)
        {
            Points += amount;
            OnPickUpPoints?.Invoke();
            OnPointsValueChange?.Invoke(Points);
        }

        public void SaveData()
        {
            SaveSystem.SavePoints(Points);
        }

        public void LoadData()
        {
            Points = SaveSystem.LoadPoints();
            OnPointsValueChange?.Invoke(Points);
        }
    }
}