using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D _rigidbody;
    [SerializeField] private float _speed = 500f;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        Invoke(nameof(SetTrajectory), 1f);
    }

   private void SetTrajectory()
    { 
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-1f, 1f);
        force.y = -1f;
        _rigidbody.AddForce(force.normalized * _speed);

        
    }

}
