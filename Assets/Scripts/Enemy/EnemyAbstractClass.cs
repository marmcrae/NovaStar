using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAbstractClass : MonoBehaviour
{
    [SerializeField] protected float _hp;
    [SerializeField] protected float _speed = 2f;

    protected Animator _anim;
    protected BoxCollider _boxCollider;

    [SerializeField] protected GameObject _explosionAnim;
    [SerializeField] protected GameObject _enemyWeapon;
    [SerializeField] protected Transform _weaponPos;
    [SerializeField] protected float _fireCD;
    [SerializeField] protected float _fireRate = 2.0f;

    //beam
    [SerializeField] protected bool _beamHit;
    [SerializeField] protected bool _onScreen;
    protected float _hitTime;
    [SerializeField] protected bool _dying;
    [SerializeField] protected float _iFrameTime = 0.2f;
    [SerializeField] protected float _beamDamage = 1.0f;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        _anim = transform.GetComponent<Animator>();
        _boxCollider = transform.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }
    protected virtual void Movement()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
    protected virtual void WeaponFire()
    {
        if (Time.time > _fireCD)
        {
            _fireCD = Time.time + _fireRate;
            Instantiate(_enemyWeapon, _weaponPos.position, Quaternion.identity);
        }
    }
    public virtual void Damage(float _damageTaken)
    {
        if (_onScreen)
        {
            Debug.Log("Damage Taken");
            _hp -= _damageTaken;    
        }

        if (_hp <= 0)
        {
            _speed = 0;
            _dying = true;
            Instantiate(_explosionAnim, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            //_anim.SetTrigger("Death");
        }

    }  
    protected virtual void OnTriggerStay(Collider other)
    {
        //Beam Collision
        if (other.CompareTag("Beam"))
        {
            Debug.Log("Hit detected");
            if (_beamHit != true)
            {
                Debug.Log("Damage Dealt");
                Damage(_beamDamage);
                _hitTime = Time.time;
                _beamHit = true;
                StartCoroutine(HitTimer());
            }
        }
    }

    protected virtual void OnScreenCheck()
    {
        if (transform.position.x < 33.0f && transform.position.x > -33.0f)
        {
            _onScreen = true;
        }
        else
        {
            _onScreen = false;
        }
    }
    IEnumerator HitTimer()
    {
        yield return new WaitForSeconds(_iFrameTime);
        _beamHit = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerHealthAndDamage player = other.GetComponent<PlayerHealthAndDamage>();

            Damage(1.0f);

            if (player != null)
            {
                player.PlayerDamage();
            }
        }
    }

    /*
    protected virtual void PowerUp()
    {
        int randomNum = Random
    } */
}
