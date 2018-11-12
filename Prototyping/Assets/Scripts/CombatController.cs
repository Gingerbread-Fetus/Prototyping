using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles combat scene interactions.
/// </summary>
public class CombatController : MonoBehaviour {
    public void Attack() {
        Debug.Log(DungeonManager.CurrentEncounterEnemies[0]);
        if (DungeonManager.CurrentEncounterEnemies[0].GetComponent<clsEnemyStandard>().TakeDamage(1))
            DungeonManager.CurrentEncounterEnemies.Remove(DungeonManager.CurrentEncounterEnemies[0]);
        CheckRemainingEnemies();
    }

    public void CheckRemainingEnemies() {
        if (DungeonManager.CurrentEncounterEnemies.Count == 0) {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
}
