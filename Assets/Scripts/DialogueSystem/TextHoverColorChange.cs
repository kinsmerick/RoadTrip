using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class TextHoverColorChange : MonoBehaviour
{

  public Color hoverTextColor;

  private TextMeshProUGUI _tmp;
  private Color _standardTextColor;

    // Start is called before the first frame update
    void Start()
    {
        _tmp = this.GetComponent<TextMeshProUGUI>();
        if(_tmp != null)
        {
            _standardTextColor = _tmp.color;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void SetOtherColor()
    {
        _tmp.color = hoverTextColor;
    }

    public void SetOriginalColor()
    {
        _tmp.color = _standardTextColor;
    }

}
