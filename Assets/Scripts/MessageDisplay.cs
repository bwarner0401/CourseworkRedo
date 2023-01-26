using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageDisplay : MonoBehaviour
{
    public string text;
    public float time;

    private bool display = false;

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
        if (hit.gameObject.tag == "Bull")
        {
            StartCoroutine(ActivateDisplay());
        }
    }

    void OnGUI()
    {
        if(display)
        {
            GUI.Label(new Rect((Screen.width/2)-150, (Screen.height/2)-75, 300, 150), text);
        }      
    }

    IEnumerator ActivateDisplay()
    {
        Collider thisCollider = gameObject.GetComponent<Collider>();
        display = true;
        thisCollider.enabled = false;
        yield return new WaitForSeconds(time);
        display = false;
        thisCollider.enabled = true;
    }
}
