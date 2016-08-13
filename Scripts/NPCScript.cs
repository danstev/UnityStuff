using UnityEngine;
using System.Collections;

public class NPCScript : MonoBehaviour {

    public float speed;
    public float radius;
    public float attackSpeed;
    public float attackRadius;
    public float attackDamage;
    private float attackTimer;
    public float randomMoveTimer;
    private float randomMoveTimerSet;
    private Vector3 randomMove;
    public float mod;
    public GameObject target;
    private ZombieScript zombie;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (target == null)
        {
            findTarget(); 
        }

        if(target != null)
        {
            moveAttackTarget();
        }
    }

    void findTarget()
    {
        Collider[] detectColliders = Physics.OverlapSphere(transform.position, radius);
        for (int i = 0; i < detectColliders.Length; i++)
        {
            if (detectColliders[i].tag == "Player")
            {
                target = detectColliders[i].gameObject;
                zombie = target.GetComponent<ZombieScript>();
            }

        }

        if (target == null)
        {
            if (randomMoveTimerSet <= 0)
            {
                randomMoveTimerSet = randomMoveTimer * Random.Range(1, 2);
                randomMove = new Vector3(Random.Range(-1 * mod, 1 * mod), 0, Random.Range(-1 * mod, 1 * mod));
                transform.position += randomMove;
            }

            if (randomMoveTimerSet > 0)
            {
                transform.position += randomMove;
                randomMoveTimerSet -= Time.deltaTime;
            }
        }
    }

    void moveAttackTarget()
    {
        //if target, move to target, try and attack
        if (attackTimer <= 0 && attackRadius > Vector3.Distance(transform.position, target.transform.position))
        {
            //Do attack
            //targetHealth.health -= attackDamage;
            //Set timer to attackspeed
            attackTimer = attackSpeed;
        }
        else if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step / 2);

        }
        else
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
        }

        //If target moves away
        if (target != null && radius * 10 > Vector3.Distance(transform.position, target.transform.position))
        {
            target = null;
        }

    }
}
