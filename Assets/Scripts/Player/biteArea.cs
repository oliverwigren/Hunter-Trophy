using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class biteArea : MonoBehaviour
{
    //private GameManager Player;

    public AudioSource biteAudio;
    public AudioSource EatAudio;

    public Animator animator;

    int a = 0;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0))
            {
                if (a == 0)
                {
                    a++;
                    collision.gameObject.GetComponent<Enemy>().Kill();
                    animator.SetTrigger("Kill");
                    if (!EatAudio.isPlaying)
                    {
                        EatAudio.Play();
                    }
                    else
                    {
                        EatAudio.Stop();
                        EatAudio.Play();
                    }
                    a = 0;
                }
            }
        }
        if (collision.CompareTag("Boss"))
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0))
            {
                if (a == 0)
                {
                    a++;
                    collision.gameObject.GetComponent<Boss_1>().Kill();
                    animator.SetTrigger("Kill");
                    if (!EatAudio.isPlaying)
                    {
                        EatAudio.Play();
                    }
                    else
                    {
                        EatAudio.Stop();
                        EatAudio.Play();
                    }
                    a = 0;
                }
            }
        }
        else
        {
            a = 0;
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0))
            {
                animator.SetTrigger("Bite");
                if (!biteAudio.isPlaying)
                {
                    biteAudio.Play();
                }
                else
                {
                    biteAudio.Stop();
                    biteAudio.Play();
                }
            }
        }
    }
}
