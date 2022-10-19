using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MultiPlayerManager:BaseManager
{
    public GameObject m_TankPrefab;
    public PlayerManager[] m_player_Tanks;

    private void Start()
    {
        mainAudio = gameObject.GetComponent<AudioSource>();
        mainAudio.volume = PlayerPrefs.GetFloat("volume");

        m_StartWait = new WaitForSeconds(m_StartDelay);
        m_EndWait = new WaitForSeconds(m_EndDelay);

        m_Tanks = new BaseTank[m_player_Tanks.Length];

        for (int i = 0; i < m_Tanks.Length; i++)
        {
           m_Tanks[i] = m_player_Tanks[i];
        }

        SpawnAllTanks();
        SetCameraTargets();
        StartCoroutine(GameLoop());
    }

    // instance tank : position, rotation, numbertank and setup
    private void SpawnAllTanks()
    {
        for (int i = 0; i < m_Tanks.Length; i++)
        {
            m_Tanks[i].m_Instance =
                Instantiate(m_TankPrefab, m_Tanks[i].m_SpawnPoint.position, m_Tanks[i].m_SpawnPoint.rotation) as GameObject;
            m_Tanks[i].m_PlayerNumber = i + 1;
            m_Tanks[i].Setup();
        }
    }
}
