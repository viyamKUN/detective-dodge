using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Story
{
    public class StoryManager : MonoBehaviour
    {
        private void Awake()
        {
            int targetScenario = Data.StaticData.StoryBookmark.GetScenarioNumber();
            ShowScenario(targetScenario);
        }

        private void ShowScenario(int id)
        {
            // TODO
        }
    }
}
