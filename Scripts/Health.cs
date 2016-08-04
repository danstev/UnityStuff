using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public float health;

    void Update()
    {
        if(health <= 0)
        {
            print("You are dead.");
            Dead();
        }
    }

    void Dead()
    {
        Destroy(gameObject);
    }

    void ApplyDamage(int damage)
    {
        health -= damage;
    }
}
