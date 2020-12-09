using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{

    [SerializeField] private float _speed = 10.0f;

    private bool _isEnemyLaser = false;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        MoveLeft();

    }

    void MoveLeft()
    {
        transform.Translate(Vector3.left* _speed * Time.deltaTime);
        
        if(transform.position.x < -35.0f)
        {
            if(transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerHealthAndDamage player = other.GetComponent<PlayerHealthAndDamage>();

            if(player != null)
            {
                player.PlayerDamage();
            }
        }
    }
}
