using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpriteButton : MonoBehaviour {

    public UnityEvent OnClick;

    public void OnMouseDown()
    {
        OnClick.Invoke();
    }
}
