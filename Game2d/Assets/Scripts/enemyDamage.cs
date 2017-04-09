﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{

    // Use this for initialization
    public float damage;
    public float damageRate;
    public float pushBackForce;

    float nextDamage;

    void Start()
    {
        nextDamage = 0f;

    }

    // Update is called once per frame
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && nextDamage<Time.time)
        {
            playerHealth theHP = other.gameObject.GetComponent<playerHealth>();
            theHP.addDamage(damage);
            nextDamage = Time.time + damageRate;

            pushBack(other.transform);
        }
    }

    void pushBack(Transform pushedObject)
    {
        Vector2 pushDirection = new Vector2(pushedObject.position.x - transform.position.x, pushedObject.position.y - transform.position.y).normalized;
        pushDirection *= pushBackForce;
        Rigidbody2D pushRB = pushedObject.gameObject.GetComponent<Rigidbody2D>();
        pushRB.velocity = Vector2.zero;
        pushRB.AddForce(pushDirection, ForceMode2D.Impulse);

    }
}