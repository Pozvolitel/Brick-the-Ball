using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Text _second;
    private Text _minutes;
    private float _time = 0;
    private int _minInt;

    private void Start()
    {
        _second = transform.GetChild(0).GetComponent<Text>();
        _minutes = transform.GetChild(1).GetComponent<Text>();
    }

    private void Update()
    {
        _time += Time.deltaTime;
        _second.text = Mathf.Round(_time).ToString();
        if(_time >= 59)
        {
            _time = 0;
            _minInt++;
            _minutes.text = _minInt.ToString();
        }
    }
}
