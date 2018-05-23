using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GorgonBehaviour : MonoBehaviour {
    public GameObject arrowLeft;
    public GameObject arrowRight;
    public float DrawTime = 0.5f;
    float currentDrawtime = 0;
    float currentCooldown = 0;
    bool isDrawing = true;
    bool onCooldown = false;
    public float waittime=0.5f;
    SpriteRenderer sr;
    public Animator anim;
    public GameObject go;
	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (isDrawing)
        {
            anim.SetBool("IsAnimating", true);
            if (currentDrawtime >= DrawTime)
            {
                currentCooldown = waittime;
                onCooldown = true;
                if (sr.flipX)
                {
                    Instantiate(arrowRight, new Vector3(transform.position.x - 0.08f, transform.position.y + 0.05f, transform.position.z), Quaternion.identity);
                    isDrawing = false;
                }
                else
                {
                    Instantiate(arrowLeft, new Vector3(transform.position.x + 0.08f, transform.position.y + 0.05f, transform.position.z), Quaternion.identity);
                    isDrawing = false;
                }
            }
            else
            {
                currentDrawtime += Time.deltaTime;
            }
        }
        else if (onCooldown)
        {
            anim.SetBool("IsAnimating", false);
            currentCooldown -= Time.deltaTime;
            if (currentCooldown <= 0)
            {
                onCooldown = false;
            }
        }
        else
        {
            isDrawing = true;
        }
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("DeathZone") || collision.gameObject.layer == LayerMask.NameToLayer("PlayerAttack"))
        {
            Destroy(go);

        }
    }
}
