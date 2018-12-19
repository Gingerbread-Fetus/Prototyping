using UnityEngine;

public class EventController : MonoBehaviour {
    public int EventIndex;

	public void CallEventByIndex(int index) {
        switch (index) {
            case 0:  Debug.Log("EVENT 0"); break; //StartCoroutine("FadeTextBoxIn"); break;
            case 1: Debug.Log("EVENT 1");
                GameObject.FindGameObjectWithTag("DungeonManager").GetComponent<DungeonManager>().MoveAllEncounters();
            break;
        }
    }

    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player"))
            CallEventByIndex(EventIndex);
    }
}
