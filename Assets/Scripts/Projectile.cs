using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    private float _speed = 10.0f;
    [SerializeField]
    private Rigidbody _rb;

    private void FixedUpdate()
    {
        Movement();
    }

    public abstract void Movement();
}
