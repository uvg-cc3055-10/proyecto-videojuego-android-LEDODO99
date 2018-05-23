﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundWhenHit : MonoBehaviour {
    public AudioSource audio;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            audio.Play();
        }
    }
}
