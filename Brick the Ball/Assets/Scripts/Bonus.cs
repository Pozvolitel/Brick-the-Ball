using UnityEngine;

public class Bonus : MonoBehaviour
{
    [SerializeField] private GameObject _prefabBall;
    public Vector2 BallPosition;
    [SerializeField] private GameObject _prefabMagnitude;
    private MagnitBonus _magnit;    
    [SerializeField] private GameObject _flyPaddle;
    private GameObject _paddle;
    [SerializeField] private AudioSource _prelesno;
    [SerializeField] private AudioSource _malovato;
    [SerializeField] private AudioSource _goodby;
    [SerializeField] private AudioSource _viju;
    [SerializeField] private AudioSource _neViju;

    private void Start()
    {
        _paddle = GameObject.FindGameObjectWithTag("Paddle");
        _magnit = FindObjectOfType<MagnitBonus>();
    }

    private void RandomBonus()
    {
        var random = Random.Range(1, 5);

        if (random == 1)
        {
            _malovato.Play();
            InstationPrefabBall();
        }
        else if (random == 2)
        {
            _prelesno.Play();
            InstationPrefabMagnitude();
        }
        else if (random == 3)
        {
            ScalePadd();
        }
        else if (random == 4)
        {
            _goodby.Play();
            flyPaddle();
        }
    }

    private void flyPaddle()
    {
        Instantiate(_flyPaddle);
    }
  
    private void ScalePadd()
    {
        if(_paddle.transform.localScale.x == 5)
        {
            _viju.Play();
            _paddle.transform.localScale = new Vector2(10, 0.5f);
        }
        else if(_paddle.transform.localScale.x == 10)
        {
            _neViju.Play();
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
            Destroy(gameObject, 3f);
        }
        else if(collision.transform.name == "WallDown")
        {
            Destroy(gameObject, 3f);
        }
    }
}
