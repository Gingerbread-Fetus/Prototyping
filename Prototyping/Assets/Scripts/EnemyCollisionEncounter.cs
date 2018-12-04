using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionEncounter : MonoBehaviour {
    [SerializeField] List<GameObject> enemies;
    public void MoveInDirection(Vector3 direction) {
        this.gameObject.transform.Translate(direction * DungeonManager.WORLD_SCALE, Space.World);
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            //TODO: Play scene header animation

            //Takes enemies set in the editor for the encounter and loads them for use from the Battle scene.
            DungeonManager.CurrentEncounterEnemies = enemies;
            Debug.Log("Enountering " + enemies[0]);
            //Load the battle scene
            DungeonManager.StartEngagement(1);
        }
    }
}
