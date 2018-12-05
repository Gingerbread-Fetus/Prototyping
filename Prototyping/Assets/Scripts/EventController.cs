using UnityEngine;

public class EventController : MonoBehaviour {
    public int EventIndex;

	public void CallEventByIndex(int index) {
        switch (index) {
            case 0:  Debug.Log("EVENT 0"); break; //StartCoroutine("FadeTextBoxIn"); break;
        }
    }

    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player"))
            CallEventByIndex(EventIndex);
    }
}
