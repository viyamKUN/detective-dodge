using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StaticData
{
    using Models.Story;
    public static class ClueStaticData
    {
        private static readonly string _cluePath = "KR";
        private static readonly string _fileName = "Clues";
        private static Dictionary<string, Clue> _clues;

        public static void ReadData()
        {
            if (_clues != null) return;
            _clues = new Dictionary<string, Clue>();
            var dataList = CSVReader.Read(Resources.Load<TextAsset>($"{_cluePath}/{_fileName}"));
            foreach (var data in dataList)
            {
                _clues.Add(data["ID"].ToString(), new Clue(
                    data["Name"], data["Contents"], data["Rarity"]
                ));
            }
        }

        public static Clue GetClue(string id)
        {
            return _clues[id];
        }
    }
}
