using UnityEngine;
using System.Collections;

public class BackgroundMove : MonoBehaviour
{

    public float speed;
    public float moveTime;
    float moveTimeTimer;

    private void Start()
    {
        Color color = this.gameObject.GetComponent<SpriteRenderer>().color;
        color.a = 0;

        // Не даем значению выйти за границы, для цвета это (0, 1).
        color.a = Mathf.Clamp(color.a, 0, 1);
        // Задаем спрайту новый цвет.
        this.gameObject.GetComponent<SpriteRenderer>().color = color;
    }

    public void Update()
    {
        Color color = this.gameObject.GetComponent<SpriteRenderer>().color;
        color.a += speed * Time.deltaTime;

        // Не даем значению выйти за границы, для цвета это (0, 1).
        color.a = Mathf.Clamp(color.a, 0, 1);
        // Задаем спрайту новый цвет.
        this.gameObject.GetComponent<SpriteRenderer>().color = color;

        Vector3 mousePosition = new Vector3(Input.mousePosition.x,Input.mousePosition.y); // переменной записываються координаты мыши по иксу и игрику
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition); // переменной - объекту присваиваеться переменная с координатами мыши
        transform.position = objPosition; // и собственно объекту записываються координаты
    }
    //bool moveDirection; //true - right move, false - left move 

    //// Use this for initialization 
    //void Start()
    //{
    //    moveDirection = true;
    //    moveTimeTimer = moveTime;
    //}

    //// Update is called once per frame 
    //void Update()
    //{
    //    checkDirection();
    //    moveBg();
    //}

    //public void checkDirection()
    //{
    //    moveTimeTimer -= Time.deltaTime;
    //    if (moveTimeTimer <= 0)
    //    {
    //        moveTimeTimer = moveTime;
    //        changeMoveDirection();
    //    }
    //}
    //public void changeMoveDirection()
    //{
    //    moveDirection = !moveDirection;
    //}

    //public void moveBg()
    //{
    //    if (moveDirection)
    //    {
    //        transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.World);
    //    }
    //    else
    //    {
    //        transform.Translate(Vector3.back * Time.deltaTime * speed, Space.World);
    //    }
    //}
}