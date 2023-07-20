using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{
    public float speed = 5;
    private float moveInput;
    private float offset = 4f;

    public FixedJoystick joystick;

    public List<GameObject> tailObjects = new List<GameObject>();
    public List<Vector3> positions = new List<Vector3>();

    public GameObject TailPrefab;

    public Text ScoreText;
    public Text SpeedText;
    public Text LevelText;

    [SerializeField] private Rigidbody rigidbodyComp;

    public const int MAX_SPEED = 7;
    public const int MAX_LEVEL = 4;
    public const int MAX_SCORE_TO_NEXT_LEVEL = 10;
    public const int MAX_TAIL_TO_SPEED_UP = 5;

    void Start()
    {
        tailObjects.Add(gameObject);
    }

    void Update()
    {
        SetText();
        Move();
        if (rigidbodyComp) {
            rigidbodyComp.velocity = new Vector3(joystick.Horizontal*speed, rigidbodyComp.velocity.y, joystick.Vertical*speed);
            if (joystick.Horizontal != 0 || joystick.Vertical !=0) {
                transform.rotation = Quaternion.LookRotation(rigidbodyComp.velocity);
            }
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
        if (tailObjects.Count % Snake.MAX_TAIL_TO_SPEED_UP == 0 && speed < Snake.MAX_SPEED) {
            speed++;
        }
    }

    /**
     * Переход на следующий уровень
     */
    private void NextLevel()
    {
        if (Counter.score % Snake.MAX_SCORE_TO_NEXT_LEVEL == 0 && Counter.level < Snake.MAX_LEVEL) {
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
        newTailPos.z -= offset;

        GameObject tail = GameObject.Instantiate(TailPrefab, newTailPos, Quaternion.identity) as GameObject;

        tailObjects.Add(tail);
    }
}
