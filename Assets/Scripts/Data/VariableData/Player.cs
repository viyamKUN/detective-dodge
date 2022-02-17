using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data.VariableData
{
    [System.Serializable]
    public class StoryProgress
    {
        public bool IsActivate;
        public bool DidRead;

        public StoryProgress()
        {
            this.IsActivate = false;
            this.DidRead = false;
        }
    }

    [System.Serializable]
    public class Player
    {
        public string Name;
        public float EXP;
        public List<int> ClueList;
        public List<StoryProgress> ActivateStories;

        public Player(string name, int storyCount)
        {
            Name = name;
            EXP = 0;
            ClueList = new List<int>();
            ActivateStories = new List<StoryProgress>(storyCount);
        }
    }
}
