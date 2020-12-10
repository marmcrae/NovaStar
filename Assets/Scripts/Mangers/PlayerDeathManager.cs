using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathManager : MonoBehaviour
{
   private SpawnManager _spawnManager;
   private GameObject _deathPanel;
    void Start()
    {
        _deathPanel = GameObject.Find("Player_Death_Panel");
        if(_deathPanel == null)
        {
            Debug.Log("Missing death panel");
        }
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        if (_spawnManager == null)
        {
            Debug.Log("Cant find spawn manager");
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
            _deathPanel.SetActive(false);
        }
    }

    public void LoadLevel()
    {
        // Main Scene in GameDevHQ folder
        SceneManager.LoadScene(2);
    }

    public void LoadCheckpoint()
    {
        _spawnManager.SetStatus();
        _deathPanel.SetActive(false);
    }

    public void QuitLevel()
    {
        SceneManager.LoadScene(0);
        _deathPanel.SetActive(false);
    }
}