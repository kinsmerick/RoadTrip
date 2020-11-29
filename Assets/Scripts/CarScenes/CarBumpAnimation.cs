using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBumpAnimation : MonoBehaviour
{
    public GameObject Mish;
    public GameObject Dani;
    public GameObject FrontCar;
    public GameObject SideCar;
    public float randomFloat = 0f;

    private Animator _carAnim;
    private Animator _mishAnim;
    private Animator _daniAnim;
    private Animator _sideCarAnim;

    private const float _THRESHOLD = 99.85f;
    public float _timeElapsed = 0f;
    private float _minTimeBeforeBump = 2f;

    private bool _setToFalse = true;
    private bool _isDriving = true;
    private bool _animSwitchedOff = false;

    // Start is called before the first frame update
    void Start()
    {
        _carAnim = FrontCar.GetComponent<Animator>();
        _mishAnim = Mish.GetComponent<Animator>();
        _daniAnim = Dani.GetComponent<Animator>();
        _sideCarAnim = SideCar.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isDriving)
        {
            if (_timeElapsed > _minTimeBeforeBump)
            {
                randomFloat = Random.Range(0f, 100f);

                if (randomFloat >= _THRESHOLD)
                {
                    setTrue();
                }

            }
            else
            {
                if (!_setToFalse)
                {
                    setFalse();
                    _setToFalse = true;
                }
                _timeElapsed += Time.deltaTime;
            }
        }
        else if (!_animSwitchedOff)
        {
            setFalse();

            _animSwitchedOff = true;
        }
    }

    public void StopAnimations()
    {
        _isDriving = false;
    }

    private void setTrue()
    {
       // _carAnim.SetBool("PlayBump", true);
        //_mishAnim.SetBool("PlayBump", true);
       // _daniAnim.SetBool("PlayBump", true);
      //  _sideCarAnim.SetBool("PlayBump", true);
        _carAnim.Play("CarBump");
        _mishAnim.Play("MishBump");
        _daniAnim.Play("DaniBump");
        _sideCarAnim.Play("SideCarBump");

        _timeElapsed = 0f;
        randomFloat = 0f;
        _setToFalse = false;
    }

    private void setFalse()
    {
        _carAnim.SetBool("PlayBump", false);
        _mishAnim.SetBool("PlayBump", false);
        _daniAnim.SetBool("PlayBump", false);
        _sideCarAnim.SetBool("PlayBump", false);
    }
}
