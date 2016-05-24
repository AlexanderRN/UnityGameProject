using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour {

    // Set attackers walking speed
    [Range(-1f, 1.5f)]
    public float currentSpeed;
    [Tooltip ("How often the attacker is spawned.")]
    public float timeInterval;
    private GameObject currentTarget;
    private Animator animator;

    void Start ()
    {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        // Make the attacker move to the left of the board.
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
        if (!currentTarget)
        {
            animator.SetBool("IsAttacking", false);
        }
	} 

    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }

    // Used by animator at the time of the attack begins
    public void StrikeCurrentTarget(float damage)
    {
        if (currentTarget) {
            Health health = currentTarget.GetComponent<Health>();
            if (health)
            {
                health.DealDamage(damage);
            }
        }
    }
    
    // When the attacker needs to attack
    public void Attack (GameObject obj)
    {
        currentTarget = obj;

    }

}
