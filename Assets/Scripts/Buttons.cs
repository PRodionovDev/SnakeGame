using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    /**
     * Кнопка "начать игру"
     */
    public void PlayPressed()
    {
        Counter.score = Counter.startScore;
        Counter.level = Counter.firstLevel;
        Scene.loadLevel(Counter.firstLevel);
    }

    /**
     * Кнопка выхода из игры
     */
    public void ExitPressed()
    {
        Application.Quit();
    }

    /**
     * Кнопка "в меню"
     */
    public void MenuPressed()
    {
        Counter.score = Counter.startScore;
        Scene.loadMenu();
    }
}
