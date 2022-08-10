using UnityEngine.Events;
using GoalKeeper.Event;
using GoalKeeper.Controllers;

namespace GoalKeeper.Interactables
{
    public class ProgressInteractable : Interactable
    {
        private ChangeProgressEvent _changeProgressEvent = new ChangeProgressEvent();

        private void Start()
        {
            EventManager.AddInvokerChangeProgressEvent(this);
        }
        public override void ApplyEffect()
        {
            _changeProgressEvent.Invoke(_interactableScore);
            base.ApplyEffect();
        }
        public void AddChangeProgressEvent(UnityAction<int> listener)
        {
            _changeProgressEvent.AddListener(listener);
        }
    }
}
