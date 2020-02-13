using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGen : MonoBehaviour
{
    [Range(0,1000)]
    public float size = 1f;
    [Range(0, 1000)]
    public int gridSize = 16;

    private MeshFilter filter;

    void Start()
    {
        filter = GetComponent<MeshFilter>();
        filter.mesh = GenerateMesh();
    }

    private Mesh GenerateMesh()
    {
        Mesh waterMesh = new Mesh();

        var vertecies = new List<Vector3>();
        var normals = new List<Vector3>();
        var UVs = new List<Vector2>();

        for (int x = 0; x < gridSize + 1; x++)
        {
            for (int y = 0; y < gridSize + 1; y++)
            {
                vertecies.Add(new Vector3(-size * 0.5f + size * (x / ((float)gridSize)), 0, -size * 0.5f + size * (y / ((float)gridSize))));
                normals.Add(Vector3.up);
                UVs.Add(new Vector2(x / (float)gridSize, y / (float)gridSize));
            }
        }

        var triangles = new List<int>();
        var vertCount = gridSize + 1;

        for (int i = 0; i < vertCount * vertCount - vertCount; i++)
        {
            if ((i + 1) % vertCount == 0)
            {
                continue;
            }
            triangles.AddRange(new List<int>()
            {
                i + 1 + vertCount,
                i + vertCount,
                i,
                i,
                i + 1,
                i + vertCount + 1
            });

        }
        waterMesh.SetVertices(vertecies);
        waterMesh.SetNormals(normals);
        waterMesh.SetUVs(0, UVs);
        waterMesh.SetTriangles(triangles, 0);
        return waterMesh;
    }
}
