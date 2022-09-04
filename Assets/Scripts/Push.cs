    using System;
    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{
    private Vector3 target;
    private bool touchingPlayer;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        target = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float dist = Vector3.Distance(transform.position, target);
        
        if (dist > 0.03 && dist < 0.5 && rb.velocity.magnitude > 0 && !touchingPlayer)
        {
            transform.position = Vector3.Lerp(transform.position, target, 0.8f);
        }
        else if (dist < 0.03)
        {
            transform.position = target;
        }

        if (!touchingPlayer)
        {
            rb.velocity = Vector2.zero;
        }
    }


    private void OnCollisionExit2D(Collision2D other)
    {
        target = new Vector2((int)Math.Round(transform.position.x), (int)Math.Round(transform.position.y));
        if (other.transform.CompareTag("player"))
        {
            touchingPlayer = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("player"))
        {
            touchingPlayer = true;
        }
    }
}
