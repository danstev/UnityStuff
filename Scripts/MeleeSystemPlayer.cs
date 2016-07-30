using UnityEngine;
using System.Collections;

public class MeleeSystemPlayer : MonoBehaviour {

	public int damage = 50;
	public float distance;
	public int reach;

	void Update() {

		if (Input.GetButtonDown ("Fire1"))
		{
			RaycastHit hit = new RaycastHit();

			if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
			{
				distance = hit.distance;
				print (hit.collider.gameObject.name);
				if (distance < reach)
				{
					hit.transform.SendMessage (("ApplyDamage"), damage, SendMessageOptions.DontRequireReceiver);
				}
			}
		}
	}
}
