using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForgiveValueRecorder : MonoBehaviour
{
  //notice! this component should be in a scene before an exploration scene, and take the
  //forgiveness value from it

  public float forgivenessValue = 0;


    // Start is called before the first frame update
    void Start()
    {
      DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
