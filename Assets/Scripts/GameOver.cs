using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text ScoreText;
    public int TotalScore;

    public void Start()
    {
        TotalScore = Score.score;
        ScoreText.text = "Очки: " + TotalScore.ToString();
    }

    public void PlayPressed()
    {
        Score.score = 0;
        Level.level = 1;
        Speed.speed = 2;
        SceneManager.LoadScene("Play");
    }

    public void ExitPressed()
    {
        Application.Quit();
    }
}
