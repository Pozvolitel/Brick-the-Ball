using System.Collections.Generic;
using UnityEngine;

public class MissZone : MonoBehaviour
{
    public List<GameObject> BallObj = new List<GameObject>();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            Destroy(collision.gameObject);
        }
        
    }
    private void Update()
    {
        if (BallObj.Count <= 0)
        {
            Debug.Log("+");
            FindObjectOfType<GameManager>().Miss();
        }
    }
}