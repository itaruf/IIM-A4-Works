using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleGenerator : MonoBehaviour
{
    public float radius = 1;
    public int count = 9;
    public MeshFilter meshFilter;
    public Mesh mesh;
    void Start()
    {
        //Vector3[] vertices = new Vector3[count];
        //vertices[0] = new Vector3(0, 0, 0); // vertex en son centre
        //int[] triangles = new int[count * 3];

        List<Vector3> vertices = new List<Vector3>();
        vertices.Add(new Vector3(0, 0, 0)); // vertex en son centre

        List<int> triangles = new List<int>();

        /*x = cos(i * 2 * PI / count) * radius
          y = 0
          z = sin(i * 2 * PI / count) * radius
        */

        for (int i = 0; i < count + 1; i++) 
        {
            vertices.Add(new Vector3(Mathf.Cos(i * 2 * Mathf.PI / count) * radius, 0, Mathf.Sin(i * 2 * Mathf.PI / count) * radius));
        }

        for (int i = 0; i < count; i++)
        {
            /*triangles.Add(0);
            triangles.Add(i + 1);
            triangles.Add(i + 2);*/

            triangles.Add(0);
            triangles.Add(i + 2);
            triangles.Add(i + 1);
        }

        meshFilter = GetComponent<MeshFilter>();
        mesh = new Mesh();

        mesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;

        /*mesh.vertices = vertices;
        mesh.triangles = triangles;*/

        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();

        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
        mesh.RecalculateTangents();

        meshFilter.mesh = mesh;
    }
}
