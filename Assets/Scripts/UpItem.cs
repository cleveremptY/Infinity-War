using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpItem : MonoBehaviour {

    public GameObject itemSlot;

    public void GiveItem()
    {
        itemSlot.SetActive(true);
        this.gameObject.SetActive(false);
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
