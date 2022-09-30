using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyPaddle : MonoBehaviour
{
    [SerializeField] private GameObject _paddle;
    private Transform _transformPaddle;
    [SerializeField] private GameObject _flyPaddle;
    

    private void Start()
    {
        _paddle = GameObject.FindGameObjectWithTag("Paddle");
        _transformPaddle = _paddle.transform;
        InstantiatePaddle();
        Destroy(gameObject);
    }

    private void InstantiatePaddle()
    {
        Instantiate(_flyPaddle, _transformPaddle.position, Quaternion.identity);        
    }
}
