using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource aSource;

    public void PlayAudio()
    {
        aSource.Play();
    }
}
