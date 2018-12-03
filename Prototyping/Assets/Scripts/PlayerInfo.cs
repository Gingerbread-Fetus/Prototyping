using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour {
    public TextController textController;

    private void Awake() {
        this.gameObject.transform.position = DungeonManager.GetPlayerPosition();
        this.gameObject.transform.rotation = DungeonManager.GetPlayerRotation();
    }

    private void Start() {
        this.textController.SetText(0);
    }

}
