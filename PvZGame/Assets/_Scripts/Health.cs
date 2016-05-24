using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public float health = 100f;
    private StarDisplay starDisplay;

    void Start()
    {
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();
    }

    public void DealDamage (float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            // Adds a small chance upon a dying gameObject to earn a few(5) stars.
            ChanceOfStars();

            // Can add animation for death.
            DestroyObject();
        }
    }

    private void ChanceOfStars()
    {
        var number = Random.Range(1, 10);
        if (number == 1)
        {
            starDisplay.AddStars(5);
        }
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
