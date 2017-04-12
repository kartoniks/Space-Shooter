using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour {

    public float maxHealth;
    public GameObject deathFX;
    public float currentHealth;
    
    //HUD variables
    public Slider healthSlider;
    public Image damageScreen;
    bool damaged = false;
    Color damagedColor = new Color(0f, 0f, 0f, 1f);
    float smoothColor = 5f;

	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;

        //HUD initialization
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if(damaged)
        {
            damageScreen.color = damagedColor;
        }
        else if(!damageScreen.IsDestroyed())
        {
            damageScreen.color = Color.Lerp(damageScreen.color, Color.clear, smoothColor * Time.deltaTime);
        }
        damaged = false;
	}

    public void addDamage(float damage)
    {
        if (damage <= 0) return;
        currentHealth -= damage;
        healthSlider.value = currentHealth;
        damaged = true;

        if(currentHealth<=0)
        {
            makeDead();
        }
    }
    public void addHP(float health)
    {
        currentHealth += health;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
        healthSlider.value = currentHealth;
    }
    public void makeDead()
    {
        //Instantiate(deathFX, transform.position, transform.rotation);
        //Destroy(gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
}
