using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class TweenImage : MonoBehaviour
{
    public Image image;
    public float tweenTime;
    public TextMeshProUGUI textMeshPro;
    // Start is called before the first frame update
    void Start()
    {
        Tween();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Tween()
    {
        LeanTween.cancel(gameObject);
        transform.localScale = Vector3.one;
        LeanTween.scale(gameObject, Vector3.one * 2, tweenTime)
            .setEasePunch();
    }
}
