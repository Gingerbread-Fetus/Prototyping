using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour {
    private void Awake() {
        this.gameObject.transform.position = DungeonManager.GetPlayerPosition();
        this.gameObject.transform.rotation = DungeonManager.GetPlayerRotation();
    }
}
