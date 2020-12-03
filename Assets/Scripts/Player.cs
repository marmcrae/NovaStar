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
    public GameObject _laserPrefab;

    // Player attack values
    //[SerializeField]
    private float _fireRate = 0.25f;

    private float _canFire = -1.0f;


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
            FireLaser();
        }
       
    }

    void FireLaser()
    {
        _canFire = Time.time + _fireRate;

        Instantiate(_laserPrefab, transform.position + new Vector3(1.05f, 0, 0), Quaternion.identity);
    }


    public void Damage()
    {

    }
}
