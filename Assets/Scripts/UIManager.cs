using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void CloseGame()
    {
        // Close the application
        Application.Quit();
        Debug.Log("Game Closed");
    }

    public void OpenScene(int sceneIndex)
    {
        // Load the scene with the specified index
        SceneManager.LoadScene(sceneIndex);
    }
}
