using UnityEngine;
using UnityEngine.SceneManagement;
using GoalKeeper.Controllers;

namespace GoalKeeper.UI
{
    public class UIButtons : MonoBehaviour
    {
        [Header("Settings for UI Buttons")]
        [SerializeField] private GameObject _restartButton;
        [SerializeField] private GameObject _nextlevelButton;

        private bool _isActive = false;
        private void Start()
        {
            _restartButton.SetActive(_isActive);
            _nextlevelButton.SetActive(_isActive);
            EventManager.AddListenerFinishGameEvent(ActivateButton);
        }
        private void ActivateButton()
        {
            _isActive = !_isActive;

            _restartButton.SetActive(_isActive);
            _nextlevelButton.SetActive(_isActive);
            Time.timeScale = 0;
        }
        public void RestartLevel()
        {
            PlayerPrefs.SetInt("Score", GameData.Score);
            PlayerPrefs.Save();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        public void GoToNextLevel()
        {
            if(GameData.Score >= GameData.NextLevelPrice)
            {
                GameData.Score -= GameData.NextLevelPrice;
                PlayerPrefs.SetInt("Score", GameData.Score);
                PlayerPrefs.Save();
                SceneManager.LoadScene(++GameData.SceneIndex);
            }
        }
    }
}
