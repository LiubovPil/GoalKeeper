using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace GoalKeeper.UI
{
    public class UITimer : MonoBehaviour
    {
        [Header("Settings for UI Timer")]
        [SerializeField] private TMP_Text _timeText;
        [SerializeField] private float _gameDuration;

        private const string _timeTextPrefix = "Time: ";
        private float _currentTime;

        private bool _gameOver;
        private void Start()
        {
            Inizialize();
        }

        public void Inizialize()
        {
            _timeText.text = _timeTextPrefix + _gameDuration.ToString();

            _gameOver = false;

            _currentTime = _gameDuration;
        }

        void Update()
        {
            if (!_gameOver)
            {
                if (_currentTime <= 0.0f)
                {
                    _gameOver = true;
                    _timeText.text = _timeTextPrefix + "00:00";
                }
                else
                {
                    _currentTime -= Time.deltaTime;
                    int minutes = Mathf.FloorToInt(_currentTime / 60.0f);
                    int seconds = Mathf.FloorToInt(_currentTime % 60.0f);

                    _timeText.text = _timeTextPrefix + minutes.ToString() + ":" + seconds.ToString();
                }
            }
        }
    }
}
