using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public List<Collider2D> inHitRange;
    private Rigidbody2D rb;
    [SerializeField] float playerSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        Physics.gravity = Vector3.zero;
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        float x = playerSpeed * Input.GetAxis ("Horizontal") * Time.fixedDeltaTime;
        float y = playerSpeed * Input.GetAxis ("Vertical") * Time.fixedDeltaTime;
        rb.velocity = new Vector2(x, y);
        if (Input.GetKey("jump")){
            
        }
    }

}
