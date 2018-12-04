using UnityEngine;

public class PlayerInfo : MonoBehaviour {
    public GameObject textController;

    private void Awake() {
        this.gameObject.transform.position = DungeonManager.GetPlayerPosition();
        this.gameObject.transform.rotation = DungeonManager.GetPlayerRotation();
    }

    private void Start() {
        textController.SetActive(true);
        this.textController.GetComponent<TextController>().SetText(2);
    }

}
