using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics.Internal;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class BotMovement : MonoBehaviour
{
    NavMeshAgent _agent;
    Transform _player;
    public float lookRadius = 10f;
    public int m_PlayerNumber = 1;
    public Rigidbody m_Shell;
    public Transform m_FireTransform;
    public Slider m_AimSlider;
    public AudioSource m_ShootingAudio;
    public AudioClip m_ChargingClip;
    public AudioClip m_FireClip;
    public float m_MinLaunchForce = 15f;
    public float m_MaxLaunchForce = 30f;
    public float m_MaxChargeTime = 0.75f;

    Rigidbody _rb;

    private float m_CurrentLaunchForce;
    private float m_ChargeSpeed;
    private bool m_Fired;

    public float interval = 1;
    float timer;

    float distance = 0;

    private void OnEnable()
    {
        m_CurrentLaunchForce = m_MinLaunchForce;
        m_AimSlider.value = m_MinLaunchForce;
    }

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _rb = GetComponent<Rigidbody>();
        GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player");
        _player = playerGameObject.transform;
        m_ChargeSpeed = (m_MaxLaunchForce - m_MinLaunchForce) / m_MaxChargeTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        distance = Vector3.Distance(_player.position, this.transform.position);

        if (distance <= lookRadius && IsBotVisible())
        {
            Fire();
        }
        if (distance < lookRadius && IsBotVisible())
        {
            int distanceX = 2;
            int distanceZ = 2;
            if (transform.position.x > 0)
            {
                distanceX = -distanceX;
            }
            if (transform.position.z > 0)
            {
                distanceZ = -distanceZ;
            }
            Vector3 direction = new Vector3(transform.position.x + distanceX, transform.position.y, transform.position.z + distanceZ);
            _agent.SetDestination(direction);
            FaceTarget();
        }
        else
        {
            _agent.SetDestination(_player.position);
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (_player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 20f);
    }

    void Fire()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            Rigidbody shellInstance = Instantiate(m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;
            shellInstance.velocity = m_CurrentLaunchForce * m_FireTransform.forward;
            m_ShootingAudio.clip = m_FireClip;
            m_ShootingAudio.Play();
            timer -= interval;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    bool IsBotVisible()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if(hit.transform.tag == "Barrier")
            {
                return false;
            }
        }
        return true;
    }
}
