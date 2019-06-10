using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string SceneName;
    public void Begin()
    {
        SceneManager.LoadScene(SceneName);
    }

    public void Quit()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
