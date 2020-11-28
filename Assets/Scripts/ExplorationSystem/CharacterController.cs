using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

  public float walkSpeed = 2f;
  public GameObject examineBox;
  public bool canWalk = true;
  public bool canInteract = true;

  [Header("Directions")]
  public GameObject up;
  public GameObject down;
  public GameObject left;
  public GameObject right;

  [Header("Footstep Noises")]
  public bool playSteps = false;
  public string [] stepNames;
  public float timeTillNextStep = 0.5f;
  private float stepTimer;
  private AudioManager _audManager;


  private Vector2 movement;


  private Rigidbody2D rb;

  private float hf = 0.0f;
  private float vf = 0.0f;

  private Animator daniAnimation;
  private SpriteRenderer daniSprite;

  private bool lookingForward = true;

    // Start is called before the first frame update
    void Start()
    {
      _audManager = FindObjectOfType<AudioManager>();
      stepTimer = Time.time;
      rb = GetComponent<Rigidbody2D>();
      daniAnimation = GetComponent<Animator>();

      daniSprite = GetComponent<SpriteRenderer>();
      daniAnimation.SetBool("forward", lookingForward);

    }

    // Update is called once per frame
    void Update()
    {

      movement.x = Input.GetAxisRaw("Horizontal");
      movement.y = Input.GetAxisRaw("Vertical");
      hf = movement.x > 0.01f ? movement.x : movement.x < -0.01f ? 1 : 0;
      vf = movement.y > 0.01f ? movement.y : movement.y < -0.01f ? 1 : 0;

      if( (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical")) && canWalk){
        daniAnimation.SetTrigger("walk");
      }
      else if( ( Input.GetButtonUp("Horizontal") || Input.GetButtonUp("Vertical") ) && !(Input.GetButton("Horizontal") || Input.GetButton("Vertical")) ){
        daniAnimation.SetTrigger("stopwalk");
      }



      //determines what direction you are facing (put animation triggers below)
      if(Input.GetButton("Horizontal") && canWalk){
        PlayFootstep();
        if (movement.x < -0.01f){
          //looking left
            examineBox.transform.position = left.transform.position;
            if(!daniSprite.flipX){
              daniSprite.flipX = true;
            }
        }
        else
        {
          //looking right
            examineBox.transform.position = right.transform.position;
            if(daniSprite.flipX){
              daniSprite.flipX = false;
            }
        }
      }
      if(Input.GetButton("Vertical") && canWalk){
        PlayFootstep();
        if (movement.y < -0.01f){
          //looking down
            examineBox.transform.position = down.transform.position;
            if(!lookingForward){
              lookingForward = true;
              daniAnimation.SetBool("forward", lookingForward);
            }
        }
        else
        {
          //looking up
            examineBox.transform.position = up.transform.position;
            if(lookingForward){
              lookingForward = false;
              daniAnimation.SetBool("forward", lookingForward);
            }
        }
      }





    }

    void FixedUpdate(){
      if(canWalk){
        rb.MovePosition(rb.position + movement * walkSpeed * Time.fixedDeltaTime);
      }
    }

    void PlayFootstep(){
      if(playSteps && stepNames.Length > 0 && Time.time - stepTimer > timeTillNextStep){
        _audManager.playSound(stepNames[Random.Range(0, stepNames.Length)]);
        stepTimer = Time.time;
      }

    }


}
