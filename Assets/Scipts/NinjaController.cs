using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaController : MonoBehaviour
{
    public float VelocityRunX = 5;
    public float jumpForce = 100;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sr;

    private const int RUN = 0;
    private const int JUMP = 1;
    private const int DIE = 2;

    // Start is called before the first frame update
    private bool isDead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            rb.velocity = new Vector2(VelocityRunX, rb.velocity.y);
            changeAnimation(RUN);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                changeAnimation(JUMP);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            isDead = true;
            changeAnimation(DIE);
        }
    }

    private void changeAnimation(int animation)
    {
        animator.SetInteger("Estado", animation);
    }
}
