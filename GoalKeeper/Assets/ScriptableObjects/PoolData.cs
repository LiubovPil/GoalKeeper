using UnityEngine;

namespace GoalKeeper.Pooler
{
    [CreateAssetMenu(fileName = "New PoolData", menuName = "Pool Data")]
    public class PoolData : ScriptableObject
    {
        #region Field
        [SerializeField] private GameObject _poolPrefab;
        [SerializeField] private string _poolName;
        [SerializeField] private int _poolCapacity;
        #endregion

        #region Properties
        public GameObject PoolPrefab
        {
            get { return _poolPrefab; }
            set { _poolPrefab = value; }
        }
        public string PoolName
        {
            get { return _poolName; }
            set { _poolName = value; }
        }
        public int PoolCapacity
        {
            get { return _poolCapacity; }
            set { _poolCapacity = value; }
        }
        #endregion
    }
}