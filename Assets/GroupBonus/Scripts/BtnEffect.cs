using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnEffect : MonoBehaviour
{
    public AudioSource hoverSound;
    public AudioSource clickSound;

    public void HoverSound() 
    {
        hoverSound.Play();
    }

    public void ClickSound() 
    {
        if (clickSound != null)
        {
            clickSound.Play();
        }    
    }
}
