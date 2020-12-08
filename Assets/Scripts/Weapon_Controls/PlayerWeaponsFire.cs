using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponsFire : MonoBehaviour
{

    [SerializeField]
    private GameObject[] _weaponsPrefab;

    [SerializeField]
    private GameObject _chargeSprite;

    [SerializeField]
    private float _fireRate = 0.25f;

    [SerializeField]
    private float _willFire;

    private int _totalWepCount;

    public int _weaponPowerUpID = 0;

    private GameObject newCharge;

    private GameObject newLaser;

    private GameObject laserSprite;

    private Collider _targetCollider = null;

    private float _totalCharge;

    private bool _canShoot = true;
    
    private Animator _laserAnim;


    private enum CurrentWeapon : int
    {
        FirstWeapon,
        SecondWeapon,
        ThirdWeapon,
        FourthWeapon,
        FifthWeapon,
        SixthWeapon
    }

    [SerializeField]
    private CurrentWeapon _weaponCurrentlyOn;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        _weaponPowerUpID = 0;
        _totalWepCount = _weaponsPrefab.Length - 1;
       
    }

    // Update is called once per frame
    void Update()
    { 

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _willFire && _canShoot)
        {
            FireShot();
        }
    }

    public void FireShot()
    {
        _willFire = Time.time + _fireRate;

        switch (_weaponCurrentlyOn)
        {

            case CurrentWeapon.FirstWeapon:
                Instantiate(_weaponsPrefab[0], transform.position + new Vector3(5, 0, 0), Quaternion.identity);
                break;

            case CurrentWeapon.SecondWeapon:
                Instantiate(_weaponsPrefab[1], transform.position + new Vector3(5, 0, 0), Quaternion.identity);
                break;

            case CurrentWeapon.ThirdWeapon:
                Instantiate(_weaponsPrefab[2], transform.position + new Vector3(5, 0, 0), Quaternion.identity);
                break;

            case CurrentWeapon.FourthWeapon:
                Instantiate(_weaponsPrefab[3], transform.position + new Vector3(5, 0, 0), Quaternion.identity);
                break;

            case CurrentWeapon.FifthWeapon:
                Instantiate(_weaponsPrefab[4], transform.position + new Vector3(5, 0, 0), Quaternion.identity);
                break;

            case CurrentWeapon.SixthWeapon:
                _canShoot = false;           
                newCharge = Instantiate(_chargeSprite, transform);
                newCharge.GetComponent<LaserCharge>()._playerObj = gameObject;
                break;

            default:
                Debug.Log("Invalid ID!");
                break;
        }

    }

    public void FireLaser(float chargeTime)
    {

        Destroy(newCharge);

        _totalCharge = chargeTime;

        newLaser = Instantiate(_weaponsPrefab[5], transform);

        laserSprite = newLaser.transform.GetChild(0).gameObject;

        _laserAnim = laserSprite.GetComponent<Animator>();

        _laserAnim.SetTrigger("laserStart");

        if (_laserAnim.GetBool("laserEnd") == true)
        {
            _laserAnim.ResetTrigger("laserEnd");
        }

        StartCoroutine(LaserTimer());
    }

    public void ChargeCancel()
    {
        _canShoot = true;
    }
   


    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "PowerUp")
        {
           
            PlayerHealthAndDamage playerHealth = GameObject.Find("Player").GetComponent<PlayerHealthAndDamage>();
            if(_weaponPowerUpID < _totalWepCount)
            {
                _weaponPowerUpID++;
            }
            
            playerHealth.health = playerHealth.maximumHealth;
 
            switch (_weaponPowerUpID)
            {

                case 0:
                    _weaponCurrentlyOn = CurrentWeapon.FirstWeapon;
                    break;

                case 1:
                    _weaponCurrentlyOn = CurrentWeapon.SecondWeapon;
                    break;

                case 2:
                    _weaponCurrentlyOn = CurrentWeapon.ThirdWeapon;
                    break;

                case 3:
                    _weaponCurrentlyOn = CurrentWeapon.FourthWeapon;
                    break;

                case 4:
                    _weaponCurrentlyOn = CurrentWeapon.FifthWeapon;
                    break;

                case 5:
                    _weaponCurrentlyOn = CurrentWeapon.SixthWeapon;
                    break;
                default:
                    Debug.Log("Invalid ID!");
                    break;
            }

            Destroy(other.gameObject);
        }
    }

    IEnumerator LaserTimer()
    {
        float fireTime = _totalCharge;

        while (fireTime > 0)
        {
            fireTime -= Time.deltaTime;
            yield return null;
        }

        _laserAnim.SetTrigger("laserEnd");

        if (_laserAnim.GetBool("laserStart") == true)
        {
            _laserAnim.ResetTrigger("laserStart");
        }

        if (_laserAnim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            Debug.Log("Anim End");

            //newLaser.GetComponent<Collider>().enabled = false;

            Destroy(newLaser, 0.3f);
        }

        _canShoot = true;
    }
}
