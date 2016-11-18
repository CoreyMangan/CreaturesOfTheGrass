using UnityEngine;
using System.Collections;

public class RayCast : MonoBehaviour {
    public float range;

    private float dmg = 45f;
    private Camera fpsCam;
    private Vector3 rayOrigin;

    RaycastHit hit;

	// Use this for initialization
	void Start () {
        fpsCam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
        rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f ,0.5f, 0));

        if(Input.GetButtonDown("Fire1"))
        {
            //GetComponent<Animator>().Play(0);
            attack();
        }
        
	}

    void attack()
    {
        if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.collider.gameObject);

            hit.collider.GetComponent<EnemyHealth>().enemyHP -= dmg;
        }
    }
}
