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
        [SerializeField]
        private SelectionSetter _selectionSetter;
        private List<ScenarioLine> _scenarioList;
        private int _pin;
        private int _flag;
        private bool _isOnLoading;
        private List<ScenarioLine> _selectionLines;

        private void Awake()
        {
            _selectionSetter.Init();
            int targetScenario = Data.StaticData.StoryBookmark.GetScenarioNumber();
            ShowScenario(targetScenario);
        }

        private void ShowScenario(int id)
        {
            _scenarioList = StoryStaticData.GetScenario(id);
            _isOnLoading = false;
            _selectionLines = new List<ScenarioLine>();
            _pin = 0;
            _flag = 0;
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
                    var nextLine = _scenarioList[_pin + 1];
                    if (!nextLine.Code.Equals("SELECT"))
                    {
                        _selectionLines.Add(line);
                        _selectionSetter.SetSelections(_selectionLines);
                    }
                    else
                    {
                        _selectionLines.Add(line);
                        Next();
                    }
                    break;
            }
        }

        private void EndScenario()
        {
            if (_isOnLoading) return;
            _loader.Load(SceneName.Home);
        }

        private void Next()
        {
            _pin++;
            if (_scenarioList.Count <= _pin)
            {
                EndScenario();
            }
            else
            {
                var line = _scenarioList[_pin];
                if (line.Flag == 0 && _flag != 0)
                {
                    _flag = 0;
                }
                if (line.Flag != _flag)
                {
                    Next();
                    return;
                }
                ReadScenario();
            }
        }

        public void GetNextInput()
        {
            var line = _scenarioList[_pin];
            if (line.Code.Equals("SELECT"))
                return;
            // 만약에 TALK 텍스트 애니메이션 재생 중이면 안 넘기기
            Next();
        }

        public void GetSelect(int index)
        {
            if (System.Int32.TryParse(_selectionLines[index].Info, out int flag))
            {
                _flag = flag;
            }
            else
            {
                _flag = 0;
            }
            _selectionLines.Clear();
            Next();
        }
    }
}
