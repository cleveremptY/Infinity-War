using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenuPage : MonoBehaviour
{
    public List<GameObject> otherPages;
    public GameObject mainPage;

    public void GoToMainPage()
    {
        foreach (var page in otherPages)
            page.SetActive(false);
        mainPage.SetActive(true);
    }
}
