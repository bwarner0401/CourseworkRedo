using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageReaction : MonoBehaviour
{
    public GameObject bull;
    public float disValue;

    private Scoring scSys;
    private float score;

    // Start is called before the first frame update
    void Start()
    {
        scSys = bull.GetComponent<Scoring>();
        
    }

    // Update is called once per frame
    void Update()
    {
        score = scSys.score;
        if(score>disValue)
        {
            this.gameObject.SetActive(false);
        }
    }
}
