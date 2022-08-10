using UnityEngine;
using UnityEngine.UI;
using GoalKeeper.Controllers;

namespace GoalKeeper.UI
{
    public class UIProgressBar : MonoBehaviour
    {
        private const float _maxProgress = 100;

        [Header("Settings for UI ProgressBar")]
        [SerializeField] private Slider _progressBar;

        //Timer settings
        private Timer _decreaseTimer;
        private float _decreaseTime = 2.0f;

        //ProgressBar settings
        private float _progressBarValue;
        private float _totalProgress;

        private void Awake()
        {
            _decreaseTimer = GetComponent<Timer>();
            _decreaseTimer.Duration = _decreaseTime;
            _decreaseTimer.Run(); ;
        }
        private void Start()
        {
            EventManager.AddListenerChangeProgressEvent(GetScoreFromInteractable);
        }
        private void Update()
        {
            if (_decreaseTimer.Finished)
            {
                _totalProgress -= 0.5f;
                UpdateScore();
                _decreaseTimer.Run();
            }
        }
        private void GetScoreFromInteractable(int score)
        {
            _totalProgress += score;
            UpdateScore();
        }
        private void UpdateScore()
        {
            if(_totalProgress >= 0 && _totalProgress <= 100)
            {
                _progressBarValue = Mathf.Clamp01(_totalProgress / _maxProgress);
                _progressBar.value = _progressBarValue;
            }
        }
    }
}
