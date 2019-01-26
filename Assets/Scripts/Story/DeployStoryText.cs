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

        private Text _text;

        private readonly List<string> _storyline = new List<string>
        {
            "You survive since several months alone.\nHuman warmth begins to severely miss you...\nYou build a new home, in a safe place and you have to go out to find some equipment.\nAnd, why not, find some people to build a better home, a new family...",
            "",
            ""
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
        }

        public void DisplayText(string text)
        {
            _text.text = text;
            _storyCanvas.enabled = true;
        }
    }
}