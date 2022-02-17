using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Story
{
    using StaticData;
    using Models.Story;
    using DefaultUI;

    public class StoryManager : MonoBehaviour
    {
        [SerializeField]
        private SceneLoader _loader;
        [SerializeField]
        private DialogSetter _dialogSetter;
        [SerializeField]
        private StandingSetter _standingSetter;
        private List<ScenarioLine> _scenarioList;
        private int _pin;
        private bool _isOnLoading;

        private void Awake()
        {
            int targetScenario = Data.StaticData.StoryBookmark.GetScenarioNumber();
            ShowScenario(targetScenario);
        }

        private void ShowScenario(int id)
        {
            _scenarioList = StoryStaticData.GetScenario(id);
            _isOnLoading = false;
            _pin = 0;
            ReadScenario();
        }

        private void ReadScenario()
        {
            var line = _scenarioList[_pin];
            switch (line.Code)
            {
                case "SET":
                    switch (line.Info)
                    {
                        case "Member":
                            _standingSetter.SetStandings(line.Contents);
                            break;
                        case "Name":
                            // TODO: 사용자 이름 입력받기
                            break;
                    }
                    Next();
                    break;
                case "TALK":
                    _dialogSetter.SetDialog(line.Info, line.Contents);
                    break;
                case "SELECT":
                    break;
            }
        }

        private void EndScenario()
        {
            if (_isOnLoading) return;
            _loader.Load(SceneName.Home);
        }

        public void Next()
        {
            _pin++;
            if (_scenarioList.Count <= _pin)
            {
                EndScenario();
            }
            else
            {
                ReadScenario();
            }
        }
    }
}
