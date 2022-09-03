using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        Mesh mesh = new Mesh();
        
        Vector3[] points = new Vector3[6]; 
        Vector2[] texture = new Vector2[6]; 
        int[] path = new int[6];

        for (int i=0; i<texture.Length; i++){
            texture[i] = new Vector2(0,0);
        }

        foreach (int i in path){
            path[i] = i;
        }
        float radians = 0.0f;
        int j = 0;
        foreach (Vector3 p in points){
            radians+=(2*Mathf.PI)/points.Length;
            points[j] = new Vector3(50*Mathf.Cos(radians),50*Mathf.Sin(radians));
            j++; 
        }

        mesh.vertices = points;
        mesh.uv = texture;
        mesh.triangles = path;

        gameObject.GetComponent<MeshFilter>().mesh = mesh;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
