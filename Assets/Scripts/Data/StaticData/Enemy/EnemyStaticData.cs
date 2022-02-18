using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data.StaticData.Enemy
{
    using Models.Enemy;
    public static class EnemyStaticData
    {
        private readonly static string _fileName = "Enemies";
        private static Dictionary<int, Enemy> _enemyMap;
        public static void ReadData()
        {
            if (_enemyMap != null) return;
            _enemyMap = new Dictionary<int, Enemy>();
            var dataMaps = CSVReader.Read(Resources.Load<TextAsset>(_fileName));
            foreach (var data in dataMaps)
            {
                _enemyMap.Add((int)data["ID"], new Enemy(
                    data["Name"], data["HP"], data["Speed"], data["Power"], data["EXPDrops"], data["ItemDrops"], data["ClueDrop"]
                ));
            }
        }

        public static float GetSpeed(int id)
        {
            return _enemyMap[id].Speed;
        }

        public static float GetPower(int id)
        {
            return _enemyMap[id].Power;
        }

        public static int GetHP(int id)
        {
            return _enemyMap[id].HP;
        }
    }
}
