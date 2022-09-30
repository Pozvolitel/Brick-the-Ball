using System.Collections.Generic;
using UnityEngine;

public class MissZone : MonoBehaviour
{
    public List<GameObject> BallObj = new List<GameObject>();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            RemoveObj(collision.gameObject);
            Destroy(collision.gameObject);
        }        
    }

    private void RemoveObj(GameObject Ball)
    {
        BallObj.Remove(Ball);
    }

    private void Update()
    {
        if (BallObj.Count <= 0)
        {
            FindObjectOfType<GameManager>().Miss();
        }
    }
}