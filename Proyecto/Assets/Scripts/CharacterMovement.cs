using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {
    public float speed = 10f;
    public bool facingRight = true;
    public int attackFrames = 7;
    public int currentAttackFrame = 7;
    public float jumpforce = 100f;
    public bool isGrounded = true;
    public bool isAttacking = false;
    BoxCollider2D bc;
    Animator anim;
    SpriteRenderer sr;
    Rigidbody2D rb;
    CapsuleCollider2D cc;
    Vector3 StartingPosition;
	// Use this for initialization
	void Start ()
    {
        bc = GetComponent<BoxCollider2D>();
        cc = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        StartingPosition = new Vector3(transform.position.x,transform.position.y,transform.position.z);
    }
	
	// Update is called once per frame
	void Update ()
    {
        float movX = Input.acceleration.x;
        if (Mathf.Abs(movX) >= 0.08)
            movX = 0.38f*(Mathf.Abs(movX)/movX);
        else
            movX = 0;
        transform.Translate(Vector2.right * speed * movX *
        Time.deltaTime);
        if (movX!=0)
            facingRight = movX > 0;
        anim.SetFloat("speed", Mathf.Abs(movX));
        sr.flipX = !facingRight;
        if (!facingRight)
            bc.offset = new Vector2((float)-0.3, bc.offset.y);
        else
            bc.offset = new Vector2((float)0.4, bc.offset.y);
        if (rb.velocity.y != 0)
        {
            anim.SetBool("isGrounded", false);
            isGrounded = false;
        }
        else
        {
            anim.SetBool("isGrounded", true);
            isGrounded = true;
        }
        if (isAttacking)
        {
            bc.enabled = true;
            anim.SetBool("isAttacking", true);
            currentAttackFrame++;
            if (currentAttackFrame == attackFrames)
                isAttacking = false;
        }
        else
        {
            bc.enabled = false;
            anim.SetBool("isAttacking", false);
        }

    }
    public void onButtonJumpClick()
    {   if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpforce);
            isGrounded = false;
        }
    }
    public void onButtonAttackClick()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            currentAttackFrame = 0;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("DeathZone"))
            transform.position = StartingPosition;
    }
}
