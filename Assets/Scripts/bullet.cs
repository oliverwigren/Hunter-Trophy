using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float distance;
    public int damage;

    //public GameObject destroyEffect;

    private void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player hit");
            collision.gameObject.GetComponent<Player>().Hit(this.gameObject);
            DestroyProjectile();
        }
        if (collision.CompareTag("Enviroment") || collision.CompareTag("Enemy"))
        {
            DestroyProjectile();
        }
    }

    void DestroyProjectile()
    {
        //Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
