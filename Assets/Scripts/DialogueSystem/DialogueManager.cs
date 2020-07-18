using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject speechBubble;
    public GameObject[] characters;
    public bool isExploration = false;

    private Image bubbleImage;

    private void Awake()
    {
        bubbleImage = speechBubble.GetComponent<Image>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            setSpeaker("Kinsey");
        }
    }

    public void setSpeaker(string speakerName)
    {
        CharacterManager chara = null;

        for(int i = 0; i < characters.Length; i++)
        {
            if (characters[i].name.Equals(speakerName))
            {
                chara = characters[i].GetComponent<CharacterManager>();
                Debug.Log(chara.name + " found.");
                break;
            }//end if

            if(i == characters.Length - 1)
            {
                Debug.LogError(speakerName + " not found in DialogueManager's character list.");
            }//end else if
        }//end for loop

        changeBubbleColor(chara.dialogueColor);
        setBubble(chara);
    }

    private void changeBubbleColor(Color col)
    {
        bubbleImage.color = col;
    }

    private void setBubble(CharacterManager chara)
    {
        //code that will move the bubble to the specified position
        if(!isExploration)
        {
            speechBubble.transform.localPosition = chara.bubblePositions[0].pos;
        }
        else
        {
            Debug.Log("Finding in-game character position.");
            speechBubble.transform.position = chara.transform.position;
        }
    }

    public void setBubble(string posName)
    {

    }
}
