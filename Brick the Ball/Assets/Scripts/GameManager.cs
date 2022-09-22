using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int Level = 1;
    public int Score = 0;
    public int Lives = 3;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
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

    
}
