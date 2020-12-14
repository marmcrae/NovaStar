using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollider : MonoBehaviour
{
    [SerializeField] private GameObject _explosionAnim;
    
    [SerializeField] private float _hitVolume = 1.0f;
    [SerializeField] private AudioClip _sfxSource;
    [SerializeField] private AudioClip _hitSfxsource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealthAndDamage>().PlayerDamage();

            if (_explosionAnim != null)
            {

                GameObject explosion = Instantiate(_explosionAnim, transform.position, Quaternion.identity);
                explosion.gameObject.GetComponent<ExplosionAnim>()._sfxSource = _hitSfxsource;
                explosion.gameObject.GetComponent<ExplosionAnim>()._volume = _hitVolume;

            }

            Destroy(gameObject);
        }
    }
}
