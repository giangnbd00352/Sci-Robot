using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Diamond : MonoBehaviour {

    Animator anim;
    GameController gameController;

    void Start()
    {
        anim = GetComponent<Animator>();
        gameController = FindObjectOfType<GameController>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameController.GetPoint();
            gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            anim.SetBool("isDisappear", true);
            Destroy(gameObject, 2f);            
        }
    }
}
