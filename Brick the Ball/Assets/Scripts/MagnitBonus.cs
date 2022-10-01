using UnityEngine;

public class MagnitBonus : MonoBehaviour
{
    [SerializeField] private Ball[] _ball = new Ball[100];
    private Paddle _paddle;
    public float Timer = 10f;
    private float _speed = 50f;
    private SpriteRenderer _spriteBall;
    private TrailRenderer trailWhite;
    private TrailRenderer trailRed;

    private void Start()
    {
        _paddle = FindObjectOfType<Paddle>();
    }

    private void Update()
    { 
        Timer -= Time.deltaTime;
        _ball = FindObjectsOfType<Ball>();
        if (Timer > 0)
        {
            if (_ball.Length > 0)
            {
                foreach (var item in _ball)
                {
                    if (item.transform.position.y < 0 && item.IsPaddle == false && item != null)
                    {
                        _spriteBall = item.GetComponent<SpriteRenderer>();
                        _spriteBall.color = Color.red;
                        trailWhite = item.transform.GetChild(0).GetComponent<TrailRenderer>();
                        trailRed = item.transform.GetChild(1).GetComponent<TrailRenderer>();
                        trailWhite.enabled = false;
                        trailRed.enabled = true;
                        item.transform.position = Vector3.MoveTowards(item.transform.position, _paddle.transform.position, _speed * Time.deltaTime);
                    }
                }
            }
        }
        else
        {
            foreach (var item in _ball)
            {
                _spriteBall = item.GetComponent<SpriteRenderer>();
                _spriteBall.color = Color.white;
                trailWhite = item.transform.GetChild(0).GetComponent<TrailRenderer>();
                trailRed = item.transform.GetChild(1).GetComponent<TrailRenderer>();
                trailWhite.enabled = true;
                trailRed.enabled = false;
            }
            
            Destroy(gameObject);
        }
    }
}
