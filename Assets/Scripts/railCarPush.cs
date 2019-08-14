using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class railCarPush : MonoBehaviour {

    public float maxSpeed = 10f;
    public Texture2D cursor;
    public GameObject player;
    public AudioSource railCarSound;

    void OnMouseDown()
    {
        bool back = Input.GetButtonDown("Fire1");

        if (back && (player.transform.position.x < this.transform.position.x))
        {
            float move = Input.GetAxis("Horizontal");
            GetComponent<Rigidbody2D>().velocity = new Vector2(-1  * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        if (back && (player.transform.position.x > this.transform.position.x))
        {
            float move = Input.GetAxis("Horizontal");
            GetComponent<Rigidbody2D>().velocity = new Vector2( maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
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

    private void FixedUpdate()
    {
        if (GetComponent<Rigidbody2D>().velocity.x != 0 && railCarSound.isPlaying == false)
        {
            railCarSound.Play();
        }
        if (GetComponent<Rigidbody2D>().velocity == new Vector2(0, 0))
        {
            railCarSound.Stop();
        }
    }
}
