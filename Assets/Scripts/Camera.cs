using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject player;

    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 target = new Vector3(0, 0, -10) + player.transform.position;
        transform.position = Vector3.Lerp(transform.position, target, speed * Time.deltaTime);
    }
}
