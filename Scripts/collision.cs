using UnityEngine;
using System.Collections;

public class collision : MonoBehaviour
{
    private Collider[] hitColliders;

    public float blastRadius;
    public float explosionPower;
    public LayerMask explosionLayers;

    private bool used;

    public GameObject bloodEffect;

    void OnCollisionEnter(Collision col)
    {
        if(used == false)
        {
            if (col.gameObject.transform.root.CompareTag("box"))
            {
                gore(col.contacts[0].point);
                Instantiate(bloodEffect, col.transform.position, Quaternion.identity);
                Destroy(gameObject, 4f);
                used = true;
            }
        }
    }

    void gore(Vector3 explosionPoint)
    {
        hitColliders = Physics.OverlapSphere(explosionPoint, blastRadius, explosionLayers);

        foreach (Collider hitCol in hitColliders)
        {
            if (hitCol.GetComponent<Rigidbody>() != null)
            {
                //hitCol.gameObject.SetActive(false);
                hitCol.GetComponent<Rigidbody>().isKinematic = false;
                hitCol.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * 5;
                hitCol.GetComponent<Rigidbody>().AddExplosionForce(explosionPower, explosionPoint, blastRadius, 1, ForceMode.Impulse);
                hitCol.gameObject.GetComponent<Renderer>().material.color = new Color(0.541f, 0.027f, 0.027f);
            }
        }
    }
}