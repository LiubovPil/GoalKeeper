using UnityEngine;
using GoalKeeper.Interactables;

namespace GoalKeeper.Controllers
{
    public class SpawnController : MonoBehaviour
    {
        protected const float _offsetZ = 1.5f;

        [Header("Size of football border")]
        [SerializeField] protected Transform _rightBorder;
        [SerializeField] protected Transform _leftBorder;
        [SerializeField] protected float _minPositionY;
        [SerializeField] protected float _maxPositionY;
        //for z the coordinate can take the value from rightborder/leftborder

        [Header("Interactables spawn limits")]
        [SerializeField] protected int _minSpawnTime;
        [SerializeField] protected int _maxSpawnTime;

        //Timer settings
        protected Timer _spawnTimer;
        protected int _spawnTime;

        //Target position settings        
        protected Vector3 _targetPosition;

        //Interactable
        protected GameObject _interactable;
        protected IInteractables _interactablesInterface;
        protected void Awake()
        {
            _spawnTimer = GetComponent<Timer>();

            ConfigureTimer();
        }
        protected void Update()
        {
            if (_spawnTimer.Finished)
            {
                float positionY = Random.Range(_minPositionY, _maxPositionY);
                float positionX = Random.Range(_leftBorder.transform.position.x, _rightBorder.transform.position.x);
                float positionZ = _leftBorder.transform.position.z - _offsetZ;

                _targetPosition = new Vector3(positionX, positionY, positionZ);

                _interactable = ChooseInteractable();

                _interactable.SetActive(true);
                _interactable.transform.position = transform.position;

                _interactablesInterface = _interactable.GetComponent<IInteractables>();
                _interactablesInterface.ApplyForce(_targetPosition);

                ConfigureTimer();
            }
        }
        protected void ConfigureTimer()
        {
            _spawnTime = Random.Range(_minSpawnTime, _maxSpawnTime);
            _spawnTimer.Duration = _spawnTime;
            _spawnTimer.Run();
        }
        protected virtual GameObject ChooseInteractable()
        {
            return _interactable;
        }
    }
}
