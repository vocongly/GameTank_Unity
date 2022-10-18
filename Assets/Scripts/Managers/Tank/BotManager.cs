using System;
using UnityEngine;

[Serializable]
public class BotManager:BaseTank
{
    private BotMovement m_Movement;

    public BotManager() : base()
    {

    }

    public override void Setup()
    {
        m_ColoredPlayerText = "<color=#" + ColorUtility.ToHtmlStringRGB(m_PlayerColor) + ">Bot " + m_PlayerNumber + "</color>";
        m_Movement = m_Instance.GetComponent<BotMovement>();
        base.Setup();
    }

    public override void DisableControl()
    {
        m_Movement.enabled = false;
        base.DisableControl();
    }

    public override void EnableControl()
    {
        m_Movement.enabled = true;
        base.EnableControl();
    }
}
