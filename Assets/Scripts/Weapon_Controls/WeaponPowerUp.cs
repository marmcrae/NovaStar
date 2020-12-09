using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPowerUp : MonoBehaviour
{
    [SerializeField]
    private Transform _newPosLeft;

    [SerializeField]
    private Transform _newPosRight;

    [SerializeField]
    private GameObject[] _weaponsPowerUpPrefab;

    [SerializeField]
    private float _speed = 1;


    // Update is called once per frame
    void Update()
    {
        PowerUpMovement();
    }

    void PowerUpMovement()
    {


    }
}
