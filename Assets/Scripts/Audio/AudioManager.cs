using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

/*The AudioManager creates an array of scriptable object Sound, initalizes
  AudioSource game objects per Sound, and provides methods to start and
  stop the playing of each Sound. It is designed such that someone could
  easily add the sounds to a scene using the inspector in one place, and
  is built on the understanding that all sounds that don't play on Start
  will be called from other scripts or events.*/

public class AudioManager : MonoBehaviour
{
    //creates an array of sounds that can be edited to in the inspector
    [SerializeField]
    public Sound[] soundArray;
    
    private DialogueManager _dialogueManager;

    //Gets the scene's Dialogue Manager.
    //Instantiates the SoundArray specified in the inspector as children game object
    //with AudioSource components of the AudioManager. If any given Sound is set to
    //play on Awake, playSound(that given Sound) is called now.
    private void Awake()
    {
        _dialogueManager = FindObjectOfType<DialogueManager>();

        for (int i = 0; i < soundArray.Length; i++)
        {
            GameObject sound = new GameObject(soundArray[i].clipName + "AudioSource");
            sound.transform.SetParent(transform);
            soundArray[i].setSource(sound.AddComponent<AudioSource>());

            if (soundArray[i].playOnAwake)
            {
                playSound(soundArray[i].clipName);

            }//end if

        }//end for loop
    }

    /* Creates Yarn Command <<PlaySound>> that allows a yarn script to
     * play a sound from this AudioManager's array of sounds. It calls
     * checkSoundExists to confirm the passed in clip name matches an
     * existing sound. If true, it calls the Sound's play method.*/

    [YarnCommand("PlaySound")]
    public void playSound(string name)
    {
        int positionInSoundArray = _checkSoundExists(name);

        if (positionInSoundArray > -1)
        {
            soundArray[positionInSoundArray].play();
        }
    }//end playSound method

    /* Creates Yarn Command <<StopSound>> that allows a yarn script to
     * stop a sound being played from this AudioManager's array of sounds.
     * It calls checkSoundExists to confirm the passed in clip name matches an
     * existing sound. If true, it calls the Sound's stop method.*/

    [YarnCommand("StopSound")]
    public void stopSound(string name)
    {
        int positionInSoundArray = _checkSoundExists(name);

        if (positionInSoundArray > -1)
        {
            soundArray[positionInSoundArray].stop();
        }
    }//end stopSound method

    //playCharacterSound is called by the Yarn Dialogue UI component each time a line starts.
    //It gets the character manager of the current speaker from the dialogue manager and
    //plays that character manager's active sound.

    public void playCharacterSound()
    {
        CharacterManager cm = _dialogueManager.getCurrentSpeaker();
        cm.getActiveSound().play();

    }//end playCharacterSound method

    //Checks to see if the soundArray contains a sound with clip name "name".
    //If true, return the position of the sound in soundArray. If false, log
    //an error in the console and return -1.

    private int _checkSoundExists(string name)
    {
        for (int i = 0; i < soundArray.Length; i++)
        {
            if (soundArray[i].clipName == name)
            {
                return i;
            }//end if
        }//end for loop

        Debug.LogError(name + " audio clip doesn't exist in the Sound"
                                + "Array. Was there a typo?");
        return -1;

    }//end doesSoundExist method

}//end AudioManager class