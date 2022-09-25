using UnityEngine;
using UnityEngine.UI;

public class Canvas : MonoBehaviour
{
    [SerializeField] private Image _scoreImage;
    [SerializeField] private Image _lives;
    [SerializeField] public Image _level;
    private Text _textScore;
    private Text _textLives;
    private Text _textLevel;

    void Start()
    {
        _scoreImage = transform.GetChild(0).GetComponent<Image>();
        _lives = transform.GetChild(1).GetComponent<Image>();
        _level = transform.GetChild(2).GetComponent<Image>();
        _textScore = _scoreImage.GetComponentInChildren<Text>();
        _textLives = _lives.GetComponentInChildren<Text>();
        _textLevel = _level.GetComponentInChildren<Text>();
    }

    private void Update()
    {
        _textLives.text = FindObjectOfType<GameManager>().Lives.ToString();
        _textLevel.text = FindObjectOfType<GameManager>().Level.ToString();
    }
    public void HitScore()
    {
        _textScore.text = FindObjectOfType<GameManager>().Score.ToString();
    }

    
}
