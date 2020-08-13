using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ToggleOptionText : MonoBehaviour
{
    private TextMeshProUGUI _tmp;
    private Toggle _toggle;

    //onEnable, get the text mesh pro component of the child as well as this's toggle
    //component. Update the text of the button according to the status of the toggle
    //this is so that, if the user has saved a state different than the default one,
    //the toggle updates the text upon opening of the settings screen to reflect
    //the user set value
    private void OnEnable()
    {
        _tmp = GetComponentInChildren<TextMeshProUGUI>();
        _toggle = GetComponent<Toggle>();
        if (!_toggle.Equals(null))
        {
            toggleText();
        }

    }

    //when called, changes the text in the toggle's child TMP to reflect
    //the state of the toggle
    public void toggleText()
    {
        if (_toggle.isOn)
        {
            _tmp.text = "On";
        }
        else
        {
            _tmp.text = "Off";
        }

    }//end toggleText method
}//end ToggleOptionText class
