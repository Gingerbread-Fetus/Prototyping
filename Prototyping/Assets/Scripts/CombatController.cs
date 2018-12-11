using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

/// <summary>
/// Handles combat scene interactions.
/// </summary>
public class CombatController : MonoBehaviour {

    public GameObject Pos1, Pos2, Pos3, Pos4, Pos5;
    public List<GameObject> enemies;

    public Text CombatLog;

    private bool isSelectingTarget = false;
    private List<GameObject> listPositions;
    private int attackType;
    private int targetPosition;

    void Start() {
        listPositions = new List<GameObject>();
        listPositions.Add(Pos1);
        listPositions.Add(Pos2);
        listPositions.Add(Pos3);
        listPositions.Add(Pos4);
        listPositions.Add(Pos5);

        SetEnemies(DungeonManager.CurrentEncounterEnemies);
    }

    public void Attack() {
        if (!enemies[targetPosition].GetComponent<clsEnemyStandard>().TakeDamage(1)) {
            CombatLog.text += "\n";
            CombatLog.text += enemies[targetPosition].name +
                " took 1 damage. " +
                enemies[targetPosition].GetComponent<clsEnemyStandard>().health +
                " remains."
                ;
        } else {
            CombatLog.text += "\n";
            CombatLog.text += enemies[targetPosition].name + " has been destroyed.";
            enemies.RemoveAt(targetPosition);
            listPositions[targetPosition].SetActive(false);
        }
        CheckRemainingEnemies();
    }

    public void SetEnemies(List<GameObject> listEnemies) {
        Debug.Log("Setting enemies: " + listEnemies);
        enemies = new List<GameObject>();

        //enemies = listEnemies;

        for (int i = 0; i < listEnemies.Count; ++i) {
            GameObject o = (GameObject)Object.Instantiate(listEnemies[i]);
            o.transform.parent = listPositions[i].transform;
            o.transform.position = listPositions[i].transform.position;
            o.transform.rotation = Quaternion.Euler(0, 180, 0);
            enemies.Add(o);
        }
    }

    public void SetAttack1() {
        attackType = 1;
        StartTargetting();
    }

    public void SetAttack2() {
        attackType = 2;
        StartTargetting();
    }

    public void StartTargetting() {
        isSelectingTarget = true;
        //enable highlight on enemy position --------------------------------------
    }

    public void SetTarget(int position) {
        if (isSelectingTarget) {
            isSelectingTarget = false;
            targetPosition = position;
            Attack();
        }
    }

    public void CheckRemainingEnemies() {
        if (enemies.Count == 0) {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            DungeonManager.ClearEncounterByCurrent();
        }
    }

    public void LoadDebugBattle() {
        List<GameObject> minPrefabs = new List<GameObject>();
        for (int i = 0; i < 5; ++i) {
            minPrefabs.Add((GameObject)Resources.Load("Assets/Prefabs/Enemies/Minotaur.prefab"));
        }
        DungeonManager.CurrentEncounterEnemies = minPrefabs;
    }
}
 