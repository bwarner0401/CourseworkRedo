using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InHoleDetector : MonoBehaviour
{
    public GameObject cage;
    public InHoleAction action;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("HoleCage");
        cage = gos[0];
        action = cage.GetComponent<InHoleAction>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.tag == "Detector")
        {
            action.inHole = true;
        }
    }
}
