using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public bool drilling;
    public hide(bool hide){
        this.SetActive(hide); 
    }

    void OnCollisionEnter(Collision collision){
        this.SetActive(drilling);
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
