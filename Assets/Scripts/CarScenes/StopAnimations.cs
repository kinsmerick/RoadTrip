using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class StopAnimations : MonoBehaviour
{
    public Instantiation[] instantiations;
    public CarBumpAnimation carbumpanim;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [YarnCommand("StopTrees")]
    public void StopTrees()
    {
        carbumpanim.StopAnimations();

        for(int i = 0; i < instantiations.Length; i++)
        {
            instantiations[i].StopAllCoroutines();
            instantiations[i].enabled = false;
        }
    }
}
