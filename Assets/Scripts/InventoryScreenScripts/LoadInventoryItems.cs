using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class LoadInventoryItems : MonoBehaviour
{
//note! this class has to be updated along with ItemCollection.cs to allow for any new items
//added to the story!
//the prefab this is attached to will have to be updated as well to connect the items
//unless later

  private ItemCollection itemCollection;






    // Start is called before the first frame update
    void Start()
    {
      if(File.Exists(Application.persistentDataPath + "/items.sav")) {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/items.sav", FileMode.Open);
        itemCollection = (ItemCollection)bf.Deserialize(file);
        file.Close();
      }



    }

    // Update is called once per frame
    void Update()
    {

    }
}
