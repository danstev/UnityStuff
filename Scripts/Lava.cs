using UnityEngine;
using System.Collections;

public class Lava : MonoBehaviour {

    //Lava specific
    public Health health;
    public Movement movement;
    public float Period;
    private float ActionTime;


    void Start()
    {
        health = GetComponent<Health>();
        movement = GetComponent<Movement>();
    }

    void OnEnable()
    {
        movement.gravity = 10f;
        movement.jumpSpeed = 15f;
        movement.speed = 2f;
    }

    void Update()
    {

        if(Time.time > ActionTime)
        {
            ActionTime += Period;
            health.health -= 10;
        }
        
    }
}
