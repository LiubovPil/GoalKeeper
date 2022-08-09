using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoalKeeper.Pooler;
using GoalKeeper.Interactables;

namespace GoalKeeper.Controllers
{
    public class SpawnController : MonoBehaviour
    {
        //Spawn setting 
        private const float _probabilitySpawnBall = 0.6f;
        private const float _offsetZ = 1.5f;

        [Header("Size of football border")]
        [SerializeField] private Transform _rightBorder;
        [SerializeField] private Transform _leftBorder;
        [SerializeField] private float _minPositionY;
        [SerializeField] private float _maxPositionY;
        //for z the coordinate can take the value from rightborder/leftborder

        [Header("Interactables spawn limits")]
        [SerializeField] private int _minSpawnTime;
        [SerializeField] private int _maxSpawnTime;

        //Timer settings
        private Timer _spawnTimer;
        private int _spawnTime;

        //Target position settings        
        private Vector3 _targetPosition;

        //Interactable
        private GameObject _interactable;
        private IInteractables _interactablesInterface;
        private void Awake()
        {
            _spawnTimer = GetComponent<Timer>();
            _spawnTime = Random.Range(_minSpawnTime, _maxSpawnTime);

            _spawnTimer.Duration = _spawnTime;
            _spawnTimer.Run();
        }
        private void Update()
        {
            if (_spawnTimer.Finished)
            {
                float positionY = Random.Range(_minPositionY, _maxPositionY);
                float positionX = Random.Range(_leftBorder.transform.position.x, _rightBorder.transform.position.x);
                float positionZ = _leftBorder.transform.position.z - _offsetZ;

                _targetPosition = new Vector3(positionX, positionY, positionZ);

                float probability = Random.Range(0f, 1.0f);

                if(probability <= _probabilitySpawnBall)
                    _interactable = PoolerController.Instance.GetFromPool("Ball");
                else
                    _interactable = PoolerController.Instance.GetFromPool("Bomb");

                _interactable.SetActive(true);
                _interactable.transform.position = transform.position;

                _interactablesInterface = _interactable.GetComponent<IInteractables>();
                _interactablesInterface.ApplyForce(_targetPosition);

                _spawnTime = Random.Range(_minSpawnTime, _maxSpawnTime);
                _spawnTimer.Duration = _spawnTime;
                _spawnTimer.Run();
            }
        }
    }
}
