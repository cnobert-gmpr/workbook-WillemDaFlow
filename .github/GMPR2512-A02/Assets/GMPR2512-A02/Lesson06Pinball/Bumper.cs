using System;
using System.Collections;
using UnityEngine;

namespace GMPR2512.Lesson06Pinball
{
    public class Bumper : MonoBehaviour
    {
        [SerializeField] private float _bumperForce = 15, _litDuration = 0.2f;
        [SerializeField] private Color _litColour = Color.yellow;
        private bool _isLit = false;
        private Color _originalColour;
        private SpriteRenderer _spriteRenderer;
        void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _originalColour = _spriteRenderer.color;
        }
        void OnCollisionEnter2D(Collision2D collision)
        {
            
            // collision.collider is the collider that it us
            // collision.otherCollider is our collider
            if(collision.collider.CompareTag("Ball"))
            {
                #region adding force to ball
                if (!_isLit)
                
                //Debug.Log($"A game object with the {collision.collider.tag}just hit me");
                if(collision.rigidbody != null)
                {
                    // Step 1: Get the normal of the first contact point
                    Vector2 normal = Vector2.zero;
                    if (collision.contactCount > 0)
                    {
                        ContactPoint2D contact = collision.GetContact(0);
                        normal = contact.normal;  // points *outward* from the bumper surface
                    }
                    // Step 2: If for some reason we didn't get a contact normal, fall back
                    if (normal == Vector2.zero)
                    {
                        Vector2 direction = (collision.rigidbody.position - (Vector2)transform.position).normalized;
                        normal = direction;
                    }
                    normal *= -1;
                    // Step 3: Calculate an impulse along the normal
                    Vector2 impulse = normal * _bumperForce;
                    // Step 4: Apply as an instantaneous force (ignores mass scaling)


                    collision.rigidbody.AddForce(impulse, ForceMode2D.Impulse);
                }
                #endregion
                {
                    StartCoroutine(LightUp());
                }
            
            }   
        }
        private IEnumerator LightUp()
        {
            _isLit = true;
            _spriteRenderer.color = _litColour;
            yield return new WaitForSeconds(_litDuration);
            _spriteRenderer.color = _originalColour;
            _isLit = false;
        }
    }
}
