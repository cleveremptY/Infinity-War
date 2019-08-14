using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuNavigation : MonoBehaviour
{
    public void LoadLevel(string level)
    {
        if (string.IsNullOrEmpty(level))
            SceneManager.LoadScene("Level0");
        else
            SceneManager.LoadScene(level);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
