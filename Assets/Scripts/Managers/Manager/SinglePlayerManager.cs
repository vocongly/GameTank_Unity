using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class SinglePlayerManager : BaseManager
{
    public GameObject m_TankPrefab2;
    public PlayerManager[] m_player_Tanks;
    public BotManager[] m_bot_Tanks;
    private BaseTank[] m_Tanks;

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
        SpawnAllTanks();
        SetCameraTargets(m_Tanks);
        StartCoroutine(GameLoop(m_Tanks));
    }

    private void SpawnAllTanks()
    {
        List<GameObject> tanks = new List<GameObject>();
        tanks.Add(m_TankPrefab);
        tanks.Add(m_TankPrefab2);
        for (int i = 0; i < m_Tanks.Length; i++)
        {
            m_Tanks[i].m_Instance =Instantiate(tanks[i], m_Tanks[i].m_SpawnPoint.position, m_Tanks[i].m_SpawnPoint.rotation) as GameObject;
            m_Tanks[i].m_PlayerNumber = i + 1;
            m_Tanks[i].Setup();
        }
    }
}
