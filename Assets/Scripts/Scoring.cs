using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoring : MonoBehaviour
{
    public float score;

    public float keys;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI keyText;

    public ParticleSystem ps;

    private Rigidbody body;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score.ToString("F2");
        keyText.text = "Keys: " + keys.ToString();
    }

    void OnCollisionEnter (Collision hit)
    {
        if (hit.gameObject.tag == "Rammable")
        {
            body = hit.gameObject.GetComponent<Rigidbody>();
            float mass = body.mass;
            score += mass;
            body.mass = mass/2;
            if (body.mass < 0.5)
            {
                GameObject breakDust = Instantiate(ps.gameObject, hit.gameObject.transform.position, hit.gameObject.transform.rotation);
                Destroy(breakDust, 0.5f);
                Destroy(hit.gameObject);
            }
        }
        
        if (hit.gameObject.tag == "Key")
        {
            keys += 1;
            Destroy(hit.gameObject);
        }

        if (hit.gameObject.tag == "Person")
        {
            score += 50;
            hit.gameObject.tag = "Untagged";
            body = hit.gameObject.GetComponent<Rigidbody>();
            body.AddForce(hit.gameObject.transform.up * 30, ForceMode.Impulse);
            StartCoroutine(DestroyCoroutine(hit.gameObject));
        }
    }

    IEnumerator DestroyCoroutine(GameObject hit)
    {
        yield return new WaitForSeconds(5); 
        GameObject breakDust = Instantiate(ps.gameObject, hit.transform.position, hit.transform.rotation);
        Destroy(breakDust, 0.5f);
        Destroy(hit.GetComponent<Collider>());
        Destroy(hit.GetComponent<MeshRenderer>());
    }
}
