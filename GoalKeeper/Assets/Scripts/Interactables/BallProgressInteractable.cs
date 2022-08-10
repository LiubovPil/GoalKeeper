using UnityEngine;

namespace GoalKeeper.Interactables
{
    public class BallProgressInteractable : ProgressInteractable
    {
        [Header("Points for losing the ball")]
        [SerializeField] private int _interactableLostPoint;
        protected override void OnTriggerEnter(Collider other)
        {
            if (other.transform.CompareTag(_destroyZoneTag))
            {
                _changeProgressEvent.Invoke(_interactableLostPoint);
            }
            base.OnTriggerEnter(other);
        }
    }
}
