using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPickup : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision hit)
    {
        if(hit.gameObject.tag=="GravPick")
        {
            StartCoroutine(PickupReset(hit.gameObject));
            StartCoroutine(GravChange());
        }
    }

    IEnumerator GravChange()
    {
        Vector3 currGrav = Physics.gravity;
        Physics.gravity = new Vector3(0, -5f, 0);
        yield return new WaitForSeconds(40);
        Physics.gravity = currGrav;
    }

    IEnumerator PickupReset(GameObject pickup)
    {
        pickup.SetActive(false);
        yield return new WaitForSeconds(60);
        pickup.SetActive(true);
    }
}
