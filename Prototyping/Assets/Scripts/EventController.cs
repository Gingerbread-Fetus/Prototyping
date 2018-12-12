using UnityEngine;

public class EventController : MonoBehaviour {
    public int EventIndex;

	public void CallEventByIndex(int index) {
        switch (index) {
            case 0:  Debug.Log("EVENT 0"); break; //StartCoroutine("FadeTextBoxIn"); break;
            case 1: Debug.Log("EVENT 1");
            if (GameObject.Find("Minotaur") != null)
                GameObject.Find("Minotaur").GetComponent<EnemyCollisionEncounter>().MoveInDirection(Vector3.forward * DungeonManager.WORLD_SCALE);
            GameObject.Find("Argbus").GetComponent<EnemyCollisionEncounter>().MoveInDirection(Vector3.left * DungeonManager.WORLD_SCALE);
            break;
        }
    }

    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player"))
            CallEventByIndex(EventIndex);
    }
}
