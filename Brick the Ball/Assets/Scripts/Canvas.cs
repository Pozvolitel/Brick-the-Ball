using UnityEngine;
using UnityEngine.UI;

public class Canvas : MonoBehaviour
{
    [SerializeField] private Image _lives;
    [SerializeField] public Image _level;
    private Text _textLives;
    private Text _textLevel;
    public int Lives;
    public int Level;

    void Start()
    {
        _lives = transform.GetChild(1).GetComponent<Image>();
        _level = transform.GetChild(2).GetComponent<Image>();
        _textLives = _lives.GetComponentInChildren<Text>();
        _textLevel = _level.GetComponentInChildren<Text>();
    }

    public void UpdateScore()
    {
        _textLives.text = Lives.ToString();
        _textLevel.text = Level.ToString();
    }       
}
