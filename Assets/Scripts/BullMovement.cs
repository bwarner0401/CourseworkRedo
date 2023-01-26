using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateSpeed = 100f;
    public float jumpStrength = 10f;

    private float move;
    private float rotate;
    private bool onFloor = false;

    private Rigidbody body;

    private float moveDetection;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        moveDetection = Input.GetAxis("Vertical");
        rotate = Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;
        if (onFloor)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                body.AddForce(transform.up * jumpStrength, ForceMode.Impulse);
                onFloor = false;
            }
        }
        
    }

    void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.tag == "Floor" || hit.gameObject.tag == "Building" || hit.gameObject.tag == "Box" || hit.gameObject.tag == "Ice")
        {
            onFloor = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       if (onFloor)
        {
            body.AddForce(transform.forward * moveSpeed * moveDetection);
        }
        transform.Rotate(0f, rotate, 0f);
    }

    
}
