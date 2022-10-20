using UnityEngine;
using UnityEngine.SceneManagement;

namespace PrehistoricPlatformer.LevelManagement
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private int level_1BuildIndex, menuBuildIndex, winBuildIndex;

        public void RestartCurrentLevel() => LoadSceneWithIndex(SceneManager.GetActiveScene().buildIndex);

        public void LoadStartLevel() => LoadSceneWithIndex(level_1BuildIndex);

        public void LoadNextLevel() => LoadSceneWithIndex(GetNextLevelIndex());

        public void LoadMenu() => LoadSceneWithIndex(menuBuildIndex);
        public void LoadWinScene() => LoadSceneWithIndex(winBuildIndex);
        

        public void LoadSceneWithIndex(int levelIndex)
        {
            SceneManager.LoadScene(levelIndex);
        }
        public int GetNextLevelIndex()
        {
            int index = SceneManager.GetActiveScene().buildIndex + 1;

            return (index < SceneManager.sceneCountInBuildSettings) ? index : winBuildIndex;
        }

        public void QuitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
            
#endif
        }
    }
}