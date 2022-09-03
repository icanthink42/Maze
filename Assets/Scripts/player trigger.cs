using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playertrigger : MonoBehaviour
{
    private List<Collision> inHitRange = new List<Collision>();
    void OnCollisionEnter(Collision other){
        inHitRange.Add(other);
    }

    void OnCollisionExit(Collision other){
        inHitRange.Remove(other);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
