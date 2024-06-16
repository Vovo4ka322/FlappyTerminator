using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour, IMoveble
{
    [SerializeField] private Transform _enemy;
    [SerializeField] private float _speed;

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        _enemy.transform.position += Vector3.left * _speed * Time.deltaTime;
    }
}
