using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthAndDamage : MonoBehaviour
{
    [SerializeField]
    public float health = 1;
    [SerializeField]
    public float maximumHealth = 1;
    [SerializeField] 
    private GameObject _deathPanel;

    private PlayerWeaponsFire _playerWeapon;
    private SpawnManager _spawnManager;
    private Button _checkpointButton;

    private void Start()
    {
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        if (_spawnManager == null)
        {
            Debug.LogError("Missing Spawn Manager");
        }
        if (_deathPanel == null)
        {
            Debug.LogError("Missing Death Panel");
        }

        _playerWeapon = GameObject.Find("Player").GetComponent<PlayerWeaponsFire>();
        if (_playerWeapon == null)
        {
            Debug.LogError("Player Weapon is NULL");
        }
    }

    // Update is called once per frame
    void Update()
    {
        ///PlayerDamageTest();
    }


    public void PlayerDamage()
    {
        health -= .5f;
        _playerWeapon._weaponPowerUpID = 0;

        if (health <= 0)
        {
            this.gameObject.SetActive(false);
            health = 5f;
            _deathPanel.SetActive(true);
            
            if (_spawnManager.GetCheckPointStatus() == true)
            {
                _checkpointButton = GameObject.Find("Checkpoint_Button").GetComponent<Button>();
                if (_checkpointButton == null)
                {
                    Debug.LogError("Missing checkpoint button");
                }
                _checkpointButton.interactable = true;
            }
        }
    }

    //for testing
    public void PlayerDamageTest()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            PlayerDamage();
            //Debug.Log("Health= " + health);
        }
    }

}

