using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

  public bool canInteract = false;
  private bool interacting = false;
  public GameObject testInteract;

  public CharacterController playerControl;

    // Start is called before the first frame update
    void Start()
    {
      playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
      if(canInteract && !interacting && (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Jump")) ){
        interacting = true;
        playerControl.canWalk = false;
        testInteract.SetActive(true);
      }
      else if(interacting && (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Jump")) ){
        interacting = false;
        playerControl.canWalk = true;
        testInteract.SetActive(false);
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
