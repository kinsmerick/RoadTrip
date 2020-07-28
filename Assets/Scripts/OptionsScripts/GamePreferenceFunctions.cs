using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class GamePreferenceFunctions : MonoBehaviour
{

//if the scene has the dialogue ui, attach it to this so that the saved speed will save to it
  public DialogueUI dialogueObjectToEdit;

  public float defaultTextSpeed = 0.07f;
  private float currentTextSpeed;

  public void Start(){
    if(dialogueObjectToEdit != null){
      currentTextSpeed = PlayerPrefs.GetFloat("TextSpeed", defaultTextSpeed);
      dialogueObjectToEdit.textSpeed = currentTextSpeed;
    }
  }

//call this from a ui slider to set the speed
    public void ChangeTextSpeed(float speed){
      PlayerPrefs.SetFloat("TextSpeed", speed);
      if(dialogueObjectToEdit != null){
        dialogueObjectToEdit.textSpeed = speed;
      }

    }

}
