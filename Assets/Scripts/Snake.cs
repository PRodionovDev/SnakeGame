using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{
    public float speed = 2;
    public float RotationSpeed = 100;

    public FixedJoystick joystick;

    private float moveInput;

    public List<GameObject> tailObjects = new List<GameObject>();

    public float z_offset = 3f;

    public GameObject TailPrefab;

    public Text ScoreText;
    public Text SpeedText;
    public Text LevelText;

    public Material material;

    [SerializeField] private Rigidbody rigidbody;

    void Start()
    {
        tailObjects.Add(gameObject);
    }

    void Update()
    {
        SetText();
        Move();
        rigidbody.velocity = new Vector3(joystick.Horizontal*speed, rigidbody.velocity.y, joystick.Vertical*speed);

        if (joystick.Horizontal != 0 || joystick.Vertical !=0) {
            transform.rotation = Quaternion.LookRotation(rigidbody.velocity);
        }
    }

    /**
     * Рендер текста на экране
     */
    private void SetText()
    {
        ScoreText.text = "Очки: " + Counter.score;
        SpeedText.text = "Скорость: " + speed;
        LevelText.text = "Уровень: " + Counter.level;
    }

    /**
     * Движение змеи
     */
    private void Move()
    {
        transform.Translate(Vector3.forward*speed*Time.deltaTime);
    }

    /**
     * Добавление элемента в змейку
     */
    public void AddTail()
    {
        UpScore();
        UpSpeed();
        NextLevel();
        InitTail();
    }

    /**
     * Рендер текста на экране
     */
    private void UpScore()
    {
        Counter.score++;
    }

    /**
     * Увеличение скорости
     */
    private void UpSpeed()
    {
        if (tailObjects.Count % 5 == 0 && speed <= 6) {
            speed++;
        }
    }

    /**
     * Переход на следующий уровень
     */
    private void NextLevel()
    {
        if (Counter.score % 2 == 0 && Counter.level <= 3) {
            Counter.level++;
            Scene.loadLevel(Counter.level);
        }
    }

    /**
     * Инициализация хвоста
     */
    private void InitTail()
    {
        Vector3 newTailPos = tailObjects[tailObjects.Count - 1].transform.position;
        newTailPos.z -= z_offset;

        GameObject tail = GameObject.Instantiate(TailPrefab, newTailPos, Quaternion.identity) as GameObject;
        tail.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value, 1);

        tailObjects.Add(tail);
    }
}
