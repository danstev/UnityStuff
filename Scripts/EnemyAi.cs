using UnityEngine;
using System.Collections;

public class EnemyAi : MonoBehaviour {

    public float aggroDistance = 10;
    public float meleeDistance = 2;
    public float attackPower = 10;
    public float speed;
    private GameObject[] players = new GameObject[8];
    private GameObject target;
    private Health targetHealthScript;

	void Update () {
        players = GameObject.FindGameObjectsWithTag("Player");
        target = getTarget();
        if(Vector3.Distance(transform.position, target.transform.position) < aggroDistance && target != null)
        {
            transform.LookAt(target.transform);
            move();
        }

        if(Vector3.Distance(transform.position, target.transform.position) < meleeDistance && target != null)
        {
            transform.LookAt(target.transform);
            targetHealthScript = target.GetComponent<Health>();
            targetHealthScript.health -= attackPower * Time.deltaTime;
        }
	}

    GameObject getTarget()
    {
        float enemyDistance;
        float enemyDistanceLow = 0;
        GameObject current = GameObject.FindGameObjectWithTag("Player");

        foreach(GameObject Player in players)
        {
            enemyDistance = (Vector3.Distance(transform.position, Player.transform.position));
            print(enemyDistance);
            if(enemyDistance < enemyDistanceLow && enemyDistanceLow != 0)
            {
                enemyDistanceLow = enemyDistance;
                current = Player;
            }
        }
        return current;
    }

    void move()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
    }

}
