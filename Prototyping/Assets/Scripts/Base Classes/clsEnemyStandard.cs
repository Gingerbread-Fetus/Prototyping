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

    public string enemyName;

    private ParticleSystem ps;

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

    public void CreateHighlight(Vector3 highlightAt) {
        if (!highlight.isPlaying) {
            ps = Instantiate(highlight);
            ps.transform.position = highlightAt;
            ps.transform.Translate(new Vector3(0, -0.7f, 0));
            ps.Play();

            //Debug.Log("highlight playing: " + ps);
            //Debug.Log("it is at: " + ps.gameObject.transform.position);
        }
    }

    public void DestroyHighlight() {
        GameObject.Destroy(ps);
    }

    /*
    public void OnMouseEnter() {
        Debug.Log("Mouse Entered");
    }

    public void OnMouseExit() {
        Debug.Log("Mouse Exited");
    }
    */
}
