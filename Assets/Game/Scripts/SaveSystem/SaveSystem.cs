using System.Collections;
using System.Collections.Generic;
using PrehistoricPlatformer.Utilities;
using UnityEngine;

namespace PrehistoricPlatformer.LevelManagement
{
    public class SaveSystem : MonoBehaviour
    {
        public static void SaveGameData(int levelIndexToSave)
        {

            SaveLevel(levelIndexToSave);
            PlayerPrefs.SetInt(GameConstants.SaveDataKey, 1);
        }

        private static void SaveLevel(int levelIndex)
        {
            PlayerPrefs.SetInt(GameConstants.LevelKey, levelIndex);
        }

        public static int LoadLevelIndex()
        {
            if (IsSaveDataPresent())
                return PlayerPrefs.GetInt(GameConstants.LevelKey);
            return -1;
        }

        private static bool IsSaveDataPresent()
        {
            return PlayerPrefs.GetInt(GameConstants.SaveDataKey) == 1;
        }

        public static void SaveWeapons(List<string> weaponNames)
        {
            string data = JsonUtility.ToJson(new PlayerWeapons { playerWeapons = weaponNames });
            PlayerPrefs.SetString(GameConstants.PlayerWeaponsKey, data);
        }
        public static List<string> LoadWeapons()
        {
            if (IsSaveDataPresent())
            {
                string data = PlayerPrefs.GetString(GameConstants.PlayerWeaponsKey);
                if (data.Length > 0)
                {
                    return JsonUtility.FromJson<PlayerWeapons>(data).playerWeapons;
                }
            }
            return null;
        }


        public static void SavePoints(int amount)
        {
            PlayerPrefs.SetInt(GameConstants.PointsKey, amount);
        }

        public static int LoadPoints()
        {
            return PlayerPrefs.GetInt(GameConstants.PointsKey);
        }

        public static void ResetSaveData()
        {
            PlayerPrefs.DeleteKey(GameConstants.PointsKey);
            PlayerPrefs.DeleteKey(GameConstants.PlayerWeaponsKey);
            PlayerPrefs.DeleteKey(GameConstants.LevelKey);
            PlayerPrefs.DeleteKey(GameConstants.SaveDataKey);
        }

        private struct PlayerWeapons
        {
            public List<string> playerWeapons;
        }
    }
}
