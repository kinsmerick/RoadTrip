﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullscreenToggle : MonoBehaviour
{
    private GamePreferenceFunctions _gpf;
    private Toggle _toggle;

    // Start is called before the first frame update
    void Awake()
    {
        _gpf = FindObjectOfType<GamePreferenceFunctions>();
        _toggle = this.GetComponent<Toggle>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnToggle()
    {
        _gpf.ChangeFullscreen(_toggle.isOn);
        Screen.fullScreen = _toggle.isOn;
    }
}
