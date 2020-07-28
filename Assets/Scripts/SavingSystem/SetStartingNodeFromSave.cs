using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;


public class SetStartingNodeFromSave : MonoBehaviour
{

  public DialogueRunner runnerToEdit;
  private ContinueGameSaveLoad loadScript;

    // Start is called before the first frame update
    void Start()
    {
      loadScript = FindObjectOfType<ContinueGameSaveLoad>();
      if(loadScript != null){
        runnerToEdit.startNode = loadScript.savedNodeName;
        //runnerToEdit.variableStorage = loadScript.savedVars;
      }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
