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
        print(inHitRange);
        float dx = playerSpeed * Input.GetAxis ("Horizontal") * Time.fixedDeltaTime;
        float dy = playerSpeed * Input.GetAxis ("Vertical") * Time.fixedDeltaTime;
        rb.velocity = new Vector2(dx, dy);
        if (Input.GetKey(KeyCode.Space) && inHitRange.Count != 0)
        {
            Collider2D closest = inHitRange[0];
            foreach (var t in inHitRange)
            {
                if (Vector2.Distance(transform.position,t.transform.position) < Vector2.Distance(transform.position, closest.transform.position))
                {
                    closest = t;
                }
            }
            closest.gameObject.GetComponent<Wall>().Hide();
        }
    }

}   
