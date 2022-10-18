using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class BaseManager : MonoBehaviour
{
    public int m_NumRoundsToWin = 5;
    public float m_StartDelay = 3f;
    public float m_EndDelay = 3f;
    public CameraControl m_CameraControl;
    public Text m_MessageText;
    public GameObject m_TankPrefab;

    protected int m_RoundNumber;
    protected WaitForSeconds m_StartWait;
    protected WaitForSeconds m_EndWait;
    protected BaseTank m_RoundWinner;
    protected BaseTank m_GameWinner;
    protected AudioSource mainAudio;

    protected void SetCameraTargets(BaseTank[] m_Tanks)
    {
        Transform[] targets = new Transform[m_Tanks.Length];

        for (int i = 0; i < targets.Length; i++)
        {
            targets[i] = m_Tanks[i].m_Instance.transform;
        }

        m_CameraControl.m_Targets = targets;
    }

    protected IEnumerator GameLoop(BaseTank[] m_Tanks)
    {
        // yield == await
        yield return StartCoroutine(RoundStarting(m_Tanks));
        yield return StartCoroutine(RoundPlaying(m_Tanks));
        yield return StartCoroutine(RoundEnding(m_Tanks));

        if (m_GameWinner != null)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            StartCoroutine(GameLoop(m_Tanks));
        }
    }

    // reset all tanks, set camera, set round number and set message UI
    private IEnumerator RoundStarting(BaseTank[] m_Tanks)
    {
        ResetAllTanks(m_Tanks);
        DisableTankControl(m_Tanks);

        m_CameraControl.SetStartPositionAndSize();

        m_RoundNumber++;
        m_MessageText.text = "ROUND " + m_RoundNumber;



        yield return m_StartWait;
    }

    // enable all tank controls, empty message UI
    private IEnumerator RoundPlaying(BaseTank[] m_Tanks)
    {
        EnableTankControl(m_Tanks);

        m_MessageText.text = string.Empty;

        while (!OneTankLeft(m_Tanks))
        {
            yield return null;
        }
    }

    // disabale all tank controls, check for game winner, cal message UI and show UI
    private IEnumerator RoundEnding(BaseTank[] m_Tanks)
    {
        DisableTankControl(m_Tanks);

        m_RoundWinner = null;

        m_RoundWinner = GetRoundWinner(m_Tanks);

        if (m_RoundWinner != null)
        {
            m_RoundWinner.m_Wins++;
        }

        m_GameWinner = GetGameWinner(m_Tanks);

        string message = EndMessage(m_Tanks);

        m_MessageText.text = message;

        yield return m_EndWait;
    }


    private bool OneTankLeft(BaseTank[] m_Tanks)
    {
        int numTanksLeft = 0;

        for (int i = 0; i < m_Tanks.Length; i++)
        {
            if (m_Tanks[i].m_Instance.activeSelf)
                numTanksLeft++;
        }

        return numTanksLeft <= 1;
    }

    private BaseTank GetRoundWinner(BaseTank[] m_Tanks)
    {
        for (int i = 0; i < m_Tanks.Length; i++)
        {
            if (m_Tanks[i].m_Instance.activeSelf)
                return m_Tanks[i];
        }
        return null;
    }


    private BaseTank GetGameWinner(BaseTank[] m_Tanks)
    {
        for (int i = 0; i < m_Tanks.Length; i++)
        {
            if (m_Tanks[i].m_Wins == m_NumRoundsToWin)
                return m_Tanks[i];
        }

        return null;
    }


    private string EndMessage(BaseTank[] m_Tanks)
    {
        string message = "DRAW!";

        if (m_RoundWinner != null)
            message = m_RoundWinner.m_ColoredPlayerText + " WINS THE ROUND!";

        message += "\n\n\n\n";

        for (int i = 0; i < m_Tanks.Length; i++)
        {
            message += m_Tanks[i].m_ColoredPlayerText + ": " + m_Tanks[i].m_Wins + " WINS\n";
        }

        if (m_GameWinner != null)
            message = m_GameWinner.m_ColoredPlayerText + " WINS THE GAME!";

        return message;
    }

    private void ResetAllTanks(BaseTank[] m_Tanks)
    {
        for (int i = 0; i < m_Tanks.Length; i++)
        {
            m_Tanks[i].Reset();
        }
    }


    private void EnableTankControl(BaseTank[] m_Tanks)
    {
        for (int i = 0; i < m_Tanks.Length; i++)
        {
            m_Tanks[i].EnableControl();
        }
    }


    private void DisableTankControl(BaseTank[] m_Tanks)
    {
        for (int i = 0; i < m_Tanks.Length; i++)
        {
            m_Tanks[i].DisableControl();
        }
    }
}