using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;

public class Char : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public float moveSpeed = 5f;
    public float defSpeed = 5f;
    public float jumpHeight = 700f;
    public static float dirX;
    private bool facingRight = true;
    private Vector3 localScale;
    public Transform firePoint;

    //health
    public static int health;
    public GameObject heart1, heart2, heart3;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        localScale = transform.localScale;

        health = 3;
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        //movements
        dirX = CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed;

        if (CrossPlatformInputManager.GetButtonDown("Jump") && rb.velocity.y == 0)
            rb.AddForce(Vector2.up * jumpHeight);
        
        if (Mathf.Abs(dirX) > 0 && rb.velocity.y == 0)
            anim.SetBool("isRun", true);
        else
            anim.SetBool("isRun", false);

        if(rb.velocity.y == 0)
        {
            anim.SetBool("isJump", false);
            anim.SetBool("isFall", false);
        }

        if(rb.velocity.y > 0)
        {
            anim.SetBool("isJump", true);
        }
        if(rb.velocity.y < 0)
        {
            anim.SetBool("isJump", false);
            anim.SetBool("isFall", true);
        }

        //health
        if (health > 3)
            health = 3;

        switch (health)
        {
            case 3:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                break;


            case 2:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(false);
                break;

            case 1:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                break;

            case 0:
                killPlayer();
                break;
        }
    }

    public void killPlayer()
    {
        //kill player
        heart1.gameObject.SetActive(false);
        heart2.gameObject.SetActive(false);
        heart3.gameObject.SetActive(false);
        //Destroy(gameObject);
        //Time.timeScale = 0f;
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, rb.velocity.y);
    }

    private void LateUpdate()
    {
        //flip player
        if (dirX > 0)
            facingRight = true;
        else if (dirX < 0)
            facingRight = false;

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
        {
            localScale.x *= -1;
            firePoint.transform.Rotate(0f, 180f, 0f);
        }
        

        transform.localScale = localScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //enter shop
        if(collision.gameObject.tag == "Shop")
        {
            DataInventory.showInventory = true;
        }
    }

    public void charTakeDamage(int dmg)
    {
        //take damage
        health -= dmg;
    }
}
