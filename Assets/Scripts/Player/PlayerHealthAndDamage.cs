using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthAndDamage : MonoBehaviour
{
    [SerializeField]
    public float health = 1;

    [SerializeField]
    public float maximumHealth = 1;

    private PlayerWeaponsFire _playerWeapon;

    private void Start()
    {
        _playerWeapon = GameObject.Find("Player").GetComponent<PlayerWeaponsFire>();

        if (_playerWeapon == null)
        {
            Debug.LogError("Player Weapon is NULL");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //PlayerDamageTest();
    }


    public void PlayerDamage()
    {
        health -= .5f;
        _playerWeapon._weaponPowerUpID = 0;

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    //for testing
    public void PlayerDamageTest()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            PlayerDamage();
            Debug.Log("Health= " + health);
        }
    }

}

