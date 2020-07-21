using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

/* OptionTextDisplayHandler implements three interfaces that pointer events for entering, exiting, and pressing down.
 * These events adjust the Option text bubbles' text. The Options' images are handled by the Button component, but the
 * text needs to change color to maintain readability when the images change color. The color, for now, can be set
 * in the Editor to be Daniella's character color for testing purposes, but when that color is decided, it will be
 * made a constant within this class.*/

public class OptionTextDisplayHandler : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{    
    [Tooltip("Set this to Daniella's character color.")]
    public Color hoverTextColor;

    public TextMeshProUGUI _tmp;
    private Color _standardTextColor;

    // Start is called before the first frame update
    //Gets the option's TMP component and stores the set starting text color for it.
    void Start()
    {
        _tmp = this.GetComponentInChildren<TextMeshProUGUI>();

        if(_tmp != null)
        {
            _standardTextColor = _tmp.color;
        }
        else
        {
            Debug.LogError(this.name + " 's TextMeshPro not found in OptionsTextDisplayHandler.");
        }
    }

    //turn option text to hover color when mouse enter
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        _tmp.color = hoverTextColor;

    }

    //turn option text to normal color when mouse down for next time options are used
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        _tmp.color = _standardTextColor;
    }

    //turn option text to normal color when mouse exit
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        _tmp.color = _standardTextColor;
    }

}//end OptionTextDisplayHandler class
