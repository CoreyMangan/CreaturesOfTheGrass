using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
    public float speed;
    public float rotSpeed;

    private float lookDistance = 20f;
    private float chaseDistance = 15f;
    private float attackDistance = 5f;
    private float dmg = 20f;
    private float distanceToTarget;

    private Quaternion targetRotation;
    private Transform target;

	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        distanceToTarget = Vector3.Distance(transform.position, target.position);
        moveAI();
	}

    void moveAI()
    {
        if(distanceToTarget <= lookDistance)
        {
            Debug.Log("Enemy Looking At Player");
            targetRotation = Quaternion.LookRotation(target.position - transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotSpeed * Time.deltaTime);
        }

        if(distanceToTarget <= chaseDistance)
        {
            Debug.Log("Enemy Chasing PLayer");
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        if(distanceToTarget <= attackDistance)
        {
            Debug.Log("Enemy Attacking Player");
            transform.Translate(Vector3.forward * 0);
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().playerHP -= dmg;
        }
    }
}
