using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] private GameObject text;
    void OnTriggerEnter2D(Collider2D other){
        if (other.transform.CompareTag("player")){
            text.GetComponent<TextAnimation>().ShowErrorText("Level Complete!");
            Application.LoadScene("TestingScene"); 
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
