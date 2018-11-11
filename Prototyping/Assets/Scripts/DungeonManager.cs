using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonManager : MonoBehaviour {

    public static DungeonManager instance = null;

    public static Vector3 storedPos;
    public static Quaternion storedRot;
    

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }

        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    public static void LoadScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public static void SavePlayerPosition(Vector3 playerPos, Quaternion playerRot)
    {
        storedPos = playerPos;
        storedRot = playerRot;
        //Debug.Log("Rotation: " + storedRot);
        //Debug.Log("Position: " + storedPos);
    }
}
