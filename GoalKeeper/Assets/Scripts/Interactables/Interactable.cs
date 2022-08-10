using UnityEngine;
using GoalKeeper.Pooler;

namespace GoalKeeper.Interactables
{
    [RequireComponent(typeof(Rigidbody))]
    public class Interactable : MonoBehaviour, IInteractables
    {
        [Header("Interactable settings")]
        [SerializeField] protected float _interactableForce;
        [SerializeField] protected int _interactableScore;

        protected string _destroyZoneTag = "DestroyZone";

        protected Rigidbody _intaractableRigidbody;

        private void Awake()
        {
            _intaractableRigidbody = GetComponent<Rigidbody>();
        }
        protected void OnTriggerEnter(Collider other)
        {
            if (other.transform.CompareTag(_destroyZoneTag))
            {
                PoolerController.Instance.ReturnToPool(gameObject, gameObject.tag);
            }
        }
        public virtual void ApplyEffect()
        {
            Debug.Log(gameObject.name + " " + "return to pool");
            PoolerController.Instance.ReturnToPool(gameObject, gameObject.tag);
        }
        public void ApplyForce(Vector3 position)
        {
            Vector3 direction = (position - transform.position).normalized;
            _intaractableRigidbody.AddForce(direction * _interactableForce, ForceMode.Impulse);
        }
    }
}
