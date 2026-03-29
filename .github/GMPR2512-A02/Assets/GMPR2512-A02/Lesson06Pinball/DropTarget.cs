using UnityEngine;

namespace GMPR2512.Lesson06Pinball
{
    public class DropTarget : MonoBehaviour
    {
        [SerializeField] private Color _hitColour = Color.blue;
        [SerializeField] private float _hideDelay = 0.1f;
        [SerializeField] private TargetBank _bank;
        //above line links me to targetbank

        private bool _isDown = false;
        public bool IsDown => _isDown; // allows targetbank to read this code

        private SpriteRenderer _renderer;
        private Color _originalColor;

        void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
            _originalColor = _renderer.color;
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.collider.CompareTag("Ball") && !_isDown)
            {
                _isDown = true;
                _renderer.color = _hitColour;
                
                Invoke(nameof(HideTarget), _hideDelay);
                
                
                if(_bank != null) _bank.CheckTargets();
            }
        }

        void HideTarget()
        {
            _renderer.enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }

        public void ResetTarget()
        {
            _isDown = false;
            _renderer.color = _originalColor;
            _renderer.enabled = true;
            GetComponent<Collider2D>().enabled = true;
        }
    }
}