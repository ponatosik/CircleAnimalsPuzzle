using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    Vector3 startposition;
    float repeatwidth;
    public float speed = 1f;
    void Start()
    {
        startposition = transform.position;
        repeatwidth = GetComponent<BoxCollider2D>().size.x / 2;
    }
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
        if (transform.position.x < startposition.x - repeatwidth)
        {
            transform.position = startposition;
        }
    } 
}
