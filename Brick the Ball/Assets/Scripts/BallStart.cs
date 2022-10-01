using UnityEngine;

[SerializeField]
public class BallStart : MonoBehaviour
{
    public Rigidbody2D _rigidbody;
    [SerializeField] private float _speed = 300f;    
    private Vector2 _force;    
   
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        SetTrajectory();
    }

    private void SetTrajectory()
    {
        _force = Vector2.zero;
        _force.x = Random.Range(-1f, 1f);
        _force.y = -1f;
        _rigidbody.AddForce(_force.normalized * _speed);
    }           
}
