using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    private GameObject _prefapBall;
    private Transform _ballPosition;

    private void Start()
    {
        _prefapBall = GameObject.FindGameObjectWithTag("Ball");
    }

    private void InstationPrefab()
    {
        _ballPosition = _prefapBall.transform;
        for (int i = 0; i < 3; i++)
        {
            Instantiate(_prefapBall, _ballPosition.position, Quaternion.identity);
        }               
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.name == "Paddle")
        {
            InstationPrefab();
            Destroy(gameObject);
        }
    }
}
