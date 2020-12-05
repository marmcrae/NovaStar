using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenericMovement : Enemy
{
    [SerializeField] float frequency = 1.5f; // Speed
    [SerializeField] float magnitude = 5f; // Size 

    Vector3 pos;
    Vector3 axis;

    void Start()
    {
        pos = transform.position;
        axis = transform.up;
    }

    protected override void Update()
    {
        base.Update();
        // special movement for base enemy
        CalculateMovement();
    }

    private void CalculateMovement()
    {
        pos += Vector3.left * Time.deltaTime * _startingSpeed;
        transform.position = pos + axis * Mathf.Sin(Time.time * frequency) * magnitude;
    }

}
