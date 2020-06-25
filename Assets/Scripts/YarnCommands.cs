using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class YarnCommands : MonoBehaviour
{

    public GameObject[] shotUI; //editor defined list of Shot Dialogue UI containers
    public GameObject[] shotEnvironments;
    private DialogueUI yarnDialogueUI;
    private GameObject activeUI;
    private GameObject activeEnvironment;
    private GameObject activeBubble;

    private void Awake()
    {
        yarnDialogueUI = this.GetComponent<DialogueUI>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }//end Start method

    // Update is called once per frame
    void Update()
    {

    }

    /*Adds <<changeShot>> command to Yarn. Takes in a shot name. First iterates through
     * list of shot dialogue UIs that is defined in the editor. If it finds a shot UI with a name
     * that contains the given shotName (case sensitive), it proceeds to iterate through list of
     * shot environments that is defined in the editor. If it finds a shot environment that contains
     * the same shotName, it will set the Dialogue UI script's dialogueContainer to that
     * shot's UI, set the environment to active, and set the previous UI and environment to inactive.
     * Throws an error if there is no matching shot UI and environment.
  */

    [YarnCommand("changeShot")]
    public void changeShot(string shotName)
    {
        Debug.Log("changeShot called with " + shotName);
        for(int i = 0; i < shotUI.Length; i++)
        {
            if (shotUI[i].name.Contains(shotName))
            {
                for(int j = 0; j < shotEnvironments.Length; j++)
                {
                    if (shotEnvironments[j].name.Contains(shotName)){

                        //checks for bubble in previous shot to de-activate
                        if (activeBubble != null)
                        {
                            activeBubble.SetActive(false);
                        }

                        //checks for previous UI to de-activate
                        if (activeUI != null)
                        {
                            activeUI.SetActive(false);
                        }

                        //checks for previous environment to de-activate
                        if(activeEnvironment != null)
                        {

                            activeEnvironment.SetActive(false);
                        }

                        //set and activate the new UI and environment
                        //the dialogueContainer SHOULD make a starter UI active,
                        //but doesn't handle mid-scene shifts
                        Debug.Log(yarnDialogueUI.name);
                        Debug.Log(yarnDialogueUI.dialogueContainer.name);
                        Debug.Log(shotUI[i].name);
                        yarnDialogueUI.dialogueContainer = shotUI[i];
                        shotUI[i].SetActive(true);
                        shotEnvironments[j].SetActive(true);

                        //record them locally as the active UI and environment
                        activeUI = shotUI[i];
                        activeEnvironment = shotEnvironments[j];
                        break;
                    }
                }//end shot environments for loop
                
                //break b/c shot UI was found
                break;

            }//end if shotName matches name in shotUI[]

            else if(i == shotUI.Length - 1)
            {

                Debug.LogError("Shot name " + shotName + " not found.");

            }//end else if at end of for loop iterating for shot UI

        }//end for loop

    }//end Yarn Command changeShot method

    [YarnCommand("setBubble")]
    public void setBubble(string bubbleName) {
        Debug.Log("setBubble called with " + bubbleName);
        if(activeBubble != null)
        {
            activeBubble.SetActive(false);
        }

        Transform nextBubble = activeUI.transform.Find(bubbleName + "Bubble");
        nextBubble.gameObject.SetActive(true);
        activeBubble = nextBubble.gameObject;

    }//end Yarn Command setBubble method
}
