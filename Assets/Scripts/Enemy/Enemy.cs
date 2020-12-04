using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private float _startingHealth = 10f;

    private void Start()
    {
    }
    protected virtual void Update()
    {
        if (transform.position.x < -35f)
        {
            Die();
        }
    }

    public void TakeDamage(float dmg)
    {
        _startingHealth -= dmg;
        if (_startingHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}
