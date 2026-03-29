using UnityEngine;
using System.Collections.Generic;

namespace GMPR2512.Lesson06Pinball
{
    public class TargetBank : MonoBehaviour
    {
        [SerializeField] private List<DropTarget> _targets;
        [SerializeField] private float _bankResetDelay = 1.0f;

        // This is called by a target when it gets hit
        public void CheckTargets()
        {
            foreach (var target in _targets)
            {
                // If even one target is still active/up, don't reset yet
                if (!target.IsDown) return;
            }

            // If we got here, all targets are down!
            Invoke(nameof(ResetAllTargets), _bankResetDelay);
        }

        private void ResetAllTargets()
        {
            foreach (var target in _targets)
            {
                target.ResetTarget();
            }
        }
    }
}
