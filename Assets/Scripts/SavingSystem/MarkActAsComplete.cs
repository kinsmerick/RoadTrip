using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class MarkActAsComplete : MonoBehaviour
{
//code largely same as in NPCOrItem.cs, refer to that

  public GameCompletionRecord actThisIs;

  private GameCompletionRecord actDataLoad;

  private GameCompletionRecord actDataToSave;

  public void CompleteAct(){

    if(File.Exists(Application.persistentDataPath + "/gameCompletion.sav")) {
      BinaryFormatter bf = new BinaryFormatter();
      FileStream file = File.Open(Application.persistentDataPath + "/gameCompletion.sav", FileMode.Open);
      actDataLoad = (GameCompletionRecord)bf.Deserialize(file);
      file.Close();
      actDataToSave = actDataLoad + actThisIs;

    }
    else{
      actDataToSave = actThisIs;
    }

    //save File
    BinaryFormatter bf_save = new BinaryFormatter();
    FileStream file_save = File.Create (Application.persistentDataPath + "/gameCompletion.sav");
    bf_save.Serialize(file_save, actDataToSave);
    file_save.Close();


  }

}
