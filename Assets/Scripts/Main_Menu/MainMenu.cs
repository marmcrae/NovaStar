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
        SceneManager.LoadScene(1); //scene 1 is main game in current build/may be subject to change
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


    //start game
    //quit game
    //options overlay
    //set volume
    //set brightness (post-processing)

}
