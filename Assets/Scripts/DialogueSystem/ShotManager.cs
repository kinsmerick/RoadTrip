using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class ShotManager : MonoBehaviour
{
    public GameObject[] shots;

    private GameObject _currentShot;
    private DialogueManager _dialogueManager;


    private void Awake()
    {
        _dialogueManager = this.GetComponent<DialogueManager>();
    }

    /*ChangeShot is called in Yarn command <<ChangeShot>>. It takes in a string of a name of the desired shot.
     If that string is contained in the name of shot in the array of shots that is set in the editor, the
     current active shot (if any) gets set to inactive, this requested shot gets set as the current shot, and
     it gets set active. It also calls SwitchCharacterArtVisible whenever the shot is changed to or away from
     the Front shot to update Daniella and Mish's gameobjects' sprite renderers to be enabled or disabled
     accordingly.*/

    [YarnCommand("ChangeShot")]
    public void ChangeShot(string shotName)
    {
        for(int i = 0; i < shots.Length; i++)
        {
            if (shots[i].name.Contains(shotName))
            {
                //if there is an already active shot, set it to be inactive.
                //if that shot is the Front shot, switch the characters' sprite renderers to disabled.
                
                if (_currentShot != null)
                {
                    _currentShot.SetActive(false);
                    if (_currentShot.name.Contains("Front"))
                    {
                        SwitchCharacterArtVisible(false);
                    }
                }
                
                _currentShot = shots[i];
                _currentShot.SetActive(true);

                //if the new shot is the Front shot, set the characters' sprite renderers to enabled.
                if (_currentShot.name.Contains("Front"))
                {
                    SwitchCharacterArtVisible(true);
                }
                break;

            }//end if

            //if no shot with that name is found, log an error.
            if(i == shots.Length - 1)
            {
                Debug.LogError(shotName + " not found in array of shots.");

            }//end if

        }//end for loop

    }//end ChangeShot method

    /*SwitchCharacterArtVisible is called whenever a shot is changed to or from the Front shot. It
     goes through the characters in the DialogueManager, finds all of their sprite renderers,
     (this is important because the driver character has a child gameobject with a sprite
     renderer for the hands) and sets them to either be enabled or disabled depending on the
     call's parameters.*/

    private void SwitchCharacterArtVisible(bool state)
    {
        foreach (var chara in _dialogueManager.characters)
        {
            foreach (var spriteRenderer in chara.GetComponentsInChildren<SpriteRenderer>())
            {
                spriteRenderer.enabled = state;
            }//end foreach for each sprite renderer

        }//end foreach for each character

    }//end SwitchCharacterArt
}//end class
