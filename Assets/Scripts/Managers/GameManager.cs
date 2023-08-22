using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Player player;

    [HideInInspector]
    public float score;
    [SerializeField]
    private TMP_Text scoreText;
    [SerializeField]
    private TMP_Text enemiesText;
    [SerializeField]
    private TMP_Text finalScoreText;
    [HideInInspector]
    public int deadEnemies = 0;
    [SerializeField]
    private int maxEnemies;
    [SerializeField]
    Animator animator;

    public GameObject DoneScreen;

    [Header("Scenes")]
    [SerializeField] private int SceneNum;
    private int SceneNum2;
    public string bossFightName;

    [Header("Stars")]
    private int stars = 3;
    [SerializeField] GameObject star1;
    [SerializeField] GameObject star2;
    [SerializeField] GameObject star3;
    int b = 0;

    //public AudioSource music;

    private void Start()
    {
        SceneNum2 = SceneNum;
    }
    // Update is called once per frame
    void Update()
    {
        enemiesText.text = deadEnemies + " / " + maxEnemies;

        if (deadEnemies == maxEnemies && b == 0)
        {
            b++;

            if (player.health < 100)
            {
                stars--;
            }
            if (player.health < 50)
            {
                stars--;
            }

            DoneScreen.SetActive(true);

            string sceneName = "Highscore" + SceneNum2;

            scoreText.text = stars.ToString();
            finalScoreText.text = "STARS " + stars;
            if (stars == 3)
            {
                star1.SetActive(true);
                star2.SetActive(true);
                star3.SetActive(true);
            }
            else if(stars == 2)
            {
                star1.SetActive(true);
                star2.SetActive(true);
                star3.SetActive(false);
            }
            else if (stars == 1)
            {
                star1.SetActive(true);
                star2.SetActive(false);
                star3.SetActive(false);
            }
            else
            {
                star1.SetActive(false);
                star2.SetActive(false);
                star3.SetActive(false);
            }

            int highScore = PlayerPrefs.GetInt(sceneName, 0);
            if (highScore < stars)
            {
                PlayerPrefs.SetInt(sceneName, stars);
            }
        }

    }

    public void Menu()
    {
        StartCoroutine(CloseMenu());
    }
    IEnumerator CloseMenu()
    {
        animator.SetTrigger("close");
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("Map");
    }

    public void Next()
    {
        StartCoroutine(NextClose());
    }
    IEnumerator NextClose()
    {
        animator.SetTrigger("close");
        yield return new WaitForSeconds(.5F);
        if (SceneNum == 5) //SceneNum = 5 => bossfight
        {
            SceneManager.LoadScene(bossFightName);
        }
        else
        {
            SceneNum += 1;
            string sceneName = "Level_" + SceneNum;
            SceneManager.LoadScene(sceneName);
        }
    }

    public void Continue()
    {
        PlayerPrefs.SetInt("mapSpawnNum",SceneNum);
        Debug.Log(SceneNum);
        StartCoroutine(CloseContinue());
    }
    IEnumerator CloseContinue()
    {
        animator.SetTrigger("close");
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("Map");
    }

    public void Retry()
    {
        StartCoroutine(CloseRetry());
    }

    IEnumerator CloseRetry()
    {
        animator.SetTrigger("close");
        yield return new WaitForSeconds(.5f);
        string sceneName = "Level_" + SceneNum;
        SceneManager.LoadScene(sceneName);
    }

    public void Replay()
    {
        StartCoroutine(CloseReplay());
    }

    IEnumerator CloseReplay()
    {
        animator.SetTrigger("close");
        yield return new WaitForSeconds(.5f);
        string String = "Level_" + SceneNum;
        SceneManager.LoadScene(String);
    }
}
