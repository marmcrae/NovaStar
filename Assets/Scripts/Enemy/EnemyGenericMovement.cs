using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenericMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] float frequency = 1.5f; // Speed of sine movement
    [SerializeField] float magnitude = 5f; //  Size of sine movement
    Vector3 pos;
    Vector3 axis;

    private bool _isAlive = true;

    void Start()
    {
        pos = transform.position;
        axis = transform.up;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isAlive)
        {
            CalculateMove();
        }
    }

    private void CalculateMove()
    {
        pos += Vector3.left * Time.deltaTime * _speed;
        transform.position = pos + axis * Mathf.Sin(Time.time * frequency) * magnitude;
    }

}
