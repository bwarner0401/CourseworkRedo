using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockManager : MonoBehaviour
{
    public static FlockManager FM;
    public GameObject personPrefab;
    public int numPeople = 20;
    public GameObject[] allPeople;
    public Vector3 areaLimit = new Vector3(45, 1, 45);
    public Vector3 goalPos = Vector3.zero;

    [Header("Flock Settings")]
    [Range(0.0f, 5.00f)]
    public float minSpeed;
    [Range(0.0f, 5.00f)]
    public float maxSpeed;

    [Range(1.0f, 80.00f)]
    public float neighbourDistance;
    [Range(1.0f, 5.00f)]
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        allPeople = new GameObject[numPeople];
        for (int i = 0; i < numPeople; i++)
        {
            Vector3 pos = this.transform.position + new Vector3(Random.Range(-areaLimit.x, areaLimit.x), 0, Random.Range(-areaLimit.z, areaLimit.z));
            allPeople[i] = Instantiate(personPrefab, pos, Quaternion.identity);
        }
        FM = this;
        goalPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Random.Range(0,10000) < 5)
        {
            goalPos = this.transform.position + new Vector3(Random.Range(-areaLimit.x, areaLimit.x), 0, Random.Range(-areaLimit.z, areaLimit.z));
        }
    }
}
