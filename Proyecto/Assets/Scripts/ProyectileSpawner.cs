using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectileSpawner : MonoBehaviour {
    public GameObject projectileRight;
    public GameObject projectileLeft;
    SpriteRenderer sr;
    public float spawnTime=2;
    float currentTime=0;
    public float distanceToSpawn;
    // Use this for initialization
    void Start () {
        sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (sr.flipX&&currentTime>spawnTime)
        {
            currentTime = 0;
            Instantiate(projectileLeft, new Vector3(transform.position.x - distanceToSpawn, transform.position.y+0.01f, transform.position.z), Quaternion.identity);
        }
        else if (currentTime>spawnTime)
        {
            currentTime = 0;
            Instantiate(projectileLeft, new Vector3(transform.position.x + distanceToSpawn, transform.position.y+0.01f, transform.position.z), Quaternion.identity);
        }
        else
        {
            currentTime += Time.deltaTime;
        }
	}
}
