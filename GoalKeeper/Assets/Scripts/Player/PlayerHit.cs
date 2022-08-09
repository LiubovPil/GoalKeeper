using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoalKeeper.Interactables;

namespace GoalKeeper.Player
{
    public class PlayerHit : MonoBehaviour
    {
        private CapsuleCollider _playerCapsulleCollider;

        private void Awake()
        {
            _playerCapsulleCollider = GetComponent<CapsuleCollider>();
        }

        private void OnTriggerEnter(Collider other)
        {
            IInteractables interactablesInterface = other.GetComponent<IInteractables>();
            Debug.Log(gameObject.name + " " + interactablesInterface);
            if (interactablesInterface != null)
            {
                Debug.Log("Hit!");
                interactablesInterface.ApplyEffect();
            }
        }
    }
}
