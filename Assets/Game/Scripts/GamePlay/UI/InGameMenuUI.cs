using PrehistoricPlatformer.LevelManagement;
using UnityEngine;

namespace PrehistoricPlatformer.UI
{
    public class InGameMenuUI : MonoBehaviour
    {
        LevelManager levelManager;
        [SerializeField] private GameObject menuPanel;

        private void Awake()
        {
            levelManager = FindObjectOfType<LevelManager>();
            if (levelManager == null)
                Debug.LogError("No Level Manager found");
        }

        public void ToggleMenu()
        {
            menuPanel.SetActive(!menuPanel.activeSelf);
            Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        }

        public void LoadMenu()
        {
            levelManager.LoadMenu();
        }

        public void RestartLevel()
        {
            levelManager.RestartCurrentLevel();
        }

        public void ResetTimeScale()
        {
            Time.timeScale = 1;
        }
    }
}