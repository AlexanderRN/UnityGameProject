using UnityEngine;
using System.Collections;

// Requires attacker, if not Fox does not work. Unity can therefor add it for us.
[RequireComponent (typeof (Attacker))]
public class Fox : MonoBehaviour {

    private Animator anim;
    private Attacker attacker;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject obj = collider.gameObject;

        // Leaves method if it DOES NOT collides with defender.
        if (!obj.GetComponent<Defender>())
        {
            return;
        }

        if (obj.GetComponent<Stone>())
        {
            anim.SetTrigger("Jump Trigger");
        } else
        {
            anim.SetBool("IsAttacking", true);
            attacker.Attack(obj);
        }

    }
}
