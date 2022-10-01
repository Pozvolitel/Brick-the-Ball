using UnityEngine;

public class OpenLevel : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }
    public void LoadLevel(int Level)
    {
        _gameManager.NewGame(Level);
    }
}
