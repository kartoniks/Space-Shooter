using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootSpore : MonoBehaviour {

    public GameObject projectile;
    public float shootTime;
    public Transform shootFrom;
    public int chanceShoot;
    float nextShootTime=0f;
    Animator cannonAnim;
    Rigidbody2D playerRB;
	// Use this for initialization
	void Start () {
        cannonAnim = GetComponentInChildren<Animator>();
        playerRB = GameObject.Find("character").GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
    private void FixedUpdate()
    {
        if (Mathf.Abs(playerRB.position.x - shootFrom.position.x) < 10 && nextShootTime < Time.time)
        {
            if (Random.Range(0, 10) > chanceShoot)
            {
                nextShootTime = Time.time+shootTime;
                Instantiate(projectile, shootFrom.position, Quaternion.identity);
                cannonAnim.SetTrigger("cannonShoot");
            }
        }
    } 
}
