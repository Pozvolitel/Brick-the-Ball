using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResetLevel : MonoBehaviour
{
    private Button _button;

    private void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ResetLvL);
    }

    private void ResetLvL()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
