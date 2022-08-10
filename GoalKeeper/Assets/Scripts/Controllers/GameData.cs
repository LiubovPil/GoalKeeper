using UnityEngine;

namespace GoalKeeper.Controllers
{
    public static class GameData
    {
        private static int _sceneIndex = 0;
        private static int _nextLevelPrice = 3;
        private static int _score;

        public static int SceneIndex
        {
            get { return _sceneIndex; }
            set { _sceneIndex = value; }
        }
        public static int NextLevelPrice
        {
            get { return _nextLevelPrice; }
            set { _nextLevelPrice = value; }
        }
        public static int Score
        {
            get { return _score; }
            set { _score = value; }
        }

    }
}
