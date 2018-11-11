using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonManager : MonoBehaviour {

    public static DungeonManager instance = null;

    public static Vector3 storedPos = new Vector3(0, 0.5f, 0);
    public static Quaternion storedRot;

    public static List<GameObject> CurrentEncounterEnemies;

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
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
