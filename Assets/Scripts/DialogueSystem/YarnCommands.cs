using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class YarnCommands : MonoBehaviour
{

    public GameObject[] shotUI; //editor defined list of Shot Dialogue UI containers
    public GameObject[] shotEnvironments;
    private DialogueUI yarnDialogueUI;
    public string positionOfMC;
    private GameObject activeUI;
    private GameObject activeEnvironment;
    private GameObject activeBubble;

    public DialogueManager dialogueManager;

    private void Awake()
    {
        yarnDialogueUI = this.GetComponent<DialogueUI>();
        dialogueManager = this.GetComponent<DialogueManager>();
        setMC("Driver");
    }
    // Start is called before the first frame update
    void Start()
    {
    }//end Start method

    // Update is called once per frame
    void Update()
    {

    }

    /*Adds <<setMC>> command to Yarn. Takes in seat position of the MC as posMC. If posMC
     * is Driver or Passenger, it stores that. If not, it logs an error.*/

    [YarnCommand("setMC")]
    public void setMC(string posMC)
    {
        if(posMC == "Driver")
        {
            positionOfMC = posMC;
        }
        else if (posMC == "Passenger")
        {
            positionOfMC = posMC;
        }
        else
        {
            Debug.LogError(posMC + " not valid position for MC.");
        }
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
                            Transform prevOptions = activeUI.transform.Find(positionOfMC + "Options");
                            activeUI.SetActive(false);
                        }

                        //checks for previous environment to de-activate
                        if(activeEnvironment != null)
                        {

                            activeEnvironment.SetActive(false);
                        }

                        //set and activate the new UI and environment
                        //the dialogueContainer is updated so that, if this is
                        //the last UI of this yarn node, the Dialogue UI Script
                        //will know to turn it off at the end.
                        
                        yarnDialogueUI.dialogueContainer = shotUI[i];
                        shotUI[i].SetActive(true);
                        shotEnvironments[j].SetActive(true);

                        Transform optionBubbles = shotUI[i].transform.Find(positionOfMC + "Options");
                        updateDialogueUIOptions(optionBubbles);

                        //record them locally as the active UI and environment
                        activeUI = shotUI[i];
                        activeEnvironment = shotEnvironments[j];

                        //break b/c shot environment was updated
                        break;

                    }//end if specificed shot environment found

                    else if(j == shotEnvironments.Length - 1)
                    {

                        Debug.LogError("Shot environment " + shotName + " not found.");

                    }//end else if at end of for loop iterating for shot environment

                }//end shot environments for loop
                
                //break b/c shot UI and environment were updated
                break;

            }//end if shotName matches name in shotUI[]

            else if(i == shotUI.Length - 1)
            {

                Debug.LogError("Shot UI " + shotName + " not found.");

            }//end else if at end of for loop iterating for shot UI

        }//end for loop

    }//end Yarn Command changeShot method

    /*Adds <<setBubble>> command to Yarn. Takes in a bubble name. If there is an active speech
     bubble, it sets it to inactive. Then, it searches through the activeUI's children to find
     one named bubblename + "Bubble", i.e. "PassengerFarBubble". If this bubble exists in the
     activeUI, it sets it to be active and records it locally as the active bubble. If it
     does not exist, it logs an error. The previous active bubble will still be set inactive
     as an additional meaasure of alerting the dev to the typo in the Yarn command.*/

    //NOTE: ONLY PROTOTYPE BUILD CODE. DO NOT USE.

    [YarnCommand("setBubble")]
    public void setBubble(string bubbleName) {
        Debug.Log("setBubble called with " + bubbleName);

        if(activeBubble != null)
        {
            activeBubble.SetActive(false);
        }

        Transform nextBubble = activeUI.transform.Find(bubbleName + "Bubble");
        
        if (nextBubble != null)
        {
            nextBubble.gameObject.SetActive(true);
            activeBubble = nextBubble.gameObject;
        }
        else
        {
            Debug.LogError("Speech Bubble " + bubbleName + " does not exist in active UI " +
                            activeUI);
        }


    }//end Yarn Command setBubble method

    [YarnCommand("setSpeaker")]
    public void setSpeaker(string speakerName)
    {
        Debug.Log("Yarn called setSpeaker with " + speakerName);
        dialogueManager.setSpeaker(speakerName);
    }

    /*Called when the Yarn Command changeShot is called. It takes in the relevant active UI's MC's
     position-based Options transform (i.e. PassengerOptions of the Front shot) as a parameter.
     First, it clears out any option buttons that the DialogueUI has. Then, it goes through
     the Options transform's children to find transforms with the name Option and a number, which
     are the options buttons. Any matching transform's button is then added to DialogueUI's
     list of buttons.*/

    private void updateDialogueUIOptions(Transform optionsTransform)
    {
        yarnDialogueUI.optionButtons.Clear();

        for(int i = 0; i < optionsTransform.childCount + 1; i++)
        {
            Debug.Log("childcount: " + optionsTransform.childCount + " i " + i);
            Transform opt = optionsTransform.Find("Option" + i);
            if (opt != null)
            {
                Debug.Log(opt + " " + i);
                yarnDialogueUI.optionButtons.Add(opt.gameObject.GetComponent<Button>());
            }
        }
    }
}
