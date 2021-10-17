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
        GenerateSynay();
        GenerateIudea();
        GenerateAravia();
        GenerateBabilon();
        GenerateSiria();
        GenerateMesopotamia();
        GenerateSkifia();
        GenerateKilikia();
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

    private void GenerateSynay()
    {
        GameObject tile = new GameObject();
        tile.transform.parent = transform;
        tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
        tile.transform.eulerAngles = new Vector3(-90, 0, 180);
        Mesh mesh = new Mesh();
        tile.AddComponent<MeshFilter>().mesh = mesh;
        tile.AddComponent<MeshRenderer>().material = material;

        int y = 0;

        Vector3[] vertices = new Vector3[14];
        vertices[0] = new Vector3(43.1f, y, 14.2f);
        vertices[1] = new Vector3(43.7f, y, 14.6f);
        vertices[2] = new Vector3(43.3f, y, 13.2f);
        vertices[3] = new Vector3(44.2f, y, 14.6f);
        vertices[4] = new Vector3(43.3f, y, 12.3f);
        vertices[5] = new Vector3(44.8f, y, 15.2f);
        vertices[6] = new Vector3(47f, y, 13.5f);
        vertices[7] = new Vector3(47.5f, y, 12f);
        vertices[8] = new Vector3(44.5f, y, 11.5f);
        vertices[9] = new Vector3(44.7f, y, 10.8f);
        vertices[10] = new Vector3(45.9f, y, 10.3f);
        vertices[11] = new Vector3(46f, y, 10f);
        vertices[12] = new Vector3(47.8f, y, 10f);
        vertices[13] = new Vector3(47.5f, y, 9f);

        int[] tris = new int[] { 0,1,2,  2,1,3,  4,2,3, 4,3,5,  4,5,6,  4,6,7,  8,4,7,  9,8,7,  10,9,7,  11,10,7,  12,11,7,  13,11,12 };

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "Synay";
    }

    private void GenerateIudea()
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
        vertices[0] = new Vector3(44.7f, y, 15.2f);
        vertices[1] = new Vector3(44.5f, y, 20.5f);
        vertices[2] = new Vector3(46.1f, y, 21f);
        vertices[3] = new Vector3(47.9f, y, 21f);
        vertices[4] = new Vector3(48f, y, 19f);
        vertices[5] = new Vector3(48.2f, y, 18f);
        vertices[6] = new Vector3(48.5f, y, 17f);
        vertices[7] = new Vector3(49.2f, y, 16f);
        vertices[8] = new Vector3(50f, y, 15f);
        vertices[9] = new Vector3(47.2f, y, 13.8f);

        int[] tris = new int[] { 0,1,2,  0,2,3,  0,3,4,  0,4,5,  0,5,6,  0,6,7,  0,7,8,  0,8,9 };

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "Iudea";
    }

    private void GenerateAravia()
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
        vertices[0] = new Vector3(47.2f, y, 13.8f);
        vertices[1] = new Vector3(51f, y, 15.3f);
        vertices[2] = new Vector3(52.5f, y, 15.3f);
        vertices[3] = new Vector3(53.5f, y, 15f);
        vertices[4] = new Vector3(55.5f, y, 14.7f);
        vertices[5] = new Vector3(57.7f, y, 13.9f);
        vertices[6] = new Vector3(57.7f, y, 6f);
        vertices[7] = new Vector3(49f, y, 10.2f);
        vertices[8] = new Vector3(48f, y, 10.2f);

        int[] tris = new int[] { 0,1,2,  0,2,3,  0,3,4,  0,4,5,  0,5,6,  0,6,7,  0,7,8 };

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "Aravia";
    }

    private void GenerateBabilon()
    {

        GameObject tile = new GameObject();
        tile.transform.parent = transform;
        tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
        tile.transform.eulerAngles = new Vector3(-90, 0, 180);
        Mesh mesh = new Mesh();
        tile.AddComponent<MeshFilter>().mesh = mesh;
        tile.AddComponent<MeshRenderer>().material = material;

        int y = 0;

        Vector3[] vertices = new Vector3[18];
        vertices[0] = new Vector3(57.7f, y, 18.9f);
        vertices[1] = new Vector3(57.7f, y, 14f);
        vertices[2] = new Vector3(55.1f, y, 14.8f);
        vertices[3] = new Vector3(52.3f, y, 15.3f);
        vertices[4] = new Vector3(51f, y, 15.3f);
        vertices[5] = new Vector3(50f, y, 15f);
        vertices[6] = new Vector3(48.6f, y, 17f);
        vertices[7] = new Vector3(56.5f, y, 19.8f);
        vertices[8] = new Vector3(55.2f, y, 20.7f);
        vertices[9] = new Vector3(54.2f, y, 21f);
        vertices[10] = new Vector3(53.4f, y, 21.9f);
        vertices[11] = new Vector3(52.4f, y, 21.2f);
        vertices[12] = new Vector3(51.3f, y, 21f);
        vertices[13] = new Vector3(50.3f, y, 21.2f);
        vertices[14] = new Vector3(48.2f, y, 18f);
        vertices[15] = new Vector3(48f, y, 19f);
        vertices[16] = new Vector3(47.9f, y, 21f);
        vertices[17] = new Vector3(49.5f, y, 21.5f);

        int[] tris = new int[] { 0,1,2,  0,2,3,  0,3,4,  0,4,5,  0,5,6,  6,7,0,  6,8,7,  6,9,8,  6,10,9,  6,11,10,  6,12,11,  6,13,12,
                                 13,6,14,  13,14,15,  13,15,16,  13,16,17};

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "Babylon";
    }

    private void GenerateSiria()
    {
        GameObject tile = new GameObject();
        tile.transform.parent = transform;
        tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
        tile.transform.eulerAngles = new Vector3(-90, 0, 180);
        Mesh mesh = new Mesh();
        tile.AddComponent<MeshFilter>().mesh = mesh;
        tile.AddComponent<MeshRenderer>().material = material;

        int y = 0;

        Vector3[] vertices = new Vector3[22];
        vertices[0] = new Vector3(51.7f, y, 23.5f);
        vertices[1] = new Vector3(53.2f, y, 21.9f);
        vertices[2] = new Vector3(51.7f, y, 21.1f);
        vertices[3] = new Vector3(50.8f, y, 21.1f);
        vertices[4] = new Vector3(49.6f, y, 21.6f);
        vertices[5] = new Vector3(47.7f, y, 21f);
        vertices[6] = new Vector3(45.7f, y, 21f);
        vertices[7] = new Vector3(44.4f, y, 20.5f);
        vertices[8] = new Vector3(44.3f, y, 21f);
        vertices[9] = new Vector3(44.5f, y, 21.5f);
        vertices[10] = new Vector3(44.5f, y, 22f);
        vertices[11] = new Vector3(44.7f, y, 22.5f);
        vertices[12] = new Vector3(44f, y, 23.3f);
        vertices[13] = new Vector3(44.2f, y, 23.7f);
        vertices[14] = new Vector3(43.8f, y, 25.4f);
        vertices[15] = new Vector3(43.5f, y, 25.9f);
        vertices[16] = new Vector3(44.2f, y, 27.2f);
        vertices[17] = new Vector3(44.2f, y, 30f);
        vertices[18] = new Vector3(51.3f, y, 25.3f);
        vertices[19] = new Vector3(48f, y, 31.8f);
        vertices[20] = new Vector3(44.5f, y, 30.6f);
        vertices[21] = new Vector3(46.5f, y, 31.1f);

        int[] tris = new int[] { 0,1,2,  0,2,3,  0,3,4,  0,4,5,  0,5,6,  0,6,7,  0,7,8,  0,8,9,  0,9,10,  0,10,11,  0,11,12,  0,12,13,  0,13,14,
                                 0,14,15,  0,15,16,  0,16,17,  17,18,0,  17,19,18,  17,20,21 };

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "Siria";
    }

    private void GenerateMesopotamia()
    {
        GameObject tile = new GameObject();
        tile.transform.parent = transform;
        tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
        tile.transform.eulerAngles = new Vector3(-90, 0, 180);
        Mesh mesh = new Mesh();
        tile.AddComponent<MeshFilter>().mesh = mesh;
        tile.AddComponent<MeshRenderer>().material = material;

        int y = 0;

        Vector3[] vertices = new Vector3[14];
        vertices[0] = new Vector3(56.7f, y, 34.8f);
        vertices[1] = new Vector3(57.7f, y, 35.4f);
        vertices[2] = new Vector3(57.7f, y, 18.9f);
        vertices[3] = new Vector3(56.7f, y, 19.6f);
        vertices[4] = new Vector3(55.7f, y, 20.5f);
        vertices[5] = new Vector3(54.7f, y, 21f);
        vertices[6] = new Vector3(54.4f, y, 21f);
        vertices[7] = new Vector3(52f, y, 23.4f);
        vertices[8] = new Vector3(51.4f, y, 25.3f);
        vertices[9] = new Vector3(55.2f, y, 34.7f);
        vertices[10] = new Vector3(53.5f, y, 34.4f);
        vertices[11] = new Vector3(50.5f, y, 32.9f);
        vertices[12] = new Vector3(49.5f, y, 32.7f);
        vertices[13] = new Vector3(48f, y, 32f);

        int[] tris = new int[] { 0,1,2,  0,2,3,  0,3,4,  0,4,5,  0,5,6,  0,6,7,  0,7,8,  8,9,0,  8,10,9,  8,11,10,  8,12,11,  8,13,12 };

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "Mesopotamia";
    }

    private void GenerateSkifia()
    {
        GameObject tile = new GameObject();
        tile.transform.parent = transform;
        tile.transform.position = new Vector3(28.76f, -21.15f, 0.6f);
        tile.transform.eulerAngles = new Vector3(-90, 0, 180);
        Mesh mesh = new Mesh();
        tile.AddComponent<MeshFilter>().mesh = mesh;
        tile.AddComponent<MeshRenderer>().material = material;

        int y = 0;

        Vector3[] vertices = new Vector3[45];
        vertices[0] = new Vector3(53.4f, y, 34.5f);
        vertices[1] = new Vector3(57.5f, y, 42.5f);
        vertices[2] = new Vector3(57.5f, y, 35.5f);
        vertices[3] = new Vector3(56.8f, y, 35f);
        vertices[4] = new Vector3(55f, y, 35f);
        vertices[5] = new Vector3(51f, y, 33.2f);
        vertices[6] = new Vector3(49f, y, 32.6f); //
        vertices[7] = new Vector3(46.7f, y, 37.7f);//
        vertices[8] = new Vector3(46.7f, y, 42.5f);
        vertices[9] = new Vector3(46.2f, y, 38.7f);
        vertices[10] = new Vector3(45f, y, 39.3f);
        vertices[11] = new Vector3(44f, y, 39.3f);
        vertices[12] = new Vector3(43.6f, y, 39.7f);
        vertices[13] = new Vector3(42.8f, y, 39.7f);
        vertices[14] = new Vector3(42.6f, y, 39.9f);
        vertices[15] = new Vector3(42.6f, y, 42.5f);
        vertices[16] = new Vector3(42f, y, 39.7f);
        vertices[17] = new Vector3(41.5f, y, 40.2f);
        vertices[18] = new Vector3(40.8f, y, 40f);
        vertices[19] = new Vector3(40.6f, y, 40.3f);
        vertices[20] = new Vector3(40.6f, y, 42.5f);
        vertices[21] = new Vector3(39.8f, y, 39.9f);
        vertices[22] = new Vector3(39.5f, y, 40.1f);
        vertices[23] = new Vector3(39.1f, y, 40f);
        vertices[24] = new Vector3(39f, y, 40.7f);
        vertices[25] = new Vector3(38.6f, y, 40.7f);
        vertices[26] = new Vector3(38.6f, y, 41f);
        vertices[27] = new Vector3(39f, y, 41.3f);
        vertices[28] = new Vector3(38.9f, y, 41.6f);
        vertices[29] = new Vector3(39.2f, y, 41.8f);
        vertices[30] = new Vector3(39.2f, y, 42.5f);
        vertices[31] = new Vector3(46.4f, y, 37.2f);
        vertices[32] = new Vector3(46.4f, y, 36.6f);
        vertices[33] = new Vector3(45.8f, y, 36f);
        vertices[34] = new Vector3(44.7f, y, 35.5f);
        vertices[35] = new Vector3(43.7f, y, 34.5f);
        vertices[36] = new Vector3(48f, y, 32f);
        vertices[37] = new Vector3(46f, y, 31.1f);
        vertices[38] = new Vector3(44.5f, y, 30.7f);
        vertices[39] = new Vector3(43.1f, y, 34.4f);
        vertices[40] = new Vector3(42.7f, y, 34.4f);
        vertices[41] = new Vector3(42.3f, y, 34f);
        vertices[42] = new Vector3(42f, y, 34f);
        vertices[43] = new Vector3(41.7f, y, 32f);
        vertices[44] = new Vector3(42.2f, y, 29.5f);

        int[] tris = new int[] { 0,1,2, 2,3,0,  0,5,1, 5,6,1,  6,7,1,  7,8,1,  7,9,8,  9,10,8,  10,11,8,  11,12,8,  12,13,8,  13,14,8,  14,15,8,
                                 15,14,16,  15,16,17,  15,17,18,  15,18,19,  15,19,20,  20,19,21,  20,21,22,  20,22,23,  20,23,24,  20,24,25,  
                                 20,25,26,  20,26,27,  20,27,28,  20,28,29,  20,29,30,  7,6,31,  6,32,31,  6,33,32,  6,34,33,  6,35,34,  35,6,36,
                                 35,36,37,  35,37,38,  35,38,39,  38,40,39,  38,41,40,  38,42,41,  38,43,42,  38,44,43};

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("MapTile");
        tile.AddComponent<MeshCollider>();

        tile.name = "Skifia";
    }

    private void GenerateKilikia()
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
        vertices[0] = new Vector3(42.2f, y, 29.5f);
        vertices[1] = new Vector3(44.2f, y, 30.4f);
        vertices[2] = new Vector3(44f, y, 30f);
        vertices[3] = new Vector3(44f, y, 27f);
        vertices[4] = new Vector3(43.2f, y, 25.4f);
        vertices[5] = new Vector3(42.6f, y, 24.7f);
        vertices[6] = new Vector3(42.2f, y, 24.7f);
        vertices[7] = new Vector3(41.9f, y, 24.3f);
        vertices[8] = new Vector3(41.6f, y, 24.5f);
        vertices[9] = new Vector3(41f, y, 23.1f);
        vertices[10] = new Vector3(40.5f, y, 22.8f);
        vertices[11] = new Vector3(40.5f, y, 28.6f);
        vertices[12] = new Vector3(39.7f, y, 27.8f);
        vertices[13] = new Vector3(40.2f, y, 22.4f);
        vertices[14] = new Vector3(39.2f, y, 22.1f);
        vertices[15] = new Vector3(38.7f, y, 22.5f);
        vertices[16] = new Vector3(38.3f, y, 22.4f);
        vertices[17] = new Vector3(37.6f, y, 22.7f);
        vertices[18] = new Vector3(37.8f, y, 24.7f);
        vertices[19] = new Vector3(38f, y, 26.4f);
        vertices[20] = new Vector3(38.7f, y, 27.35f);

        int[] tris = new int[] { 0,1,2,  0,2,3,  0,3,4,  0,4,5,  0,5,6,  0,6,7,  0,7,8,  0,8,9,  0,9,10,  0,10,11,  10,12,11,  10,13,12,  12,13,14,
                                 12,14,15,  12,15,16,  12,16,17,  12,17,18,  12,18,19,  12,19,20};

        mesh.vertices = vertices;
        mesh.triangles = tris;

        tile.layer = LayerMask.NameToLayer("Hover");
        tile.AddComponent<MeshCollider>();

        tile.name = "Kilikia";
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
