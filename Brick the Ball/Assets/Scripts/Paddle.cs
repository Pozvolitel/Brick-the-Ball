using UnityEngine;


public class Paddle : MonoBehaviour
{    
    private Vector2 _direction;
    [SerializeField] private float _speed = 500f;
    [SerializeField] private float _maxAngleBounce = 75;
    

    private void Start()
    {
        
    }

    public void ResetPaddle()
    {
        transform.position = new Vector2(0f, transform.position.y);
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) && transform.position.x >= -15.28f)
        {
            transform.position = transform.position + new Vector3(-1, 0, 0) * _speed * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) && transform.position.x <= 15.28f)
        {
            transform.position = transform.position + new Vector3(1, 0, 0) * _speed * Time.deltaTime;
        }
        else
        {
            _direction = Vector2.zero;
        }

       
    } 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();

        if (ball != null)
        {
            Vector3 paddlePosition = transform.position;
            Vector2 contactPoint = collision.GetContact(0).point;

            float offset = paddlePosition.x - contactPoint.x;
            float width = collision.otherCollider.bounds.size.x / 2;

            float currentAngle = Vector2.SignedAngle(Vector2.up, ball._rigidbody.velocity);
            float bounceAngle = (offset / width) * _maxAngleBounce;
            float newAngle = Mathf.Clamp(currentAngle + bounceAngle, -_maxAngleBounce, _maxAngleBounce);

            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            ball._rigidbody.velocity = rotation * Vector2.up * ball._rigidbody.velocity.magnitude;
        }
    }
}
