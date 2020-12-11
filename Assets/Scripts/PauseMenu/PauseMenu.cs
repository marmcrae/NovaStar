using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    private float _savedVolume;
    private float _savedBrightness;
    [SerializeField]
    private Slider _volumeSlider;
    [SerializeField]
    private Slider _brightnessSlider;
    [SerializeField]
    private AudioMixer _audioMixer;
    [SerializeField]
    private Image _brightness;

    private void Start()
    {
        _brightness = GameObject.Find("BrightnessManager").transform.GetChild(0).GetChild(0).GetComponent<Image>();
        _savedVolume = PlayerPrefs.GetFloat("Volume");
        _savedBrightness = PlayerPrefs.GetFloat("Brightness");
        UpdateSliders();
    }
    private void OnEnable()
    {
        Time.timeScale = 0;
    }
    private void OnDisable()
    {
        Time.timeScale = 1;
    }
    private void UpdateSliders()
    {
        _savedVolume = PlayerPrefs.GetFloat("Volume");
        _savedBrightness = PlayerPrefs.GetFloat("Brightness");

        _volumeSlider.value = _savedVolume;
        _brightnessSlider.value = _savedBrightness;

        SetBrightness(_savedBrightness);
        SetVolume(_savedVolume);
    }

    public void SetVolume(float volume)
    {
        _audioMixer.SetFloat("Volume", volume);
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save();
    }

    public void SetBrightness(float brightness)
    {
        _brightness.color = new Color(255, 255, 255, brightness);
        PlayerPrefs.SetFloat("Brightness", brightness);
        PlayerPrefs.Save();
    }
}
