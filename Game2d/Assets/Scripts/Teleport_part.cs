using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport_part : MonoBehaviour {

    public GameObject teleporter;
    public GameObject other;
    Animator myAnim;
    public float delay;
    float lastenter;
	// Use this for initialization
	void Start () {
        lastenter = Time.time;
		teleporter = transform.parent.gameObject;
        if (this.name == "Left")
            other = teleporter.transform.GetChild(1).gameObject;
        if (this.name == "Right")
            other = teleporter.transform.GetChild(0).gameObject;
        myAnim = other.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Time.time-lastenter>delay)
        {
            collision.gameObject.transform.position = other.transform.position;
            lastenter = Time.time;
            other.GetComponent<Teleport_part>().lastenter = Time.time;
            myAnim.Play("PortalOpen");
        }
    }
}
