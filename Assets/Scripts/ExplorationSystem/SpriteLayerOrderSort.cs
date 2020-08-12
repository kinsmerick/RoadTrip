using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLayerOrderSort : MonoBehaviour
{

  public GameObject player;

  public int aboveValue = 2;
  public int belowValue = -2;

  private SpriteRenderer theRenderer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        theRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
      if(player.transform.position.y > transform.position.y){
        theRenderer.sortingOrder = aboveValue;
      }
      else{
        theRenderer.sortingOrder = belowValue;
      }
    }
}
