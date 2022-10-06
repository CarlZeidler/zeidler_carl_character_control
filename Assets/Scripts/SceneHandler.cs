using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void StartJumpScene()
    {
        SceneManager.LoadScene("Jump");
    }

    public void RestartCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
