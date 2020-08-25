using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpCreditsAnimation : MonoBehaviour
{

  public float fastSpeedAmount = 4;
  private Animator credAnim;
  private float defaultSpeed;

    // Start is called before the first frame update
    void Start()
    {
        credAnim = GetComponent<Animator>();
        defaultSpeed = credAnim.speed;
    }

    // Update is called once per frame
    void Update()
    {

      if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Jump"))
          {
              credAnim.speed = fastSpeedAmount;
          }
      else if(Input.GetButtonUp("Fire1") || Input.GetButtonUp("Jump"))
          {
              credAnim.speed = defaultSpeed;
          }

    }
}
