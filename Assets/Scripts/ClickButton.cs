using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickButton : MonoBehaviour
{
    public string scene;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnMouseDown(){
        SceneManager.LoadScene(scene); 
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
