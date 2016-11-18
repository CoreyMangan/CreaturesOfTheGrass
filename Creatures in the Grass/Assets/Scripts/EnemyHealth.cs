using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
    public float enemyHP = 100f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(enemyHP <= 0)
        {
            Destroy(gameObject);
        }
	}
}
