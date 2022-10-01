using UnityEngine;
using UnityEngine.UI;

public class NewGame : MonoBehaviour
{
    private Button _button;
    [SerializeField] private GameManager _gameManager;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(StartGameScene);
    }

    private void StartGameScene()
    {
        _gameManager.NewGame(1);
    }
}
