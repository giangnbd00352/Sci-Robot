using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    [SerializeField]
    Slider healthBar;
    [SerializeField]
    Text healthText;
    [SerializeField]
    GameObject DeathUI;

    Animator anim;

    float maxHealth = 100;
    float currentHealth;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();

        healthBar.value = maxHealth;
        currentHealth = healthBar.value;

    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Saw")
        {
            healthBar.value -= 1.5f;
            currentHealth = healthBar.value;
        }
        if (collision.gameObject.tag == "Acid")
        {
            healthBar.value -= .5f;
            currentHealth = healthBar.value;
        }
        if (collision.gameObject.tag == "Spike")
        {
            healthBar.value -= 2.5f;
            currentHealth = healthBar.value;
        }
    }

    void Update()
    {
        healthText.text = currentHealth.ToString("n0") + " %";

        if (currentHealth <= 0)
        {
            //play animation dead
            anim.SetBool("isDead", true);
            GetComponent<RobotController>().enabled = false;

            DeathUI.gameObject.SetActive(true);
        }
            
    }
}
