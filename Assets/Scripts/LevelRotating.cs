using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRotating : MonoBehaviour {



    private Rigidbody rigi;
    private void Awake()
    {
        rigi = GetComponent<Rigidbody>();
    }

    Vector3 movement = new Vector3(0, 0, -10);

    // Update is called once per frame
    void Update()
    {
        var cam = GameObject.Find("Player").gameObject;

        bool shoot = Input.GetButtonDown("Fire1");
        shoot |= Input.GetButtonDown("Fire2");

       // float goZ = 10/90f; //Коэфициент изменения оси Z

        if (shoot)
        {
            //    for (int i = 1; i <= 90; i++)
            //    {
            //        //Time.deltaTime;
            //        cam.transform.Rotate(0, i * 2, 0);
                      movement += new Vector3(10 / 90f, 0, 10 / 90f);
            //        cam.transform.position = position;
            //        //cam.transform.rotation = Quaternion.Slerp(0, -i, 0);
            //        //System.Threading.Thread.Sleep(50);
            //    }
            //    position = new Vector3(10, 0, 0);
            //    cam.transform.position = position;
            //    cam.transform.Rotate(0, -0.00001f, 0);
            //rigi.velocity = new Vector3(10, 0, 10);
        }
    }
    private void FixedUpdate()
    {
        // Применить движение к Rigidbody
        rigi.velocity = movement;
    }
}
