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
        ScoreText.text = "Total score: " + TotalScore.ToString();
    }

    public void PlayPressed()
    {
        Score.score = 0;
        SceneManager.LoadScene("Play");
    }

    public void ExitPressed()
    {
        Application.Quit();
    }
}