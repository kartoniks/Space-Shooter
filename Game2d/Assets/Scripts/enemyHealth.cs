using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour {

    public float enemyMaxHealth;
    float currentHealth;
    public GameObject enemyDeathFX;
    public Slider enemySlider;
    public bool canDrop;
    public GameObject drop;
	// Use this for initialization
	void Start () {
        currentHealth = enemyMaxHealth;
        enemySlider.maxValue = enemyMaxHealth;
        enemySlider.value = enemyMaxHealth;
	}
	
    public void addDamage(float damage)
    {
        currentHealth -= damage;
        enemySlider.gameObject.SetActive(true);
        enemySlider.value = currentHealth;
        if (currentHealth <= 0)
            makeDead();
    }
    void makeDead()
    {
        if (transform.parent != null)
        {
            Destroy(transform.parent.gameObject);
        }
        else
            Destroy(gameObject);
        Instantiate(enemyDeathFX, transform.position, transform.rotation);
        if (canDrop) Instantiate(drop, transform.position, transform.rotation);
    }
}
