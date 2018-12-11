using UnityEngine;

public class EnemyPositionClickTrigger : MonoBehaviour {
    public CombatController cc;
    public int Position;

    public void OnMouseDown() {
        SetCombatControllerPosition();
    }

    public void SetCombatControllerPosition() {
        cc.SetTarget(Position);
        Debug.Log("SCCP: " + Position);
    }
}
