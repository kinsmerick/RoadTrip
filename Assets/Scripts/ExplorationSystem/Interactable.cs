using System.Collections;
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

      //begins dialogue and sets canwalk to false so the player can't run away during dialogue
      if(canInteract && !interacting && (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Jump")) ){
        interacting = true;
        playerControl.canWalk = false;

        dialogueRunner.StartDialogue(nodeName);
      }
      else if(interacting && !dialogueRunner.IsDialogueRunning ){
      //once dialogue is over as determined by yarn, lets the player walk again
        interacting = false;
        playerControl.canWalk = true;
      }
    }

//trigger enter/exit to determine if the player can activate the dialogue
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
