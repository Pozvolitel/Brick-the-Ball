using UnityEngine;
using UnityEngine.UI;

public class OpenTab : MonoBehaviour
{
    [SerializeField] private GameObject _tabClose;

    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(Open);
    }

    private void Open()
    {
        _tabClose.SetActive(true);
    }
}
