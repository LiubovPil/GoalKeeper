using UnityEngine;
using GoalKeeper.Pooler;
using GoalKeeper.Controllers;

namespace GoalKeeper.Interactables
{
    [RequireComponent(typeof(Rigidbody))]
    public class Interactable : MonoBehaviour, IInteractables
    {
        [Header("Interactable settings")]
        [SerializeField] protected float _interactableForce;
        [SerializeField] protected int _interactablePoint;

        protected string _destroyZoneTag = "DestroyZone";

        protected Rigidbody _intaractableRigidbody;

        private void Awake()
        {
            _intaractableRigidbody = GetComponent<Rigidbody>();
        }
        private void Start()
        {
            EventManager.AddListenerFinishGameEvent(ResetInteractable);
        }
        private void ResetInteractable()
        {
            _intaractableRigidbody.velocity = new Vector3(0f, 0f, 0f);
            _intaractableRigidbody.angularVelocity = new Vector3(0f, 0f, 0f);
            PoolerController.Instance.ReturnToPool(gameObject, gameObject.tag);
        }
        protected virtual void OnTriggerEnter(Collider other)
        {
            if (other.transform.CompareTag(_destroyZoneTag))
            {
                ResetInteractable();
            }
        }
        public virtual void ApplyEffect()
        {
            Debug.Log(gameObject.name + " " + "return to pool");
            ResetInteractable();
        }
        public void ApplyForce(Vector3 position)
        {
            Vector3 direction = (position - transform.position).normalized;
            _intaractableRigidbody.AddForce(direction * _interactableForce, ForceMode.Force);
        }
    }
}
