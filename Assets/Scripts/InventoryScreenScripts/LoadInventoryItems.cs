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



  public GameObject dogText;
  public GameObject missingDogText;

  public GameObject lollipopText;
  public GameObject missingLollipopText;

  public GameObject robotText;
  public GameObject missingRobotText;

  public GameObject frogText;
  public GameObject missingFrogText;


  public GameObject happyRockText;
  public GameObject missingHappyRockText;

  public GameObject sadRockText;
  public GameObject missingSadRockText;

  public GameObject happyOwlText;
  public GameObject missingHappyOwlText;

  public GameObject sadOwlText;
  public GameObject missingSadOwlText;



    // Start is called before the first frame update
    void Start()
    {
      if(File.Exists(Application.persistentDataPath + "/items.sav")) {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/items.sav", FileMode.Open);
        itemCollection = (ItemCollection)bf.Deserialize(file);
        file.Close();
      }

      if(itemCollection.dogPoster){
        dogText.SetActive(true);
        missingDogText.SetActive(false);
      }

      if(itemCollection.sadRock){
        sadRockText.SetActive(true);
        missingSadRockText.SetActive(false);
      }

      if(itemCollection.happyRock){
        happyRockText.SetActive(true);
        missingHappyRockText.SetActive(false);
      }

      if(itemCollection.lollipop){
        lollipopText.SetActive(true);
        missingLollipopText.SetActive(false);
      }

      if(itemCollection.robot){
        robotText.SetActive(true);
        missingRobotText.SetActive(false);
      }

      if(itemCollection.plushFrog){
        frogText.SetActive(true);
        missingFrogText.SetActive(false);
      }

      if(itemCollection.happyOwl){
        happyOwlText.SetActive(true);
        missingHappyOwlText.SetActive(false);
      }

      if(itemCollection.sadOwl){
        sadOwlText.SetActive(true);
        missingSadOwlText.SetActive(false);
      }





    }

    // Update is called once per frame
    void Update()
    {

    }
}
