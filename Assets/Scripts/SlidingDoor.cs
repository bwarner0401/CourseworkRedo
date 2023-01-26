using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    public Vector3 openPos;
    public float speed = 1f;
    public GameObject bull;

    private Scoring scSys;
    private float keys;
    
    // Start is called before the first frame update
    void Start()
    {
        scSys = bull.GetComponent<Scoring>();
    }

    // Update is called once per frame
    void Update()
    {
        keys = scSys.keys;
        if(keys > 3)
        {
            float dist = Vector3.Distance(transform.position, openPos);
            if (dist > 0.1f)
            {
                transform.position = Vector3.Lerp(transform.position, openPos, speed * Time.deltaTime);
            }
        }
    }
}
