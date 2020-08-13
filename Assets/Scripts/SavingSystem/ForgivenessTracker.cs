using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using System.IO;

public class ForgivenessTracker : MonoBehaviour
{
    private InMemoryVariableStorage _memStorage;

    // Start is called before the first frame update
    void Start()
    {
        _memStorage = this.GetComponent<InMemoryVariableStorage>();
        setForgiveness(loadForgiveness());
        Debug.Log("Yarn variable forgiveness set to saved value of " + loadForgiveness());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setForgiveness(float value)
    {
        _memStorage.SetValue("$forgiveness", value);
        saveForgiveness();
        Debug.Log("Forgiveness set to " + value);
    }

    public float getForgiveness()
    {
        return _memStorage.GetValue("$forgiveness").AsNumber;
    }

    public void saveForgiveness()
    {
        Debug.Log("Saving forgiveness as " + getForgiveness());
        PlayerPrefs.SetFloat("forgiveness", getForgiveness());
    }

    public float loadForgiveness()
    {
        return PlayerPrefs.GetFloat("forgiveness", 0);
    }
}
