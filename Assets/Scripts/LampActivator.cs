using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LampActivator : MonoBehaviour
{
    public CharacterControllerScript player;
    public Image lampInvSlot;
    public Sprite lampInvOn;
    public Sprite lampInvOff;
    public AudioSource lapmOnSound;
    public AudioSource lapmOffSound;

    //private Animator anim;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Activate Lamp");
        player.anim.SetBool("LampOn", true);
        if (player.anim.GetBool("UseLamp"))
            lapmOnSound.Play();
        lampInvSlot.sprite = lampInvOn;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Deactivate Lamp");
        player.anim.SetBool("LampOn", false);
        if (player.anim.GetBool("UseLamp"))
            lapmOffSound.Play();
        lampInvSlot.sprite = lampInvOff;
    }
}
