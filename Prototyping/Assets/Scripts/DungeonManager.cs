using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonManager : MonoBehaviour {

    public static DungeonManager instance = null;
    public static bool intro = true;

    //Position of where the player is located
    public static Vector3 storedPos = new Vector3(0, 0.5f, -3.66f);
    public static Quaternion storedRot = Quaternion.Euler(0, 180, 0);

    //Size of the tile distance in this dungeon
    public static float WORLD_SCALE = 1.33f;

    //Enemies to be loaded in the Encounter Battle Scene
    public static List<GameObject> CurrentEncounterEnemies;
    public static EnemyCollisionEncounter CurrentEnemyCollisionEncounter;

    public static bool isPlayerTurn;

    //Tracks position of all active encounters in the dungeon
    public static List<GameObject> enemyEncounters;

    public void MoveAllEncounters() {
        for (int i = 0; i < enemyEncounters.Count; ++i) {
            enemyEncounters[i].GetComponent<EnemyCollisionEncounter>().MoveInDirection(Vector3.forward * DungeonManager.WORLD_SCALE);
        }
    }

    public void Start() {
        //Load current enemies for demo
        GameObject[] arrEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        Debug.Log(arrEnemies);
        enemyEncounters = new List<GameObject>(arrEnemies);
        Debug.Log(enemyEncounters);

    }

    //Clear Encounters to load in next set
    public static void ClearEncounters() {
        enemyEncounters = null;
    }

    //Clear passed in encounter from the list of enemyEncounters
    public static void ClearEncounterByIndex(int index) {
        enemyEncounters[index] = null;
    }

    public static void ClearEncounterByCurrent() {
        for (int i = 0; i < enemyEncounters.Count; ++i) {
            if (enemyEncounters[i].GetComponent<EnemyCollisionEncounter>().Equals(CurrentEnemyCollisionEncounter)) {
                CurrentEnemyCollisionEncounter.DestroyThisEncounter();
                Debug.Log("ClearEncounterByCurrent Success.");
                return;
            }
        }
    }

    public static void SetEncounters(List<GameObject> encounters) {
        enemyEncounters = encounters;
    }

    public static void StartEngagement(int battleSceneNumber) {
        SceneManager.LoadScene(battleSceneNumber, LoadSceneMode.Additive);
        Debug.Log("Started engagement with enemies: " + CurrentEncounterEnemies);
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

    public static List<GameObject> GetEnemies (){
        return CurrentEncounterEnemies;
    }
}
