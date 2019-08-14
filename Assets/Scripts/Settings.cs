using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour {

    public Texture2D cursor;

    // Use this for initialization
    void Start () {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        
    }
}
