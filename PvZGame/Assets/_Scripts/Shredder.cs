using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {

    // Because our sprite is on the projectiles bodies, we use shredder to remove it.
	void OnTriggerEnter2D (Collider2D collider)
    {
        Destroy(collider.gameObject);
    }
}
