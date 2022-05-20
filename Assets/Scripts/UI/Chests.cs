using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chests : MonoBehaviour
{
    Animator anima;
    bool playerInRange = false;
    bool chestOpened = false;
    // Start is called before the first frame update
    void Start()
    {
        anima = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!chestOpened)
        {
            if (Input.GetKeyDown(KeyCode.F) && playerInRange)
            {
                anima.SetBool("Opening", true);
                chestOpened = true;
            }
        }
        else
        {
            anima.SetBool("Opened", true);
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerInRange = true;
            
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerInRange = false;

        }
    }
}