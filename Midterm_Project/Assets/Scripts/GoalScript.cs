﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    private Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("isFood"))
        {
            Destroy(other.gameObject);
            anim.SetTrigger("isEating");
            GameManager.instance.Food--;
            //print("I've been eaten!");
        }
    }
}
