using UnityEngine;
public class Instantiation : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject myPrefab;
    public AnimationClip myAnimation;
    public float secondsBeforeFirstInstantiation = 1.0f;
    public float secondsBetweenInstantiation;

    //Makes a repeating instance of the events called l8r
    void OnEnable()

    {
        InvokeRepeating("MoreTrees", secondsBeforeFirstInstantiation, secondsBetweenInstantiation);
    }

    //when the shot is disabled, stop the trees from being generated
    private void OnDisable()
    {
        CancelInvoke();
    }


    void MoreTrees()
    {
        GameObject _prefab;
        // Make duplicates of the same lil guy
        _prefab = Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        _prefab.transform.SetParent(this.transform);

        //Instantiate(myAnimation, new Vector3(1, 1, 1), Quaternion.identity);
    }


}
