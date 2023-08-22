using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    [SerializeField]
    private BossGameManager_1 bossGameManager;

    [Header("Shooting")]
    public float startTimeBtwShots;
    private float timeBtwShots;
    public bool playerInRange = false;

    public GameObject bullet;
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Transform shotPoint;
    [SerializeField]
    private Transform center;

    [SerializeField]
    private float offset = -90;

    [SerializeField]
    private AudioSource shootAudio;
    [SerializeField]
    private AudioSource skrik;

    public GameObject[] blodpöl;
    public GameObject blodstänk;

    public Sprite deadSprite;

    bool dead;

    [SerializeField]
    private bool bossFight;

    // Start is called before the first frame update
    void Start()
    {
        timeBtwShots = startTimeBtwShots;
        if (!bossFight)
        {
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        }
    }

    private void Update()
    {
        Vector3 difference = target.position - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);


        if (timeBtwShots <= 0 && playerInRange /* player är inom range och inget är ivägen*/)
        {
            Instantiate(bullet, shotPoint.position, transform.rotation);
            shootAudio.Play();
            //Instantiate(shotEffect, shotPoint.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    public void Kill()
    {
        
        if (bossFight)
        {
            bossGameManager.GetComponent<BossGameManager_1>().deadEnemies++;
        }
        else
        {
            gameManager.score += 1000;
            gameManager.deadEnemies++;
        }

        //Instantiate(blodstänk, this.transform.position, Quaternion.identity);
        skrik.PlayDelayed(.35f);
        Instantiate(blodpöl[Random.Range(0,blodpöl.Length)], new Vector3(center.position.x, center.position.y, 2), Quaternion.identity);
        Destroy(GetComponent<CircleCollider2D>());
        //this.gameObject.SetActive(false);
        this.gameObject.transform.position = center.position;
        this.gameObject.transform.rotation = Quaternion.Euler(center.rotation.x, center.rotation.y, Random.Range(0,360));
        gameObject.GetComponent<SpriteRenderer>().sprite = deadSprite;
        Destroy(this);
    }
}
