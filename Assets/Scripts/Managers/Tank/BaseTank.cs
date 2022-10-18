using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[Serializable]
public class BaseTank
{
    public Color m_PlayerColor;
    public Transform m_SpawnPoint;
    [HideInInspector] public int m_PlayerNumber;
    [HideInInspector] public string m_ColoredPlayerText;
    [HideInInspector] public GameObject m_Instance;
    [HideInInspector] public int m_Wins;
    private GameObject m_CanvasGameObject;

    public virtual void Setup()
    {
        m_CanvasGameObject = m_Instance.GetComponentInChildren<Canvas>().gameObject;
        MeshRenderer[] renderers = m_Instance.GetComponentsInChildren<MeshRenderer>();
        // make color to tank
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material.color = m_PlayerColor;
        }
    }


    public virtual void DisableControl()
    {
        m_CanvasGameObject.SetActive(false);
    }


    public virtual void EnableControl()
    {
        m_CanvasGameObject.SetActive(true);
    }


    public void Reset()
    {
        m_Instance.transform.position = m_SpawnPoint.position;
        m_Instance.transform.rotation = m_SpawnPoint.rotation;
        m_Instance.SetActive(false);
        m_Instance.SetActive(true);
    }
}
