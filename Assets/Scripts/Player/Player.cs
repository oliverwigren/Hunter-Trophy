using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject gameManager;

    public GameObject GameOverScreen;

    public float health;
    public float maxHealth;

    public healthBar healthBar;

    public GameObject blodStänk;
    public GameObject blodPöl;
    Animator animator;
    public AudioSource gåLjud;

    [SerializeField]
    private bool bossFight;

    private int a = 0;

    private void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        animator = this.gameObject.GetComponent<Animator>();
    }

    public void Hit(GameObject angle)
    {
        health -= 20;
        if (bossFight)
        {
            //gameManager.GetComponent<BossGameManager_1>().score -= 50;
        }
        else
        {
            gameManager.GetComponent<GameManager>().score -= 50;
        }
        healthBar.SetHealth(health);
        Instantiate(blodStänk, transform.position, angle.transform.rotation);
    }

    private void Update()
    {
        if (health <= 0 && a == 0)
        {
            a++;
            GameOver();
            Instantiate(blodPöl, new Vector3(transform.position.x -0.6f , transform.position.y, 1), Quaternion.identity);
            animator.SetBool("Dead", true);
        }
    }

    public void GameOver()
    {
        GameOverScreen.SetActive(true);
        gameObject.GetComponentInChildren<PlayerMovement>().enabled = false;
        gåLjud.Stop();
        //Time.timeScale = 0.0f;
    }
}
