using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

//Scriptable object that instantiates an AudioSource with the settings defined by
//the user in the inspector. It contains methods to start and stop the AudioSource's playing.

[CreateAssetMenu(fileName = "New Sound Object", menuName = "SoundObject")]
public class Sound : ScriptableObject
{
    //The AudioSource for the Sound, which communicates with the scene's
    //AudioListener.

    private AudioSource _audioSource;

    /*The following variables are set within the inspector and then passed into
     audio sources that are instantiated on Start(). They reflect the attributes
     of an AudioSource component, but not all of its variables are included here
     for ease of use/comprehension by an individual without advanced sound knowledge.

     clipName: a string that will be used by the AudioManager to play this Sound
     clip: the Sound's audio file
     volume: a float representing the volume the audio file will be played at
     loop: a bool representing whether or not the Sound should play on loop

     playOnStart: a bool representing whether or not the Sound should play on Awake.*/

    public string clipName;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;

    public bool loop;
    public bool playOnAwake;

    public AudioType audioType;

    //A constructor that sets a given AudioSource (instantiated in
    //AudioManager's Start()) to the values set in the inspector.

    public void setSource(AudioSource source)
    {
        setVolumeToPrefs();

        _audioSource = source;
        _audioSource.clip = clip;
        _audioSource.volume = volume;
        _audioSource.loop = loop;
        _audioSource.playOnAwake = playOnAwake;

    }//end setSource method

    //calls the AudioSource's Play method if it isn't already playing
    public void play()
    {
        if (!_audioSource.isPlaying)
        {
            _audioSource.Play();
        }//end if

    }//end play method

    //calls the AudioSource's Stop method if it is playing
    public void stop()
    {
        if (_audioSource.isPlaying)
        {
            _audioSource.Stop();
        }//end if

    }//end Stop method

    public void setVolumeToPrefs()
    {
        switch (audioType)
        {
            case AudioType.Music:
                volume = PlayerPrefs.GetFloat("Music Volume", 0.5f);
                break;

            case AudioType.Sfx:
                volume = PlayerPrefs.GetFloat("Sfx Volume", 0.5f);
                break;

            case AudioType.Character:
                volume = PlayerPrefs.GetFloat("Chara Volume", 0.5f);
                break;

            default:
                break;
        }
    }

}//end Sound scriptable object

[System.Serializable]
public enum AudioType
{
    Music,
    Character,
    Sfx
}