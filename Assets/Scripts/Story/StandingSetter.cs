using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Story
{
    public class StandingSetter : MonoBehaviour
    {
        [SerializeField]
        private StroyAssets _assets;
        [SerializeField]
        private List<Image> _standingSlots;

        public void SetStandings(string contents)
        {
            if (contents.Equals(string.Empty))
            {
                SetStandingSlots(null);
            }
            SetStandingSlots(contents.Split(','));
        }

        private void SetStandingSlots(string[] members)
        {
            if (members == null)
            {
                _standingSlots.ForEach(x => x.gameObject.SetActive(false));
            }
            else if (members.Length == 1)
            {
                SetSlot(_standingSlots[0], members[0]);
                _standingSlots[1].gameObject.SetActive(false);
                _standingSlots[2].gameObject.SetActive(false);
            }
            else
            {
                _standingSlots[0].gameObject.SetActive(false);
                SetSlot(_standingSlots[1], members[0]);
                SetSlot(_standingSlots[2], members[1]);
            }
        }

        private void SetSlot(Image image, string name)
        {
            var sprite = _assets.GetStandingAsset(name);
            if (sprite == null)
            {
                image.gameObject.SetActive(false);
            }
            else
            {
                image.gameObject.SetActive(true);
                image.sprite = sprite;
            }
        }
    }
}
