using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollower : MonoBehaviour {
    public GameObject camera;
    public GameObject endzone;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        camera.transform.position = new Vector3(transform.position.x,transform.position.y,camera.transform.position.z);
        endzone.transform.position = new Vector3(transform.position.x, endzone.transform.position.y, transform.position.z);
	}
}
