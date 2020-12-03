using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPattern : MonoBehaviour
{
    [SerializeField]
    private GameObject _bulletPrefab;
    [SerializeField]
    private float _startAngle, _endAngle;
    private float _angle;
    [SerializeField]
    private float _angleStep;
    [SerializeField]
    private float _startStep, _endStep;
    // Start is called before the first frame update
    void Start()
    {
        _angle = _startAngle;
        InvokeRepeating("Fire", 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Fire()
    {
        float x = transform.position.x + Mathf.Sin((_angle * Mathf.PI) / 180);
        float y = transform.position.y + Mathf.Cos((_angle * Mathf.PI) / 180);

        Vector3 dir = new Vector3(x, y, 0f);
        dir = (dir - transform.position).normalized;
        GameObject bul = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
        bul.GetComponent<Bullet>().SetDirection(dir);

        if (_angle == _endAngle)
        {
            _angleStep = _endStep;
        }
        else if (_angle == _startAngle)
        {
            _angleStep = _startStep;
        }
        _angle += _angleStep;
    }
}
