using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hippoWalkAcross : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    public int minNum;
    public int maxNum;
    public int animTime;

    // Start is called before the first frame update
    void Start()
    {
        Move();
    }

    void Move()
    {
        StartCoroutine(moveAcross());
    }

    IEnumerator moveAcross()
    {
        yield return new WaitForSeconds(Random.Range(minNum,maxNum));
        animator.SetTrigger("MoveAcross");
        yield return new WaitForSeconds(Random.Range(minNum, maxNum) + animTime + 2);
        Move();
    }
}
