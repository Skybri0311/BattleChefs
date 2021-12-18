using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 startPosition;
    private void Awake()
    {
        rb = FindObjectOfType<Rigidbody2D>();
    }

    void Start()
    {
       startPosition = rb.position;
    }

}
