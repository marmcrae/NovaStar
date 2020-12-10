﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Bar_UI : MonoBehaviour
{
   

    [SerializeField]
    private Slider _healthSlider;
    
    [SerializeField]
    private Image _healthBackground;
    
    [SerializeField]
    private Text _healthText;

    private float _currentHealth;
    private float _maxHealth = 1f;

    private PlayerHealthAndDamage _player;

    // Start is called before the first frame update
    void Start()
    {

        _player = GameObject.Find("Player").GetComponent<PlayerHealthAndDamage>();

        if (_player == null)
        {
            Debug.Log("Player is NULL");
        }
        
        _healthText.text = "Health";

    }

    private void Update()
    {
        HealthUpdate();
    }


    public void HealthUpdate()
    {

        _currentHealth = _player.health;
        float fillAmount = _currentHealth;
        _healthBackground.fillAmount = fillAmount;
        _healthText.text = "Health";

        if (_currentHealth <= .5f)
        {
            _healthText.color = Color.red;
        }
        else
        {
            _healthText.color = Color.white;
        }

    }


}

