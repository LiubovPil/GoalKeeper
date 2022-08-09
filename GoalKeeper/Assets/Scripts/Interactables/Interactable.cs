using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoalKeeper.Interactables
{
    public class Interactable : MonoBehaviour
    {
        [Header("Interactable settings")]
        [SerializeField] protected float _interactableForce;
        [SerializeField] protected int _interactableScore;

        private string _destroyZoneTag = "DestroyZone";

        protected Rigidbody _intaractableRigidbody;

        protected void OnTriggerEnter(Collider other)
        {
            if (other.transform.CompareTag(_destroyZoneTag))
            {
                Debug.Log(gameObject.name + " " + transform.position);
                GoalKeeper.Pooler.
                PoolerController.Instance.ReturnToPool(gameObject, gameObject.tag);
            }
        }
    }
}
