using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // wave 7 mid tier boss

    // [SerializeField] private GameObject _enemyContainer;
    // credit to Brackeys start
    // Serialized Fields start 
    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform[] enemy;
        public int count;
        public float rate;
    }
    public Wave[] waves;
    public Transform[] spawnPoints;
    public float timeBetweenWaves = 5f;
    //Serialized Fields end 
    private enum SpawnState { SPAWNING, WAITING, COUNTING }
    private SpawnState state = SpawnState.COUNTING;
    private int nextWave = 0;
    private float waveCountdown;
    private float searchCountdown = 1f;
    private bool _stopSpawning = false;
    private bool _checkpointReached = false;
    private bool _playerDied = false;
    private GameObject[] objectsToDestroy;
    private GameObject _player;

    void Start()
    {
        _player = GameObject.Find("Player");
        if (spawnPoints.Length <= 0)
        {
            Debug.LogError("No spawnPoints found");
        }
        waveCountdown = timeBetweenWaves;
    }

    void Update()
    {
        if (_checkpointReached && _playerDied)
        {
            nextWave = 7;
            _playerDied = false;
            _stopSpawning = false;
            _player.SetActive(true);
            _player.transform.position = new Vector3(-20,0,0);
        }


        if (!_stopSpawning)
        {
            if (state == SpawnState.WAITING)
            {
                if (!EnemyIsAlive())
                {
                    WaveCompleted();
                }
                else
                {
                    return;
                }
            }

            if (waveCountdown <= 0)
            {
                if (state != SpawnState.SPAWNING)
                {
                    StartCoroutine(SpawnWave(waves[nextWave]));
                }
            }
            else
            {
                waveCountdown -= Time.deltaTime;
            }
        }
    }
    void WaveCompleted()
    {
        Debug.Log("Wave Completed " + nextWave);
        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave >= 7)
        {
            _checkpointReached = true;
        }

        if (nextWave + 1 > waves.Length - 1)
        {
            //nextWave = 0;
            Debug.Log("End");
            _stopSpawning = true;
        }

        else
        {
            nextWave++;
        }
    }
    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy[Random.Range(0, _wave.enemy.Length)]);
            yield return new WaitForSeconds(1f / _wave.rate);
        }
        state = SpawnState.WAITING;
        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, _sp.position, _sp.rotation);
    }

    public void SetStatus()
    {
        _playerDied = true;
        _stopSpawning = true;
        DestroyAllObjects();
    }

    public bool GetCheckPointStatus()
    {
        return _checkpointReached;
    }

    public bool DidWin()
    {
        if (nextWave + 1 > waves.Length - 1 && _stopSpawning)
        {
            return true;
        } else
        {
            return false;
        }
    }

    void DestroyAllObjects()
    {
        objectsToDestroy = GameObject.FindGameObjectsWithTag("Enemy");

        for (var i = 0; i < objectsToDestroy.Length; i++)
        {
            Destroy(objectsToDestroy[i]);
        }
    }
}
