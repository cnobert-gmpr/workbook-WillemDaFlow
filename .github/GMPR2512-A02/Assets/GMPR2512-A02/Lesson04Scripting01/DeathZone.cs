using UnityEngine;

namespace GMPR2512.Lesson04Scripting01
{
    public class DeathZone : MonoBehaviour
    {
        [SerializeField] private int _year = 1000;
        private float _seconds = 0;
        void Awake()
        // awake is called once before Start()
        {
            _year += 1260;
            Debug.Log($"I'm awake! It's the year {_year}");
        }
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            Debug.Log($"Lets get started! It's finally the year {_year}");
            _year++;
        }

        // Update is called once per frame
        void Update()
        {
            _seconds += Time.deltaTime;

            //Debug.Log($"This scene has been running for {_seconds:f2} seconds.");
        }
        // if 2 game objects touch and both colliders and at least one of those colliders
        //has "is trigger" checked, and at least one has a ridgedbody2d, this method is invoked

        void OnTriggerEnter2D(Collider2D collider)
        {
            Debug.Log("KAPOWWWWWWW");
        }
    }
}
