using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMap : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] mapManager mapManager;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float runSpeed = 5.0f;

    //public AudioSource walkAudio;

    //private Animator animator;

    [SerializeField] Transform cameraTransform;

    public Color32 hoverColor;
    //public Color32 disabledColor;
    public Color32 noColor;

    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
    }

    void Update()
    {

        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down

        if (horizontal == -1 && vertical == 0)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0f);
        }
        if (horizontal == 1 && vertical == 0)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 180f);
        }
        if (horizontal == 0 && vertical == -1)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 90f);
        }
        if (horizontal == 0 && vertical == 1)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 270f);//
        }
        if (horizontal == -1 && vertical == -1)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 45f);
        }
        if (horizontal == 1 && vertical == 1)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 225f);
        }
        if (horizontal == -1 && vertical == 1)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 315f);
        }
        if (horizontal == 1 && vertical == -1)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 135f);
        }
    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        rb.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("LevelStarter"))
        {
            //if (collision.GetComponent<Button>().enabled == false)
            //{
            ////    collision.GetComponent<Image>().color = disabledColor;
            //}
            //else
            //{
            string name = collision.name;
            collision.GetComponent<Image>().color = hoverColor;
            if (Input.GetKey(KeyCode.Space))
            {
                mapManager.Invoke(name, 0f);
            }
            //}
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("LevelStarter"))
        {
        collision.GetComponent<Image>().color = noColor;

        }
    }
}
