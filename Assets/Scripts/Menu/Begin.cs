using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Begin : MonoBehaviour {

    public Texture2D cursor;

    void OnMouseDown()
    {
        //Application.LoadLevel(0);
        SceneManager.LoadScene("Level0"); 
    }

    void OnMouseEnter()
    {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
        Debug.Log("1");
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        Debug.Log("2");
    }
}
