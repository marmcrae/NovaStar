using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private float _speed = 10.0f;
    [SerializeField]
    private Rigidbody _rb;

    private void Start()
    {
        transform.Rotate(0f, 270f, 0);
    }
    private void FixedUpdate()
    {
        Movement();
    }
    public void Movement()
    {
        _rb.velocity = transform.forward * _speed;
    }
}
