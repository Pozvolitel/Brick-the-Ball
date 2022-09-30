using System.Collections;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    [SerializeField] private GameObject _prefabBall;
    public Vector2 BallPosition;
    [SerializeField] private GameObject _prefabMagnitude;
    private MagnitBonus _magnit;
    [SerializeField] private GameObject _scalePrefab;
    [SerializeField] private GameObject _flyPaddle;

    private void Start()
    {
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
        Instantiate(_scalePrefab);
    }
    private void InstationPrefabMagnitude()
    {
        if (_magnit != null)
        {
            _magnit.Timer = 20f;
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
