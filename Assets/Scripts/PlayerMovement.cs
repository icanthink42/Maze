using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private float playerSpeed = -1.0f;
    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = playerSpeed*Input.GetAxis ("Horizontal");
        float y = playerSpeed*Input.GetAxis ("Vertical");
        controller.Move(new Vector3(x,y,0));   
        // Debug.Log("x: "+x);
        // Debug.Log("y: "+y);
    }
}
