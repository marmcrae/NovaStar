using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private GameObject _endPanel;
    private Button _checkPointButton;
    private PlayerHealthAndDamage _player;
    private SpawnManager _spawnManager;
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<PlayerHealthAndDamage>();
        if (_player == null)
        {
            Debug.Log("Missing Player Health");
        }

        if (_endPanel == null)
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
        CheckEndPanelStatus();
    }

    void CheckEndPanelStatus()
    {
        if (!_player.getPlayerStatus())
        {
            _endPanel.SetActive(true);
            if (_spawnManager.GetCheckPointStatus())
            {
                _checkPointButton = GameObject.Find("Checkpoint_Button").GetComponent<Button>();
                if (_checkPointButton == null)
                {
                    Debug.LogError("Missing checkpoint button");
                }
                _checkPointButton.interactable = true;
            }
        }
        else
        {
            _endPanel.SetActive(false);
        }
    }
}
