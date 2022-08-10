using UnityEngine;
using TMPro;
using GoalKeeper.Controllers;

namespace GoalKeeper
{
    public class UIScore : MonoBehaviour
    {
        private const string _scoreTextPrefix = "Score: ";

        [Header("Settings for UI Score")]
        [SerializeField] private TMP_Text _scoreText;
        
        private float _scoreValue = 0;

        private void Awake()
        {
            _scoreText.text = _scoreTextPrefix + _scoreValue.ToString();
        }
        private void Start()
        {
            EventManager.AddListenerChangeScoreEvent(ChangeScore);
        }
        private void ChangeScore(int score)
        {
            _scoreValue += score;
            _scoreText.text = _scoreTextPrefix + _scoreValue.ToString();
        }
    }
}
