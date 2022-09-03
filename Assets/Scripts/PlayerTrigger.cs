using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public List<Collider2D> inHitRange = new List<Collider2D>();
    void OnTriggerEnter2D(Collider2D other){
        if (other.transform.tag == "breakable")
            return;
        inHitRange.Add(other);
    }

    void OnTriggerExit2D(Collider2D other){
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
