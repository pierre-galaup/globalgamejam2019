﻿using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class ScoreManager : MonoBehaviour
    {
        public static int score;        // The player's score.

        private Text text;                      // Reference to the Text component.

        private void Awake()
        {
            // Set up the reference.
            text = GetComponent<Text>();

            // Reset the score.
            score = 0;
        }

        private void Update()
        {
            // Set the displayed text to be the word "Score" followed by the score value.
            text.text = "Score: " + score;
        }
    }
}