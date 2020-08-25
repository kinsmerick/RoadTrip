using UnityEngine;
public class Despawn : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public float TimeTillDelete = 3f;
    private float timer;

    //Makes a repeating instance of the events called l8r
    void Start()

    {
        timer = Time.time;
    }

    private void Update()
    {
        if (Time.time - timer > TimeTillDelete)
        {
            Destroy(gameObject);
        }
    }


}