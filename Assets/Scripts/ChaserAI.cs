using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaserAI : MonoBehaviour
{
    private HealthBar bullHealth;

    public GameObject bull;

    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Bull");
        bull = gos[0];
        agent = gameObject.GetComponent<NavMeshAgent>();
        StartCoroutine(TimeKiller());
    }

    // Update is called once per frame
    void Update()
    {
       agent.SetDestination(bull.transform.position); 
    }

    void OnCollisionEnter (Collision hit)
    {
        if (hit.gameObject.tag == "Bull")
        {
            bullHealth = hit.gameObject.GetComponent<HealthBar>();
            bullHealth.health -= 10; 
            Destroy(gameObject.GetComponent<NavMeshAgent>());
            Destroy(gameObject.GetComponent<ChaserAI>());
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    IEnumerator TimeKiller()
    {
        yield return new WaitForSeconds(100);
        Destroy(gameObject);
    }
}
