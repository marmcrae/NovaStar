using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawner : MonoBehaviour
{
    private bool spawn = true;

    private Vector3 spawnPos;

    [SerializeField]
    private GameObject powerup;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator Spawner()
    {
        while (spawn)
        {
            spawnPos = new Vector3(Random.Range(-20.0f, -25.0f), 18.0f, 0);
            Instantiate(powerup, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(3.0f);
        }
    }
}
