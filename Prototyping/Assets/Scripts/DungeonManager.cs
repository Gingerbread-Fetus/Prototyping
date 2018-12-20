using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonManager : MonoBehaviour {

    public static DungeonManager instance = null;
    public static bool intro = true;

    //Position of where the player is located
    public static Vector3 storedPos = new Vector3(0, 0.5f, -3.66f);
    public static Vector3 storedRot = new Vector3(0, 180, 0);

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
        enemyEncounters = new List<GameObject>();
        GameObject[] arrEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < arrEnemies.Length; ++i) {
            enemyEncounters.Add(arrEnemies[i]);
        }
        Debug.Log("DM START:" + enemyEncounters[0]);
    }

    //Clear Encounters to load in next set
    public static void ClearEncounters() {
        enemyEncounters = null;
    }

    //Clear passed in encounter from the list of enemyEncounters
    public static void ClearEncounterByIndex(int index) {
        Destroy(enemyEncounters[index].gameObject);
        enemyEncounters.RemoveAt(index);
    }

    public static void ClearEncounterByCurrent() {
        for (int i = 0; i < enemyEncounters.Count; ++i) {
            if (enemyEncounters[i].GetComponent<EnemyCollisionEncounter>().Equals(CurrentEnemyCollisionEncounter)) {
                enemyEncounters[i].gameObject.SetActive(false);
                enemyEncounters.Remove(CurrentEnemyCollisionEncounter.gameObject);
                CurrentEnemyCollisionEncounter.DestroyThisEncounter();
                CurrentEnemyCollisionEncounter = null;

                //set player in position
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                player.GetComponent<GridMove>().isMoving = false;
                player.gameObject.transform.position = GetPlayerPosition();
                player.gameObject.transform.rotation = Quaternion.Euler(GetPlayerRotation());
                Debug.Log("ClearEncounterByCurrent Success.");
                return;
            }
        }
    }

    public static void SetEncounters(List<GameObject> encounters) {
        enemyEncounters = encounters;
    }

    public static void StartEngagement(int battleSceneNumber) {
        GameObject.FindGameObjectWithTag("Player").GetComponent<GridMove>().StopAllCoroutines();
        GameObject.FindGameObjectWithTag("Player").GetComponent<GridMove>().isMoving = true;
        SceneManager.LoadScene(battleSceneNumber, LoadSceneMode.Additive);
        Debug.Log("Started engagement with enemy: " + CurrentEncounterEnemies[0]);
    }

    public static void SavePlayerPosition(Vector3 playerPos, Vector3 playerRot) {
        storedPos = playerPos;
        storedRot = playerRot;
    }

    public static Vector3 GetPlayerPosition() {
        return storedPos;
    }

    public static Vector3 GetPlayerRotation() {
        return storedRot;
    }

    public static List<GameObject> GetEncounterEnemies (){
        return CurrentEncounterEnemies;
    }
}
