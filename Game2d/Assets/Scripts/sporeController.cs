using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sporeController : MonoBehaviour {

    public float sporeSpeedHigh;
    public float sporeSpeedLow;
    Rigidbody2D sporeRB;
    Rigidbody2D playerRB;
	// Use this for initialization
	void Start () {
        sporeRB = GetComponent<Rigidbody2D>();
        playerRB = GameObject.Find("character").GetComponent<Rigidbody2D>();
        sporeRB.AddForce(new Vector2((playerRB.position.x - sporeRB.position.x)*24, 500));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
