using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Story
{
    using StaticData;
    using Models.Story;

    public class StoryManager : MonoBehaviour
    {
        [SerializeField]
        private DialogSetter _dialogSetter;
        private List<ScenarioLine> _scenarioList;
        private int _pin;

        private void Awake()
        {
            int targetScenario = Data.StaticData.StoryBookmark.GetScenarioNumber();
            ShowScenario(targetScenario);
        }

        private void ShowScenario(int id)
        {
            _scenarioList = StoryStaticData.GetScenario(id);
            _pin = 0;
            ReadScenario();
        }

        private void ReadScenario()
        {
            var line = _scenarioList[_pin];
            switch (line.Code)
            {
                case "SET":
                    break;
                case "TALK":
                    _dialogSetter.SetDialog(line.Info, line.Contents);
                    break;
                case "SELECT":
                    break;
            }
        }

        public void Next()
        {
            _pin++;
            ReadScenario();
        }
    }
}
