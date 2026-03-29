using System.Collections;
using UnityEngine;

namespace GMPR2512.Lesson06Pinball
{
    public class DeathZone : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private Flipper[] _flippers;
        [SerializeField] private Plunger[] _plungers;
        void OnTriggerEnter2D(Collider2D collider2D)
        {
            if(collider2D.gameObject.CompareTag("Ball"))
            {
                ToggleFlippers(false);
                TogglePlunger(false);
                //wait 2 seconds then respawn the ball at a predetermined spawnpoint
                StartCoroutine(RespawnBall(collider2D.gameObject));
            }
        }
        private IEnumerator RespawnBall(GameObject ball)
        {
            yield return new WaitForSeconds(2);
            Rigidbody2D ballRB = ball.GetComponent<Rigidbody2D>();
            ballRB.linearVelocity = Vector2.zero;
            ballRB.angularVelocity = 0;
            
            // whatever we want to happen in 2 seconds goes here
            Debug.Log("Its been 2 seconds since the ball left gameplay!");
            ball.transform.position = _spawnPoint.position;
            ToggleFlippers(true);
            TogglePlunger(true);
        }
        private void ToggleFlippers(bool canPlayerControl)
        {
            foreach (Flipper f in _flippers)
            {
                f.PlayerControls = canPlayerControl;
            }
        }
        private void TogglePlunger(bool canPlayerUse)
        {
            foreach (Plunger p in _plungers)
            {
                p.PlayerControls = canPlayerUse;
            }
        }
    }   
}
//Debug.Log("Kapowww");
//Destroy(collider2D.gameObject);