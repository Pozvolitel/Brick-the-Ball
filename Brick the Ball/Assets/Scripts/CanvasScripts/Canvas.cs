using UnityEngine;
using UnityEngine.UI;

public class Canvas : MonoBehaviour
{
    private Image _lives;
    private Image _level;
    private Text _textLives;
    private Text _textLevel;
    private GameManager _gameManager;

    void Start()
    {
        _lives = transform.GetChild(1).GetComponent<Image>();
        _level = transform.GetChild(2).GetComponent<Image>();
        _textLives = _lives.GetComponentInChildren<Text>();
        _textLevel = _level.GetComponentInChildren<Text>();
        _gameManager = FindObjectOfType<GameManager>();
        _gameManager.OnLivesChangedEvent += OnLivesValueChangedHandler;
        OnLivesValueChangedHandler(_gameManager.Lives);
        _gameManager.OnLevelChangedEvent += OnLevelValueChangedHandler;
        OnLevelValueChangedHandler(_gameManager.Level);
    }    

    private void OnLevelValueChangedHandler(int level)
    {
        _textLevel.text = level.ToString();        
    }

    private void OnLivesValueChangedHandler(int lives)
    {
        _textLives.text = lives.ToString();
    }

    private void OnDestroy()
    {
        _gameManager.OnLevelChangedEvent -= OnLevelValueChangedHandler;
        _gameManager.OnLivesChangedEvent -= OnLivesValueChangedHandler;
    }
}