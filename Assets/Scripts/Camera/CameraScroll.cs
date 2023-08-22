using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll : MonoBehaviour
{
    Rigidbody2D rb;
    float horizontal; 
    public float speed;
    public float maxWidth;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= 0)
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
        } 
        if (transform.position.x >= maxWidth)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
        }
        if (transform.position.x <= maxWidth && transform.position.x >= 0)
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
        }


    }
}
