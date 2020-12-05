using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float _startingHealth;
    [SerializeField] protected float _startingSpeed;
    [SerializeField] protected float _startingPoints;

    protected virtual void Update()
    {
        if (transform.position.x < -35f)
        {
            Die();
        }
    }

    protected virtual void TakeDamage(float dmg)
    {
        _startingHealth -= dmg;
        if (_startingHealth <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerPosition player = other.transform.GetComponent<PlayerPosition>();
            if (player != null)
            {
                //hurt player here;
            }
            // hurt enemy?
        }
    }
}
