using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Ball ball { get; private set; }
    public Paddle paddle { get; private set; }
    public Bricks[] bricks { get; private set; }
    [SerializeField] private GameObject _prefapBall;

    public List<GameObject> BallObj = new List<GameObject>();
    
    public int Level = 1;
    public int Score = 0;
    public int Lives = 3;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        SceneManager.sceneLoaded += OnLevelLoaded;
    }

    void Start()
    {
        NewGame();
    } 

    private void NewGame()
    {
        this.Score = 0;
        this.Lives = 3;
        
        LoadLevel(1);
    }

    private void LoadLevel(int Level)
    {
        this.Level = Level;

        SceneManager.LoadScene("Level" + Level);
    }

    private void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        this.ball = FindObjectOfType<Ball>();
        this.paddle = FindObjectOfType<Paddle>();
        this.bricks = FindObjectsOfType<Bricks>();        
    }

    private void ResetLevel()
    {
        //this.ball.ResetBall();
        Instantiate(_prefapBall, _prefapBall.transform.position, Quaternion.identity);
        this.paddle.ResetPaddle();
        
    }

    public void Hit(Bricks brick)
    {
        this.Score += brick.points;
        

        if (Cleared())
        {
            LoadLevel(this.Level + 1);
        }
    }

    private bool Cleared()
    {
        for (int i = 0; i < this.bricks.Length; i++)
        {
            if(bricks[i].gameObject.activeInHierarchy)
            {
                return false;
            }
        }
        return true;
    }

    private void GameOver()
    {
        NewGame();
    }

    public void Miss()
    {
        
            if (BallObj.Count <= 0)
            {
                this.Lives--;

                if (Lives > 0)
                {
                    ResetLevel();
                }
                else
                {
                    GameOver();
                }
                return;

            }
        
        

    }
}
