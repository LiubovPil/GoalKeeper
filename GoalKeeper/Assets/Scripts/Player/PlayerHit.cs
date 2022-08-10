using UnityEngine;
using GoalKeeper.Interactables;

namespace GoalKeeper.Player
{
    public class PlayerHit : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            IInteractables interactablesInterface = other.GetComponent<IInteractables>();
            if (interactablesInterface != null)
            {
                Debug.Log("Hit!");
                interactablesInterface.ApplyEffect();
            }
        }
    }
}
