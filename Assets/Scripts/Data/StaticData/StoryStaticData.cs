using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StaticData
{
    using Models.Story;
    public static class StoryStaticData
    {
        private static readonly string _scenarioPath = "KR/Scenarios";
        private static readonly string _requireFilename = "ScenarioRequirement";
        private static Dictionary<int, List<ScenarioLine>> _scenarios;
        private static RequirementsList _requirements;

        public static void ReadData()
        {
            if (_scenarios != null) return;
            _scenarios = new Dictionary<int, List<ScenarioLine>>();

            foreach (var asset in Resources.LoadAll<TextAsset>(_scenarioPath))
            {
                var dataList = CSVReader.Read(asset);
                var id = int.Parse(asset.name.Replace("Scenario_", ""));
                _scenarios.Add(id, new List<ScenarioLine>());
                foreach (var data in dataList)
                {
                    _scenarios[id].Add(new ScenarioLine(
                        data["Code"], data["Flag"], data["Info"], data["Contents"]
                    ));
                }
            }

            _requirements = JsonUtility.FromJson<RequirementsList>(Resources.Load<TextAsset>(_requireFilename).text);
        }

        public static int ScenarioCount => _scenarios.Count;
        public static List<ScenarioLine> GetScenario(int scenarioNumber)
        {
            return _scenarios[scenarioNumber];
        }

        public static string[] GetRequires(int scenarioNumber)
        {
            return _requirements.Requires[scenarioNumber].ClueList;
        }
    }
}
