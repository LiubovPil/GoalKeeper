using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoalKeeper.Pooler;
using GoalKeeper.Interactables;

namespace GoalKeeper.Controllers
{
    public class InteractableProgressSpawnController : SpawnController
    {
        //Additioan spawn setting
        protected const float _probabilitySpawnBall = 0.6f;

        protected override GameObject ChooseInteractable()
        {
            float probability = Random.Range(0f, 1.0f);

            if (probability <= _probabilitySpawnBall)
                _interactable = PoolerController.Instance.GetFromPool("Ball");
            else
                _interactable = PoolerController.Instance.GetFromPool("Bomb");

            return _interactable;
        }
    }
}
