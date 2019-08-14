using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WatchGameItem : MonoBehaviour {

    public Image fullScreen;
    public Sprite loadingImage;

    public void WatchItem()
    {
        fullScreen.sprite = loadingImage;
        fullScreen.color = new Color(255, 255, 255, 255);
        Debug.Log("Image loaded");
    }
}
