using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class ItemCollectable : MonoBehaviour
{

  public bool canInteract = false;
  private bool interacting = false;

  public CharacterController playerControl;
  [Header ("Yarn Script")]
  public string nodeName;

  public ItemCollection itemThisIs;

  private ItemCollection itemDataLoad;

  private ItemCollection itemDataToSave;

  private DialogueRunner dialogueRunner;

    // Start is called before the first frame update
    void Start()
    {
      playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
      dialogueRunner = FindObjectOfType<DialogueRunner>();
    }

    // Update is called once per frame
    void Update()
    {
      if(canInteract && !interacting && (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Jump")) ){
        interacting = true;
        playerControl.canWalk = false;
        AddItemToCollection();
        dialogueRunner.StartDialogue(nodeName);
      }
      else if(interacting && !dialogueRunner.IsDialogueRunning ){
        interacting = false;
        playerControl.canWalk = true;

        Destroy(gameObject);
      }
    }

    void OnTriggerEnter2D(Collider2D other){
      if(other.tag == "Observer"){
        canInteract = true;
      }
    }


    void OnTriggerExit2D(Collider2D other){
      if(other.tag == "Observer"){
        canInteract = false;
      }
    }

    public void AddItemToCollection(){
      //savedCollection = savedCollection + itemThisIs;

      if(File.Exists(Application.persistentDataPath + "/items.sav")) {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/items.sav", FileMode.Open);
        itemDataLoad = (ItemCollection)bf.Deserialize(file);
        file.Close();
        //loads file, updates jump number
        itemDataToSave = itemDataLoad + itemThisIs;

      }
      else{
        //fresh file, saves jump number
        itemDataToSave = itemThisIs;
      }

      //save File
      BinaryFormatter bf_save = new BinaryFormatter();
      FileStream file_save = File.Create (Application.persistentDataPath + "/items.sav");
      bf_save.Serialize(file_save, itemDataToSave);
      file_save.Close();


    }

}