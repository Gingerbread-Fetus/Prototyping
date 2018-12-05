﻿using UnityEngine;

/// <summary>
/// Handles combat scene interactions.
/// </summary>
public class CombatController : MonoBehaviour {

    public GameObject Pos1, Pos2, Pos3, Pos4, Pos5;

    private bool isSelectingTarget;

    void Start() {
        Pos1 = DungeonManager.CurrentEncounterEnemies[0];
        Pos2 = DungeonManager.CurrentEncounterEnemies[1];
        Pos3 = DungeonManager.CurrentEncounterEnemies[2];
        Pos4 = DungeonManager.CurrentEncounterEnemies[3];
        Pos5 = DungeonManager.CurrentEncounterEnemies[4];
    }

    public void Attack() {
        Debug.Log(DungeonManager.CurrentEncounterEnemies[0].GetComponent<clsEnemyStandard>().health);
        DungeonManager.CurrentEncounterEnemies[0].GetComponent<clsEnemyStandard>().TakeDamage(1);
        isSelectingTarget = true;
        CheckRemainingEnemies();
    }

    public void CheckRemainingEnemies() {
        if (DungeonManager.CurrentEncounterEnemies.Count == 0) {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
}
