using UnityEngine;

public class PlayerInfo : MonoBehaviour {
    public TextController textController;

    public void Start() {
        if (DungeonManager.intro) {
            DungeonManager.intro = false;
            textController.gameObject.SetActive(true);
            this.textController.GetComponent<TextController>().SetText(2);
        }
    }

    private void Awake() {
        this.gameObject.transform.position = DungeonManager.GetPlayerPosition();
        this.gameObject.transform.rotation = DungeonManager.GetPlayerRotation();
    }

    public void DestroyMinotaur() {
        Debug.Log("How to kill the Minotaur:");
        Destroy(GameObject.Find("Minotaur"));
        Debug.Log("Destroy: " + GameObject.Find("Minotaur").gameObject == null);
        GameObject.Find("Minotaur").SetActive(false);
    }
}
