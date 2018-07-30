using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour {

    PlayerHealth playerHealth;

    public float HealthBonus = 15f;
    // Use this for initialization
    void Awake()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if ((playerHealth.currentHealth + HealthBonus) < playerHealth.maxHealth)
            {
                Destroy(gameObject);
                playerHealth.currentHealth = playerHealth.currentHealth + HealthBonus;
            }
            else if ((playerHealth.currentHealth + HealthBonus) > playerHealth.maxHealth)
            {
                Destroy(gameObject);
                playerHealth.currentHealth = 100f;
            }
        }
       
    }
}
