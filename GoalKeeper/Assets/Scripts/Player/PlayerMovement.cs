using UnityEngine.InputSystem;
using UnityEngine;

namespace GoalKeeper.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Size of football border")]
        [SerializeField] private Transform _rightBorder;
        [SerializeField] private Transform _leftBorder;

        [Header("Movement speed settings")]
        [SerializeField] private float _movementSpeed = 5.0f;
        
        private Input _input;

        private Vector3 _newPosition;
        private Vector3 _inputValue;
        private const float _offsetX = 0.4f;

        private void Awake()
        {
            _input = new Input();
            
            _newPosition = transform.position;
        }
        private void OnEnable()
        {
            _input.Player.Movement.Enable();
        }
        private void FixedUpdate()
        {
            transform.position = Vector3.MoveTowards(transform.position, _newPosition, _movementSpeed * Time.fixedDeltaTime);
        }
        /// <summary>
        /// The method is called from unity (thanks to the new Player Input component attached to player)
        /// and is applicable for both mouse and touchscreen
        /// </summary>
        private void OnMovement(InputValue input)
        {
            _inputValue = Camera.main.ScreenToWorldPoint(new Vector3(input.Get<Vector2>().x,
                    input.Get<Vector2>().y, -Camera.main.transform.position.z));
            //Debug.Log("InputValue = " + _inputValue);
            
            _newPosition.x = Mathf.Clamp(_inputValue.x, _leftBorder.transform.position.x + _offsetX, 
                _rightBorder.transform.position.x - _offsetX);
        }
        private void OnDisable()
        {
            _input.Player.Movement.Disable();
        }
    }
}
