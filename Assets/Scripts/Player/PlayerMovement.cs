using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float runSpeed = 5.0f;
    public float sprintSpeed = 7.0f;
    public bool sprinting;

    public float dashLength;
    public float startDashCooldown;
    private float dashCooldown;

    [SerializeField]
    private float stamina = 5;
    [SerializeField]
    private float maxStamina;

    public Slider staminaBar;

    bool staminaCounting;

    public AudioSource walkAudio;

    private Animator animator;

    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        stamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        staminaBar.value = stamina;

        if (sprinting)
        {
            animator.SetBool("sprinting",true);
        }
        else if (!sprinting)
        {
            animator.SetBool("sprinting", false);
        }
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (stamina > 0)
            {
                sprinting = true;
                animator.SetBool("sprinting", true);
                stamina -= 1 * Time.deltaTime;
            }
            else
            {
                sprinting = false;
                animator.SetBool("sprinting", false);
                if (!staminaCounting)
                {
                    StartCoroutine(staminaCount());
                }
            }
        }
        else
        {
            if (!staminaCounting)
            {
                StartCoroutine(staminaCount());
            }
            sprinting = false;
            animator.SetBool("sprinting", false);
        }
        if (horizontal == -1 && vertical == 0)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0f);
        }
        if (horizontal == 1 && vertical == 0)
        {
            transform.rotation =  Quaternion.Euler(transform.rotation.x, transform.rotation.y, 180f);
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

        int a = 0;
        if (dashCooldown <= 0 && Input.GetKeyDown(KeyCode.LeftAlt) && a == 0)
        {
            a++;
            rb.transform.Translate(Vector2.left * dashLength * Time.deltaTime);
            dashCooldown = startDashCooldown;
            animator.SetTrigger("dashTrigger");
        }
        else
        {
            animator.ResetTrigger("dashTrigger");
            dashCooldown -= Time.deltaTime;
            a = 0;
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

        if (sprinting)
        {
            rb.velocity = new Vector2(horizontal * sprintSpeed, vertical * sprintSpeed);
        }
        else
        {
            rb.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        }
    }

    IEnumerator staminaCount()
    {
        staminaCounting = true;
        yield return new WaitForSeconds(2);
        if (sprinting == false )
        {
            stamina = maxStamina;
            staminaBar.value = stamina;
        }
        staminaCounting = false;
    }

}