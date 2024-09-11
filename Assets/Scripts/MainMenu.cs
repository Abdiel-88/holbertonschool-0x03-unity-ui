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
}
