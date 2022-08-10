using UnityEngine.Events;
using GoalKeeper.Event;
using GoalKeeper.Controllers;

namespace GoalKeeper.Interactables
{
    public class CoinInteractable : Interactable
    {
        private ChangeScoreEvent _changescoreEvent = new ChangeScoreEvent();

        private void Start()
        {
            EventManager.AddInvokerChangeScoreEvent(this);
        }
        public override void ApplyEffect()
        {
            _changescoreEvent.Invoke(_interactablePoint);
            base.ApplyEffect();
        }
        public void AddListenerChangeScoreEvent(UnityAction<int> listener)
        {
            _changescoreEvent.AddListener(listener);
        }
    }
}
