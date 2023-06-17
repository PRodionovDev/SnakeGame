using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    /**
     * Загрузка уровня
     */
    public static void loadLevel(int level)
    {
        SceneManager.LoadScene("Level " + level);
    }

    /**
     * Загрузка меню
     */
    public static void loadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    /**
     * Окончание игры:
     * Если первый уровень - перезапускаем уровень, иначе - экран окончания игры
     */
    public static void gameOver()
    {
        if (Counter.level == Counter.firstLevel) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        } else {
            SceneManager.LoadScene("GameOver");
        }
    }
}
