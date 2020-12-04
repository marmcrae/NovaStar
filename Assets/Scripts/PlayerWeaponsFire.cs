using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponsFire : MonoBehaviour
{

    [SerializeField]
    private GameObject[] _weaponsPrefab;

    [SerializeField]
    private GameObject _fireballPrefab;

    [SerializeField]
    private float _willFire;

    [SerializeField]
    private float _fireRate;

    public int _weaponPowerUpID = 0;


    private enum CurrentWeapon : int
    {
        FirstWeapon,
        SecondWeapon,
        ThirdWeapon,
        FourthWeapon,
        FifthWeapon
    }

    private CurrentWeapon weaponCurrentlyOn;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
       _weaponPowerUpID = 0;
}

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        _fireRate = .20f;

        if (Time.time > _willFire && Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            FireShot();
            _willFire = Time.time + _fireRate;
        }
    }

    public void FireShot()
    {
        if (weaponCurrentlyOn == CurrentWeapon.FirstWeapon)
        {
            Instantiate(_weaponsPrefab[0], transform.position + new Vector3(5, 0, 0), Quaternion.identity);
        }

        if (weaponCurrentlyOn == CurrentWeapon.SecondWeapon)
        {
            Instantiate(_weaponsPrefab[1], transform.position + new Vector3(5, 0, 0), Quaternion.identity);
        }

        if (weaponCurrentlyOn == CurrentWeapon.ThirdWeapon)
        {
            Instantiate(_weaponsPrefab[2], transform.position + new Vector3(5, 0, 0), Quaternion.identity);
        }

        if (weaponCurrentlyOn == CurrentWeapon.FourthWeapon)
        {
            Instantiate(_weaponsPrefab[3], transform.position + new Vector3(5, 0, 0), Quaternion.identity);
        }

        if (weaponCurrentlyOn == CurrentWeapon.FifthWeapon)
        {
            Instantiate(_weaponsPrefab[4], transform.position + new Vector3(5, 0, 0), Quaternion.identity);
        }

    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "PowerUp")
        {
            WeaponPowerUp weaponPowerUp = other.transform.GetComponent<WeaponPowerUp>();
            PlayerHealthAndDamage playerHealth = GameObject.Find("Player").GetComponent<PlayerHealthAndDamage>();
            _weaponPowerUpID++;
            playerHealth.health = playerHealth.maximumHealth;

            if (weaponPowerUp != null)
            {
                switch (_weaponPowerUpID)
                {

                    case 0:
                        weaponCurrentlyOn = CurrentWeapon.FirstWeapon;
                        break;

                    case 1:
                        weaponCurrentlyOn = CurrentWeapon.SecondWeapon;
                        
                        break;

                    case 2:
                        weaponCurrentlyOn = CurrentWeapon.ThirdWeapon;
                        break;

                    case 3:
                        weaponCurrentlyOn = CurrentWeapon.FourthWeapon;
                        break;

                    case 4:
                        weaponCurrentlyOn = CurrentWeapon.FifthWeapon;
                        break;


                    default:
                        Debug.Log("Invalid ID!");
                        break;
                }
            }
       

        }

        Destroy(other.gameObject);

    }
}
