using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    float speed;



    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(FlockManager.FM.minSpeed, FlockManager.FM.maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0, 10000) < 5)
        {
            speed = Random.Range(FlockManager.FM.minSpeed, FlockManager.FM.maxSpeed);
        }
        
        if (Random.Range(0, 100) < 30)
        {
            ApplyRules();
        }
        this.transform.Translate(0, 0, speed * Time.deltaTime);

        if(this.transform.position.y < 0.45f)
        {
            this.transform.position = this.transform.position + new Vector3(0,0.3f,0);
        }
    }

    void ApplyRules()
    {
        GameObject[] gos;
        gos = FlockManager.FM.allPeople;

        Vector3 vcenter = Vector3.zero;
        Vector3 vavoid = Vector3.zero;
        float gSpeed = 0.01f;
        float nDistance;
        int groupSize = 0;

        foreach(GameObject go in gos)
        {
            if(go != this.gameObject)
            {
                nDistance = Vector3.Distance(go.transform.position, this.transform.position);
                if(nDistance <= FlockManager.FM.neighbourDistance)
                {
                    vcenter += go.transform.position;
                    groupSize++;

                    if  (nDistance < 1.0f)
                    {
                        vavoid = vavoid + (this.transform.position - go.transform.position);
                    }

                    Flock anotherFlock = go.GetComponent<Flock>();
                    gSpeed = gSpeed + anotherFlock.speed;
                }
            }
        }

        if (groupSize > 0)
        {
            vcenter = vcenter / groupSize + (FlockManager.FM.goalPos - this.transform.position);
            speed = gSpeed / groupSize;
            if(speed  > FlockManager.FM.maxSpeed)
            {
                speed = FlockManager.FM.maxSpeed;
            }
            Vector3 direction = (vcenter + vavoid) - transform.position;
            if(direction != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), FlockManager.FM.rotationSpeed * Time.deltaTime);
            }
        }
    }
}
