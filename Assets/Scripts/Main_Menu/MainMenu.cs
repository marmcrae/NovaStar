using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject _optionsMenu;
    [SerializeField]
    private AudioMixer _audioMixer;

    public void StartGame()
    {
        SceneManager.LoadScene(1); //Should load in loading screen whichever integer that may correspond to
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
        //need to load game auido through a master mixer (possibly)
    }

    //set brightness (post-processing)

}
