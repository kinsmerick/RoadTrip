using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class DialogueManager : MonoBehaviour
{
    public GameObject SpeechBubble;
    public GameObject Option1Bubble;
    public GameObject Option2Bubble;
    public GameObject[] Characters;
    public bool IsExploration = false;

    private Image _bubbleImage;
    private CharacterManager _currentSpeaker;

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
        //exists for testing
        if (Input.GetKeyDown("space"))
        {
            SetSpeaker("Kinsey");
        }
    }

    /*SetSpeaker is called in Yarn command <<SetSpeaker>>. It takes in the name of the desired speaker, iterates through the list
     of characters in the scene that is set in the Editor, and, if there is a name match, records that character as the current speaker,
     changes the speech bubble to the character's color, and calls the private _SetBubblePosition method to update the bubble's position.*/

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
        _SetBubblePosition();
        _SetOptionsPosition();
    }

    /*Private method _SetBubblePosition is called only when SetSpeaker is called. It is NOT connected to the Yarn command setBubble, because
     * this is meant to update the bubble being printed to in the Exploration scenes, where each character only has one spot a bubble
     * could be printed to: the space above their gameObject. So, it moves the speech bubble to 2 above the character's gameObject's
     * transform's position.
     * 
     * It also contains a case for if the conversation is NOT happening in an exploration scene. Ideally This makes sure that, if
     * setSpeaker is called during a car scene and the Yarn script forgets to follow up by specifying the character's specific bubble
     * they want to print to, the first bubble position in the character's array of possible print locations will at least be set. BUT,
     * ideally, they never forget to specify. :^) */

    private void _SetBubblePosition()
    {
        //code that will move the bubble to the specified position
        if (!IsExploration)
        {
            SpeechBubble.transform.localPosition = _currentSpeaker.BubblesPositions[0].textPos;
            Option1Bubble.transform.localPosition = _currentSpeaker.BubblesPositions[0].option1Pos;
            Option2Bubble.transform.localPosition = _currentSpeaker.BubblesPositions[0].option2Pos;
        }//end if

        else
        {
            Debug.Log("Finding in-game character position.");
            SpeechBubble.transform.position = new Vector3(_currentSpeaker.transform.position.x, _currentSpeaker.transform.position.y + 2f,
                                                            _currentSpeaker.transform.position.z);
            if (_currentSpeaker.isDaniella)
            {
                _SetOptionsPosition();
            }
        }//end else

    }//end _SetBubblePosition method

    private void _SetOptionsPosition()
    {
        //fill this out for exploration stuff
    }

    /*Public method SetBubblePosition is called in Yarn Command <<SetBubblePosition>>. It takes in a name of the desired speech bubble
     * position we want to move the speech bubble to and checks the current speaker's array of possible bubble positions. If there
     * exists a bubble position with the given name, it sets the speech bubble to that position. If not, it throws an error.*/

    [YarnCommand("SetBubblePosition")]
    public void SetBubblePosition(string posName)
    {
        for(int i = 0; i < _currentSpeaker.BubblesPositions.Length; i++)
        {
            if(posName == _currentSpeaker.BubblesPositions[i].posName)
            {
                SpeechBubble.transform.localPosition = _currentSpeaker.BubblesPositions[i].textPos;

                if (_currentSpeaker.isDaniella)
                {
                    _SetOptionsPosition(posName);
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

    private void _SetOptionsPosition(string posName)
    {
        for (int i = 0; i < _currentSpeaker.BubblesPositions.Length; i++)
        {
            if (posName == _currentSpeaker.BubblesPositions[i].posName)
            {
                SpeechBubble.transform.localPosition = _currentSpeaker.BubblesPositions[i].textPos;
                Debug.Log(posName + " found.");
                break;
            }//end if

            if (i == _currentSpeaker.BubblesPositions.Length - 1)
            {
                Debug.LogError(posName + " not found in " + _currentSpeaker.name + "'s bubble positions array.");
            }//end if

        }//end for loop
    }

    /*_ChangeBubbleColor takes in a color and changes the color of the speech bubble's Image component to the given color.*/
    private void _ChangeBubbleColor(Color col)
    {
        _bubbleImage.color = col;
    }
}
