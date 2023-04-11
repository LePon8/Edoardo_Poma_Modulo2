using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject[] pPoints;
    [SerializeField] float enemySpeed;
    [SerializeField] float timeBeforemove;

    GameManager GM;

    // Start is called before the first frame update
    void Start()
    {
        GM = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(EnemyMovement());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SetActive(false);
            GM.GameOver();
        }
    }

    int index = 0;
    IEnumerator EnemyMovement()
    {
        if (index == 0/*pPoints.Length - 1 != index*/)
        {
            yield return new WaitForSeconds(timeBeforemove);
            transform.position = Vector3.MoveTowards(transform.position, pPoints[0].transform.position, enemySpeed * Time.deltaTime);
            if(Vector3.Distance(transform.position, pPoints[0].transform.position) <= 0)
            {
                index = 1;
            }
     
        }
        if (index == 1)
        {
            yield return new WaitForSeconds(timeBeforemove);
            transform.position = Vector3.MoveTowards(transform.position, pPoints[1].transform.position, enemySpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, pPoints[1].transform.position) <= 0 /*&& index != 0*/)
            {
                index = 0;
            }
           
            
        }
        

    }
}
