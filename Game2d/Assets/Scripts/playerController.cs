using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour {
    // movement variables
    public float maxSpeed;
    Rigidbody2D myRB;
    Animator myAnim;
    bool facingRight;
    Vector2 movement;
    //jumping variables
    bool grounded = false;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float jumpHeight;
    //for shooting
    public Transform gunTip;
    public GameObject bullet;
    float fireRate = 0.5f;
    float nextFire = 0f;
    public float move;
    public bool jump;
    bool fire;
    
	// Use this for initialization
	void Start () {
        myRB = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        facingRight = true;
	}

    // Update is called once per frame
    void Update()
    {
        if(grounded && jump)
        {
            grounded = false;
            myAnim.SetBool("isGrounded", grounded);
            myRB.AddForce(new Vector2(0, jumpHeight));
        }
        //player shooting
        if (fire)
        {
            fireRocket();
        }

    }
    void FixedUpdate () {
        //check if we're grounded, if no we are falling
        fire = CrossPlatformInputManager.GetButton("Fire");
        jump = CrossPlatformInputManager.GetButton("Jump");

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        myAnim.SetBool("isGrounded", grounded);
        
        myAnim.SetFloat("verticalSpeed", myRB.velocity.y);

        move = CrossPlatformInputManager.GetAxis("Horizontal");
        myAnim.SetFloat("speed", Mathf.Abs(move));
        movement.Set(move * maxSpeed,0);
 
        if(grounded && move!=0)
            myRB.AddForce(movement);

        if (move > 0 && facingRight == false)
            flip();
        else if (move < 0 && facingRight == true)
            flip();
	}

    //flipping character face
    void flip(){
        facingRight = !facingRight;
        Vector3 myScale = transform.localScale;
        myScale.x *= -1;
        transform.localScale = myScale;
    }    
    //firing rocket
    void fireRocket()
    {
        if(Time.time>nextFire)
        {
            nextFire = Time.time + fireRate;
            if (facingRight)
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else if (!facingRight)
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 180f)));
            }
        }
    }
    public void Jump()
    {
        jump = !jump;
    }
}
