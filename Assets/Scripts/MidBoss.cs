using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidBoss : MonoBehaviour
{
    [SerializeField]
    private int _health = 50;
    [SerializeField]
    private float _speed = 5.0f;
    private Vector3 _targetPosition;
    private bool _canFire = true;
    [SerializeField]
    private GameObject _bombPrefab;
    [SerializeField]
    private GameObject _bombPlacement;
    // Start is called before the first frame update
    void Start()
    {
        _targetPosition = new Vector3(19f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if(_canFire)
        {
            StartCoroutine(FireBullet());
        }
    }

    private void Movement()
    {
        if (_targetPosition == transform.position)
        {
            float x = Random.Range(10f, 23f);
            float y = Random.Range(-14f, 15f);
            _targetPosition = new Vector3(x, y, 0f);
        }

        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
    }


    IEnumerator FireBullet()
    {
        _canFire = false;
        Instantiate(_bombPrefab, _bombPlacement.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        _canFire = true;
    }
}
