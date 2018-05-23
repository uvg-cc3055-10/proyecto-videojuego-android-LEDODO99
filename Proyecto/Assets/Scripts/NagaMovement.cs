using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NagaMovement : MonoBehaviour {
    private Transform target;
    public GameObject go;
    public float speed=100f;
    Vector3 positionToGO;
    bool canAttack = false;
    bool isAttacking = false;
    public BoxCollider2D attack;
    public Animator anim;
    public AudioSource espada;
    public AudioSource grito;
    int currentFrame = 0;
    bool attackOnCooldown = false;
    int currentCooldown = 0;
    public int attackCooldown=20;
    public int attackFrames=10;
    SpriteRenderer sr;
    // Use this for initialization
    void Start () {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        sr = GetComponent<SpriteRenderer>();

	}
	
	// Update is called once per frame
	void Update () {
        float difPos = Mathf.Abs(target.position.x - transform.position.x);
        if (target.position.x > transform.position.x)
        {
            sr.flipX = false;
        }
        else
        {
            sr.flipX = true;
        }
        if (difPos < 5 && difPos > 0.8 && !isAttacking) {
            canAttack = false;
            positionToGO = new Vector3(target.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, positionToGO, speed * Time.deltaTime);
        }else if (difPos < 0.8)
        {
            canAttack = true;
        }
        else
        {
            canAttack = false;
        }
        if ((canAttack) && (!isAttacking))
        {
            isAttacking = true;
            currentFrame = 0;
            currentCooldown = 0;
        }
        if (isAttacking)
        {
            if (currentFrame < attackFrames)
            {
                if (currentFrame == 0)
                {
                    espada.Play();
                }
                anim.SetBool("Attacking", true);
                attack.enabled = true;
                currentFrame++;
            }else if (currentCooldown < attackCooldown)
            {
                anim.SetBool("Attacking", false);
                attack.enabled = false;
                currentCooldown++;
            }
            else
            {
                isAttacking = false;    
            }
        }
        else
        {
            anim.SetBool("Attacking", false);
            attack.enabled = false;
        }

	}
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("DeathZone")|| collision.gameObject.layer == LayerMask.NameToLayer("PlayerAttack"))
        {
            Destroy(go);
            
        }
    }
}   
