﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

  public float walkSpeed = 2f;
  public GameObject examineBox;
  public bool canWalk = true;

  [Header("Directions")]
  public GameObject up;
  public GameObject down;
  public GameObject left;
  public GameObject right;

  private Vector2 movement;


  private Rigidbody2D rb;

  private float hf = 0.0f;
  private float vf = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

      movement.x = Input.GetAxisRaw("Horizontal");
      movement.y = Input.GetAxisRaw("Vertical");
      hf = movement.x > 0.01f ? movement.x : movement.x < -0.01f ? 1 : 0;
      vf = movement.y > 0.01f ? movement.y : movement.y < -0.01f ? 1 : 0;

      //determines what direction you are facing (put animation triggers below)
      if(Input.GetButton("Horizontal") && canWalk){
        if (movement.x < -0.01f){
          //looking left
            examineBox.transform.position = left.transform.position;
        }
        else
        {
          //looking right
            examineBox.transform.position = right.transform.position;
        }
      }
      if(Input.GetButton("Vertical") && canWalk){
        if (movement.y < -0.01f){
          //looking down
            examineBox.transform.position = down.transform.position;
        }
        else
        {
          //looking up
            examineBox.transform.position = up.transform.position;
        }
      }



    }

    void FixedUpdate(){
      if(canWalk){
        rb.MovePosition(rb.position + movement * walkSpeed * Time.fixedDeltaTime);
      }
    }

}
