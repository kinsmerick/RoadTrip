using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsSwapZone : MonoBehaviour
{

  public CharacterController playerControl;

  public bool stepsAudible = true;
  public string [] newStepNames;



    // Start is called before the first frame update
    void Start()
    {
      playerControl = FindObjectOfType<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other){
      if(other.tag == "Player"){
        playerControl.stepNames = newStepNames;
        playerControl.playSteps = stepsAudible;
      }
    }

}
