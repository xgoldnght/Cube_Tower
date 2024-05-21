using UnityEngine;

public class SoftCube : MonoBehaviour
{
    protected MeshFilter MeshFilter;
    protected Mesh Mesh;

    public float UpDownFactor = 0.1f;
    public float UpDownSpeed = 6f;

    public float LeftFactor = 0.3f;
    public float LeftSpeed = 3f;
    public float LeftOffset = 2.3f;

    public float StrectFactor = -0.1f;
    public float StrectSpeed = 6f;


    // Start is called before the first frame update
    void Start()
    {
        Mesh = new Mesh();
        Mesh.name = "NewMesh";

        Mesh.vertices = NewVertCube();
        Mesh.triangles = NewTrisCube();

        Mesh.RecalculateNormals();
        Mesh.RecalculateBounds();

        MeshFilter = gameObject.AddComponent<MeshFilter>();
        MeshFilter.mesh = Mesh;
    }

    private Vector3[] NewVertCube(float up = 0f, float left = 0f, float stretch = 0f)
    {
        return new Vector3[]
{
    //Bottom
            new Vector3(-1,0,1),
            new Vector3(1,0,1),
            new Vector3(1,0,-1),
            new Vector3(-1,0,-1),

            //Top
            new Vector3(-1 - stretch + left, 2 + up, 1 + stretch),
            new Vector3(1 + stretch + left, 2 + up, 1 + stretch),
            new Vector3(1 + stretch + left, 2 + up, -1 - stretch),
            new Vector3(-1 - stretch + left, 2 + up, -1 - stretch),
};
    }

    private int[] NewTrisCube()
    {
        return new int[]
{
            //Bottom
            2,1,0,
            2,0,3,

            //Top
            4,5,6,
            4,6,7,

            //front
            2,7,6,
            2,3,7,

            //back
            4,0,1,
            4,1,5,

            //left
            0,4,3,
            3,4,7,

            //right
            1,2,6,
            1,6,5,
};
    }
    // Update is called once per frame
    void Update()
    {
        Mesh.vertices = NewVertCube(Mathf.Sin(Time.realtimeSinceStartup * UpDownSpeed) * UpDownFactor,
            Mathf.Sin(Time.realtimeSinceStartup * LeftSpeed + LeftOffset) * LeftFactor,
            Mathf.Sin(Time.realtimeSinceStartup * StrectSpeed) * StrectFactor);
    }
}