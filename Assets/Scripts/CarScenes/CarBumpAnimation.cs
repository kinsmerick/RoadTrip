using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBumpAnimation : MonoBehaviour
{
    public GameObject Mish;
    public GameObject Dani;
    public float randomFloat = 0f;

    private Animator _carAnim;
    private Animator _mishAnim;
    private Animator _daniAnim;

    private const float _THRESHOLD = 98f;
    public float _timeElapsed = 0f;
    private float _minTimeBeforeBump = 2f;

    private bool _setToFalse = true;

    // Start is called before the first frame update
    void Start()
    {
        _carAnim = this.GetComponent<Animator>();
        _mishAnim = Mish.GetComponent<Animator>();
        _daniAnim = Dani.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_timeElapsed > _minTimeBeforeBump)
        {
            randomFloat = Random.Range(0f, 100f);

            if(randomFloat >= _THRESHOLD)
            {
                _carAnim.SetBool("PlayBump", true);
                _mishAnim.SetBool("PlayBump", true);
                _daniAnim.SetBool("PlayBump", true);

                _timeElapsed = 0f;
                randomFloat = 0f;
                _setToFalse = false;
            }
        }
        else
        {
            if(_timeElapsed > 0.2f && !_setToFalse)
            {
                _carAnim.SetBool("PlayBump", false);
                _mishAnim.SetBool("PlayBump", false);
                _daniAnim.SetBool("PlayBump", false);

                _setToFalse = true;
            }
            _timeElapsed += Time.deltaTime;
        }
    }
}
