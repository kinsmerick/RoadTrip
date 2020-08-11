using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

/* OptionsHandler implements three interfaces, one for pointer enter and then select and deselect.
 * These events set the selected object in the Event system and the Option text bubbles' text color, respectively.
 * The Options buttons' colors are handled by the Button component, but the text needs to change color to maintain
 * readability when the images change color. The color, for now, can be set in the Editor to be Daniella's character
 * color for testing purposes, but when that color is decided, it will be made a constant within this class.*/

public class OptionsHandler : MonoBehaviour, IPointerEnterHandler, ISelectHandler, IDeselectHandler
{    
    [Tooltip("Set this to the desired hover text character color.")]
    public Color hoverTextColor;

    private TextMeshProUGUI _tmp;
    private Color _standardTextColor;
    private EventSystem _eventSystem;
    private AudioManager _audManager;


    private void Awake()
    {
        _tmp = this.GetComponentInChildren<TextMeshProUGUI>();
        _audManager = FindObjectOfType<AudioManager>();
    }

    // Start is called before the first frame update
    // Stores the set starting text color for of text mesh pro component
    void Start()
    {

        if(_tmp != null)
        {
            _standardTextColor = _tmp.color;
        }
        else
        {
            Debug.LogError(this.name + " 's TextMeshPro not found in OptionsTextDisplayHandler.");
        }
    }

    //Each time the options bubbles are enabled, it grabs the current event system. It also makes sure that
    //if the gameobject has the name Option in it, the scene does not start with a button selected, so that,
    //if players are spamming continue, they won't accidentally select a choice before they see it. But, if
    //this is any other sort of button, it won't set the event to inactive such that the UI menu will still
    //go to the set start button upon activation.

    private void OnEnable()
    {
        _eventSystem = EventSystem.current;
        if ( _eventSystem.currentSelectedGameObject == this.gameObject && this.gameObject.name.Contains("Option"))
        {
            _eventSystem.SetSelectedGameObject(null);
        }
    }

    //On update, it checks to see if this object is selected. It updates the color of the text accordingly.
    //It also checks for whether or not this current event system has no object selected. If
    //true, it will listen for key inputs from the player if the player wants to again select an option
    //with the keyboard. This may seem redundant, as OnSelect and OnDeselect change the color, but there are weird edge
    //cases that can happen if the player simultaneously uses the mouse and the keyboard to select options,
    //so the check in Update handles those.

    private void Update()
    {
        if (_eventSystem.currentSelectedGameObject == this.gameObject){
            _tmp.color = hoverTextColor;
        }
        else
        {
            _tmp.color = _standardTextColor;
        }

        //If the user has clicked away from the buttons, and this component is attached to the last selected button,
        //then it listens for a directional key press. If it's pressed, it selects an option bubble.
        //This is so that if the user clicks with the mouse but then decides they want to use the keys to navigate,
        //the event system will recognize the buttons as the current event again.

        if (_eventSystem.currentSelectedGameObject == null)
        {
            if(Input.GetButton("Horizontal") || Input.GetButton("Vertical")){

                _eventSystem.SetSelectedGameObject(this.gameObject);
            }
        }

    }//end Update

    //make this game object the selected object when the pointer enters
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        _eventSystem.SetSelectedGameObject(this.gameObject);
    }

    //when an object is selected, change its color to selected
    public void OnSelect(BaseEventData data)
    {
        _tmp.color = hoverTextColor;
        _audManager.playSound("Start_Menu_Button_Hover");
    }

    //when an object is deselected, change its color to normal
    public void OnDeselect(BaseEventData data)
    {
        _tmp.color = _standardTextColor;
    }

}//end OptionTextDisplayHandler class
