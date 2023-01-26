using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReset : MonoBehaviour
{

    void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.tag == "Floor" || hit.gameObject.tag == "Building")
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            transform.position = new Vector3(54.19f, 8.5f, -58.6f);
            rb.velocity = Vector3.zero;
        }
    }
}
