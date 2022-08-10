using UnityEngine;

namespace GoalKeeper.UI
{
    public class UITooltip : MonoBehaviour
    {
        [Header("Settings for UI Tooltip")]
        [SerializeField] private GameObject _tooltipText;

        private bool _isActive = false;
        private void Start()
        {
            _tooltipText.SetActive(_isActive);
        }
        public void ShowTooltip()
        {
            _isActive = !_isActive;
            _tooltipText.SetActive(_isActive);
        }
    }
}
