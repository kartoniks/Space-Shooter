using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPickrup : MonoBehaviour {

    // Use this for initialization
    float extraHP=20f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Player")
        {
            playerHealth theHP = other.gameObject.GetComponent<playerHealth>();
            theHP.addHP(extraHP);
            Destroy(gameObject);
        }
    }
}
