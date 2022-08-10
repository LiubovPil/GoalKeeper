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
        
        private int _scoreValue;

        private void Awake()
        {
            _scoreValue = PlayerPrefs.GetInt("Score", 0);
            _scoreValue = GameData.Score;
            _scoreText.text = _scoreTextPrefix + _scoreValue.ToString();
        }
        private void Start()
        {
            EventManager.AddListenerChangeScoreEvent(ChangeScore);
        }
        private void ChangeScore(int score)
        {
            _scoreValue += score;
            GameData.Score = _scoreValue;
            PlayerPrefs.SetInt("Score", _scoreValue);

            _scoreText.text = _scoreTextPrefix + _scoreValue.ToString();
        }
    }
}
