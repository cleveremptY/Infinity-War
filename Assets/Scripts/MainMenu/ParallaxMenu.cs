using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxMenu : MonoBehaviour
{
    public Transform background;
    public Vector2 center;
    public bool isLock = true;
    public float xStength = 1;
    public float yStength = 1;

    private float x;
    private float y;

    private Vector2 basePosition;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        if (background == null)
            background = this.gameObject.transform;
        basePosition = background.position;
    }

    void Update()
    {
        GetXY();
        Debug.Log(x + " " + y);
        background.position = new Vector2(background.position.x + x, background.position.y + y);
        
    }

    private void GetXY()
    {
        if (isLock)
        {
            if (Input.mousePosition.x < Screen.width - 5 && Input.mousePosition.x > 5)
                x = center.x - Input.GetAxis("Mouse X");
            else
                x = 0;
            if (Input.mousePosition.y < Screen.height - 5 && Input.mousePosition.y > 5)
                y = center.y - Input.GetAxis("Mouse Y");
            else
                y = 0;
        }
        else
        {
            x = center.x - Input.GetAxis("Mouse X");
            y = center.y - Input.GetAxis("Mouse Y");
        }
    }
}
