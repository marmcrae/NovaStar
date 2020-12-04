using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody _rb;
    private Vector3 _dir;
    [SerializeField]
    private float _speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        GetComponentInChildren<SpriteRenderer>().flipX = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_dir * _speed * Time.deltaTime);
    }

    public void SetDirection(Vector3 dir)
    {
        _dir = dir;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
