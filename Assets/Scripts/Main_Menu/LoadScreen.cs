using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScreen : MonoBehaviour
{
    #region Bars
    [SerializeField]
    private Slider _progressSlider;
    #endregion

    #region Text Fields
    [SerializeField]
    private Text _loadingText;
    [SerializeField]
    private Text _tipText;
    #endregion


    void Start()
    {
        StartCoroutine(LoadScreenAsync());
        TipText();
    }

    IEnumerator LoadScreenAsync()
    {
        yield return null;
        //LoadSceneAsync(NUMBER/"STRING") should be replaced with scene/"scene" you wish to load
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(2); 
        //doesn't allow scene to load until input is received (defined below)
        asyncLoad.allowSceneActivation = false;
        
        while (!asyncLoad.isDone)
        {
            //outputs load progress in the form of a percentage and a slider value
            _loadingText.text = "Loading... " + (asyncLoad.progress * 100) + "%";
            _progressSlider.value = asyncLoad.progress;
            if (asyncLoad.progress >= 0.9f)
            {
                _loadingText.text = "Press Space Bar to Continue";
                _progressSlider.value = 1;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    //loads scene when space key is pressed
                    asyncLoad.allowSceneActivation = true;
                }
            }        
            yield return null;
        }

    }

    void TipText()
    {
        //string input for tip text on loading screen: Separate tips with , with the exception of the final tip in the list.
        string[] loadingTips = new string[]
        {
            "Collecting Powerups will not only power up your weapons, but also keep you alive!", 
            "Enemy Lasers, bad!", 
            "Does anyone actually read these?",
            "Sometimes, when I'm feeling down, I like to roll in the dirt and pretend I'm a vegetable.  Then I don't CARROT all!",
            "Spaaaaaaaaaaaaaaaaace!",
            "The faster you finish an enemy wave, the more currency you receive!"
        };

        _tipText.text = loadingTips[Random.Range(0, loadingTips.Length)];
    }
}
