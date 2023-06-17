using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Генерация еды на поле
 */
public class FoodGenerator : MonoBehaviour
{
    /**
     * Координаты краев поля
     */
    public float Zsize = 13.03f;
    public float Xsize = 12.83f;

    public GameObject foodPrefab;
    
    public Vector3 currentPosition;
    public GameObject currentFood;

    /**
     * Добавление нового объекта еды на поле
     */
    void AddNewFood()
    {
        GetRandomPosition();
        currentFood = GameObject.Instantiate(foodPrefab, currentPosition, Quaternion.identity) as GameObject;
    }

    void Update()
    {
        if (!currentFood) {
            AddNewFood();
        }
    }

    /**
     * Получаем случайную позицию для генерации еды
     */
    void GetRandomPosition()
    {
        currentPosition = new Vector3(Random.Range(Zsize*-1, Zsize), 0.25f, Random.Range(Xsize*-1, Xsize));
    }
}
