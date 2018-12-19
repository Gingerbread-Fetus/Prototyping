using UnityEngine;

/// <summary>
/// Used as a basic inheritable class from which all other enemies can be derived. Functions as an 
/// interface and standard to interact with enemy units.
/// </summary>
public class clsEnemyStandard : MonoBehaviour {
    public ParticleSystem highlight;
    public int health;
    public int attack;
    public int defence;
    public int mana;

    /// <summary>
    /// Deducts health by passed value. Returns true if health falls below 0.
    /// </summary>
    public bool TakeDamage(int value) {
        health -= value;
        if (health <= 0) {
            return true;
        }
        return false;
    }

    public void CreateHighlight() {
        /*
        if (!highlight.isPlaying) {
            ParticleSystem ps = Instantiate(highlight);
            ps.transform.parent = this.gameObject.transform;
            ps.Play();
            Debug.Log("highlight playing: " + ps);
            Debug.Log("it is at: " + ps.gameObject.transform.position);
        }
        */
    }

    public void OnMouseEnter() {
        Debug.Log("Mouse Entered");
        CreateHighlight();
    }

}
