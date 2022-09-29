using UnityEngine;

public class MagnitBonus : MonoBehaviour
{
    [SerializeField] private Ball[] _ball;
    private Paddle _paddle;
    private float _time = 20f;
    private float _speed = 50f;
    private SpriteRenderer _spriteBall;

    private void Start()
    {
        _paddle = FindObjectOfType<Paddle>();
    }

    private void Update()
    { 
        _time -= Time.deltaTime;
        _ball = FindObjectsOfType<Ball>();
        if (_time > 0)
        {
            if (_ball.Length > 0)
            {
                foreach (var item in _ball)
                {
                    if (item.transform.position.y < 0 && item.IsPaddle == false && item != null)
                    {
                        _spriteBall = item.GetComponent<SpriteRenderer>();
                        _spriteBall.color = Color.red;
                        item.transform.position = Vector3.MoveTowards(item.transform.position, _paddle.transform.position, _speed * Time.deltaTime);
                    }
                }
            }
        }
        else
        {
            _spriteBall.color = Color.white;
            Destroy(gameObject);
        }
    }
}
