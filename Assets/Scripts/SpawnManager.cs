using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private bool _stopSpawning = false;
    [SerializeField] private GameObject _enemyContainer;

    // credit to Brackeys start
    private enum SpawnState { SPAWNING, WAITING, COUNTING }

    // Serialized Fields start 
    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform[] enemy;
        public int count;
        public float rate;
        public GameObject _waveAnim;
    }
    public Wave[] waves;
    public Transform[] spawnPoints;
    public float timeBetweenWaves = 5f;
    //Serialized Fields end 

    [SerializeField]
    private int nextWave = 0;
    private float waveCountdown;
    private float searchCountdown = 1f;
    private SpawnState state = SpawnState.COUNTING;


    void Start()
    {
        if (spawnPoints.Length <= 0)
        {
            Debug.LogError("No SpawnPoints found");
        }
        waveCountdown = timeBetweenWaves;
    }

    void Update()
    {
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
        Debug.Log("Wave Completed" + nextWave);
        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            //nextWave = 0;
            Debug.Log("loop");
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
        SpawnWaveAnim(_wave);

        for (int i = 0; i < _wave.count; i++)
        {
            var _randRate = Random.Range(_wave.rate, _wave.rate * 1.5f);
            SpawnEnemy(_wave.enemy[Random.Range(0, _wave.enemy.Length)]);
            yield return new WaitForSeconds(_randRate);
        }
        state = SpawnState.WAITING;
        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, _sp.position, _sp.rotation);
    }

    //spawn animation
    void SpawnWaveAnim(Wave _wave)
    {
        if (_wave._waveAnim != null)
        {
            Vector3 _animPos = new Vector3(0f, 0f, 0f);
            Instantiate(_wave._waveAnim, _animPos, Quaternion.identity);
        }
    }
}
