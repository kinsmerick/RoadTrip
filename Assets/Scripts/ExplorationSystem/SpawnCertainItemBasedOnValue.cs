using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCertainItemBasedOnValue : MonoBehaviour
{

  public float valueToCompareTo = 0;
  public GameObject activeIfAboveValue;
  public GameObject activeIfBelowOrEqual;


  private float savedForgivenessValue;

    // Start is called before the first frame update
    void Start()
    {

      savedForgivenessValue = PlayerPrefs.GetFloat("forgiveness", 0);

      if(activeIfAboveValue != null && activeIfBelowOrEqual != null){
        if(savedForgivenessValue > valueToCompareTo){
          activeIfAboveValue.SetActive(true);
        }
        else{
          activeIfBelowOrEqual.SetActive(true);
        }
      }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
