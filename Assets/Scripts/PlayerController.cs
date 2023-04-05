using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float playerSpeed;

    [Header("Shooting")]
    [SerializeField] GameObject bomb;
    [SerializeField] float countDownBetweenShoot;
    private float countDownNextShoot;



    //private Vector2 direction = Vector2.down;
    
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        InstantiateBomb();
    }

    private void PlayerMovement()
    {
        float xMovement = Input.GetAxis("Horizontal");
        float yMovement = Input.GetAxis("Vertical");

        Vector2 Movement = new Vector2(xMovement, yMovement);
        rb.MovePosition(rb.position + Movement * Time.deltaTime * playerSpeed);

    }



    private void InstantiateBomb()
    {
        if (Input.GetKeyDown(KeyCode.Space) && countDownNextShoot > countDownBetweenShoot)
        {
            Instantiate(bomb, transform.position, Quaternion.identity);
            countDownNextShoot = 0;
            
        }

        countDownNextShoot += Time.deltaTime;
    }
}
