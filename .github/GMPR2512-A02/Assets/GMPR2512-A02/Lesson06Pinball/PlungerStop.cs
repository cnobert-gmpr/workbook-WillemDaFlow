using UnityEngine;


namespace GMPR2512.Lesson06Pinball
{
    public class PlungerStop : MonoBehaviour
    {
        void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.name == "Plunger")
            {Debug.Log("this plungerstop got hit");
                collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            }
        }
    }
}