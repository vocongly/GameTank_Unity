using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManage : MonoBehaviour
{
    public AudioSource mainAudio;
    public Slider sliderMusic;

    private void Start()
    {
        sliderMusic.value = PlayerPrefs.GetFloat("volume");
        PlayerPrefs.SetFloat("volume", sliderMusic.value);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

    public void GoToMultiPlayer()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void GoToSinglePlayer()
    {
        SceneManager.LoadScene("BotScene");
    }

     public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ChangeVolumeMusic() 
    {
        PlayerPrefs.SetFloat("volume", sliderMusic.value);
        mainAudio.volume = PlayerPrefs.GetFloat("volume");
    }
}
