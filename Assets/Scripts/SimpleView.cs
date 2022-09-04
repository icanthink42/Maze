using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleView : MonoBehaviour
{
    [SerializeField] private Transform player;
    
    private float vision_range = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>() ;
        foreach (var obj in allObjects)
        {
            if (obj.transform.CompareTag("player"))
            {
                continue;
            }
            SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
            if (sr == null)
            {
                continue;
            }
            if (Vector2.Distance(obj.transform.position, player.position) < vision_range)
            {
                sr.enabled = true;
            }
            else
            {
                sr.enabled = false;
            }
        }
    }
}
