using UnityEngine;
using UnityEngine.Events;
using TMPro;
using GoalKeeper.Event;
using GoalKeeper.Controllers;

namespace GoalKeeper.UI
{
    public class UITimer : MonoBehaviour
    {
        private const string _timeTextPrefix = "Time: ";

        [Header("Settings for UI Timer")]
        [SerializeField] private TMP_Text _timeText;
        [SerializeField] private float _gameDuration;

        private FinishGameEvent _finishGameEvent = new FinishGameEvent();

        private float _currentTime;
        private bool _gameOver;
        private void Start()
        {
            Inizialize();

            EventManager.AddInvokerFinishGameEvent(this);
        }
        public void Inizialize()
        {
            _timeText.text = _timeTextPrefix + _gameDuration.ToString();
            _gameOver = false;
            _currentTime = _gameDuration;
        }
        private void Update()
        {
            if (!_gameOver)
            {
                if (_currentTime <= 0.0f)
                {
                    _gameOver = true;
                    _timeText.text = _timeTextPrefix + "00:00";
                    _finishGameEvent.Invoke();
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
        public void AddListenerFinishGameEvent(UnityAction listener)
        {
            _finishGameEvent.AddListener(listener);
        }
    }
}
