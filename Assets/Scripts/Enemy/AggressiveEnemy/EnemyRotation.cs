using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotation : MonoBehaviour
{
    [SerializeField] private Transform _enemyRotation;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _enemyRotation.transform.rotation = Quaternion.Euler(0, -90, -55);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            _enemyRotation.transform.rotation = Quaternion.Euler(0, -90, 0);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            _enemyRotation.transform.rotation = Quaternion.Euler(0, -90, 55);

        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            _enemyRotation.transform.rotation = Quaternion.Euler(0, -90, 0);
        }
    }
}
