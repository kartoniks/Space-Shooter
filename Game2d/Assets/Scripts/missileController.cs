using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missileController : MonoBehaviour {

    Rigidbody2D myRB;
    public float rocketSpeed;
    public float weaponDamage;

	// Use this for initialization
	void Awake () {
        myRB = GetComponent<Rigidbody2D>();
        if(transform.localRotation.z>0)
            myRB.AddForce(new Vector2(-1, 0) * rocketSpeed, ForceMode2D.Impulse);
        else
            myRB.AddForce(new Vector2(1, 0) * rocketSpeed, ForceMode2D.Impulse);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Shootable"))
            Destroy(gameObject);
        if(collision.gameObject.tag =="Enemy")
        {
            enemyHealth hurtEnemy = collision.gameObject.GetComponent<enemyHealth>();
            hurtEnemy.addDamage(weaponDamage);
        }
    }
}
