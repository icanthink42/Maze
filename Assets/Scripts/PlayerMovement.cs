using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public List<Collider2D> inHitRange;
    private Rigidbody2D rb;
    [SerializeField] int drills;
    [SerializeField] float playerSpeed;
    [SerializeField] private GameObject text;
    private float lastMine;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        Physics.gravity = Vector3.zero;
        lastMine = Time.time;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float dx = playerSpeed * Input.GetAxis ("Horizontal") * Time.fixedDeltaTime;
        float dy = playerSpeed * Input.GetAxis ("Vertical") * Time.fixedDeltaTime;
        rb.velocity = new Vector2(dx, dy);
        if (Input.GetKey(KeyCode.Space) && inHitRange.Count != 0 && drills>0)
        {
            Collider2D closest = inHitRange[0];
            foreach (Collider2D t in inHitRange)
            {
                if (Vector2.Distance(transform.position,t.transform.position) < Vector2.Distance(transform.position, closest.transform.position))
                {
                    closest = t;
                }
            }
            closest.gameObject.GetComponent<Renderer>().enabled = false; //stops rendering the sprite

            // remove collision (could just remove collision attrubute
            // but I don't think the object should be continued to render when its destroyed)
            Destroy (closest); 
            drills--;
            
        }
    }

}   
