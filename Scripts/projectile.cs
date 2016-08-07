using UnityEngine;
using System.Collections;

public class shoot : MonoBehaviour
{

    public GameObject projectile;

    public GameObject bulletExit;

	void Start()
    {
	
	}
	
	void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            GameObject bul = (GameObject) Instantiate(projectile, bulletExit.transform.position, Quaternion.identity);
            bul.gameObject.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * 35;
        }
	}
}