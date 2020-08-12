using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GamePreferenceFunctions : MonoBehaviour
{

//if the scene has the dialogue ui, attach it to this so that the saved speed will save to it

  private float currentTextSpeed;

  public void Start(){
  }

//call this from a ui slider to set the speed
    public void ChangeTextSpeed(float speed){
      PlayerPrefs.SetFloat("TextSpeed", speed);
    }


    public void DeleteSaveData(){
      File.Delete(Application.persistentDataPath + "/items.sav");
      File.Delete(Application.persistentDataPath + "/gameCompletion.sav");
    }

}
