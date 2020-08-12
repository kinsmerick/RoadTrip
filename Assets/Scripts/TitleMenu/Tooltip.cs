using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Tooltip : MonoBehaviour
{
    private TextMeshProUGUI _tmp;
    private EventSystem _eventSystem;
    private GameObject _selectedObj;

    // on Start grab the textmeshpro component
    void Start()
    {
        _tmp = this.GetComponentInChildren<TextMeshProUGUI>();
    }

    //OnEnable grab the current event system and currently selected object
    private void OnEnable()
    {
        _eventSystem = EventSystem.current;
        _selectedObj = _eventSystem.currentSelectedGameObject;
    }

    // On Update, check to see if the locally stored selected object is the same as the
    // current selected object in the event system. If no, update it and update the tooltip text.
    void Update()
    {
        if(_selectedObj != _eventSystem.currentSelectedGameObject)
        {
            if (_eventSystem.currentSelectedGameObject != null)
            {
                _selectedObj = _eventSystem.currentSelectedGameObject;
                string _objName = _selectedObj.name;

                switch (_objName)
                {
                    case "NewGameButton":
                        updateTooltip("Start New Game");
                        break;

                    case "ContinueButton":
                        updateTooltip("Continue From Saved File");
                        break;

                    case "ActsButton":
                        updateTooltip("Replay an Act");
                        break;

                    case "SettingsButton":
                        updateTooltip("Adjust Game Settings");
                        break;

                    case "HowToPlayButton":
                        updateTooltip("View Game Controls");
                        break;

                    case "ItemCollectionButton":
                        updateTooltip("View Items You've Collected");
                        break;

                    case "CreditsButton":
                        updateTooltip("View Game Credits");
                        break;

                    case "CloseGameButton":
                        updateTooltip("Close the Game");
                        break;

                    //if something else is somehow selected, print no tooltip text
                    default:
                        updateTooltip("");
                        break;
                }//end switch case
            }
            //if there is no currently selected object, update selected obj to null
            //and change tooltip to blank
            else
            {
                _selectedObj = null;
                updateTooltip("");
            }//end else

        }//end if _selectedObj is not the currently selected one
    }//end Update method

    //change the tooltip text to the given string
    private void updateTooltip(string txt)
    {
        _tmp.text = txt;

    }//end updateTooltip method
}//end Tooltip class
