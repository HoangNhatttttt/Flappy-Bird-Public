using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    public float speed = 3f;
    private float leftEdge;
    public int enableMoving = 1;

    public void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    public void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime * enableMoving;

        if (transform.position.x <= leftEdge)
            Destroy(gameObject);
    }
}
