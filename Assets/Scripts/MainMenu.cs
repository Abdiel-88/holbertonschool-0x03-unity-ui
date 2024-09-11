using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // Required for scene management

public class MainMenu : MonoBehaviour
{
    public void PlayMaze()
    {
        // Load the maze scene
        SceneManager.LoadScene("maze");
    }

    public void QuitMaze()
    {
        // Log quit message (works in editor)
        Debug.Log("Quit Game");

        // Quit the application (only works in build)
        Application.Quit();
    }
}

