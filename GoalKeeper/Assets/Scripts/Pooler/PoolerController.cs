using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoalKeeper.Pooler
{
    public class PoolerController : MonoBehaviour
    {
        [SerializeField] private List<PoolData> _pools;

        private static PoolerController _instance = null;
        private static Dictionary<string, Queue<GameObject>> _poolProjectile;
        private static bool _initializied = false;
        public static PoolerController Instance
        {
            get
            {
                if (!_instance)
                {
                    Debug.LogError("Pooler isn't exist");
                }
                return _instance;
            }
        }
        private void Awake()
        {
            if (_instance == null)
                _instance = this;

            if (!_initializied)
                Initialize();
        }
        protected virtual void Initialize()
        {
            _poolProjectile = new Dictionary<string, Queue<GameObject>>();

            foreach (PoolData pool in _pools)
            {
                Queue<GameObject> newPool = new Queue<GameObject>();

                for (int i = 0; i < pool.PoolCapacity; i++)
                {
                    GameObject newProjectile = GameObject.Instantiate(pool.PoolPrefab);
                    newProjectile.SetActive(false);
                    newPool.Enqueue(newProjectile);

                    GameObject.DontDestroyOnLoad(newProjectile);
                }
                _poolProjectile.Add(pool.PoolName, newPool);
            }
            _initializied = true;
        }
        /// <summary>
        /// Get projectile from the pool (don't instantiate it)
        /// </summary>
        /// <returns></returns>
        public GameObject GetFromPool(string poolName)
        {
            if (!_poolProjectile.ContainsKey(poolName))
                return null;

            return _poolProjectile[poolName].Dequeue();
        }
        /// <summary>
        /// Return the projectile in the pool (don't destroy it)
        /// </summary>
        /// <param name="projectileUsed"></param>
        public void ReturnToPool(GameObject projectileUsed, string poolName)
        {
            if (!_poolProjectile.ContainsKey(poolName))
                return;

            projectileUsed.SetActive(false);
            _poolProjectile[poolName].Enqueue(projectileUsed);
        }
    }
}
