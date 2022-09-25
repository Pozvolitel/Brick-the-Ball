using UnityEngine;

public class MissZone : MonoBehaviour
{
    [SerializeField] private GameObject[] _ball;

   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Destroy(collision.gameObject);                                           
        }
    }   
}
