using UnityEngine;

public class PlayerHealthAndDamage : MonoBehaviour
{
    [SerializeField]
    public float health = 6;
    [SerializeField]
    public float maximumHealth = 6;

    [SerializeField]
    private GameObject _explosionAnim;

    private PlayerWeaponsFire _playerWeapon;
    private SpawnManager _spawnManager;
    private void Start()
    {
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        if (_spawnManager == null)
        {
            Debug.LogError("Missing Spawn Manager");
        }

        _playerWeapon = GameObject.Find("Player").GetComponent<PlayerWeaponsFire>();
        if (_playerWeapon == null)
        {
            Debug.LogError("Player Weapon is NULL");
        }

        health = 6;
        maximumHealth = 6;
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void PlayerDamage()
    {
        health -= 1;

        if (_playerWeapon._weaponPowerLevel > 0)
        {
            _playerWeapon._weaponPowerLevel--;
            _playerWeapon.UpdateWeaponLevel();
        }

        if (health <= 0)
        {
            this.gameObject.SetActive(false);
            Instantiate(_explosionAnim, transform.position, Quaternion.identity);           
        }
    }

    public bool getPlayerStatus()
    {
        return this.gameObject.activeSelf;
    }
}

