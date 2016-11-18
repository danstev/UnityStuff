using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public float health;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (health <= 0)
        {
            print("You are dead.");
            Dead();
        }

    }

    void ApplyDamage(int damage)
    {
        health -= damage;
    }

    void Dead()
    {
        Destroy(gameObject);
    }

}
