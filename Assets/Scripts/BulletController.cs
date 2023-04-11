using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] float timeAfterExplosion;
    GameManager GM;
    // Start is called before the first frame update
    void Start()
    {
        GM = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(DestroyBullet());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("WallToDestroy"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SetActive(false);
            GM.GameOver();
        }

    }

    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(timeAfterExplosion);
        Destroy(gameObject);
    }

    
}
