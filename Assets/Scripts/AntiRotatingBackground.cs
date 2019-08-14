using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiRotatingBackground : MonoBehaviour {

    public bool activateRotating = true;
	
	// Update is called once per frame
	void Update ()
    {
        if ((transform.parent.gameObject.transform.localScale.x<0) && (activateRotating == true))
        {
            
            Vector3 theScale = transform.localScale;
            theScale.x =theScale.x * -1;
            transform.localScale = theScale;
            Debug.Log("addsfdsf1");
        }
        //if ((transform.parent.gameObject.transform.localScale.x > 0) && activateRotating == true)
        //{
        //    Vector3 theScale = transform.localScale;
        //    theScale.x = theScale.x * -1;
        //    transform.localScale = theScale;
        //    Debug.Log("addsfdsf2");
        //}
    }
}
