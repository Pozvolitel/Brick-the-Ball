using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindBall : MonoBehaviour
{
    public List<Ball> BallObj = new List<Ball>();
    private MissZone _missZone;

    private void Start()
    {
        _missZone = FindObjectOfType<MissZone>();
        _missZone.OnBallChangedEvent += OnBallValueChangedHandler;
    }
    private void OnBallValueChangedHandler(Ball ball)
    {
        BallObj.Remove(ball);

        if(BallObj.Count <= 0)
        {
            FindObjectOfType<GameManager>().Miss();
        }
    }
}
