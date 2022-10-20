using UnityEngine;

namespace PrehistoricPlatformer.LevelManagement
{
    public class SaveSystemManager : MonoBehaviour
    {
        public void ResetSavedData()
        {
            SaveSystem.ResetSaveData();
        }
    }
}