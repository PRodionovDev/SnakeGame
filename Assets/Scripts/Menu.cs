using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayPressed()
    {
        Score.score = 0;
        SceneManager.LoadScene("Play");
    }

    public void ExitPressed()
    {
        Application.Quit();
    }

    public void MenuPressed()
    {
        Score.score = 0;
        SceneManager.LoadScene("Menu");
    }
}
