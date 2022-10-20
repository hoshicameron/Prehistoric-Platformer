using PrehistoricPlatformer.LevelManagement;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace PrehistoricPlatformer.UI
{
    public class ContinueButton : MonoBehaviour
    {
        [SerializeField] private LevelManager sceneManagement;
        [SerializeField] private Button continueButton;

        private int levelIndex = -1;

        [SerializeField] private UnityEvent OnLevelLoaded;

        private void Awake()
        {
            if (sceneManagement == null)
                sceneManagement = FindObjectOfType<LevelManager>();
            continueButton = GetComponent<Button>();
        }

        private void Start()
        {
            levelIndex = SaveSystem.LoadLevelIndex();
            if (levelIndex > -1)
            {
                continueButton.onClick.AddListener(() => sceneManagement.LoadSceneWithIndex(levelIndex));
                continueButton.interactable = true;
                OnLevelLoaded?.Invoke();
            }
        }
    }
}