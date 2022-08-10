using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoalKeeper.Pooler;

namespace GoalKeeper.Controllers
{
    public class CoinInteractableSpawnController : SpawnController
    {
        protected override GameObject ChooseInteractable()
        {
            return _interactable = PoolerController.Instance.GetFromPool("Coin");
        }
    }
}
