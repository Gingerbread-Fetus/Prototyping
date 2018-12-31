using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionEncounter : MonoBehaviour {
    [SerializeField] List<GameObject> enemies;
    public void MoveInDirection(Vector3 direction) {
        //Debug.Log("Gameobject: " + this.gameObject + " is moving: " + direction);
        this.gameObject.transform.Translate(direction, Space.World);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            //TODO: Play scene header animation
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().cullingMask ^= 1 << 9;

            //Takes enemies set in the editor for the encounter and loads them for use from the Battle scene.
            DungeonManager.CurrentEncounterEnemies = enemies;
            //Load the battle scene
            DungeonManager.CurrentEnemyCollisionEncounter = this;
            this.gameObject.SetActive(false);
            DungeonManager.StartEngagement(0);
        }
    }

    public void DestroyThisEncounter() {
        this.gameObject.SetActive(false);
        Destroy(this.gameObject);
    }
}
