using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditAnimator : MonoBehaviour
{
    public float speed = 200f;
    public float minY = -798, maxY = 580;

    private RectTransform rect;
    
    private void Start() {
        rect = GetComponent<RectTransform>();        
    }

    private void Update() {        
        if (rect.anchoredPosition3D.y >= maxY) {
            rect.anchoredPosition3D = new Vector3(rect.anchoredPosition3D.x, minY, rect.anchoredPosition3D.z);
        }
        else {
            rect.anchoredPosition3D = rect.anchoredPosition3D + Vector3.up * Time.deltaTime * speed;

        }
    }   
}
