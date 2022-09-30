using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalePaddle : MonoBehaviour
{
    private GameObject _paddle;

    private void Start()
    {
        _paddle = GameObject.FindGameObjectWithTag("Paddle");
        _paddle.transform.localScale = new Vector2(10, 0.5f);
        StartCoroutine(Countdown());

    }

    private IEnumerator Countdown()
    {
        while (true)
        {
            yield return new WaitForSeconds(20);
            _paddle.transform.localScale = new Vector2(5, 0.5f);
            Destroy(gameObject);
        }
    }
}
