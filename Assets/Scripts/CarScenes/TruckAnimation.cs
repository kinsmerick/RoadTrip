using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class TruckAnimation : MonoBehaviour
{
    public GameObject truck;

    private Animator _truckAnim;
    // Start is called before the first frame update
    void Start()
    {
        _truckAnim = truck.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    [YarnCommand("SetTruckActive")]
    public void SetTruckActive()
    {
        truck.SetActive(true);
    }

    [YarnCommand("TruckExit")]
    public void TruckExit()
    {
        _truckAnim.SetBool("IsExiting", true);
    }

    [YarnCommand("SetTruckInactive")]
    public void SetTruckInactive()
    {
        truck.SetActive(false);
    }
}
