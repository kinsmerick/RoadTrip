using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCertainItemBasedOnValue : MonoBehaviour
{

  public float valueToCompareTo = 0;
  public GameObject activeIfAboveValue;
  public GameObject activeIfBelowOrEqual;

  private ForgiveValueRecorder forgiveObject;

    // Start is called before the first frame update
    void Start()
    {
      forgiveObject = FindObjectOfType<ForgiveValueRecorder>();
      if(forgiveObject != null){
        if(forgiveObject.forgivenessValue > valueToCompareTo){
          activeIfAboveValue.SetActive(true);
        }
        else{
          activeIfBelowOrEqual.SetActive(true);
        }
        Destroy(forgiveObject.gameObject);
      }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
