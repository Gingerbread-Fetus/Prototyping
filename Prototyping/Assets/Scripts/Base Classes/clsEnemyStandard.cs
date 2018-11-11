using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used as a basic inheritable class from which all other enemies can be derived. Functions as an 
/// interface and standard to interact with enemy units.
/// </summary>
public class clsEnemyStandard : MonoBehaviour {
    public int health;
    public int attack;
    public int defence;
    public int mana;

    public bool TakeDamage(int value) {
        health -= value;
        if (health <= 0) {
            return true;
        }
        return false;
    }
}
