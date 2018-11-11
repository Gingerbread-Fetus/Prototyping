using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EnemyCollisionEncounter : MonoBehaviour {
    [SerializeField] List<GameObject> enemies;
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            //TODO: Play scene header animation
            DungeonManager.CurrentEncounterEnemies = enemies;
            //Load the battle scene
            DungeonManager.StartEngagement(1);
        }
    }
}
