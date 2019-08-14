using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCursor : MonoBehaviour {

    public Texture2D newCursor;
    public bool ResetOnClick = true;

	public void OnMouseEnter()
    {
        Cursor.SetCursor(newCursor, Vector2.zero, CursorMode.Auto);
    }

    public void OnMouseUp()
    {
        if (ResetOnClick)
        {
            OnMouseExit();
        }
    }

    public void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
