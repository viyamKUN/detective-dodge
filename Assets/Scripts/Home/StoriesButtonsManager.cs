using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Home
{
    public class StoriesButtonsManager : MonoBehaviour
    {
        [SerializeField]
        private HomeManager _manager;
        private List<StoryButton> _storyButton;

        public void Init()
        {
            int index = 0;
            _storyButton = this.gameObject.GetComponentsInChildren<StoryButton>().ToList();
            _storyButton.ForEach(x => x.Init(index++, _manager));

            // TODO 스토리 해금/안해금 표시
        }
    }
}
