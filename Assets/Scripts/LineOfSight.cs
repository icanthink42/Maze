using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    public float radius;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Mesh mesh = new Mesh();
        int vertices = 100;
        float fov = 360.0f;
        Vector3[] points = new Vector3[vertices+1]; 
        Vector2[] texture = new Vector2[vertices+1];
        int[] path = new int[(vertices-1)*3];


        // generate each point on the circle using Sin and Cos
        float radians = 0.0f;
        points[0] = new Vector3(0,0);
        for (int j = 0; j<vertices; j++){
            radians = j * (Mathf.PI*fov/180.0f) / (float)(vertices-1);
            Vector3 ray = new Vector3(radius * Mathf.Cos(radians), radius * Mathf.Sin(radians));
            RaycastHit2D checkHit = Physics2D.Raycast(ray, new Vector3(Mathf.Cos(radians), Mathf.Sin(radians)), radius);
            if (checkHit.collider == null){
                points[j+1] = ray;
            } else {
                points[j+1] = checkHit.point;
            }
            
        }

        // renders in triangles (draws everything from points[0])
        int i,triIndex;
        for (i=1, triIndex=0; triIndex+2<path.Length; i++, triIndex+=3){
            path[triIndex] = 0;
            path[triIndex+1] = i;
            path[triIndex+2] = i+1;
        }

        mesh.vertices = points;
        mesh.uv = texture;
        mesh.triangles = path;

        GetComponent<MeshFilter>().mesh = mesh;
    }
}
