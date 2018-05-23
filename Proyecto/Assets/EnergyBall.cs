using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBall : MonoBehaviour {

    public bool facingRight = true;
    public float speed = 25f;
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
        if (facingRight)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else
        {

            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
	}
    private void OnTriggerEnter2D(Collider2D collision)
    { if (!(collision.gameObject.layer == LayerMask.NameToLayer("PlayerAttack") || collision.gameObject.layer == LayerMask.NameToLayer("PlayerShield")))
        {

            Destroy(this);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this);
    }
    
}
