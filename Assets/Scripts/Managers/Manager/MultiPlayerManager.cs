using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MultiPlayerManager:BaseManager
{
    public PlayerManager[] m_Tanks;

    private void Start()
    {
        mainAudio = gameObject.GetComponent<AudioSource>();
        mainAudio.volume = PlayerPrefs.GetFloat("volume");

        m_StartWait = new WaitForSeconds(m_StartDelay);
        m_EndWait = new WaitForSeconds(m_EndDelay);

        SpawnAllTanks();
        SetCameraTargets(m_Tanks);
        StartCoroutine(GameLoop(m_Tanks));
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
