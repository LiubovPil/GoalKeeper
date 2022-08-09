using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoalKeeper.Interactables
{
    public class Bomb : MonoBehaviour, IInteractables
    {
        public void ApplyEffect()
        {
            GoalKeeper.Pooler.
                PoolerController.Instance.ReturnToPool(gameObject, gameObject.tag);
        }
    }
}
