using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Plant : MonoBehaviour
{
    [SerializeField] private GameObject text;
    public string nextLevel;
    void OnTriggerEnter2D(Collider2D other){
        if (other.transform.CompareTag("player")){
            text.GetComponent<TextAnimation>().ShowErrorText("Level Complete!");
            SceneManager.LoadScene(nextLevel); 
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
