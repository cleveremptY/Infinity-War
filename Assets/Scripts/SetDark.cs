using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDark : MonoBehaviour {

    public SpriteRenderer dark1 = null;
    public SpriteRenderer dark2 = null;
    public SpriteRenderer overlay = null;
    public float Speed = 1f;
    public GameObject player;
    public GameObject block;

    Color color1;
    Color color2;
    Color colorOverlay;
    private void Awake()
    {
        color1 = dark1.color;
        color2 = dark1.color;
        color1.a = 0;
        color2.a = 0;

        // Не даем значению выйти за границы, для цвета это (0, 1).
        color1.a = Mathf.Clamp(color1.a, 0, 1);
        color2.a = Mathf.Clamp(color2.a, 0, 1);
        // Задаем спрайту новый цвет.
        dark1.color = color1;
        dark2.color = color2;
    }

    bool IsGo = false;

	void FixedUpdate () {
        if (player.transform.position.x > this.transform.position.x)
        {
            IsGo = true;
        }
        if (IsGo)
        {
            block.SetActive(true);
            color1 = dark1.color;
            color2 = dark1.color;
            colorOverlay = overlay.color;
            color1.a += Speed * Time.deltaTime;
            color2.a += Speed * Time.deltaTime;
            colorOverlay.a -= Speed * Time.deltaTime;
            // Не даем значению выйти за границы, для цвета это (0, 1).
            color1.a = Mathf.Clamp(color1.a, 0, 1);
            color2.a = Mathf.Clamp(color2.a, 0, 1);
            colorOverlay.a = Mathf.Clamp(colorOverlay.a, 0, 1);
            // Задаем спрайту новый цвет.
            dark1.color = color1;
            dark2.color = color2;
            overlay.color = colorOverlay;
        }
    }
}
