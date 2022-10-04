using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Play : MonoBehaviour
{
    [SerializeField] private GameObject _tabClose;

    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(Close);
        _button.onClick.AddListener(OnResume);
    }

    private void Close()
    {
        _tabClose.SetActive(false);
    }

    public void OnResume()
    {
        Time.timeScale = 1f;        
    }
}
