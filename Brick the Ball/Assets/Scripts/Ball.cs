using UnityEngine;
using System.Collections.Generic;

[SerializeField]
public class Ball : MonoBehaviour
{
    public Rigidbody2D _rigidbody;
    [SerializeField] private float _speed = 300f;
    private int isWall = 1;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        
        ResetBall();
        FindObjectOfType<GameManager>().BallObj.Add(gameObject);
    }

    private void OnDestroy()
    {
        
        FindObjectOfType<GameManager>().Miss();
        FindObjectOfType<GameManager>().BallObj.Remove(gameObject);
    }

    public void ResetBall()
    {
        transform.position = Vector2.zero;
        _rigidbody.velocity = Vector2.zero;
        Invoke(nameof(SetTrajectory), 1f);
    }

   private void SetTrajectory()
    {
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-1f, 1f);
        force.y = -1f;
        _rigidbody.AddForce(force.normalized * _speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            isWall++;
            if(isWall > 5)
            {
                ResetBall();
            }
        }
        else if(collision.gameObject.tag == "Bricks" || collision.gameObject.tag == "Paddle")
        {
            isWall = 1;
        }
    }
}
