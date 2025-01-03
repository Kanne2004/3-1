using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public bool chamDat;
    public float speed = 5f;
    public float jump = 3;
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
        Fall();
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
        if (chamDat == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) && chamDat)
            {
                rb.velocity = new Vector2(rb.velocity.x, jump);
                chamDat = false;
            }
            anim.SetBool("jump", !chamDat);
        }

    }
    private void Fall()
    {
        anim.SetBool("fall", !chamDat);  
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Dat"))
        {
            chamDat = true;
        }
    }

    public void move(float move)
    {
        //Vector3 targetVelocity = new Vector2(move * 10, m_Rigidbody2D.velocity.y);
        //m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
    }
}
