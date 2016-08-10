using UnityEngine;
using System.Collections;

public class ZombieScript : MonoBehaviour {

    public float radius;
    public float speed;
    public float attackSpeed;
    public float attackDamage;
    public float attackRadius;
    private float attackTimer;
    public float randomMoveTimer;
    private float randomMoveTimerSet;
    private float normalise;
    private Vector3 randomMove;
    public float mod;
    private GameObject target;
    private PlayerControl targetHealth;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        if (target == null)
        {
            Collider[] detectColliders = Physics.OverlapSphere(transform.position, radius);
            for(int i = 0; i < detectColliders.Length; i++)
            {
                if(detectColliders[i].tag == "Player")
                {
                    target = detectColliders[i].gameObject;
                    targetHealth = target.GetComponent<PlayerControl>();
                }
            }

            if(target == null)
            {
                if (randomMoveTimerSet <= 0)
                {
                    randomMoveTimerSet = randomMoveTimer * Random.Range(1, 2);
                    randomMove = new Vector3(Random.Range(-1 * mod,1 * mod), 0, Random.Range(-1 * mod, 1 * mod));
                    transform.position += randomMove;
                }

                if(randomMoveTimerSet > 0)
                {
                    transform.position += randomMove;
                    randomMoveTimerSet -= Time.deltaTime;
                }
            }
        }

        if (target != null)
        {
            if (attackTimer <= 0 && attackRadius > Vector3.Distance(transform.position, target.transform.position))
            {
                //Do attack
                targetHealth.health -= attackDamage;
                //Set timer to attackspeed
                attackTimer = attackSpeed;
            }
            else if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;

            }
            else
            {
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
            }
        }

	
	}

}
