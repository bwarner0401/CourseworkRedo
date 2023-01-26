using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ice")
        {
            GetComponent<Collider>().material.dynamicFriction = 0;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ice")
        {
            GetComponent<Collider>().material.dynamicFriction = 0.8f;

        }
    }
}
