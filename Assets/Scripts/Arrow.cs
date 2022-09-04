using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float angle = Mathf.Atan2(player.position.y - target.position.y, player.position.x - target.position.x);
        transform.rotation = Quaternion.Euler(0, 0, angle*180/Mathf.PI - 180);
    }
}
