using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonManager : MonoBehaviour {

    public static DungeonManager instance = null;

    //Position of where the player is located
    public static Vector3 storedPos = new Vector3(0, 0.5f, -3.66f);
    public static Quaternion storedRot = Quaternion.Euler(0, 180, 0);

    //Size of the tile distance in this dungeon
    public static float WORLD_SCALE = 1.33f;

    //Enemies to be loaded in the Encounter Battle Scene
    public static List<GameObject> CurrentEncounterEnemies;

    public static bool isPlayerTurn;

    //Tracks position of all active encounters in the dungeon
    public static GameObject[] enemyEncounters;

    public void MoveAllEncounters() {
        for (int i = 0; i < enemyEncounters.Length; ++i) {
            enemyEncounters[i].GetComponent<EnemyCollisionEncounter>().MoveInDirection(Vector3.forward);
        }
    }

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void Start() {
        //Load current enemies for demo
        enemyEncounters = GameObject.FindGameObjectsWithTag("Enemy");
    }

    //Clear Encounters to load in next set
    public static void ClearEncounters() {
        enemyEncounters = new GameObject[0];
    }

    public static void SetEncounters(GameObject[] encounters) {
        enemyEncounters = encounters;
    }

    public static void StartEngagement(int battleSceneNumber) {
        SceneManager.LoadScene(battleSceneNumber);
    }

    public static void SavePlayerPosition(Vector3 playerPos, Quaternion playerRot) {
        storedPos = playerPos;
        storedRot = playerRot;
    }

    public static Vector3 GetPlayerPosition() {
        return storedPos;
    }

    public static Quaternion GetPlayerRotation() {
        return storedRot;
    }
}
