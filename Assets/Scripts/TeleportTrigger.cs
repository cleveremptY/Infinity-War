using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportTrigger : MonoBehaviour {

    public Transform teleportPosition;
    public string teleportedObjectTag;
    public bool unlock = true;
    public bool YAdaptive;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == teleportedObjectTag || teleportedObjectTag == "")
        {
            Teleport(collision);
        }
        //Debug.Log(collision.tag + "enter to teleport trigger");
    }

    public void UseKey()
    {
        unlock = !unlock;
    }

    public void Teleport(Collider2D collision)
    {
        if (unlock)
        {
            if (YAdaptive)
            {
                teleportPosition.transform.position = new Vector3(teleportPosition.transform.position.x, collision.transform.position.y, teleportPosition.transform.position.z);
            }
            collision.transform.position = new Vector3(teleportPosition.transform.position.x, teleportPosition.transform.position.y, collision.transform.position.z);
            Debug.Log("Teleported");
        }
    }
}
