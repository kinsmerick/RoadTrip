using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePreferenceFunctions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeTextSpeed(float speed){
      PlayerPrefs.SetFloat("TextSpeed", speed);
    }

}
