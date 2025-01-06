using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public bool chamDat;
    bool nhay;
    bool doubleJump;
    public float speed = 5f;
    public float jump = 3;
    public float doublejump = 2;
    public float traiPhai;

    public Rigidbody2D rb;
    public Animator anim;
    // Update is called once per frame
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        DiChuyen();
        Jump();
        //Fall();
    }

    private void DiChuyen()
    {
        traiPhai = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(traiPhai * speed, rb.velocity.y);

        if (traiPhai < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (traiPhai > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        anim.SetBool("walk", traiPhai != 0);
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && chamDat)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
            nhay = false;
        }
        if (Input.GetKeyDown(KeyCode.Space)&& chamDat)
            {
                doublejump = doublejump - 1;
            }
        anim.SetBool("jump", !nhay);
        if (doublejump == 1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = new Vector2(rb.velocity.x, jump);
            }
            doubleJump = true;
        }
        if (doublejump == 0)
        {            
            anim.SetBool("doublejump", doubleJump);
        }

        Debug.Log(doublejump);
    }

    //private void Fall()
    //{
    //    anim.SetBool("fall", !chamDat);  
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Dat"))
        {
            Debug.Log(chamDat);
            
            chamDat = true;
            doublejump = 2;
            nhay = true;
            doubleJump = false;
            Debug.Log("dJ: "+ doubleJump);
        }
    }
}
