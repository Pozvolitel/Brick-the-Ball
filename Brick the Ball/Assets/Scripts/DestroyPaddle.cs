using UnityEngine;

public class DestroyPaddle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "WallUp")
        {
            Destroy(gameObject);
        }
    }
    
}
