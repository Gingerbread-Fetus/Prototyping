using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Handles the updating of the basic persistent UI elements
/// </summary>
public class UIBasicUpdater : MonoBehaviour {
    public clsPlayerInfo pi;
    public Text health;
    public Text level;
    public Text exp;

    public void Update() {
        health.text = "Health: " + clsPlayerInfo.PI_health.ToString();
        level.text = "Level: " + clsPlayerInfo.PI_level.ToString();
        exp.text = "Exp: " + clsPlayerInfo.PI_experience.ToString();
    }

}
