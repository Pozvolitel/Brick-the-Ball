using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Ball ball { get; private set; }
    public Paddle paddle { get; private set; }
    public Bricks[] bricks { get; private set; }
    [SerializeField] private GameObject _prefapBall;

    public int Level = 1;
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
        Instantiate(_prefapBall, _prefapBall.transform.position, Quaternion.identity);
        this.paddle.ResetPaddle();
        if(FindObjectOfType<Bonus>() != null)
        {
            var bonus = FindObjectOfType<Bonus>();
            Destroy(bonus.gameObject);
        }        
    }

    public void Hit(Bricks brick)
    {
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
