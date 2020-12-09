using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
 /*
     Player will start with a base weapon/floor. Each upgrade will increase the weapon firing ability
     based on student in put. You are required to have at least 3 weapon upgrades but teams are
     allowed to have more. 

     -need access to player: complete
     -create base weapons:  completed by Kurt
     -powerup switch case: complete
     - min 3 weapons: completed by Kurt

 */

    [SerializeField]
    private float _speed = 15;


    // Update is called once per frame
    void Update()
    {
        WeaponMovement();
    }

    public void WeaponMovement()
    {

        transform.Translate(Vector3.right * _speed * Time.deltaTime);

        if (transform.position.x < 37)
        {
            Destroy(this.gameObject);
        }

    }

}

