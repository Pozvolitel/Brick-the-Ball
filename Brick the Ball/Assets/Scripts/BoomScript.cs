using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomScript : MonoBehaviour
{
    [SerializeField] private AudioSource _boom;

    private void Start()
    {
        _boom = GetComponent<AudioSource>();
    }

    public void BoomPlay()
    {
        _boom.Play();
    }
}
