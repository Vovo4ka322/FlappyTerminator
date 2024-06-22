using UnityEngine;

public class SpawnerMovement : MonoBehaviour, IMoveble
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;

    private int _currentPosition = 0;

    private void Awake()
    {
        _target = _points[_currentPosition];
    }

    void Update()
    {
        if (transform.position == _points[_currentPosition].position)
        {
            _currentPosition = (_currentPosition + 1) % _points.Length;
            _target = _points[_currentPosition];
        }

        Move();
    }

    public void Move()
    {     
        transform.position = Vector2.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
    }
}
