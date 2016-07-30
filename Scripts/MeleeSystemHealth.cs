using UnityEngine;
using System.Collections;

public class MeleeSystemHealth : MonoBehaviour {

	public int Health = 100;

	void Update() {
		if (Health <= 0) {
			Dead ();
		}
	}

	void Dead() {
		Destroy(gameObject);
	}

	void ApplyDamage (int damage) {
		Health -= damage;
	}
}
