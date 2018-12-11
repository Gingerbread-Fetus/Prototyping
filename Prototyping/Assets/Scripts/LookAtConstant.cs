using UnityEngine;

/// <summary>
/// Will attempt to face the target game object every frame.
/// </summary>
public class LookAtConstant : MonoBehaviour {
    public GameObject target;

    private bool debug = false;
    void Update() {
        if (this.target != null)
            this.transform.LookAt(target.gameObject.transform.position, Vector3.up);
        else {
            if (!debug) {
                Debug.Log("LookAtConstant target null. GameObject: " + this.gameObject);
                GameObject maincam = GameObject.FindGameObjectWithTag("MainCamera");
                Debug.Log("Setting to " + maincam);
                debug = true;
            }
        }
    }
}

