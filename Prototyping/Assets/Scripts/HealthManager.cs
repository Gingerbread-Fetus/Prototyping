using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//TODO: Health manager should manage all enemies.
public class HealthManager : MonoBehaviour {
    public GameObject[] enemies;

    private int health;
	// Use this for initialization
	void Start () {
		health = enemies[0].GetComponent<Enemy>().health;
	}
	
	// Update is called once per frame
	void Update () {
        Text m_TextComponent = GetComponent<Text>();
        health = enemies[0].GetComponent<Enemy>().health;
        m_TextComponent.text = health.ToString();

        if (health <= 0)
        {
            //TODO: Play a transfer animation.
            
        }
    }
}
