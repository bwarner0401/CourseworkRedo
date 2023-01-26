using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InHoleAction : MonoBehaviour
{
    public bool inHole = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(inHole)
        {
            this.gameObject.SetActive(false);
        }
    }
}
