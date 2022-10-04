using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject _tabOpen;

    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(Open);
        _button.onClick.AddListener(OnPause);
    }

    private void Open()
    {
        _tabOpen.SetActive(true);
    }

    public void OnPause()
    {
        Time.timeScale = 0;        
    }
}
