using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour {

    public int health;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(health <= 1)
        {
            SceneManager.LoadScene(0);
        }
	}

    public void Damage()
    {
        health -= 1;
    }
}
