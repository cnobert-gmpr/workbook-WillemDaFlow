using UnityEngine;

public class Plunger : MonoBehaviour
{
    [SerializeField] private Transform _LowestPoint, _StopPoint;
    [SerializeField] private float _velocity = -5, _force = 20;
    private Rigidbody2D _rb;
    public bool PlayerControls = true;
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bool spacePressed = Input.GetKey(KeyCode.Space);
        bool spaceReleased = Input.GetKeyUp(KeyCode.Space);
        if(spacePressed && transform.position.y >= _LowestPoint.position.y)
        {
            MovePlungerDown();
        }
        if(spaceReleased)
        {
            ReleasePlunger();
        }
        if (PlayerControls)
        
        _rb.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
        
        else if (!PlayerControls)
        {
            _rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            return;
        }
    }
    private void MovePlungerDown()
    {
        transform.Translate(0, _velocity * Time.deltaTime, 0, Space.Self);
    }
    private void ReleasePlunger()
    {
        //starts interacting with the physics engine
        _rb.bodyType = RigidbodyType2D.Dynamic;

        float distance = _StopPoint.position.y - transform.position.y;
        Vector2 impulse = new Vector2(0, _force * distance);
        _rb.AddForce(impulse, ForceMode2D.Impulse);
    }
    
}
