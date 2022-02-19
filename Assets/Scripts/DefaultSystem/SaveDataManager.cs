using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace DefaultSystem
{
    using Data.VariableData;
    public static class PlayerSaveData
    {
        private readonly static string _saveFileName = $"{Application.persistentDataPath}/savedata.save";
        private static Player _player;
        public static Player GetPlayer => _player;

        public static void Init(string name, int storyCount)
        {
            _player = new Player(name, storyCount);
            Save();
        }

        public static void Save()
        {
            using var file = File.Create(_saveFileName);
            new BinaryFormatter().Serialize(file, _player);
        }

        /// <summary>
        /// 게임 데이터가 있으면 Load 합니다.
        /// </summary>
        public static bool Load()
        {
            if (File.Exists(_saveFileName))
            {
                using var file = File.Open(_saveFileName, FileMode.Open);
                if (file != null && file.Length > 0)
                {
                    _player = (Player)new BinaryFormatter().Deserialize(file);
                    return true;
                }
            }
            return false;
        }

        public static void Delete()
        {
            File.Delete(_saveFileName);
        }
    }
}
