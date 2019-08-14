using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public UnityEvent ending;
    public int menu;
    public Image overlay;
    public Color overlayColor;
    public float overlaySpeed = 1f;
    public bool IsBegin;

    public void Awake()
    {
        overlayColor.a = 0;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        IsBegin = true;
    }

    public void FixedUpdate()
    {
        if (IsBegin)
        {
            ending.Invoke();
        }
    }

    public void DemoEnding()
    {
        overlayColor.a += overlaySpeed * Time.deltaTime;
        overlayColor.a = Mathf.Clamp(overlayColor.a, 0, 1);
        overlay.color = overlayColor;
        if (overlayColor.a == 1)
        {
            SceneManager.LoadScene(menu);
        }
    }
}
