using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Home
{
    using DefaultSystem;
    public class ClueSection : MonoBehaviour
    {
        private List<ClueUIObject> _objects;
        public void Init()
        {
            _objects = gameObject.GetComponentsInChildren<ClueUIObject>().ToList();
        }

        public void SetData(List<string> keys)
        {
            for (int i = 0; i < keys.Count; i++)
            {
                if (PlayerSaveData.GetPlayer.ClueList.Contains(keys[i]))
                {
                    _objects[i].SetClue(keys[i]);
                }
                else
                {
                    _objects[i].LockClue();
                }
            }
        }
    }
}
