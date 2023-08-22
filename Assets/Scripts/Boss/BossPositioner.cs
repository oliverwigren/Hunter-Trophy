using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPositioner : MonoBehaviour
{
    public GameObject BossPos1;
    public GameObject BossPos2;
    public GameObject BossPos3;

    public GameObject Enemy1;
    public GameObject Enemy2;

    public int posNum;

    public GameObject Boss;

    private void Start()
    {
        posNum = Random.Range(1,3);
    }
    public void switchPosition(int num)
    {
        bool boss1busy = BossPos1.GetComponent<BossPos>().busy;
        bool boss2busy = BossPos2.GetComponent<BossPos>().busy;
        bool boss3busy = BossPos3.GetComponent<BossPos>().busy;

        if (boss1busy)
        {
            if (num == 1)
            {
                gameObject.transform.position = BossPos2.transform.position;
                posNum = 1;
            }
            if (num == 2)
            {
                gameObject.transform.position = BossPos3.transform.position;
                posNum = 2;
            }
            if (num == 3)
            {
                gameObject.transform.position = BossPos2.transform.position;
                posNum = 3;
            }
        }
        if (boss2busy)
        {
            if (num == 1)
            {
                gameObject.transform.position = BossPos1.transform.position;
                posNum = 2;
            }
            if (num == 2)
            {
                gameObject.transform.position = BossPos3.transform.position;
                posNum = 4;
            }
            if (num == 3)
            {
                gameObject.transform.position = BossPos3.transform.position;
                posNum = 1;
            }
        }
        if (boss3busy)
        {
            if (num == 1)
            {
                gameObject.transform.position = BossPos2.transform.position;
                posNum = 2;
            }
            if (num == 2)
            {
                gameObject.transform.position = BossPos1.transform.position;
                posNum = 2;
            }
            if (num == 3)
            {
                gameObject.transform.position = BossPos1.transform.position;
                posNum = 1;
            }
        }
        else
        {
            if (num == 1)
            {
                gameObject.transform.position = BossPos1.transform.position;
                posNum = 2;
            }
            if (num == 2)
            {
                gameObject.transform.position = BossPos2.transform.position;
                posNum = 3;
            }
            if (num == 3)
            {
                gameObject.transform.position = BossPos3.transform.position;
                posNum = 3;
            }
        }


    }

    public void CoolPhaseOn()
    {
        Boss.SetActive(false);
        switchPosition(posNum);
        StartEnemies();
    }
    public void CoolPhaseOff()
    {
        Boss.SetActive(true);
    }

    public void StartEnemies()
    {
        Enemy1.SetActive(true);
        Enemy2.SetActive(true);
    }
}
