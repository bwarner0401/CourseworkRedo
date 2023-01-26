using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteraction : MonoBehaviour
{
    public float forceMultiplier;

    public float launchValue;

    public ParticleSystem ps;

    private Rigidbody body;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter (Collision hit)
    {
        if (hit.gameObject.tag == "Enemy")
        {
            Vector3 collNormal = hit.contacts[0].normal;
            hit.gameObject.tag = "Untagged";
            StartCoroutine(LaunchCoroutine(hit.gameObject, collNormal));
            StartCoroutine(DestroyCoroutine(hit.gameObject));
        }
    }


    IEnumerator LaunchCoroutine(GameObject hit, Vector3 normal)
    {
        normal = -normal * forceMultiplier;
        normal.y = launchValue;
        yield return new WaitForSeconds(0.05f);
        body = hit.GetComponent<Rigidbody>();
        body.AddForce(normal, ForceMode.Impulse);
    }

    IEnumerator DestroyCoroutine(GameObject hit)
    {
        yield return new WaitForSeconds(5); 
        GameObject breakDust = Instantiate(ps.gameObject, hit.transform.position, hit.transform.rotation);
        Destroy(breakDust, 0.5f);
        Destroy(hit);
    }

}
