using UnityEngine;

public class Bonus : MonoBehaviour
{
    [SerializeField] private GameObject _prefabBall;
    public Vector2 BallPosition;
    [SerializeField] private GameObject _prefabMagnitude;
    private MagnitBonus _magnit;    
    [SerializeField] private GameObject _flyPaddle;
    private GameObject _paddle;

    private void Start()
    {
        _paddle = GameObject.FindGameObjectWithTag("Paddle");
        _magnit = FindObjectOfType<MagnitBonus>();
    }

    private void RandomBonus()
    {
        var random = Random.Range(1, 5);

        if (random == 1) InstationPrefabBall();
        else if (random == 2) InstationPrefabMagnitude();
        else if (random == 3) ScalePadd();
        else if (random == 4) flyPaddle();
    }

    private void flyPaddle()
    {
        Instantiate(_flyPaddle);
    }
  
    private void ScalePadd()
    {
        if(_paddle.transform.localScale.x == 5)
        {
            _paddle.transform.localScale = new Vector2(10, 0.5f);
        }
        else if(_paddle.transform.localScale.x == 10)
        {
            _paddle.transform.localScale = new Vector2(5, 0.5f);
        }
    }
    private void InstationPrefabMagnitude()
    {
        if (_magnit != null)
        {
            _magnit.Timer = 10f;
        }
        else
        {
            Instantiate(_prefabMagnitude);
        }
    }

    private void InstationPrefabBall()
    {
        if (BallPosition != null)
        {
            for (int i = 0; i < 3; i++)
            {
                Instantiate(_prefabBall, BallPosition, Quaternion.identity);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.name == "Paddle")
        {
            RandomBonus();
            Destroy(gameObject);
        }
        else if(collision.transform.name == "WallDown")
        {
            Destroy(gameObject);
        }
    }
}
