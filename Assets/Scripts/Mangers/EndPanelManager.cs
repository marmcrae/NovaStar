using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPanelManager : MonoBehaviour
{
    private GameObject _endPanel;
    private SpawnManager _spawnManager;
   void Start()
   {
        _endPanel = GameObject.Find("End_Panel");
        _endPanel.SetActive(false);
        if(_endPanel == null)
        {
            Debug.Log("Missing end panel");
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
        _endPanel.SetActive(false);
    }

    public void QuitLevel()
    {
        SceneManager.LoadScene(0);
    }
}