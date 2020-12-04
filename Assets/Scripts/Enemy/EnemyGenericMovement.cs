using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenericMovement : Enemy
{
    [SerializeField] private float _speed = 6.0f;
    [SerializeField] float frequency = 1.5f; // Speed
    [SerializeField] float magnitude = 5f; // Size 

    Vector3 pos;
    Vector3 axis;
    private bool _isAlive = true;

    void Start()
    {
        pos = transform.position;
        axis = transform.up;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (_isAlive)
        {
            CalculateMovement();
        }
    }

    private void CalculateMovement()
    {
        pos += Vector3.left * Time.deltaTime * _speed;
        transform.position = pos + axis * Mathf.Sin(Time.time * frequency) * magnitude;
    }

}
