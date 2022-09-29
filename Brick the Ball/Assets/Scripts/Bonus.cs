using UnityEngine;

public class Bonus : MonoBehaviour
{
    private GameObject _prefabBall;
    public Transform BallPosition;
    [SerializeField] private GameObject _prefabMagnitude;

    private void Start()
    {
        _prefabBall = GameObject.FindGameObjectWithTag("Ball");
    }

    private void RandomBonus()
    {
        var random = Random.Range(1, 20);

        if (random > 10) InstationPrefabBall();
        else InstationPrefabMagnitude();
    }


    private void InstationPrefabMagnitude()
    {
        Instantiate(_prefabMagnitude);
    }

    private void InstationPrefabBall()
    {
        if (!BallPosition) BallPosition.position = Vector2.zero;

        for (int i = 0; i < 3; i++)
        {
            Instantiate(_prefabBall, BallPosition.position, Quaternion.identity);
        }               
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.name == "Paddle")
        {
            RandomBonus();
            Destroy(gameObject);
        }
    }
}
