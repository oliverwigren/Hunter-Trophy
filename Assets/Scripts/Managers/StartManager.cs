using UnityEngine;
using System;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    [SerializeField]
    Animator animator;


    public void Play()
    {
        StartCoroutine(ClosePlay());
    }

    public void Credits()
    {
        StartCoroutine(CloseCredits());
    }
    IEnumerator CloseCredits()
    {
        animator.SetTrigger("close");
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("Credits");
    }
    IEnumerator ClosePlay()
    {
        animator.SetTrigger("close");
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("Map");
    }

    public void Quit()
    {
        Application.Quit();
    }

}
