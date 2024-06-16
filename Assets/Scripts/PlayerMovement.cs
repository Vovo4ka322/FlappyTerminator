using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour, IMoveble
{
    [SerializeField] private float _tapForce;

    private Rigidbody2D _rigidbody2D;
    private float _rotateZ;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Rotate();
    }

    public void Move()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody2D.velocity = new Vector2(0, _tapForce);
        }
    }

    private void Rotate()
    {
        Vector3 followMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        _rotateZ = Mathf.Atan2(followMouse.y, followMouse.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, _rotateZ);
    }
}
