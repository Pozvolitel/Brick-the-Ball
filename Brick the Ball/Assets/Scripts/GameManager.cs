using UnityEngine;
using UnityEngine.SceneManagement;

[SerializeField]
public class GameManager : MonoBehaviour
{
    public event System.Action<int> OnLivesChangedEvent;
    public event System.Action<int> OnLevelChangedEvent;
    public Ball ball { get; private set; }
    public Paddle paddle { get; private set; }
    public Bricks[] bricks { get; private set; }
    [SerializeField] private GameObject _prefapBall;

    [SerializeField] private int _level;
    [SerializeField] private int _lives;
    private GameObject _timer;

    public int Level => _level;
    public int Lives => _lives;

    public void AddLevel(int level)
    {
        _level += level;
        OnLevelChangedEvent?.Invoke(_level);
    }

    public void AddLives(int lives)
    {
        _lives += lives;
        OnLivesChangedEvent?.Invoke(_lives);
    }

    public void SetLevel(int level)
    {
        _level = level;
        OnLevelChangedEvent?.Invoke(_level);
    }

    public void SetLives(int lives)
    {
        _lives = lives;
        OnLivesChangedEvent?.Invoke(_lives);
    }

    private void Awake()
    {
        SceneManager.sceneLoaded += OnLevelLoaded;
    }

    public void NewGame(int LvL)
    {
        if (_lives >= 3)
        {
            _lives = 0;
        }
        this.AddLives(3);
        LoadLevel(LvL);
    }

    private void LoadLevel(int Level)
    {
        this._level = Level;
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
            LoadLevel(this._level + 1);            
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
        NewGame(_level);
    }

    public void Miss()
    {        
        AddLives(-1);

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
