using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigerWall : MonoBehaviour
{
    [SerializeField]
    Transform player;

    public float except = 0f;

    void Update ()
    {
        if (player.position.y - except < this.transform.position.y)
           GetComponent<CapsuleCollider2D>().isTrigger = true;
        else GetComponent<CapsuleCollider2D>().isTrigger = false;
    }

}
