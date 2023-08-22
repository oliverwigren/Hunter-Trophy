using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossGameManager_1 : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    public BossPositioner bossPositioner;
    public Boss_1 boss;

    public GameObject WinMenu;

    public int deadEnemies = 0;

    // Update is called once per frame
    void Update()
    {
        if (deadEnemies == 2)
        {
            bossPositioner.GetComponent<BossPositioner>().CoolPhaseOff();
            boss.NoEnemies = true;
        }
    }

    public void Win()
    {
        PlayerPrefs.SetInt("mapSpawnNum", 6);
        //Debug.Log("win");
        WinMenu.SetActive(true);
    }

    public void Menu()
    {
        StartCoroutine(CloseMenu());
       // Debug.Log("menu");
    }
    IEnumerator CloseMenu()
    {
        animator.SetTrigger("close");
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("Map");
    }

    public void Retry()
    {
        StartCoroutine(CloseRetry());
        //Debug.Log("retry");
    }

    IEnumerator CloseRetry()
    {
        animator.SetTrigger("close");
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("BossFight_1");
    }

    public void Continue()
    {
        StartCoroutine(CloseContinue());
        //Debug.Log("continue");
    }

    IEnumerator CloseContinue()
    {
        animator.SetTrigger("close");
        yield return new WaitForSeconds(.5f);
        //SceneManager.LoadScene("OutroBossFight_1");
        SceneManager.LoadScene("Start");
    }
}
