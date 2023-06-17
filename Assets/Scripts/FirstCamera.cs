using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Камера
 */
public class FirstCamera : MonoBehaviour
{
    public GameObject snake;
    private Vector3 offset;
    
    void Start()
    {
        offset = transform.position;
    }

    void LateUpdate()
    {
        transform.position = snake.transform.position + offset;
    }
}
