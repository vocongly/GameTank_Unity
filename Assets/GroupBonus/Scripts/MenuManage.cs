using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManage : MonoBehaviour
{
    public AudioSource mainAudio;
    public Slider sliderMusic;
    public Image mapImage;
    public Sprite[] maps;
    public Text mapName;
    private string[] mapNames = {"Sand Map", "Ice Map", "Random Map"};

    private int mapIndex = 0;

    private void Start()
    {
        sliderMusic.value = PlayerPrefs.GetFloat("volume");
        PlayerPrefs.SetFloat("volume", sliderMusic.value);
        SetMap();
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

    public void GoToMultiPlayer()
    {
        switch (mapIndex) {
            case 0:
                SceneManager.LoadScene("MainScene");
                break;
            case 1:
                SceneManager.LoadScene("IceMap");
                break;
            case 2:                
                mapIndex = Random.Range(0, 2);
                GoToMultiPlayer();
                break;
        }
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

    public void NextMap() {
        mapIndex += 1;
        if (mapIndex > maps.Length - 1) {
            mapIndex = 0;
        }
        SetMap();
    }

    public void PreviousMap() {
        mapIndex -= 1;
        if (mapIndex < 0) {
            mapIndex = maps.Length - 1;
        }
        SetMap();
    }

    private void SetMap() {
        mapImage.sprite = maps[mapIndex];
        mapName.text = mapNames[mapIndex];
    }
}
