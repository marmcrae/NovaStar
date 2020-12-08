using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPowerUp : MonoBehaviour
{
    /*
      Player will start with a base weapon/floor. Each upgrade will increase the weapon firing ability
      based on student in put. You are required to have at least 3 weapon upgrades but teams are
      allowed to have more. 

      -need access to player: complete
      -create base weapons: 
      -powerup switch case: complete
      - min 3 weapons: 

  */

    [SerializeField]
    private GameObject[] _weaponsPowerUpPrefab;

    [SerializeField]
    private float _speed = 5;


    // Update is called once per frame
    void Update()
    {
        PowerUpMovement();
    }

    void PowerUpMovement()
    {

        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -18)
        {
            Destroy(this.gameObject);
        }

    }
}
