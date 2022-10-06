using UnityEngine;

public class MissZone : MonoBehaviour
{    
    public event System.Action<Ball> OnBallChangedEvent;   
    
    public void RemoveBall(Ball ball)
    {
        OnBallChangedEvent?.Invoke(ball);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {            
            var _ball = collision.transform.GetComponent<Ball>();
            RemoveBall(_ball);
            Destroy(collision.gameObject);
        }        
    } 
}