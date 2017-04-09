using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuelPickUp : MonoBehaviour {
    public float fuel;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            jetPack theFuel = other.gameObject.GetComponent<jetPack>();
            theFuel.addFuel(fuel);
            Destroy(gameObject);
        }
    }
}
