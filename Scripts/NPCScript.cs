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
    private Health Enemy;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (target == null)
        {
            print("1");
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
            print(detectColliders[i].name);
            if (detectColliders[i].tag == "Player" || detectColliders[i].tag == "Enemy")
            {
                target = detectColliders[i].gameObject;
                Enemy = target.GetComponent<Health>();
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
            Enemy.health -= attackDamage;
            //Set timer to attackspeed
            attackTimer = attackSpeed;
        }
        else if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
            float step = speed * Time.deltaTime;
            transform.position = movementCalc();
        }
        else
        {

            transform.position = movementCalc();
        }

        //If target moves away
        if (target != null && radius * 10 > Vector3.Distance(transform.position, target.transform.position))
        {
            target = null;
        }

    }

    Vector3 movementCalc()
    {
        Vector3 Movement;
        float dist = Vector3.Distance(transform.position, target.transform.position);
        float step = speed * Time.deltaTime;
        if ( dist > radius )
        {
            Movement = Vector3.MoveTowards(transform.position, target.transform.position, step);
        }
        else if(dist < radius * 0.8)
        {
            Movement = Vector3.MoveTowards(transform.position, target.transform.position, step);
        }
        else
        {
            Movement = transform.position;
        }

        return Movement;
    }
}
