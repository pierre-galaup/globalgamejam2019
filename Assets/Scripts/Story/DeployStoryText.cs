using Managers;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Story
{
    public class DeployStoryText : MonoBehaviour
    {
        [SerializeField]
        private Canvas _storyCanvas;

        [SerializeField]
        private Text _text;

        private readonly List<string> _storyline = new List<string>
        {
            "You survive since several months alone.\nHuman warmth begins to severely miss you...\nYou built a new Home, in a safe place. Now, you have to go out to find some equipment and resources.\nAnd, why not, find some people to build a better Home, a new family...",
            "You go outside. Pay attention to the different creatures that run.\nYou must kill these creatures to gain resources to improve your Home and your abilities.\nIf you die, you will come back to your Home directly.\nYou can return to your Home at any time by approaching your car.\nTreasures are hidden, you must take risks to find them...",
            "You're not alone anymore !\nHope begins to reborn in you, and you feel that you will be able to rebuild more than a Home: a family.\nAfter all, Home is not the place where you feel good, with those you love?"
        };

        private void Awake()
        {
            _text = GetComponent<Text>();
            _storyCanvas.enabled = false;
        }

        private void Start()
        {
            if (GameManager.Instance.daysPassed == 0)
            {
                DisplayText(_storyline[0]);
            }
            else if (GameManager.Instance.soldierSaved && !GameManager.Instance.soldierSavedText)
            {
                GameManager.Instance.soldierSavedText = true;
                GameManager.Instance.SaveGame();
                DisplayText(_storyline[2]);
            }
        }

        public void DisplayText(string text)
        {
            _text.text = text;
            _storyCanvas.enabled = true;
        }

        public void DisplayText(int index)
        {
            if (index >= 0 && index < _storyline.Count)
            {
                _text.text = _storyline[index];
                _storyCanvas.enabled = true;
            }
        }
    }
}