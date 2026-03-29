using UnityEngine;

namespace GMPR2512.Lesson07TransformAndInput
{
    public class Blocker : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("AlienProjectile") || collision.gameObject.CompareTag("ShipProjectile"))
            {
                Destroy(collision.gameObject);
                return;
            }
        }
    }
}
