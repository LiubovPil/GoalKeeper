using UnityEngine;
using UnityEngine.SceneManagement;
using GoalKeeper.Controllers;

namespace GoalKeeper.UI
{
    public class UIButton : MonoBehaviour
    {
        [SerializeField] private GameObject _restartButton;

        private bool _isActive = false;
        private void Start()
        {
            _restartButton.SetActive(_isActive);
            EventManager.AddListenerFinishGameEvent(ActivateButton);
        }
        private void ActivateButton()
        {
            _isActive = !_isActive;
            Time.timeScale = 0;
            _restartButton.SetActive(_isActive);
        }
        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
