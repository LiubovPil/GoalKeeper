using UnityEngine.SceneManagement;
using UnityEngine;

namespace GoalKeeper.UI
{
    public class UIRestartGame : MonoBehaviour
    {
        public void RestartGame()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }
    }
}
