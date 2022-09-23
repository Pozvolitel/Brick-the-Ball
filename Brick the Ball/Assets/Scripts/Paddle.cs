using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Vector2 _direction;
    [SerializeField] private float _speed = 30f;
    [SerializeField] private float _maxAngleBounce = 75;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            _direction = Vector2.left;
        }
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _direction = Vector2.right;
        }
        else
        {
            _direction = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        if(_direction != Vector2.zero)
        {
            _rigidbody.AddForce(_direction * _speed);
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
