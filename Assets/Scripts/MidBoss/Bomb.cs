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
        if (transform.position.x > 40 || transform.position.x < -40)
        {
            Destroy(this.gameObject);
        }
        if (transform.position.y > 20 || transform.position.y < -20)
        {
            Destroy(this.gameObject);
        }
    }
    public void Movement()
    {
        _rb.velocity = transform.forward * _speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealthAndDamage>().PlayerDamage();
            Destroy(gameObject);
        }
    }
}
