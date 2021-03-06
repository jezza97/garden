﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    Rigidbody2D rigidBody;
    Animator animator;

    float speed = 1.5f;

    bool frozen;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        if (frozen)
        {
            return;
        }

        Vector2 movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        
        if (movementVector != Vector2.zero)
        {
            animator.SetBool("walking", true);
            animator.SetFloat("inputX", movementVector.x);
            animator.SetFloat("inputY", movementVector.y);
        } else
        {
            animator.SetBool("walking", false);
        }

        rigidBody.MovePosition(rigidBody.position + (movementVector * speed * Time.deltaTime));

	}

    public void setFrozen(bool state)
    {
        this.frozen = state;
        animator.SetBool("walking", false);
    }
}
