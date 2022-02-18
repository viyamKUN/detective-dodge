using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Data.StaticData.Enemy
{
    using Models.Enemy;
    public static class WaveStaticData
    {
        private readonly static string _fileName = "Waves";
        private static Dictionary<int, List<Wave>> _enemyMap;

        public static void ReadData()
        {
            if (_enemyMap != null)
            {
                return;
            }
            _enemyMap = new Dictionary<int, List<Wave>>();
            var dataList = CSVReader.Read(Resources.Load<TextAsset>(_fileName)).ToList();
            dataList.ForEach(data =>
            {
                int level = (int)data["Level"];
                if (!_enemyMap.ContainsKey(level))
                {
                    _enemyMap.Add(level, new List<Wave>());
                }
                _enemyMap[level].Add(new Wave(
                    data["Shape"], data["Enemies"], data["Times"]
                ));
            });
        }
    }
}
