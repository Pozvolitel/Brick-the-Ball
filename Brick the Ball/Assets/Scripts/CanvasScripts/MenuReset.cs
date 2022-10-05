using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuReset : MonoBehaviour
{
    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ResetLvL);
    }

    private void ResetLvL()
    {
        SceneManager.LoadScene("StartScene");
        Time.timeScale = 1f;
    }
}
