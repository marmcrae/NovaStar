using UnityEngine;

public class PlayerHealthAndDamage : MonoBehaviour
{
    [SerializeField]
    public float health;
    
    [SerializeField]
    public float maximumHealth;

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

        health = _playerWeapon._weaponsPrefab.Length;
        maximumHealth = _playerWeapon._weaponsPrefab.Length;
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

