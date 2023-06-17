using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Логика экрана "Конец игры"
 */
public class GameOver : MonoBehaviour
{
    public Text ScoreText;

    public void Start()
    {
        ScoreText.text = "Очки: " + Counter.score;
    }
}
