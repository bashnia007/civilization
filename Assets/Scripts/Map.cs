using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Map : MonoBehaviour
{
    [Header("Art stuff")]
    [SerializeField] private Material material;

    private Camera currentCamera;
    private GameObject hoveredMapTile;
    void Start()
    {
        GenerateNumidia();
        GenerateCarthago();
        GenerateWestMavritania();
        GenerateLivia();
        GenerateEastMavritania();
        GenerateNorthKirenaika();
        GenerateSouthKirenaika();
        GenerateLowerEgypt();
        GenerateUpperEgypt();
    }


    private void GenerateNumidia()
    {
        GameObject tile = new GameObject();
        tile.transform.parent = transform;
        tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
        tile.transform.eulerAngles = new Vector3(-90, 0, 180);
        Mesh mesh = new Mesh();
        tile.AddComponent<MeshFilter>().mesh = mesh;
        tile.AddComponent<MeshRenderer>().material = material;

        int y = 0;

        Vector3[] vertices = new Vector3[11];
        vertices[0] = new Vector3(0, y, 0);
        vertices[1] = new Vector3(0, y, 16);
        vertices[2] = new Vector3(0.5f, y, 16.2f);
        vertices[3] = new Vector3(1f, y, 16);
        vertices[4] = new Vector3(2.2f, y, 16.1f);
        vertices[5] = new Vector3(2.3f, y, 15);
        vertices[6] = new Vector3(2f, y, 13.1f);
        vertices[7] = new Vector3(2.8f, y, 9);
        vertices[8] = new Vector3(3.4f, y, 7);
        vertices[9] = new Vector3(3.4f, y, 3.4f);
        vertices[10] = new Vector3(2.8f, y, 0);

        int[] tris = new int[] { 0,1,2,  0,2,3,  0,3,4,  0,4,5,  0,6,7,  0,7,8,  0,8,9,  0,9,10};

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "Numidia";
    }

    private void GenerateCarthago()
    {
        GameObject tile = new GameObject();
        tile.transform.parent = transform;
        tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
        tile.transform.eulerAngles = new Vector3(-90, 0, 180);
        Mesh mesh = new Mesh();
        tile.AddComponent<MeshFilter>().mesh = mesh;
        tile.AddComponent<MeshRenderer>().material = material;

        int y = 0;

        Vector3[] vertices = new Vector3[12];
        vertices[0] = new Vector3(2.2f, y, 16.2f);
        vertices[1] = new Vector3(1.7f, y, 14);
        vertices[2] = new Vector3(3.5f, y, 6.5f);
        vertices[3] = new Vector3(5.5f, y, 6.5f);
        vertices[4] = new Vector3(6.5f, y, 6f);
        vertices[5] = new Vector3(9.5f, y, 5.5f);
        vertices[6] = new Vector3(10.8f, y, 9.2f);
        vertices[7] = new Vector3(7.3f, y, 10.5f);
        vertices[8] = new Vector3(7f, y, 11.5f);
        vertices[9] = new Vector3(8.5f, y, 12.5f);
        vertices[10] = new Vector3(7.3f, y, 15f);
        vertices[11] = new Vector3(8.2f, y, 16.5f);

        //int[] tris = new int[] { 0,1,3,  1,2,3,  1,2,3,  3,4,6, 4,5,6,  3,6,7,  3,7,8,  8,9,10,  1,10,11,  0,3,8,  0,8,10};
        int[] tris = new int[] { 3,1,0,  3,2,1,  3,2,1,  6,4,3,  6,5,4,  7,6,3,  8,7,3,  10,9,8,  11,10,0,  8,3,0,  10,8,0};

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "Carthago";
    }

    private void GenerateWestMavritania()
    {
        GameObject tile = new GameObject();
        tile.transform.parent = transform;
        tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
        tile.transform.eulerAngles = new Vector3(-90, 0, 180);
        Mesh mesh = new Mesh();
        tile.AddComponent<MeshFilter>().mesh = mesh;
        tile.AddComponent<MeshRenderer>().material = material;

        int y = 0;

        Vector3[] vertices = new Vector3[10];
        vertices[0] = new Vector3(14.5f, y, 0f);
        vertices[1] = new Vector3(2.9f, y, 0);
        vertices[2] = new Vector3(3.5f, y, 2);
        vertices[3] = new Vector3(3.7f, y, 3.5f);
        vertices[4] = new Vector3(3.5f, y, 5.5f);
        vertices[5] = new Vector3(3.5f, y, 6.5f);
        vertices[6] = new Vector3(5.5f, y, 6.5f);
        vertices[7] = new Vector3(7.7f, y, 5.5f);
        vertices[8] = new Vector3(10.8f, y, 5f);
        vertices[9] = new Vector3(14.7f, y, 4f);

        int[] tris = new int[] { 0,1,2,  0,2,3,  0,3,4,  0,4,5,  0,5,6,  0,6,7,  0,7,8,  0,8,9 };

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "West Mavritania";
    }

    private void GenerateLivia()
    {
        GameObject tile = new GameObject();
        tile.transform.parent = transform;
        tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
        tile.transform.eulerAngles = new Vector3(-90, 0, 180);
        Mesh mesh = new Mesh();
        tile.AddComponent<MeshFilter>().mesh = mesh;
        tile.AddComponent<MeshRenderer>().material = material;

        int y = 0;

        Vector3[] vertices = new Vector3[11];
        vertices[0] = new Vector3(9.5f, y, 5.5f);
        vertices[1] = new Vector3(10.8f, y, 9.2f);
        vertices[2] = new Vector3(15.5f, y, 8.5f);
        vertices[3] = new Vector3(16f, y, 7.3f);
        vertices[4] = new Vector3(19.8f, y, 7f);
        vertices[5] = new Vector3(20f, y, 6.7f);
        vertices[6] = new Vector3(22f, y, 6f);
        vertices[7] = new Vector3(22.2f, y, 5.7f);
        vertices[8] = new Vector3(22.2f, y, 2.5f);
        vertices[9] = new Vector3(17f, y, 4f);
        vertices[10] = new Vector3(15f, y, 4f);

        int[] tris = new int[] { 0,1,2,  0,2,10,  10,2,3,  10,3,9,  9,3,4,  9,4,5,  9,5,6,  9,6,7,  9,7,8};

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "Livia";
    }

    private void GenerateEastMavritania()
    {
        GameObject tile = new GameObject();
        tile.transform.parent = transform;
        tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
        tile.transform.eulerAngles = new Vector3(-90, 0, 180);
        Mesh mesh = new Mesh();
        tile.AddComponent<MeshFilter>().mesh = mesh;
        tile.AddComponent<MeshRenderer>().material = material;

        int y = 0;

        Vector3[] vertices = new Vector3[12];
        vertices[0] = new Vector3(14.8f, y, 2f);
        vertices[1] = new Vector3(14.6f, y, 4f);
        vertices[2] = new Vector3(17f, y, 4f);
        vertices[3] = new Vector3(22.5f, y, 2.6f);
        vertices[4] = new Vector3(14.5f, y, 0f);
        vertices[5] = new Vector3(31.4f, y, 0f);
        vertices[6] = new Vector3(31.1f, y, 2f);
        vertices[7] = new Vector3(29.6f, y, 3f);
        vertices[8] = new Vector3(29.5f, y, 4f);
        vertices[9] = new Vector3(29.1f, y, 4.8f);
        vertices[10] = new Vector3(23.5f, y, 2.8f);
        vertices[11] = new Vector3(26f, y, 4.2f);

        int[] tris = new int[] {0,1,2,  0,2,3,  4,0,3,  4,3,5,  3,6,5,  3,7,6,  3,8,7,  10,9,8,  10,11,9};

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "East Mawritania";
    }
    private void GenerateNorthKirenaika()
    {
        GameObject tile = new GameObject();
        tile.transform.parent = transform;
        tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
        tile.transform.eulerAngles = new Vector3(-90, 0, 180);
        Mesh mesh = new Mesh();
        tile.AddComponent<MeshFilter>().mesh = mesh;
        tile.AddComponent<MeshRenderer>().material = material;

        int y = 0;

        Vector3[] vertices = new Vector3[32];
        vertices[0] = new Vector3(22f, y, 2.7f);
        vertices[1] = new Vector3(22.3f, y, 4.4f);
        vertices[2] = new Vector3(22.2f, y, 5.9f);
        vertices[3] = new Vector3(23f, y, 6.2f);
        vertices[4] = new Vector3(23.6f, y, 7.2f);
        vertices[5] = new Vector3(23.5f, y, 10f);
        vertices[6] = new Vector3(24.7f, y, 11.4f);
        vertices[7] = new Vector3(26.2f, y, 11.8f);
        vertices[8] = new Vector3(27.5f, y, 11.7f);
        vertices[9] = new Vector3(27.6f, y, 11.5f);
        vertices[10] = new Vector3(28.8f, y, 11.1f);
        vertices[11] = new Vector3(30.5f, y, 11.4f);       
        vertices[12] = new Vector3(32f, y, 11f);
        vertices[13] = new Vector3(33.2f, y, 11.4f);
        vertices[14] = new Vector3(33.3f, y, 11.3f);
        vertices[15] = new Vector3(34.2f, y, 11.6f);
        vertices[16] = new Vector3(35.3f, y, 11.5f);
        vertices[17] = new Vector3(35.9f, y, 11.6f);
        vertices[18] = new Vector3(36.3f, y, 11f);
        vertices[19] = new Vector3(36.6f, y, 9.2f);
        vertices[20] = new Vector3(36.3f, y, 8.2f);

        vertices[25] = new Vector3(36.8f, y, 6.8f);
        vertices[26] = new Vector3(35.8f, y, 6.4f);
        vertices[27] = new Vector3(33.2f, y, 6.3f);
        vertices[28] = new Vector3(30.7f, y, 5.8f);
        vertices[29] = new Vector3(29.2f, y, 4.9f);
        vertices[30] = new Vector3(26f, y, 4.4f);
        vertices[31] = new Vector3(23f, y, 2.5f);



        int[] tris = new int[] {0,1,31,  1,2,31,  2,3,31,  3,4,31, 31,4,30,  4,5,30, 5,6,30,  6,7,30,  7,8,30, 8,9,30,  9,10,30,
                                29,30,10,  10,11,29,  28,29,11,  11,12,28,  27,28,12,  12,13,27,  13,14,27,  14,15,27,  26,27,15,
                                15,16,26,  16,17,26,  17,18,26, 18,19,26,  25,26,20};

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "North Kirenaika";
    }

    private void GenerateSouthKirenaika()
    {
        GameObject tile = new GameObject();
        tile.transform.parent = transform;
        tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
        tile.transform.eulerAngles = new Vector3(-90, 0, 180);
        Mesh mesh = new Mesh();
        tile.AddComponent<MeshFilter>().mesh = mesh;
        tile.AddComponent<MeshRenderer>().material = material;

        int y = 0;

        Vector3[] vertices = new Vector3[20];
        vertices[0] = new Vector3(31.4f, y, 0f);
        vertices[1] = new Vector3(31.2f, y, 2f);
        vertices[2] = new Vector3(30.6f, y, 2.5f);
        vertices[3] = new Vector3(29.7f, y, 3f);
        vertices[4] = new Vector3(29.5f, y, 4f);
        vertices[5] = new Vector3(29.3f, y, 4.8f);
        vertices[6] = new Vector3(29.7f, y, 5f);
        vertices[7] = new Vector3(30.7f, y, 5.6f);
        vertices[8] = new Vector3(33.4f, y, 6.3f);
        vertices[9] = new Vector3(35.7f, y, 6.3f);
        vertices[10] = new Vector3(36.7f, y, 6.8f);
        vertices[11] = new Vector3(38.7f, y, 5.4f);
        vertices[12] = new Vector3(40.3f, y, 5.3f);

        vertices[16] = new Vector3(39.3f, y, 3.8f);
        vertices[17] = new Vector3(39.1f, y, 2.7f);
        vertices[18] = new Vector3(39.4f, y, 2f);
        vertices[19] = new Vector3(38.5f, y, 0f);

        int[] tris = new int[] {0,1,19,  1,18,19,  1,17,18,  1,2,17,  2,16,17,  2,3,16,  3,4,16,  4,5,16,  5,6,16,  6,7,16,  7,8,16,  8,9,16,
                                9,10,16,  10,11,16,  11,12,16};

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "South Kirenaika";
    }
    private void GenerateLowerEgypt()
    {
        GameObject tile = new GameObject();
        tile.transform.parent = transform;
        tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
        tile.transform.eulerAngles = new Vector3(-90, 0, 180);
        Mesh mesh = new Mesh();
        tile.AddComponent<MeshFilter>().mesh = mesh;
        tile.AddComponent<MeshRenderer>().material = material;

        int y = 0;

        Vector3[] vertices = new Vector3[21];
        vertices[0] = new Vector3(40.3f, y, 5.3f);
        vertices[1] = new Vector3(38.7f, y, 5.4f);
        vertices[2] = new Vector3(36.8f, y, 6.8f);
        vertices[3] = new Vector3(36.3f, y, 8.2f);
        vertices[4] = new Vector3(36.6f, y, 9.2f);
        vertices[5] = new Vector3(36.3f, y, 11f);
        vertices[6] = new Vector3(35.9f, y, 11.6f);
        vertices[7] = new Vector3(37.9f, y, 11.4f);
        vertices[8] = new Vector3(38.2f, y, 11.5f);
        vertices[9] = new Vector3(40f, y, 13.3f);
        vertices[10] = new Vector3(40.5f, y, 13.5f);
        vertices[11] = new Vector3(41f, y, 13.9f);
        vertices[12] = new Vector3(43.1f, y, 14.2f);
        vertices[13] = new Vector3(43.3f, y, 12.2f);
        vertices[14] = new Vector3(44f, y, 11.5f);
        vertices[15] = new Vector3(44.8f, y, 10.2f);
        vertices[16] = new Vector3(44.8f, y, 10f);
        vertices[17] = new Vector3(46f, y, 9.5f);
        vertices[18] = new Vector3(46.8f, y, 8.8f);
        vertices[19] = new Vector3(47.1f, y, 8f);
        vertices[20] = new Vector3(48.5f, y, 6.4f);

        int[] tris = new int[] {0,1,2,  0,2,3,  0,3,4,  0,4,5,   5,6,7,  5,7,0,  7,8,0,  8,9,0,  9,10,0,  10,11,0,  11,12,0,  12,13,0,  13,14,0,
                                14,15,0,  15,16,0,  16,17,0,  17,18,0,  18,19,0,  19,20,0};

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "Lower Egypt";
    }

    private void GenerateUpperEgypt()
    {
        GameObject tile = new GameObject();
        tile.transform.parent = transform;
        tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
        tile.transform.eulerAngles = new Vector3(-90, 0, 180);
        Mesh mesh = new Mesh();
        tile.AddComponent<MeshFilter>().mesh = mesh;
        tile.AddComponent<MeshRenderer>().material = material;

        int y = 0;

        Vector3[] vertices = new Vector3[20];
        vertices[0] = new Vector3(57f, y, 0f);
        vertices[1] = new Vector3(38.5f, y, 0f);
        vertices[2] = new Vector3(39.4f, y, 2f);
        vertices[3] = new Vector3(39.1f, y, 2.7f);
        vertices[4] = new Vector3(39.3f, y, 3.8f);
        vertices[5] = new Vector3(40.3f, y, 5.3f);
        vertices[6] = new Vector3(41.5f, y, 5.3f);
        vertices[7] = new Vector3(48.5f, y, 6.4f);
        vertices[8] = new Vector3(52.8f, y, 3.8f);
        vertices[9] = new Vector3(53f, y, 3.1f);
        vertices[10] = new Vector3(54f, y, 2.2f);
        vertices[11] = new Vector3(55.5f, y, 1.2f);

        int[] tris = new int[] { 0,1,2,  0,2,3,  0,3,4,  0,4,5,  5,6,0,  0,6,11,  6,7,8,  6,8,9,  6,9,10,  6,10,11};

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "Upper Egypt";
    }

    private void Update()
    {
        if (!currentCamera)
        {
            currentCamera = Camera.main;
            return;
        }

        RaycastHit info;
        Ray ray = currentCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out info, 100, LayerMask.GetMask("MapTile", "Hover")))
        {
            GameObject hited = info.transform.gameObject;
            //GameObject mapTile = mapTiles.FirstOrDefault(m => m.name == hited.name);

            if (hoveredMapTile == null)
            {
                hited.layer = LayerMask.NameToLayer("Hover");
                hoveredMapTile = hited;

            }
        }
        else
        {
            if (hoveredMapTile != null)
            {
                hoveredMapTile.layer = LayerMask.NameToLayer("MapTile");
                hoveredMapTile = null;
            }
        }
    }
}
