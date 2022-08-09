using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoalKeeper.Pooler;

namespace GoalKeeper.Interactables
{
    public class Ball : MonoBehaviour, IInteractables
    {
        public void ApplyEffect()
        {
            GoalKeeper.Pooler.
                PoolerController.Instance.ReturnToPool(gameObject, gameObject.tag);
        } 
    }
}
