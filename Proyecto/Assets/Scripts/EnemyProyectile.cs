using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProyectile : MonoBehaviour {
    public bool facingRight=true;
    public float speed = 25f;
    public GameObject go;
    public float Seconds = 1.5f;
    float time;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time += (Time.deltaTime);
		if (!facingRight)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else
        {

            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (time >= Seconds)
            Destroy(go);
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(go);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("PlayerShield"))
        {
            Destroy(go);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        Destroy(go);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        Destroy(go);
    }
}
