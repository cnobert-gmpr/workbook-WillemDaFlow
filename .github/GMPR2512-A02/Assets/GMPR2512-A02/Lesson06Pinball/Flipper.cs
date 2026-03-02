using UnityEngine;

public class Flipper : MonoBehaviour
{
    private HingeJoint2D _joint2D;
    [SerializeField] private bool _rightFlipper;
    public bool PlayerControls = true;
    void Awake()
    {
        _joint2D = GetComponent<HingeJoint2D>();
    }
    void Update()
    {
        if (!PlayerControls)
        {
            _joint2D.useMotor = false;
            return;
        }
        if(_rightFlipper)
            _joint2D.useMotor = Input.GetKey(KeyCode.RightControl);
        else
            _joint2D.useMotor = Input.GetKey(KeyCode.LeftControl);
    }
}
