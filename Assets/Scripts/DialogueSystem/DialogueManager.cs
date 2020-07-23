using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

/*The DialogueManager creates Yarn Commands SetSpeaker and SetBubblePosition. SetSpeaker changes the current speaker,
 adjusts the speech bubble's color according to that current speaker, and moves the speech bubble accordingly. If in
 exploration, it will call a method that moves the bubble to above the character's GameObject. If in a car or motel
 scene, it will adjust the speech bubble according to the current bubble position being used, i.e. "Far". The
 current bubble position can be changed by calling SetBubblePosition. This searches through the current speaker's
 array of bubble positions, finds the matching name, and moves the speech bubble to that set position. This DOES
 require the characters in car and motel scenes (aka Daniella and Mish) to have mirroring pairs of bubble positions,
 but this was already planned.
 
 Also of note: since only Daniella faces dialogue choices, the option bubbles only need to get moved in relation to her.
 In Exploration, these elements will be children of her GameObject, and will remain in a constain relation to her, so 
 they do not need to be adjusted. For car and motel scenes, they will need to be adjusted according to various shots.
 Their positions are included within the general speech bubble position struct in CharacterManager, so, whenever 
 SetBubblePosition is called, they get moved to the position, so long as the current speaker is Daniella.
 
 YET TO BE IMPLEMENTED:
 - Yarn Command SetBubbleStyle that will change the type of speech bubble being printed, i.e. a]
 thought bubble, a standard bubble, an emotional/excited bubble, etc.
 - Yarn Command ChangeShot that will de-activate the previous shot's environment art and activate the given shot's
   environment art. Only called in car scenes.*/

public class DialogueManager : MonoBehaviour
{
    public GameObject SpeechBubble;
    public GameObject Option1Bubble;
    public GameObject Option2Bubble;
    public GameObject[] Characters;
    public bool IsExploration = false;

    private Image _bubbleImage;
    private CharacterManager _currentSpeaker;
    private string _currentBubblePosName;
    private GameObject _currentShot;

    private void Awake()
    {
        _bubbleImage = SpeechBubble.GetComponent<Image>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*SetSpeaker is called in Yarn command <<SetSpeaker>>. It takes in the name of the desired speaker, iterates through the list
     of characters in the scene that is set in the Editor, and, if there is a name match, records that character as the current speaker,
     changes the speech bubble to the character's color, and, if the scene is an exploration scene, it calls the private _SetBubblePosition
     method to update the bubble(s)' position. If it is not an exploration scene, it will move the speech bubble(s) to the same position
     name being used by the previous speaker, i.e. if Mish was speaking "OutsideCar" and now Daniella is speaking, it will switch to Daniella's
     "OutsideCar" as default.*/

    [YarnCommand("SetSpeaker")]
    public void SetSpeaker(string speakerName)
    {
        for(int i = 0; i < Characters.Length; i++)
        {
            if (Characters[i].name.Equals(speakerName))
            {
                _currentSpeaker = Characters[i].GetComponent<CharacterManager>();
                Debug.Log(_currentSpeaker.name + " found.");
                break;
            }//end if

            if(i == Characters.Length - 1)
            {
                Debug.LogError(speakerName + " not found in DialogueManager's character list.");
            }//end else if
        }//end for loop

        _ChangeBubbleColor(_currentSpeaker.DialogueColor);

        if (IsExploration)
        {
            _SetBubblePosition();
        }//end if

        else
        {
            if(_currentBubblePosName != null)
            {
                SetBubblePosition(_currentBubblePosName);
            }

            //if the bubble position has never been set before (like at the top of a scene)
            //it automatically places the bubble in the first position of the speaker's
            //bubble positions.

            else
            {
                Debug.Log("SetBubblePosition called from SetSpeaker with no previous bubble position.");
                SetBubblePosition(_currentSpeaker.BubblesPositions[0].posName);
            }
        }//end else

    }//end SetSpeaker method

    /*Private method _SetBubblePosition is called only when SetSpeaker is called. It is NOT connected to the Yarn command SetBubblePosition,
     * because this is meant to update the bubble being printed to in the Exploration scenes, where each character only has one spot a
     * bubble could be printed to: the space above their gameObject. So, it moves the speech bubble to 2f above the character's
     * gameObject's transform's position.
     * 
     * NOTE: since there are no shot changes in the exploration mode, _SetOptionsPosition is never called. This is because the Options
     * bubbles should be made CHILDREN of Daniella and given set positions in relation to her and then hooked up to the Dialogue UI's
     * option buttons array, whereas there is only one TEXT bubble that Yarn prints to, so that gets moved dynamically rather than
     * the option buttons.*/

    private void _SetBubblePosition()
    {
        Debug.Log("Finding in-game character position.");
        SpeechBubble.transform.position = new Vector3(_currentSpeaker.transform.position.x, _currentSpeaker.transform.position.y + 2f,
                                                        _currentSpeaker.transform.position.z);

    }//end _SetBubblePosition method

    /*Public method SetBubblePosition can be called in Yarn Command <<SetBubblePosition>>. It is also called when changing the speaker
     * in a non-exploration scene. It takes in a name of the desired speech bubble position we want to move the speech bubble(s) to
     * and checks the current speaker's array of possible bubble positions. If there exists a bubble position with the given name, it
     * sets the speech bubble to that position. If not, it throws an error. If the given posName is different than the only being used
     * prior to this change, it also updates the _currentBubblePosName with the given posName. If the current speaker is Daniella, it
     * also adjusts the options bubbles, as those move in relation to where she is speaking, since other characters do not have
     * dialogue choices.*/

    [YarnCommand("SetBubblePosition")]
    public void SetBubblePosition(string posName)
    {
        for(int i = 0; i < _currentSpeaker.BubblesPositions.Length; i++)
        {
            if(posName == _currentSpeaker.BubblesPositions[i].posName)
            {
                SpeechBubble.transform.localPosition = _currentSpeaker.BubblesPositions[i].textPos;

                //update the currently used bubble position name if this is a changed
                //it may not always be, if the only thing being changed is the speaker, but the
                //position used is the same; i.e. the last and the next lines are both being printed
                //to the character's "Far" bubble positions.

                if(_currentBubblePosName != posName)
                {
                    _currentBubblePosName = posName;
                }

                if (_currentSpeaker.isDaniella)
                {
                    _SetOptionsPosition(_currentSpeaker.BubblesPositions[i]);
                }

                Debug.Log(posName + " found.");
                break;

            }//end if

            if(i == _currentSpeaker.BubblesPositions.Length - 1)
            {
                Debug.LogError(posName + " not found in " + _currentSpeaker.name + "'s bubble positions array.");
            }//end if

        }//end for loop

    }//end SetBubblePosition method

    /* _SetOptionsPosition is called when the Yarn command SetBubblePosition is called and
     * takes in the SpeechBubblePosition that was given in the Yarn command call. It moves the Options bubbles to the
     * associated locations. This method is only called if the current speaker is Daniella, as other characters will not
     * have options attached to them, since we only play as Daniella.*/

    private void _SetOptionsPosition(SpeechBubblePosition bubble)
    {
        Option1Bubble.transform.localPosition = bubble.option1Pos;
        Option2Bubble.transform.localPosition = bubble.option2Pos;

    }//end _SetOptionsPosition method

    /*_ChangeBubbleColor takes in a color and changes the color of the speech bubble's Image component to the given color.*/
    private void _ChangeBubbleColor(Color col)
    {
        _bubbleImage.color = col;

    }//end _ChangeBubbleColor method

    [YarnCommand("SetBubbleStyle")]
    public void SetBubbleStyle(string styleName)
    {
        //changes the sprite in _bubbleImage to one that matches styleName
        //may make like a scriptable object or struct smthg that contains
        //the style sprite and name
    }

    [YarnCommand("ChangeShot")]
    public void ChangeShot(string shotName)
    {
        //Sets previous shot's environment art to inactive and sets environment art named
        //shotName to active.
    }
}//end DialogueManager class
