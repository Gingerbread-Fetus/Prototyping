using UnityEngine;

/// <summary>
/// Used to contain all of the Player character information.
/// </summary>
public class clsPlayerInfo : MonoBehaviour {
    public static int PI_attack, PI_defence, PI_health, PI_experience, PI_level;

    public void Awake() {
        //load some initial player values here
        //Debug.Log("Loading inital clsPlayerInfo stats.");
        clsPlayerInfo.PI_attack = 3;
        clsPlayerInfo.PI_defence = 1;
        clsPlayerInfo.PI_experience = 0;
        clsPlayerInfo.PI_health = 14;
        clsPlayerInfo.PI_level = 0;
        // ----------------------------
    }
}
