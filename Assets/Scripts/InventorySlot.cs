using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {

    public string itemName;
    public string itemDescription;
    public bool isEmpty = true;

    public Image fullScreen;
    public Sprite loadingImage;
    public Texture2D cursor;
    public GameObject player;
    public GameObject inventory;

    public UnityEvent useItem;

    private Animator anim;

    public void OnMouseDown()
    {
        anim = player.GetComponent<Animator>();
        if (useItem != null)
        {
            //UseEmptySlot(anim);
            useItem.Invoke();
        }
        else
        {
            //UseEmptySlot();
        }
    }

    public void UseLamp()
    {
        anim.SetBool("UsePistol", false);
        anim.SetBool("UseLamp", true);
        inventory.SetActive(false);
        fullScreen.color = new Color(255, 255, 255, 0);
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    public void UseEmptySlot()
    {
        inventory.SetActive(false);
        anim.SetBool("UseLamp", false);
        anim.SetBool("UsePistol", false);
        fullScreen.sprite = null;
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    public void UsePistol()
    {
        anim.SetBool("UsePistol", true);
        anim.SetBool("UseLamp", false);
        inventory.SetActive(false);
        fullScreen.sprite = null;
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    public void UsePhoto()
    {
        fullScreen.sprite = loadingImage;
        fullScreen.color = new Color(255, 255, 255, 255);
        Debug.Log("Image loaded");
        anim.SetBool("UseLamp", false);
        anim.SetBool("UsePistol", false);
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        inventory.SetActive(false);
    }

    public void OnMouseEnter()
    {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
    }

    public void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
