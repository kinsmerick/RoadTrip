using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextSpeedToggle : MonoBehaviour
{
    private GamePreferenceFunctions _gpf;
    private Toggle _toggle;
    private bool _toggleStatus;

    // Start is called before the first frame update
    void Awake()
    {
        _gpf = FindObjectOfType<GamePreferenceFunctions>();
        _toggle = this.GetComponent<Toggle>();
        _toggleStatus = _toggle.isOn;
    }

    // Update is called once per frame
    void Update()
    {
        if (_toggleStatus != _toggle.isOn)
        {
            _toggleStatus = _toggle.isOn;

            if(_toggleStatus == true)
            {
                _gpf.ChangeTextSpeed(_toggle.GetComponentInChildren<TextMeshProUGUI>().text);
            }

        }
    }
}
