using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow2DPlatformer : MonoBehaviour {

    public Transform target;    //what camera is following
    public float smoothing;     //dampening effect
    float lowY;                 //max low camera can go
    Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position - target.position;
        lowY = -20;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing*Time.deltaTime);
        if (transform.position.y < lowY)
            transform.position= new Vector3 (transform.position.x, lowY, transform.position.z);
	}
}
