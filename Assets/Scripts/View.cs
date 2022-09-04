using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class View : MonoBehaviour
{
    private static int rays = 60;

    private int ray_inc;

    private float vision_range = 4;

    private Mesh mesh;

    public Vector3[] vertices;

    public List<int> tris = new List<int>();

    private LayerMask mask;

    [SerializeField] private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        ray_inc = 360 / rays;
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        mask = LayerMask.GetMask("Wall");
        vertices = new Vector3[rays + 1];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        tris = new List<int>();
        vertices[0] = player.transform.position;
        float angle = 0;
        for (int i = 1; i < rays; i++)
        {
            float r_angle = angle * Mathf.Deg2Rad;
            Vector3 vector = new Vector3(Mathf.Cos(r_angle), Mathf.Sin(r_angle));
            RaycastHit2D r = Physics2D.Raycast(vertices[0], vector, vision_range, mask);
            tris.Add(0);
            tris.Add(i);
            tris.Add(i + 1);
            if (r.collider == null)
            {
                vertices[i] = vision_range * vector + vertices[0];
            }
            else
            {
                vertices[i] = r.point;
            }
            angle += ray_inc;
        }

        tris.RemoveAt(tris.Count - 1);
        tris.Add(tris[1]);

        mesh.vertices = vertices;
        mesh.triangles = tris.ToArray();
    }
}
