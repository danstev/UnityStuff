using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public int health;

    void Update()
    {
        if(health <= 0)
        {
            print("You are dead.");
        }
    }
}
