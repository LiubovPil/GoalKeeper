using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GoalKeeper.Interactables
{
    public interface IInteractables
    {
        void ApplyEffect();

        void ApplyForce(Vector3 position);
    }
}
