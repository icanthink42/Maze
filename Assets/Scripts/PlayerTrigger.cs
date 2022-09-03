using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public GameObject player;
    PlayerMovement pm;
    void OnTriggerEnter2D(Collider2D other){
        if (!other.transform.CompareTag("breakable"))
        {
            return;
        }
        pm.inHitRange.Add(other);
    }

    void OnTriggerExit2D(Collider2D other){
        pm.inHitRange.Remove(other);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        pm = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
