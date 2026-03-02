using UnityEngine;
using System.Collections;


namespace GMPR2512.Lesson05DeathzoneAndRespawn
{
    public class FreezePoint : MonoBehaviour
    {
        [SerializeField] private Transform _freezePoint;
        private bool isFrozen = false;
        void OnTriggerEnter2D(Collider2D collider2D)
        {
            if(collider2D.gameObject.CompareTag("Ball"))
            {
                if (!isFrozen)
                {
                    StartCoroutine(FreezeBall(collider2D.gameObject));
                }
                
            }
        }
        private IEnumerator FreezeBall(GameObject ball)
        {
            Rigidbody2D ballRB = ball.GetComponent<Rigidbody2D>();

            isFrozen = true;

            Vector2 storedVelocity = ballRB.linearVelocity;
            float storedAngularVelocity = ballRB.angularVelocity;
            RigidbodyConstraints2D originalConstraints = ballRB.constraints;

            ballRB.linearVelocity = Vector2.zero;
            ballRB.angularVelocity = 0f;
            ballRB.constraints = RigidbodyConstraints2D.FreezeAll;

            yield return new WaitForSeconds(2f);

            ballRB.constraints = originalConstraints;
            ballRB.linearVelocity = storedVelocity;
            ballRB.angularVelocity = storedAngularVelocity;

            isFrozen = false;
        }
    }
}

