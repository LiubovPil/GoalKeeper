using UnityEngine.Events;
using GoalKeeper.Event;
using GoalKeeper.Controllers;

namespace GoalKeeper.Interactables
{
    public class ProgressInteractable : Interactable
    {
        protected ChangeProgressEvent _changeProgressEvent = new ChangeProgressEvent();

        private void Start()
        {
            EventManager.AddInvokerChangeProgressEvent(this);
        }
        public override void ApplyEffect()
        {
            _changeProgressEvent.Invoke(_interactablePoint);
            base.ApplyEffect();
        }
        public void AddChangeProgressEvent(UnityAction<int> listener)
        {
            _changeProgressEvent.AddListener(listener);
        }
    }
}
