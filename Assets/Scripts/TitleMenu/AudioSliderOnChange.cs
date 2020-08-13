using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSliderOnChange : MonoBehaviour
{
    public SliderType sliderType;

    private GamePreferenceFunctions _gpf;
    private Slider _slider;
    private float _vol;

    // Start is called before the first frame update
    void Start()
    {
        _gpf = FindObjectOfType<GamePreferenceFunctions>();
        _slider = this.GetComponent<Slider>();
        _vol = _slider.value;
    }

    // Update is called once per frame
    void Update()
    {
        if(_vol != _slider.value)
        {
            onSliderChange();
        }
    }

    public void onSliderChange()
    {
        switch (sliderType)
        {
            case SliderType.Music:
                _gpf.ChangeMusicVol(_slider.value);
                break;

            case SliderType.Sfx:
                _gpf.ChangeSfxVol(_slider.value);
                break;

            case SliderType.Chara:
                _gpf.ChangeCharaVol(_slider.value);
                break;

            default:
                break;
        }
    }

}

[System.Serializable]
public enum SliderType
{
    Music,
    Sfx,
    Chara
}