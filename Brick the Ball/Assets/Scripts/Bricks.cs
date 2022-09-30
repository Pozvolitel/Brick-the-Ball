using UnityEngine;
using UnityEngine.UI;

public class Bricks : MonoBehaviour
{
    public SpriteRenderer SpriteRend { get; private set; }
    public Color[] states;
    public int health { get; private set; }
    public bool unbreakable;
    public int points = 100;
    [SerializeField] private GameObject _prefabBonus;
    private bool isBonus = false;
    

    private void Awake()
    {
        this.SpriteRend = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        ResetBricks();
        
    }

    public void ResetBricks()
    {
        gameObject.SetActive(true);

        if (!this.unbreakable)
        {
            this.health = this.states.Length;
            this.SpriteRend.color = this.states[this.health - 1];
        }
    }

    private bool RandomHit(int value)
    {
        int random = Random.Range(1, 100);
        if (value > random) return true;
        else return false;
    }
    private void Hit()
    {
        if(this.unbreakable)
        {
            return;
        }
        this.health--;

        if (this.health <= 0)
        {
            this.gameObject.SetActive(false);
            if(RandomHit(80))
            {
                isBonus = true;
                Instantiate(_prefabBonus, this.transform.position, Quaternion.identity);
            }
        }
        else
        {
            this.SpriteRend.color = this.states[this.health - 1];
        }

        FindObjectOfType<GameManager>().Hit(this);        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            Hit();
            if(isBonus)
            {
                Vector2 ballPosition = collision.transform.position;
                FindObjectOfType<Bonus>().BallPosition = ballPosition;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "FlyPaddle")
        {
            Hit();
            if (isBonus)
            {
                Vector2 ballPosition = collision.transform.position;
                FindObjectOfType<Bonus>().BallPosition = ballPosition;
            }
        }
    }
}
