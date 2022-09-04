using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    public float radius;
    private Mesh mesh;
    private static int vertices = 100;
    private float fov = 360.0f;
    public Vector3[] points = new Vector3[vertices+1];
    private Vector2[] texture= new Vector2[vertices+1];
    private int[] path = new int[(vertices-1)*3];
    private Vector3 origin;
    [SerializeField] LayerMask layerMask;
    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        points[0] = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Vector3 x in points)
            print (x);
        // Debug.Log(points[0]);
        // generate each point on the circle using Sin and Cos
        float radians = 0.0f;
        for (int j = 0; j<vertices ; j++){
            radians = j * (Mathf.PI*fov/180.0f) / (float)(vertices-1);
            Vector3 ray = new Vector3(radius * Mathf.Cos(radians), radius * Mathf.Sin(radians));
            RaycastHit2D checkHit = Physics2D.Raycast(points[0], ray/radius, radius, layerMask);
            // Debug.Log(j);
            if (checkHit.collider == null){
                points[j+1] = points[0]+ray;
            } else {
                // Debug.Log(checkHit.point);
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
    }
}
