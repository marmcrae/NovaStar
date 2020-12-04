using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    [SerializeField]
    private GameObject _shotPrefab;

    // Player attack values
    //[SerializeField]
    private float _fireRate = 0.25f;

    private float _laserFireRate = 4.0f;

    private float _canFire = -1.0f;

    private float _canFireLaser = -1.0f;

    private int weaponLevel;

    private bool laserCharging = false;

    private bool laserFiring = false;

    private float chargeTime;

    private float totalCharge; 

    [SerializeField]
    private GameObject _laserPrefab;

    [SerializeField]
    private Animator laserAnim;


    [SerializeField]
    private GameObject chargeSprite;

    /* Boolean that affects the tracking behavior of the homing shots.
     * ENABLED: The shots will change their trajectory mid flight to a new valid target if one is detected.
     * DISABLED: The shots will choose an inital target and will only travel towards that location. 
     *           If the target was destroyed before reaching the shot reaches it the shot will continue flying along its current trajectory.
    */
    public bool _strictTracking;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            //FireShot();
            ChargeLaser();
        }
       
    }

    void FireShot()
    {
        _canFire = Time.time + _fireRate;

        Instantiate(_shotPrefab, transform.position + new Vector3(1.05f, 0, 0), Quaternion.identity);
    }


    void ChargeLaser()
    {

        _canFireLaser = Time.time + _laserFireRate;

        Debug.Log("Start Charge");
        laserCharging = true;
        float startTime = Time.time;
        //chargeSprite.SetActive(true);
        //var newCharge = Instantiate(chargeSprite, transform);

        while (laserCharging == true)
        {
            
            chargeTime = Time.time - startTime;

            if(chargeTime >= 3.0f || Input.GetKeyUp(KeyCode.Space))
            {
                Debug.Log("Fully charged");
                laserCharging = false;
            }

        }
        
        if(chargeTime > 3.0f)
        {
            totalCharge = 3.0f;
        }
        else
        {
            totalCharge = chargeTime;
        }

        //chargeSprite.SetActive(false);
        //Destroy(newCharge);
        FireLaser();
        
    }

    void FireLaser()
    {
        //_laserPrefab.SetActive(true);

        var newCharge = Instantiate(_laserPrefab, transform);

        float startTime = Time.time;

        laserAnim.SetTrigger("laserStart");

        laserFiring = true;


        if (laserAnim.GetBool("laserEnd") == true)
        {
            laserAnim.ResetTrigger("laserEnd");
        }

        while (laserFiring)
        {
            chargeTime = Time.time - startTime;

            if (chargeTime >= totalCharge)
            {
                laserFiring = false;
            }
        }

        laserAnim.SetTrigger("laserEnd");

        if (laserAnim.GetBool("laserStart") == true)
        {
            laserAnim.ResetTrigger("laserStart");
        }

        //_laserPrefab.SetActive(false);
        Destroy(_laserPrefab);
    }

    public void Damage()
    {

    }
}
