using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    private GameObject _prefabBall;
    public Transform BallPosition;

    private void Start()
    {
        _prefabBall = GameObject.FindGameObjectWithTag("Ball");
    }

    private void InstationPrefab()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(_prefabBall, BallPosition.position, Quaternion.identity);
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
