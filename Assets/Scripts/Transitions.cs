using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transitions : MonoBehaviour {

    public void StartTheGame()
    {
        Debug.Log("Starting game!");
        SceneManager.LoadScene("game");
    }

    public void GoToSettings()
    {
        Debug.Log("Going to settings!");
        SceneManager.LoadScene("settings");
    }

    public void GoToStartMenu()
    {
        SceneManager.LoadScene("Start");
    }
}
