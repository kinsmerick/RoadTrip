using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextDisplayHandler : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    public Color standardTextColor;

    public bool isOption;
    public Color hoverTextColor;

    // Start is called before the first frame update
    void Start()
    {
        tmp = this.GetComponent<TextMeshProUGUI>();
        if(tmp != null)
        {
            standardTextColor = tmp.color;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMouseEnter()
    {
        //if this text is part of an option, turn to hover color when mouse enter
        if (isOption) {
            tmp.color = hoverTextColor;
        }

    }

    private void OnMouseDown()
    {
        //if this text is part of an option, return to normal cover when mouse exit
        if (isOption)
        {
            tmp.color = standardTextColor;
        }
    }

    private void OnMouseExit()
    {
        //if this text is part of an option, return to normal cover when mouse exit
        if (isOption) {
            tmp.color = standardTextColor;
        }
    }
}
