using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInvert : MonoBehaviour {

    public Texture2D cursor;
    public GameObject player;
    public GameObject door;
    public GameObject elevator;
    public float jumpForce = 250f;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnMouseDown()
    {
        bool back = Input.GetButtonDown("Fire1");

        if (back && (anim.GetBool("IsUp")))
        {
            anim.SetBool("IsUp", false);
            door.SetActive(false);
            Debug.Log("Лифт опущен");
        }
        else
        {
            if (back && (!anim.GetBool("IsUp")))
            {
                anim.SetBool("IsUp", true);
                door.SetActive(true);
                float move = Input.GetAxis("Horizontal");
                elevator.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
                Debug.Log("Лифт поднят");
            }
        }
    }

    void OnMouseEnter()
    {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
