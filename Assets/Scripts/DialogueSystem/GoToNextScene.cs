using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.SceneManagement;


public class GoToNextScene : MonoBehaviour
{

  public string SceneToLoadAfterDialogue = "BetaMenu";
  private DialogueRunner dialogueRunner;

    // Start is called before the first frame update
    void Start()
    {
      dialogueRunner = FindObjectOfType<DialogueRunner>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!dialogueRunner.IsDialogueRunning){
          SceneManager.LoadScene(SceneToLoadAfterDialogue);
        }
    }
}
