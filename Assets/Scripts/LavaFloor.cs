using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;
using UnityEngine;

public class LavaFloor : MonoBehaviour
{
    bool on = false;
    float switchTime = 3.0f;
    float timeSinceSwitch = 0.0f;
    bool touchingPlayer=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D (Collider2D thing){
        if (thing.transform.CompareTag("player")){
            touchingPlayer=true;
        }
    }
    void OnTriggerExit2D (Collider2D thing){
        if (thing.transform.CompareTag("player")){
            touchingPlayer=false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (on == true&&touchingPlayer){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (timeSinceSwitch + switchTime < Time.time){
            on = !on;
            timeSinceSwitch = Time.time;
            print("Switched");
        }
    }
}
