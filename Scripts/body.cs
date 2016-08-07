using UnityEngine;
using System.Collections;

public class body : MonoBehaviour
{

    public GameObject mesh;

    public float headWidth;
    public float headHeight;
    public float headDepth;

    public float torsoWidth;
    public float torsoHeight;
    public float torsoDepth;

    void Start ()
    {
        CreateHead();

        CreateTorso();
    }
	
	void Update ()
    {
	    
	}

    void CreateHead()
    {
        for(float x = 0; x < headWidth; x+=0.1f)
        {
            for(float y = 0; y < headHeight; y+=0.1f)
            {
                for(float z = 0; z < headDepth; z+=0.1f)
                {
                    Vector3 vec = new Vector3(-12f, 2f, -3f);
                    GameObject cubes = (GameObject)Instantiate(mesh, vec + new Vector3(x, y, z), Quaternion.identity);
                    //cubes.transform.localScale += new Vector3(-0.9f, -0.9f, -0.9f);
                }
            }
        }
    }

    void CreateTorso()
    {
        for (float x = 0; x < torsoWidth; x += 0.1f)
        {
            for (float y = 0; y < torsoHeight; y += 0.1f)
            {
                for (float z = 0; z < torsoDepth; z += 0.1f)
                {
                    Vector3 vec = new Vector3(-11.9f, 0.5f, -2.9f);
                    GameObject cubes = (GameObject)Instantiate(mesh, vec + new Vector3(x, y, z), Quaternion.identity);
                }
            }
        } 
    }
}