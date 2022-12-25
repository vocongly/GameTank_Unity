
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class RandomSkills : MonoBehaviour
{
   
    float timer;
    public GameObject lostHealth;
    public GameObject SpeedUp;
    public GameObject SpeedDown;
    public GameObject GetArmor;
    public GameObject losthealthSound;
    public GameObject SpeedUpSound;
    public GameObject SpeedDownSound;
    public GameObject GetArmorSound;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other)
    {
        int number = Random.Range(1,5); 
        switch (number)
        {
            case 1:
                Debug.Log("1");
                TankHealth targetHealth = other.gameObject.GetComponent<TankHealth>();
                targetHealth.DecreaseHealth(25);
                
                Destroy(gameObject);
                SoundLostHealth();
                spawnLostHealthEvent();
                
                break;
            case 2:
                TankMovement speedup = other.gameObject.GetComponent<TankMovement>();
                speedup.CustomSpeed(20);

                Destroy(gameObject);
                SoundSpeedUp();
                spawnSpeedUpEvent();

                break;
            case 3:
                TankMovement speeddown = other.gameObject.GetComponent<TankMovement>();
                speeddown.CustomSpeed(2);

                Destroy(gameObject);
                SoundSpeedDown();
                spawnSpeedDownEvent();

                break;
            case 4:
                TankHealth infiniteHealth = other.gameObject.GetComponent<TankHealth>();
                infiniteHealth.DisableHealth();

                Destroy(gameObject);
                SoundGetArmor();
                spawnGetArmorEvent();
                break;
        }

    }
    private void spawnLostHealthEvent()
    {
        GameObject[] arr = GameObject.FindGameObjectsWithTag("LostHealthEvent");
        if (arr.Length == 0)
        {
            Instantiate(lostHealth);
        }
    }
    private void spawnSpeedUpEvent()
    {
        GameObject[] arr = GameObject.FindGameObjectsWithTag("SpeedUpEvent");
        if (arr.Length == 0)
        {
            Instantiate(SpeedUp);
        }
    }
    private void spawnSpeedDownEvent()
    {
        GameObject[] arr = GameObject.FindGameObjectsWithTag("SpeedDownEvent");
        if (arr.Length == 0)
        {
            Instantiate(SpeedDown);
        }
    }
    private void spawnGetArmorEvent()
    {
        GameObject[] arr = GameObject.FindGameObjectsWithTag("GetArmorEvent");
        if (arr.Length == 0)
        {
            Instantiate(GetArmor);
        }
    }
    private void SoundLostHealth()
    {
        GameObject[] arr = GameObject.FindGameObjectsWithTag("LostHealthSound");
        if (arr.Length == 0)
        {
            Instantiate(losthealthSound);
        }
    }
    private void SoundSpeedUp()
    {
        GameObject[] arr = GameObject.FindGameObjectsWithTag("SpeedUpSound");
        if (arr.Length == 0)
        {
            Instantiate(SpeedUpSound);
        }
    }
    private void SoundSpeedDown()
    {
        GameObject[] arr = GameObject.FindGameObjectsWithTag("SpeedDownSound");
        if (arr.Length == 0)
        {
            Instantiate(SpeedDownSound);
        }
    }
    private void SoundGetArmor()
    {
        GameObject[] arr = GameObject.FindGameObjectsWithTag("GetArmorSound");
        if (arr.Length == 0)
        {
            Instantiate(GetArmorSound);
        }
    }
}
