using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;


public class AddYarnScripts : MonoBehaviour
{

  public YarnProgram [] yarnScriptsToAdd;

  private DialogueRunner dialogueRunner;


    //this component will be on an object in an exploration scene, and adds the yarn scripts
    //to the list so npcs can access them

    void Start()
    {
      dialogueRunner = FindObjectOfType<DialogueRunner>();
      for(int i = 0; i < yarnScriptsToAdd.Length; i++)
      {
        dialogueRunner.Add(yarnScriptsToAdd[i]);
      }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
