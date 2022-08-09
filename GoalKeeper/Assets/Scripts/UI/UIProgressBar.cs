using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GoalKeeper.UI
{
    public class UIProgressBar : MonoBehaviour
    {
        private const float _maxScore = 100;

        [Header("Settings for UI Timer")]
        [SerializeField] private Slider _progressBar;

        private float _progressBarValue;
        private float _totalScore;

        private void Update()
        {
            _totalScore -= (Time.deltaTime * 100);
            UpdateScore();
        }
        private void GetScoreFromInteractable(int score)
        {
            _totalScore += score;
            UpdateScore();
        }
        private void UpdateScore()
        {
            if(_totalScore >= 0 && _totalScore <= 100)
            {
                _progressBarValue = Mathf.Clamp01(_progressBarValue / _maxScore);
                _progressBar.value = _progressBarValue;
            }
        }
    }
}
