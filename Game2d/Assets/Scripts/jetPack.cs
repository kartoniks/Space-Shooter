using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class jetPack : MonoBehaviour {
    Rigidbody2D myRB;
    public ParticleSystem smoke;
    public Slider fuelSlider;
    public float maxFuel;
    public float flySpeed;
    public bool flyTrigger;
    bool isFlying = false;
    float fuel;
    float startTime;
    float flyTime = 1;
    bool fly;
	// Use this for initialization
	void Start () {
        fuel = maxFuel;
        myRB = GetComponent<Rigidbody2D>();
        fuelSlider.maxValue = fuel;
        fuelSlider.value = fuel;
	}
	
	// Update is called once per frame
	void Update () {
        fuelSlider.value = fuel;
	}
    private void FixedUpdate()
    {
        fly = CrossPlatformInputManager.GetButton("Fly");
        if(fly)
        {
            if (!isFlying && fuel > 0)
                startFly();
            else if(fuel>0)
                continueFly();
            if (fuel == 0)
            {
                isFlying = false;
                myRB.gravityScale = 1;
            }
        }
        if (!fly)
        {
            myRB.gravityScale = 1;
            isFlying = false;
        }
        if(isFlying)    smoke.gameObject.SetActive(true);
        if (!isFlying) smoke.gameObject.SetActive(false);
    }

    void startFly()
    {
        startTime = Time.time;
        fuel--;
        isFlying = true;
        myRB.gravityScale = 0;

    }
    void continueFly()
    {
       if(startTime+flyTime<Time.time)
        {
            fuel--;
            startTime = Time.time;
        }
        myRB.velocity= new Vector2 (myRB.velocity.x,0);
        myRB.AddForce(new Vector2(CrossPlatformInputManager.GetAxis("Horizontal") * flySpeed, 0));
    }
    public void addFuel(float f)
    {
        fuel += f;
        if (fuel > maxFuel)
            fuel = maxFuel;
        fuelSlider.value = fuel;
    }
}
