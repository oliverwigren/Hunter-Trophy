using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class mapManager : MonoBehaviour
{
    [Header("goldstar")]
    [SerializeField] GameObject[] star1;
    [SerializeField] GameObject[] star2;
    [SerializeField] GameObject[] star3;
    [SerializeField] GameObject[] star4;
    [SerializeField] GameObject[] star5;
    //public GameObject[] starBoss;

    [Header("lockedstar")]
    [SerializeField] GameObject[] locked1;
    [SerializeField] GameObject[] locked2;
    [SerializeField] GameObject[] locked3;
    [SerializeField] GameObject[] locked4;
    [SerializeField] GameObject[] locked5;
    //public GameObject[] lockedBoss;

    [Header("lås")]
    [SerializeField] GameObject lås2;
    [SerializeField] GameObject lås3;
    [SerializeField] GameObject lås4;
    [SerializeField] GameObject lås5;
    [SerializeField] GameObject låsBoss;

    [Header("HighScore")]
    private int level1HighScore;
    private int level2HighScore;
    private int level3HighScore;
    private int level4HighScore;
    private int level5HighScore;

    [Header("Level-btns")]
    [SerializeField] GameObject btn1;
    [SerializeField] GameObject btn2;
    [SerializeField] GameObject btn3;
    [SerializeField] GameObject btn4;
    [SerializeField] GameObject btn5;
    [SerializeField] GameObject btnB;

    [Header("Animation")]
    [SerializeField]
    Animator animator;

    [SerializeField] GameObject bossImage;

    //public GameObject hippo;
    //public Camera camera;

    private float closeTime = 0.5f;

    public Color32 disabledColor; //?

    //public Sprite bossSprite;
    private int mapSpawnNum;
    private Transform spawnPos;
    [SerializeField] private GameObject playerMap;
    private Vector3 offset;

    private void Awake()
    {
        mapSpawnNum = PlayerPrefs.GetInt("mapSpawnNum", 0);
        //Debug.Log(mapSpawnNum);
        // Get highscore
        level1HighScore = PlayerPrefs.GetInt("Highscore1", 0);
        level2HighScore = PlayerPrefs.GetInt("Highscore2", 0);
        level3HighScore = PlayerPrefs.GetInt("Highscore3", 0);
        level4HighScore = PlayerPrefs.GetInt("Highscore4", 0);
        level5HighScore = PlayerPrefs.GetInt("Highscore5", 0);
    }

    private void Start()
    {
        switch (mapSpawnNum)
        {
            case 1:
                spawnPos = btn1.transform;
                offset = new Vector3(1.4f, -1.5f, 0);
                break;
            case 2:
                spawnPos = btn2.transform;
                offset = new Vector3(1.4f, 1.4f, 0);
                break;
            case 3:
                spawnPos = btn3.transform;
                offset = new Vector3(1.4f, -1.5f, 0);
                break;
            case 4:
                spawnPos = btn4.transform;
                offset = new Vector3(1.4f, 1.4f, 0);
                break;
            case 5:
                spawnPos = btn5.transform;
                offset = new Vector3(1.4f, -1.5f, 0);
                break;
            //case 6:
            //    spawnPos = btnB.transform;
            //    break;
            default:
                offset = new Vector3(0,0,0);
                spawnPos = transform;
                spawnPos.position = new Vector3(0, 0, 0);
                break;
        }
        playerMap.transform.position = spawnPos.position + offset; //Set player position depending on last level

        //set stars active, depending of the highscore
        for (int i = 0; i < level1HighScore; i++)
        {
            star1[i].SetActive(true);
        }

        for (int i = 0; i < level2HighScore; i++)
        {
            star2[i].SetActive(true);
        }

        for (int i = 0; i < level3HighScore; i++)
        {
            star3[i].SetActive(true);
        }

        for (int i = 0; i < level4HighScore; i++)
        {
            star4[i].SetActive(true);
        }

        for (int i = 0; i < level5HighScore; i++)
        {
            star5[i].SetActive(true);
        }


        if (level1HighScore == 0)
        {
            btn2.GetComponent<Image>().color = disabledColor;
            btn2.GetComponent<Button>().enabled = false;
        }
        else
        {
            btn2.GetComponent<Button>().enabled = true;
            lås2.SetActive(false);

            foreach (var a in locked2)
            {
                a.SetActive(true);
            }
        }

        if (level2HighScore == 0)
        {
            btn3.GetComponent<Image>().color = disabledColor;
            btn3.GetComponent<Button>().enabled = false;
        }
        else
        {
            btn3.GetComponent<Button>().enabled = true;
            lås3.SetActive(false);

            foreach (var b in locked3)
            {
                b.SetActive(true);
            }
        }

        if (level3HighScore == 0)
        {
            btn4.GetComponent<Image>().color = disabledColor;
            btn2.GetComponent<Button>().enabled = false;
        }
        else
        {
            btn4.GetComponent<Button>().enabled = true;
            lås4.SetActive(false);

            foreach (var c in locked4)
            {
                c.SetActive(true);
            }
        }

        if (level4HighScore == 0)
        {
            btn5.GetComponent<Image>().color = disabledColor;
            btn5.GetComponent<Button>().enabled = false;
        }
        else
        {
            btn5.GetComponent<Button>().enabled = true;
            lås5.SetActive(false);

            foreach (var d in locked5)
            {
                d.SetActive(true);
            }
        }

        if (level5HighScore == 0)
        {
            btnB.GetComponent<Button>().enabled = false;
        }
        else
        {
            btnB.GetComponent<Button>().enabled = true;
            låsBoss.SetActive(false);
            bossImage.SetActive(true);
        }
    }

    public void Menu()
    {
        StartCoroutine(CloseMenu());
    }

    //Levels
    public void Level_1()
    {
        StartCoroutine(CloseLevel_1());
    }
    public void Level_2()
    {
        if (level1HighScore != 0)
        {
            StartCoroutine(CloseLevel_2());
        }
    }
    public void Level_3()
    {
        if (level2HighScore != 0)
        {
            StartCoroutine(CloseLevel_3());
        }
    }
    public void Level_4()
    {
        if (level3HighScore != 0)
        {
            StartCoroutine(CloseLevel_4());
        }
    }
    public void Level_5()
    {
        if (level4HighScore != 0)
        {
            StartCoroutine(CloseLevel_5());
        }
    }

    //Boss fights
    public void BossFight_1()
    {
        if (level1HighScore != 0 && level2HighScore != 0 && level3HighScore != 0 && level4HighScore != 0 && level5HighScore != 0)
        {
            StartCoroutine(CloseBoss());
        }
    }

    public IEnumerator CloseMenu()
    {
        animator.SetTrigger("close");
        yield return new WaitForSeconds(closeTime);
        SceneManager.LoadScene("Start");
    }

    public IEnumerator CloseLevel_1()
    {
        animator.SetTrigger("close");
        yield return new WaitForSeconds(closeTime);
        SceneManager.LoadScene("Level_1");
    }
    public IEnumerator CloseLevel_2()
    {
        animator.SetTrigger("close");
        yield return new WaitForSeconds(closeTime);
        SceneManager.LoadScene("Level_2");
    }
    public IEnumerator CloseLevel_3()
    {
        animator.SetTrigger("close");
        yield return new WaitForSeconds(closeTime);
        SceneManager.LoadScene("Level_3");
    }
    public IEnumerator CloseLevel_4()
    {
        animator.SetTrigger("close");
        yield return new WaitForSeconds(closeTime);
        SceneManager.LoadScene("Level_4");
    }
    public IEnumerator CloseLevel_5()
    {
        animator.SetTrigger("close");
        yield return new WaitForSeconds(closeTime);
        SceneManager.LoadScene("Level_5");
    }


    public IEnumerator CloseBoss()
    {
        animator.SetTrigger("close");
        yield return new WaitForSeconds(closeTime);
        //SceneManager.LoadScene("BossFight_1");
        SceneManager.LoadScene("Cutscene_BossFight1");
    }
}
