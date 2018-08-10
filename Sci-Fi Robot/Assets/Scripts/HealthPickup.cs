using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour {

    PlayerHealth playerHealth;

    public float HealthBonus = 15f;

    AudioManager audioManager;

    bool isCollision = false;
    // Use this for initialization
    void Awake()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    void Update()
    {
        if (isCollision)
        {
            this.transform.Translate(new Vector3(0, 5 * Time.deltaTime, 0));
            transform.localScale -= new Vector3(0.01f, 0.01f, 0);
            Destroy(gameObject, 1f);
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isCollision = true;
            audioManager = AudioManager.instance;
            audioManager.PlaySound("Bonus");
            if ((playerHealth.currentHealth + HealthBonus) < playerHealth.maxHealth)
            {
                playerHealth.currentHealth = playerHealth.currentHealth + HealthBonus;
            }
            else if ((playerHealth.currentHealth + HealthBonus) > playerHealth.maxHealth)
            {
                playerHealth.currentHealth = 100f;
            }
        }
       
    }
}
