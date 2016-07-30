using UnityEngine;
using System.Collections;

public class Water : MonoBehaviour {



    //Water specific
    public Health health;
    public Movement movement;

    void Start()
    {
        health = GetComponent<Health>();
        movement = GetComponent<Movement>();
    }

    void OnEnable()
    {
        movement.gravity = 5f;
        movement.jumpSpeed = 15f;
        movement.speed = 1.5f;
    }
}
