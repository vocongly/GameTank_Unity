using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class SinglePlayerManager : BaseManager
{
    public GameObject[] m_TankPrefabs=new GameObject[2];
    public PlayerManager[] m_player_Tanks;
    public BotManager[] m_bot_Tanks;

    private void Start()
    {
        mainAudio = gameObject.GetComponent<AudioSource>();
        mainAudio.volume = PlayerPrefs.GetFloat("volume");

        m_StartWait = new WaitForSeconds(m_StartDelay);
        m_EndWait = new WaitForSeconds(m_EndDelay);

        m_Tanks = new BaseTank[m_player_Tanks.Length+m_bot_Tanks.Length];
        for (int i = 0; i < m_Tanks.Length; i++)
        {
            if (i < m_player_Tanks.Length)
            {
                m_Tanks[i] = m_player_Tanks[i];
            }
            else
            {
                m_Tanks[i] = m_bot_Tanks[i-m_player_Tanks.Length];
            }
        }
        SpawnPlayerTanks();
        SpawnBotTanks();
        SetCameraTargets();
        StartCoroutine(GameLoop());
    }

    private void SpawnPlayerTanks()
    {
        for (int i = 0; i < m_player_Tanks.Length; i++)
        {
            m_Tanks[i].m_Instance =Instantiate(m_TankPrefabs[0], m_Tanks[i].m_SpawnPoint.position, m_Tanks[i].m_SpawnPoint.rotation) as GameObject;
            m_Tanks[i].m_PlayerNumber = i + 1;
            m_Tanks[i].Setup();
        }
    }

    private void SpawnBotTanks()
    {
        for (int j = 0; j < m_bot_Tanks.Length; j++)
        {
            int i = j + m_player_Tanks.Length;
            m_Tanks[i].m_Instance = Instantiate(m_TankPrefabs[1], m_Tanks[i].m_SpawnPoint.position, m_Tanks[i].m_SpawnPoint.rotation) as GameObject;
            m_Tanks[i].m_PlayerNumber = i + 1;
            m_Tanks[i].Setup();
        }
    }
}
