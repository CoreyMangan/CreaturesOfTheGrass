using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
    public float playerHP;
    public Slider healthSlider;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        playerHP = healthSlider.value;

        if(playerHP <= 0)
        {
            Debug.Log("You Died");
        }
	
	}
}
