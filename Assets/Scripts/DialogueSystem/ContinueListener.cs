using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

/* Simple script that, when active, listens for the player to press the
 * primary mouse button. Upon doing so, it communicates to the DialogUI
 * that the line is completed (which will either finish printing the line
 * or advance to the next.
 * 
 * It should be set to disabled, with the Dialogue UI's OnDialogueStart
 * method enabling it, and the OnDialogueEnd method disabling it once more.*/

public class ContinueListener : MonoBehaviour
{
    private DialogueUI _dialogueUI;

    // Start is called before the first frame update
    void Start()
    {
        _dialogueUI = this.GetComponent<DialogueUI>();
    }

    // Update is called once per frame
    void Update()
    {
        //if user presses what would standardly be a left mouse or space key
        if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Jump"))
        {
            _dialogueUI.MarkLineComplete();
        }
    }
}
