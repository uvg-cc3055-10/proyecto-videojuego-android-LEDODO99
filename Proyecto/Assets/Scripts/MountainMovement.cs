using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainMovement : MonoBehaviour {
    Vector3 staritngPosition;
    // Use this for initialization
    void Start () {
        staritngPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
        float movX = -1*Input.acceleration.x;
        if (Mathf.Abs(movX) < 0.1)
            movX = 0;

        transform.Translate(Vector2.right *  movX * Time.deltaTime);
        if (transform.position.x < -9.7 )
            transform.position=new Vector3((float)9.7, transform.position.y, transform.position.z);
        else if (transform.position.x > 9.7 )
            transform.position=new Vector3((float)-9.7, transform.position.y, transform.position.z);


    }
}
