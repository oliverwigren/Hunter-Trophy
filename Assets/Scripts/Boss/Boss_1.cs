using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_1 : MonoBehaviour
{
    [SerializeField] GameObject parent;

    public bool NoEnemies;

    public BossGameManager_1 BossGameManager;

    [Header("Shooting")]
    public float startTimeBtwShots;
    private float timeBtwShots;

    public GameObject bullet;
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Transform shotPoint;
    [SerializeField]
    private Transform center;

    public Sprite deadSprite;

    public GameObject blodpöl;

    [SerializeField]
    private float offset = -90;

    [SerializeField]
    private AudioSource shootAudio;

    private int a = 0;

    public AudioSource skrik;

    private void Start()
    {
        timeBtwShots = startTimeBtwShots;
    }

    void Update()
    {
        Vector3 difference = target.position - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);


        if (timeBtwShots <= 0 && a==0/* player är inom range och inget är ivägen*/)
        {
            a++;
            StartCoroutine(Shoot());
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    public void Kill()
    {
        Debug.Log("Boss");
        if (!NoEnemies)
        {
        parent.GetComponent<BossPositioner>().CoolPhaseOn();

        }
        else
        {
            BossGameManager.Win();
            //this.gameObject.transform.position = center.position;
            //this.gameObject.transform.rotation = Quaternion.Euler(center.rotation.x, center.rotation.y, Random.Range(0, 360));
            skrik.Play();
            gameObject.GetComponent<SpriteRenderer>().sprite = deadSprite;
            Destroy(GetComponent<CircleCollider2D>());
            Instantiate(blodpöl, new Vector3(center.position.x, center.position.y, 12), Quaternion.identity);
            Destroy(this);
        }
    }

    IEnumerator Shoot()
    {
        Instantiate(bullet, shotPoint.position, transform.rotation);
        shootAudio.Play();
        //Instantiate(shotEffect, shotPoint.position, Quaternion.identity);
        yield return new WaitForSeconds(.3f);
        Instantiate(bullet, shotPoint.position, transform.rotation);
        shootAudio.Play();
        //Instantiate(shotEffect, shotPoint.position, Quaternion.identity);
        yield return new WaitForSeconds(.3f);
        Instantiate(bullet, shotPoint.position, transform.rotation);
        shootAudio.Play();
        //Instantiate(shotEffect, shotPoint.position, Quaternion.identity);

        timeBtwShots = startTimeBtwShots;
        a = 0;
    }
}
