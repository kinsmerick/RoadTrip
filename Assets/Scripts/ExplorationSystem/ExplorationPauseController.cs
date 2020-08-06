using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorationPauseController : MonoBehaviour
{


  public CharacterController playerControl;

  public GameObject pauseMenuObject;
  public GameObject pauseButtons;
  public GameObject collectionObject;

  public bool pauseMenuOpen = false;

    // Start is called before the first frame update
    void Start()
    {
      playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
      if(!pauseMenuOpen && Input.GetButtonDown("Cancel") && playerControl.canWalk){
        PauseGame();
      }
      else if(pauseMenuOpen && Input.GetButtonDown("Cancel")){
        ReturnToGame();
      }
    }

    public void PauseGame(){
      pauseMenuOpen = true;
      playerControl.canWalk = false;
      playerControl.canInteract = false;
      pauseMenuObject.SetActive(true);
      pauseButtons.SetActive(true);
    }

    public void ReturnToGame(){
      pauseMenuOpen = false;
      playerControl.canWalk = true;
      playerControl.canInteract = true;
      collectionObject.SetActive(false);
      pauseButtons.SetActive(false);
      pauseMenuObject.SetActive(false);
    }

}
