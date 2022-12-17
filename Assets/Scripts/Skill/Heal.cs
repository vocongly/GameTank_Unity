using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public float max_heal = 40;

    private void OnCollisionEnter(Collision other) {       
        TankHealth targetHealth = other.gameObject.GetComponent<TankHealth>();        
        targetHealth.Healing(max_heal);
        Destroy(gameObject);
    }
}