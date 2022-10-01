using UnityEngine;
using UnityEngine.UI;

public class CloseTab : MonoBehaviour
{
    [SerializeField] private GameObject _tabClose;
    
    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(Close);
    }

    private void Close()
    {
        _tabClose.SetActive(false);
    }
}
