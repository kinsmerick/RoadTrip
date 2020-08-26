using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class EnableActButtons : MonoBehaviour
{

    public GameCompletionRecord actDataLoad;
    public Button act2Button;
    public Button act3Button;


    // Start is called before the first frame update
    public void OnEnable()
    {
        Debug.Log("EnableActButtons on enable called.");

      if(File.Exists(Application.persistentDataPath + "/gameCompletion.sav")) {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/gameCompletion.sav", FileMode.Open);
        actDataLoad = (GameCompletionRecord)bf.Deserialize(file);
        file.Close();
        act2Button.interactable = actDataLoad.act1Complete;
        act3Button.interactable = actDataLoad.act2Complete;
        }
      //if the file doesn't exist, it was deleted, so the buttons should be not interactable
        else
        {
            act2Button.interactable = false;
            act3Button.interactable = false;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }




}
