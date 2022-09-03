using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleTrigger : MonoBehaviour
{
    public GameObject hole;
    void OnTriggerEnter2D (Collider2D other){
        if (other.transform.CompareTag("pushable")){
            other.gameObject.GetComponent<Renderer>().enabled = false;
            Destroy(other);
            hole.GetComponent<Renderer>().enabled = false;
            Destroy(hole);
        }
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
