﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class Interactable : MonoBehaviour
{

  public bool canInteract = false;
  private bool interacting = false;

  public CharacterController playerControl;
  [Header ("Yarn Script")]
  public string nodeName;

  private DialogueRunner dialogueRunner;

    // Start is called before the first frame update
    void Start()
    {
      playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
      dialogueRunner = FindObjectOfType<DialogueRunner>();
    }

    // Update is called once per frame
    void Update()
    {
      if(canInteract && !interacting && (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Jump")) ){
        interacting = true;
        playerControl.canWalk = false;

        dialogueRunner.StartDialogue(nodeName);
      }
      else if(interacting && !dialogueRunner.IsDialogueRunning ){
        interacting = false;
        playerControl.canWalk = true;
      }
    }

    void OnTriggerEnter2D(Collider2D other){
      if(other.tag == "Observer"){
        canInteract = true;
      }
    }


    void OnTriggerExit2D(Collider2D other){
      if(other.tag == "Observer"){
        canInteract = false;
      }
    }

}
