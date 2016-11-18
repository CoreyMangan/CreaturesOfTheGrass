using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {
    public GameObject PausePanel;
    public bool isPaused;

	// Use this for initialization
	void Start () {
        isPaused = false;
    }
	
	// Update is called once per frame
	void Update () {
        if(isPaused)
        {
            PauseGame(true);
        }
        else
        {
            PauseGame(false);
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            switchpause();
        }
	}

    void PauseGame(bool state)
    {
        if(state)
        {
            PausePanel.SetActive(true);
            Time.timeScale = 0.0f;
        }
        else
        {
            PausePanel.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }

    void switchpause()
    {
        isPaused = !isPaused;
    }
}
