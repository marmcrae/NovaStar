using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject _optionsMenu;
    [SerializeField]
    private AudioMixer _audioMixer;
    [SerializeField]
    private AudioClip _menuMusic;
    [SerializeField]
    private Image _brightness;

    private void Start()
    {
        AudioManager.Instance.PlayMusic(_menuMusic, 1f);
    }

    public void StartGame()
    {
        //Should load in loading screen whichever integer that may correspond to
        //For proper working order you can order your scenes 0 - Mainmenu 1 -loadingscreen 2 - Maingame
        SceneManager.LoadScene(1); 
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void OptionsMenuOn()
    {
        _optionsMenu.SetActive(true);
    }

    public void OptionsMenuOff()
    {
        _optionsMenu.SetActive(false);
    }

    public void SetVolume(float volume)
    {
        _audioMixer.SetFloat("Volume", volume);
    }

    public void SetBrightness(float brightness)
    {
        _brightness.color = new Color(255, 255, 255, brightness);
        PlayerPrefs.SetFloat("Brightness", brightness);
        PlayerPrefs.Save();
    }
}
