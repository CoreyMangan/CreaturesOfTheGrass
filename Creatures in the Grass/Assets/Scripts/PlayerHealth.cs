using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
    public float playerHP = 100f;
    public Slider healthSlider;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        healthSlider.value = playerHP;

        if(playerHP <= 0)
        {
            Debug.Log("You Died");
        }
	
	}

    void onTiggerEnter(Collider col)
    {
        if(col.CompareTag("Enemy"))
        {
            playerHP -= 20f;
        }
    }
}
