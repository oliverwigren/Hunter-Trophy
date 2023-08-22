using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsManager : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    public void Back()
    {
        StartCoroutine(closeBack());
    }

    IEnumerator closeBack()
    {
        animator.SetTrigger("close");
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("Start");
    }
}
