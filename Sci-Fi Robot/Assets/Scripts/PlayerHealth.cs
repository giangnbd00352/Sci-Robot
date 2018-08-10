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
    [SerializeField]
    GameObject Robot;

    Animator anim;

    public float maxHealth = 100;
    public float currentHealth;

	// Use this for initialization
	void Start () {
        anim = Robot.GetComponent<Animator>();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.transform.name);
        if (collision.gameObject.tag == "FireBall")
        {
            Destroy(collision.gameObject);
            healthBar.value -= 0.2f;
            if (healthBar.value <= 0)
            {
                // Debug.Log("OverGame");
                Destroy(collision.gameObject);
            }
        }
    }

    void Update()
    {
        healthBar.value = currentHealth;
        healthText.text = currentHealth.ToString("n0") + " %";

        if (currentHealth <= 0)
        {
            //play animation dead
            anim.SetBool("isDead", true);
            Robot.GetComponent<RobotController>().RobotAction = false;
            DeathUI.gameObject.SetActive(true);
        }
            
    }
}
