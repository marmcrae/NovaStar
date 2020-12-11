using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggressiveEnemy : EnemyAbstractClass
{
    //controls the distance enemy begins charge
    [SerializeField] private float _distCharge = 15.0f;
    [SerializeField] private Transform _target;
    //controls how many steps per frame enemy charges
    [SerializeField] private float _distDelta = 20.0f;
    [SerializeField] private bool _chargeActive;

    [SerializeField] private Renderer _enemyRend;
    private bool _colorChange = true;
    private bool _colorWhite = true;

    [SerializeField] private GameObject _enemyShield;
    [SerializeField] private Transform _rotTarget;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            _target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        _speed = 50.0f;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (_target != null)
        {
            Charge();
            WrapAround();
        }
        else
        {
            transform.Translate(Vector3.forward * 20f * Time.deltaTime);
        }       
    }
    private void Charge()
    {
        float _dist = Vector3.Distance(_target.position, transform.position);

        if (_dist < _distCharge)
        {
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
            _chargeActive = true;
            _enemyShield.SetActive(true);
            FlashRed();
        }
        else
        {
            if (_chargeActive == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, _target.position, _distDelta * Time.deltaTime);
                transform.rotation = Quaternion.Lerp(transform.rotation, _rotTarget.rotation, Time.deltaTime * 5f);
            }
            else
            {            
                transform.Translate(Vector3.forward * _speed * Time.deltaTime);             
            }
        }
    }
    private void WrapAround()
    {
        if (transform.position.x < -40.0f)
        {
            transform.position = new Vector3(40.0f, transform.position.y);
            _chargeActive = false;
            _enemyShield.SetActive(false);
            _enemyRend.material.color = Color.white;
        }
    }
    private void FlashRed()
    {
        //flash red
        if (_colorChange == true)
        {
            StartCoroutine(FlashColorChange());
            _colorChange = false; 
        }
        else if (_colorChange == false && _colorWhite == false)
        {
            StartCoroutine(FlashColorWhite());
            _colorWhite = true;
        }        
    }
    IEnumerator FlashColorChange()
    {
        yield return new WaitForSeconds(.1f);
        _enemyRend.material.color = Color.red;
        _colorWhite = false;
    }
    IEnumerator FlashColorWhite()
    {
        yield return new WaitForSeconds(.1f);
        _enemyRend.material.color = Color.white;
        _colorChange = true;
    }
}
