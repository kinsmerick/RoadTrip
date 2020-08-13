using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class GamePreferenceFunctions : MonoBehaviour
{
    public Slider musSlider;
    public Slider sfxSlider;
    public Slider charaSlider;

    public Toggle slow;
    public Toggle med;
    public Toggle fast;
    public Toggle max;

    public Toggle autoAdvance;

    public Toggle fullscreen;

    //public TMP_Dropdown resolution;

    private AudioManager _audManager;

//if the scene has the dialogue ui, attach it to this so that the saved speed will save to it

  private string currentTextSpeed;

    private void Awake()
    {
        _audManager = FindObjectOfType<AudioManager>();
    }

    public void Start(){
        setStartingPrefs();
    }

//call this from a ui slider to set the speed
    public void ChangeTextSpeed(string text){
      PlayerPrefs.SetString("TextSpeed", text);
    }

    public void ChangeMusicVol(float vol)
    {
        PlayerPrefs.SetFloat("Music Volume", vol);
        _audManager.updateVolumes(AudioType.Music);
    }

    public void ChangeSfxVol(float vol)
    {
        PlayerPrefs.SetFloat("Sfx Volume", vol);
        _audManager.updateVolumes(AudioType.Sfx);
    }

    public void ChangeCharaVol(float vol)
    {
        PlayerPrefs.SetFloat("Chara Volume", vol);
        _audManager.updateVolumes(AudioType.Character);
    }

    public void ChangeAutoAdv(bool state)
    {
        string onOff;
        if (state)
        {
            onOff = "On";
        }
        else
        {
            onOff = "Off";
        }
        PlayerPrefs.SetString("Auto Advance", onOff);
    }

    public void ChangeFullscreen(bool state)
    {
        string onOff;
        if (state)
        {
            onOff = "On";
        }
        else
        {
            onOff = "Off";
        }
        PlayerPrefs.SetString("Fullscreen", onOff);
    }

    public void DeleteSaveData(){
      File.Delete(Application.persistentDataPath + "/items.sav");
      File.Delete(Application.persistentDataPath + "/gameCompletion.sav");
    }

    public void setStartingPrefs()
    {
        musSlider.value = PlayerPrefs.GetFloat("Music Volume", 0.5f);
        sfxSlider.value = PlayerPrefs.GetFloat("Sfx Volume", 0.5f);
        charaSlider.value = PlayerPrefs.GetFloat("Chara Volume", 0.5f);

        switch(PlayerPrefs.GetString("TextSpeed", "Medium"))
        {
            case "Slow":
                slow.isOn = true;
                break;

            case "Medium":
                med.isOn = true;
                break;

            case "Fast":
                fast.isOn = true;
                break;

            case "Max":
                max.isOn = true;
                break;

            default:
                med.isOn = true;
                break;

        }

        bool autoadv;
        bool fs;

        if(PlayerPrefs.GetString("Auto Advance", "Off").Equals("On"))
        {
            autoadv = true;
        }
        else
        {
            autoadv = false;
        }

        if (PlayerPrefs.GetString("Fullscreen", "Off").Equals("On"))
        {
            fs = true;
        }
        else
        {
            fs = false;
        }

        autoAdvance.isOn = autoadv;
        fullscreen.isOn = fs;
        Screen.fullScreen = fullscreen.isOn;
    }
}
