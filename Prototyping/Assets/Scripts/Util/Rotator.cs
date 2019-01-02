using UnityEngine;

public class Rotator : MonoBehaviour {
    public float speed;
	void Update () {
        this.gameObject.transform.Rotate(new Vector3(0, 1 * speed, 0), Space.World);
	}
}
