using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGenerator : MonoBehaviour
{
    public float Zsize = 13.03f;
    public float Xsize = 12.83f;

    public GameObject foodPrefab;
    
    public Vector3 curPos;
    public GameObject curFood;

    void AddNewFood()
    {
        GetRandomPosition();
        curFood = GameObject.Instantiate(foodPrefab, curPos, Quaternion.identity) as GameObject;
    }

    void Update()
    {
        if (!curFood) {
            AddNewFood();
        } else {
            return;
        }
    }

    void GetRandomPosition()
    {
        curPos = new Vector3(Random.Range(Zsize*-1, Zsize), 0.25f, Random.Range(Xsize*-1, Xsize));
    }
}
