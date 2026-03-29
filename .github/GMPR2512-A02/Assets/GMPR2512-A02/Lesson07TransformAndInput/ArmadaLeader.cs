using UnityEngine;

namespace GMPR2512.Lesson07TransformAndInput
{
    public class ArmadaLeader : MonoBehaviour
    {
    [SerializeField] private float _speed = 10;
    [SerializeField] private Vector2 _direction = new Vector2(-1, 0);
    private float _lastMoveDownTime;
    internal Vector2 Direction { get => _direction; set => _direction = value; }

    public void MoveDown(float amount)
    {
        // Prevent moving down multiple times in the same frame if 
        // two aliens hit the wall at once.
        if (Time.time > _lastMoveDownTime + 0.1f)
            {
                transform.position += new Vector3(0, -amount, 0);
                _lastMoveDownTime = Time.time;
            }
    }
    void Update()
    {
        transform.Translate(_direction.normalized * _speed * Time.deltaTime);
    }
    }
}