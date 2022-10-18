using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class PlayerManager : BaseTank
{
    private TankMovement m_Movement;
    private TankShooting m_Shooting;

    public PlayerManager():base()
    {

    }

    public override void Setup()
    {
        m_ColoredPlayerText = "<color=#" + ColorUtility.ToHtmlStringRGB(m_PlayerColor) + ">PLAYER " + m_PlayerNumber + "</color>";
        m_Movement = m_Instance.GetComponent<TankMovement>();
        m_Shooting = m_Instance.GetComponent<TankShooting>();
        m_Movement.m_PlayerNumber = m_PlayerNumber;
        m_Shooting.m_PlayerNumber = m_PlayerNumber;
        base.Setup();
    }

    public override void DisableControl()
    {
        m_Movement.enabled = false;
        m_Shooting.enabled = false;
        base.DisableControl();
    }

    public override void EnableControl()
    {
        m_Movement.enabled = true;
        m_Shooting.enabled = true;
        base.EnableControl();
    }
}
