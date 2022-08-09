using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoalKeeper.Pooler;

namespace GoalKeeper.Interactables
{
    [RequireComponent(typeof(Rigidbody))]
    public class Ball : Interactable, IInteractables
    {
        private void Awake()
        {
            _intaractableRigidbody = GetComponent<Rigidbody>();
        }
        public void ApplyEffect()
        {
            GoalKeeper.Pooler.
                PoolerController.Instance.ReturnToPool(gameObject, gameObject.tag);
        }
        public void ApplyForce(Vector3 position)
        {
            Vector3 direction = (position - transform.position).normalized;
            Debug.Log(gameObject.name + " " + direction);
            _intaractableRigidbody.AddForce(direction * _interactableForce, ForceMode.Force);
        }
    }
}
