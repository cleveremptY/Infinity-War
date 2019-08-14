using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UseLamp : MonoBehaviour
{
    public UnityEvent OnClick;
    public CharacterControllerScript player;

    public void OnMouseDown()
    {
        if (player.anim.GetBool("UseLamp") && player.anim.GetBool("LampOn"))
        {
            OnClick.Invoke();
        }
    }
}
