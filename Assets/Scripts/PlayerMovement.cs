using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class PlayerMovement : MonoBehaviour
{
    Animator animator;
    public List<Collider2D> inHitRange;
    private Rigidbody2D rb;
    [SerializeField] int drills;
    [SerializeField] float playerSpeed;
    [SerializeField] private GameObject text;
    [SerializeField] private GameObject fade;
    private AudioSource audio;
    // [SerializeField] private LineOfSight los;
    private float lastMine;

    private float lastTeleport;

    [SerializeField] private AudioClip push;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>(); 
        rb = gameObject.GetComponent<Rigidbody2D>();
        Physics.gravity = Vector3.zero;
        lastMine = Time.time;
        lastTeleport = Time.time;
        audio = new AudioSource();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        // los.points[0] = transform.position;
        float dx = playerSpeed * Input.GetAxis ("Horizontal") * Time.fixedDeltaTime;
        float dy = playerSpeed * Input.GetAxis ("Vertical") * Time.fixedDeltaTime;


        //animation
        if (dx>0){
            animator.SetBool("MovingRight", true);
        } else {
            animator.SetBool("MovingRight", false);
        }
        if (dx<0){
            animator.SetBool("MovingLeft", true);
        } else {
            animator.SetBool("MovingLeft", false);
        }
        if (dy>0){
            animator.SetBool("MovingUp", true);
        } else {
            animator.SetBool("MovingUp", false);
        }
        if (dy<0){
            animator.SetBool("MovingDown", true);
        } else {
            animator.SetBool("MovingDown", false);
        }


        rb.velocity = new Vector2(dx, dy);
        if (Input.GetKey(KeyCode.Space) && inHitRange.Count != 0 && Time.time > lastMine + 0.5)
        {
            lastMine = Time.time;
            if (drills > 0)
            {
                Collider2D closest = inHitRange[0];
                foreach (Collider2D t in inHitRange)
                {
                    if (Vector2.Distance(transform.position,t.transform.position) < Vector2.Distance(transform.position, closest.transform.position))
                    {
                        closest = t;
                    }
                }
                closest.gameObject.SetActive(false);

                // remove collision (could just remove collision attrubute
                // but I don't think the object should be continued to render when its destroyed)
                drills--;
            }
            else
            {
                text.GetComponent<TextAnimation>().ShowErrorText("Out of Drills!");
            }
        }

        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (lastTeleport + 0.2 < Time.time)
        {
            HoleTpManager hm = col.gameObject.GetComponent<HoleTpManager>();
            if (hm != null)
            {
                transform.position = hm.endLocation.position;
                lastTeleport = Time.time;
            }
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("pushable"))
        {
            audio.clip = push;
            audio.Play();
        }
    }
}   
