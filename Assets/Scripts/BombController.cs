using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    [SerializeField] float shootRange;
    [SerializeField] GameObject shootPosition;
    [SerializeField] GameObject bullet;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Bomb());
    }

   
    IEnumerator Bomb()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);

        Instantiate(bullet, shootPosition.transform.position, Quaternion.identity);
        Instantiate(bullet, shootPosition.transform.position, Quaternion.Euler(0, 0, 90));
        Instantiate(bullet, shootPosition.transform.position, Quaternion.Euler(0, 0, -90));
        Instantiate(bullet, shootPosition.transform.position, Quaternion.Euler(0, 0, 180));
        

        //RaycastHit2D hitRight = Physics2D.Raycast(transform.position, Vector3.right, shootRange);
        //RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left, shootRange);
        //RaycastHit2D hitUp = Physics2D.Raycast(transform.position, Vector2.up, shootRange);
        //RaycastHit2D hitDown = Physics2D.Raycast(transform.position, Vector2.down, shootRange);

        ////Destroy(hitRight.transform.gameObject);

        //if (!hitRight /*Physics2D.Raycast(transform.position, Vector3.right, shootRange)*/)
        //{
        //    Debug.DrawRay(transform.position, Vector2.right * shootRange, Color.red, 2f);
        //    Destroy(transform.gameObject);
        //    Debug.Log(hitRight.transform.name);
        //}
        //if(!hitLeft /*Physics2D.Raycast(transform.position, Vector2.left, shootRange)*/)
        //{
        //    Debug.DrawRay(transform.position, Vector2.left * shootRange, Color.red, 2f);
        //    Destroy(transform.gameObject);
        //    Debug.Log(hitLeft.transform.name);
        //}
        //if(!hitUp /*Physics2D.Raycast(transform.position, Vector2.up, shootRange)*/)
        //{
        //    Debug.DrawRay(transform.position, Vector2.up * shootRange, Color.red, 2f);
        //    Destroy(transform.gameObject);
        //    Debug.Log(hitUp.transform.name);
        //}
        //if (!hitDown/*Physics2D.Raycast(transform.position, Vector2.down, shootRange)*/)
        //{
        //    Debug.DrawRay(transform.position, Vector2.down * shootRange, Color.red, 2f);
        //    Destroy(transform.gameObject);
        //    Debug.Log(hitDown.transform.name);
        //}


        
        
        
    }
}
