using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public bool drilling;
    public void Hide(){
        gameObject.SetActive(false);
    }

    void OnCollisionEnter(Collision collision){
        gameObject.SetActive(drilling);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.SetActive(false);
    }
}
