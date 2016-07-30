using UnityEngine;
using System.Collections;

public class EntityHandler : MonoBehaviour {

    public int testGround;
    public Movement movement;
    public Water water;
    public Lava lava;
    private Ray ray;
    private RaycastHit hit;
    public string floor;
    

    void Start()
    {
        movement = GetComponent<Movement>();
        water = GetComponent<Water>();
        lava = GetComponent<Lava>();

    }

    void Update()
    {
        Physics.Raycast(transform.position, Vector3.down, out hit, 20.0f);

        floor = hit.collider.name;

        print(floor);

        if(floor == "Ground")
        {
            movement.gravity = 20;
            movement.jumpSpeed = 8;
            movement.speed = 6;

            movement.enabled = true;
            water.enabled = false;
            lava.enabled = false; 
        }
        else if(floor == "Water")
        {
            movement.enabled = true;
            water.enabled = true;
            lava.enabled = false;

        }
        else if (floor == "Lava")
        {
            movement.enabled = true;
            water.enabled = false;
            lava.enabled = true;
        }
    }

    
}
