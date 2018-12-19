using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEditor;

/// <summary>
/// Handles combat scene interactions.
/// </summary>
public class CombatController : MonoBehaviour {

    public GameObject Pos1, Pos2, Pos3, Pos4, Pos5;
    public List<GameObject> enemies;
    public List<GameObject> DEBUG_ENEMIES;

    public Text CombatLog;
    public GameObject Camera;
    public Vector3 cameraOffsetPos = new Vector3(0, 1, -1);
    public Vector3 cameraOffsetRot = new Vector3(11, 0, 0);

    private bool isSelectingTarget = false;
    private List<GameObject> listPositions;
    private int attackType;
    private int targetPosition;

    void Start() {
        Debug.Log("Setting Combat Camera");
        Camera.transform.SetPositionAndRotation(DungeonManager.storedPos + cameraOffsetPos, Quaternion.Euler(DungeonManager.storedRot * cameraOffsetRot));
        Camera.GetComponent<Camera>().cullingMask ^= 1 << 9;
        Debug.Log("To Position: " + DungeonManager.storedPos);
        //all positions loaded, even if not used could be used to add more enemies mid-encounter
        listPositions = new List<GameObject>();
        listPositions.Add(Pos1);
        listPositions.Add(Pos2);
        listPositions.Add(Pos3);
        listPositions.Add(Pos4);
        listPositions.Add(Pos5);

        SetEnemies(DungeonManager.CurrentEncounterEnemies);
    }

    /// <summary>
    /// Attack controller. AttackType is set before calling this function.
    /// </summary>
    public void Attack() {
        switch (attackType) {
            case 0: Debug.Log("Bork Attack Type. NO Attack taken."); break;
            case 1:
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
                    //enemies.RemoveAt(targetPosition);
                    enemies[targetPosition].SetActive(false);
                    listPositions[targetPosition].SetActive(false);
                } break;
            case 2:
                if (!enemies[targetPosition].GetComponent<clsEnemyStandard>().TakeDamage(2)) {
                    CombatLog.text += "\n";
                    CombatLog.text += enemies[targetPosition].name +
                        " took 1 damage. " +
                        enemies[targetPosition].GetComponent<clsEnemyStandard>().health +
                        " remains."
                        ;
                } else {
                    CombatLog.text += "\n";
                    CombatLog.text += enemies[targetPosition].name + " has been destroyed.";
                    //enemies.RemoveAt(targetPosition);
                    enemies[targetPosition].SetActive(false);
                    listPositions[targetPosition].SetActive(false);
                } break;
        }
        
        CheckRemainingEnemies();
    }

    //May be used for transformation of the combat log. Trimming excess text, scrolling.
    public void AddTextToCombatLog(string textToAdd) {
        return;
    }

    public void SetEnemies(List<GameObject> listEnemies) {
        Debug.Log("Setting enemies: " + listEnemies);
        for (int i = 0; i < listEnemies.Count; ++i) {
            Debug.Log("Enemies[" + i + "] == " + listEnemies[i]);
        }
        enemies = new List<GameObject>();

        for (int i = 0; i < listEnemies.Count; ++i) {
            //assign gameobject positioning initials
            GameObject o = (GameObject)Object.Instantiate(listEnemies[i]);
            o.transform.parent = listPositions[i].transform;
            o.transform.position = listPositions[i].transform.position;
            //o.gameObject.transform.GetChild(0).Rotate(Vector3.up * 180, Space.World);
            o.transform.rotation = Quaternion.Euler(0, 0, 0);
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
        int rem = 0;
        for(int i = 0; i < enemies.Count; ++i) {
            if (enemies[i].activeSelf)
                rem += 1;
        }
        if (rem == 0) { //all enemies inactive, could be set flag
            Debug.Log(rem + " enemies remain.");
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().cullingMask = -1;
            DungeonManager.ClearEncounterByCurrent();
            //DungeonManager.ClearEncounterByIndex(0);
            UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(UnityEngine.SceneManagement.SceneManager.GetSceneAt(1));
            //UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }

    public void LoadDebugBattle() {
        DungeonManager.CurrentEncounterEnemies = DEBUG_ENEMIES;
        SetEnemies(DEBUG_ENEMIES);
        Object.Instantiate(AssetDatabase.LoadAssetAtPath("Assets/Prefabs/BattleSceneBGs/EnvArea1.prefab", typeof(GameObject)));
    }
}
 