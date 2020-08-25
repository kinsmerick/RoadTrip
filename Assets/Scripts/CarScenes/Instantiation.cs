using UnityEngine;
public class Instantiation : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject myPrefab;
    public AnimationClip myAnimation;

    //Makes a repeating instance of the events called l8r
    void Start()

    {
        InvokeRepeating("MoreTrees", 1.0f, 5.0f);
    }


    void MoreTrees()
    {
        // Make duplicates of the same lil guy
        Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);

        Instantiate(myAnimation, new Vector3(1, 1, 1), Quaternion.identity);
    }

}
