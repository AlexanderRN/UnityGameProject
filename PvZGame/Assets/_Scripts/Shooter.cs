using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

    public GameObject projectile, weapon;

    private Animator anim;
    private GameObject projectileParent;
    private Spawner thisLaneSpawner;

    void Start()
    {
        anim = GameObject.FindObjectOfType<Animator>();
        projectileParent = GameObject.Find("Projectiles");

        if(!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
        }

        SetThisLaneSpawner();
    }

    void Update()
    {
        if (IsAttackerInLane())
        {
            anim.SetBool("IsAttacking", true);
        } else
        {
            anim.SetBool("IsAttacking", false);
        }
    }

    bool IsAttackerInLane()
    {
        //Exit if no attackers in this lane.
        if (thisLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }

        //If attackers, are they in front of the defender?
        foreach (Transform attacker in thisLaneSpawner.transform)
        {
            if (attacker.transform.position.x > transform.position.x)
            {
                return true;
            }
        }

        // If the attackers are not in front.
        return false;
    }

    // Look through spawners and find the one in THIS LANE.
    void SetThisLaneSpawner()
    {
        Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner>();
        foreach(Spawner spawner in spawnerArray)
        {
            if (spawner.transform.position.y == transform.position.y)
            {
                thisLaneSpawner = spawner;
                return;
            } else
            {
                Debug.Log("Error");
            }
        }
    }

    private void Shoot()
    {
        GameObject newProjectile = Instantiate(projectile) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = weapon.transform.position;
    }
}
